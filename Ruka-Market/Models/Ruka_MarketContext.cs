using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Ruka_Market.Models
{
    public class Ruka_MarketContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Ruka_MarketContext() : base("name=Ruka_MarketContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
       
        public System.Data.Entity.DbSet<Ruka_Market.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Ruka_Market.Models.DocumentType> DocumentTypes { get; set; }

        public System.Data.Entity.DbSet<Ruka_Market.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<Ruka_Market.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<Ruka_Market.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Ruka_Market.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<Ruka_Market.Models.OrderDetail> OrderDetails { get; set; }


    }
}
