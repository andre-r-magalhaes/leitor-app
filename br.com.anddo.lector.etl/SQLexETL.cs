using br.com.anddo.lector.domain;
using System;
using System.Linq;


namespace br.com.anddo.lector.etl
{
    public class SQLexETL :IETL
    {
        //public SQLexETL()
        //{
        //    var p = new SAPETL().GetProduct("");

        //    using (var context = new Model())
        //    {
        //        context.Products.Add(p);
        //        context.SaveChanges();
        //    }
        //}

        public domain.Product GetProduct(string code)
        {
            using (var context = new Model())
            {
                // Query for all blogs with names starting with B 
                //var p = from b in context.Blogs
                            //where b.Name.StartsWith("B")
                            //select b;

                var product = context.Products.ToList();
                                //.Where(p => p.Code == code)
                                //.FirstOrDefault();

                Random r = new Random(DateTime.Now.Millisecond);
                Product p = null;
                try
                {
                    p = product.ElementAt(r.Next(212));
                }
                catch { }

                return p;
            }
        }
    }
}