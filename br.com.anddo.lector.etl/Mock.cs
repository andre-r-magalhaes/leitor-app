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
            var reader = new StreamReader(File.OpenRead(@"C:\Users\anddo_000\Desktop\produtos\produtos.tsv"));
            
            List<Product> prods = new List<Product>();
            Product p;

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
            }
        }
    }
}