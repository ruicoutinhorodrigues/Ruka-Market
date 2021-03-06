﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ruka_Market.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ruka_Market.Helpers
{
    public class CombosHelper : IDisposable
    {
        private static Ruka_MarketContext db = new Ruka_MarketContext();

        private static ApplicationDbContext da = new ApplicationDbContext();

        public static List<DocumentType> GetDocumentTypes()
        {
            var DocumentTypes = db.DocumentTypes.ToList();

            DocumentTypes.Add(new DocumentType
            {
                DocumentTypeID = 0,
                Description = "[Selecione um tipo de documento]"
            });

            DocumentTypes = DocumentTypes.OrderBy(c => c.Description).ToList();

            return DocumentTypes;

        }

        public static List<Customer> GetCustomersNames()
        {
            var Customers = db.Customers.ToList();
            Customers.Add(new Customer
            {
                CustomerID = 0,
                FirstName = "[Selecione um cliente]"
            });

            return Customers.OrderBy(c => c.Name).ToList();
        }

        public static List<Product> GetProducts()
        {
            var Products = db.Products.ToList();
            Products.Add(new Product
            {
                ProductID = 0,
                Description = "[Selecione um produto...]"
            });

            return Products.OrderBy(p => p.Description).ToList();
        }

        public static List<IdentityRole> GetRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(da));

            var list = roleManager.Roles.ToList();

            list.Add(new IdentityRole { Id = "", Name = "[Selecione uma permissão...]" });

            return list.OrderBy(r => r.Name).ToList();         
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}