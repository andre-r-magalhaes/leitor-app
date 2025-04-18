namespace br.com.anddo.lector.etl
{
    using br.com.anddo.lector.domain;
    using br.com.anddo.lector.etl.Context;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model : DbContext
    {
        // Your context has been configured to use a 'Model' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'br.com.anddo.lector.etl.Model' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model' 
        // connection string in the application configuration file.
        public Model()
            : base("name=MYSQL")
        {
            Database.SetInitializer(new MySqlInitializer());
        }

        //public Model()
        //    : base("name=SQLEXPRESS")
        //{
        //}

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Product> Products { get; set; }
    }
}