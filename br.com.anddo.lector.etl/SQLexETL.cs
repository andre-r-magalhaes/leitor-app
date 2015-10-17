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

                var product = context.Products
                                .Where(p => p.Code == code)
                                .FirstOrDefault();

                return product;
            }
        }
    }
}