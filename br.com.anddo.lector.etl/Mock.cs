using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using br.com.anddo.lector.domain;

namespace br.com.anddo.lector.etl
{
    public class Mock
    {

        public void execute()
        {
            using (var context = new Model())
            {
                
                context.Database.ExecuteSqlCommand("DELETE FROM ProductCategories");
                context.Database.ExecuteSqlCommand("DELETE FROM NutritionFacts");
                context.Database.ExecuteSqlCommand("DELETE FROM SpecialOffers");
                context.Database.ExecuteSqlCommand("DELETE FROM Products");
            }

            var reader = new StreamReader(File.OpenRead(@"C:\Users\anddo_000\Desktop\produtos\produtos.tsv"));
            
            List<Product> prods = new List<Product>();
            Product p;

            double v = 0d;
            double pe = 0d;
            double t = 0d;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                p = new Product();

                p.Code = values[0];
                p.FullName = values[1];
                p.Weight = values[2];
                
                switch (values[3])
                {
                    case "u": p.Type = WeightType.u; break;
                    case "kg": p.Type = WeightType.kg; break;
                    case "L": p.Type = WeightType.L; break;
                    case "ml": p.Type = WeightType.ml; break;
                    case "g": p.Type = WeightType.g; break;

                }

                p.Value = values[4];
                p.Imagepath = String.Format("http://lectorapi.azurewebsites.net/content/images/{0}.jpg", p.Code);


                p.Name = p.FullName.Substring(0,5);
                //p.Offer = new SpecialOffer();
                p.Category = new ProductCategory();
                p.Category.Name = RandomCategory();
                //p.Facts = new NutritionFacts();


                try{
                    if (p.Type == WeightType.L || p.Type == WeightType.kg)
                    {
                        v = double.Parse(p.Value);
                        pe = double.Parse(p.Weight);

                        t = pe > 10.0 ? v / pe * 1000 : v / pe;
                    }
                    else if (p.Type == WeightType.u)
                    {
                        t = double.Parse(p.Value);
                    }
                    else
                    {
                        v = double.Parse(p.Value);
                        pe = double.Parse(p.Weight);
                        t = v / pe * 1000;
                    }

                    p.FullWeightValue = String.Format("{0:0.00}", t);
                    
                } catch {}

                if (p.FullWeightValue != null)                
                    prods.Add(p);
            }


            using (var context = new Model())
            {
                foreach (Product pr in prods)
                {

                    try
                    {
                        context.Products.Add(pr);
                        context.SaveChanges();
                    }
                    catch (Exception ex) { }

                }
                try
                {
                    context.Products.Add(new SAPETL().GetProduct(""));
                    context.SaveChanges();
                }
                catch (Exception ex) { }
            }
        }

        public string RandomCategory()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            switch (r.Next(5))
            {
                case 0: return "Mercearia";
                case 1: return "Padaria";
                case 2: return "Limpeza";
                case 3: return "Feira";
                case 4: return "Utensílios";
                default: return "Adega";
            }
        }
    }
}