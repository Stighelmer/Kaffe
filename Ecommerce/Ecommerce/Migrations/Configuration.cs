using Ecommerce.Models;

namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ecommerce.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ecommerce.Models.ApplicationDbContext context)
        {
            // Registrerade konton
            // admin@kaffe.se - Admin@12
            // manager@kaffe.se - Manager@12

            context.Categories.AddOrUpdate(c => c.Id,
                new Category() { Id = 1, Name = "Kaffeb�nor" },
                new Category() { Id = 2, Name = "Bryggmalet" },
                new Category() { Id = 3, Name = "Snabbkaffe" }
                );

            context.Products.AddOrUpdate(p => p.Id,
                new Product()
                {
                    Id = 1,
                    Name = "Johan & Nystr�m - Sumatra Gayo",
                    CategoryId = 1,
                    Details = "Nobelkaffet 2018 - Mellanrostade kaffeb�nor - 250g",
                    Price = 75,
                    DateAdded = DateTime.Today
                },
                new Product()
                {
                    Id = 2,
                    Name = "Johan & Nystr�m - Bourbon Jungle",
                    CategoryId = 1,
                    Details = "Kraftfulla m�rkrostade kaffeb�nor - 500g",
                    Price = 109,
                    DateAdded = DateTime.Today
                },
                new Product()
                {
                    Id = 3,
                    Name = "Liding� Rosteri - Peru Peringos",
                    CategoryId = 1,
                    Details = "Mellanrostade kaffeb�nor - 250g",
                    Price = 99,
                    DateAdded = DateTime.Today
                },
                new Product()
                {
                    Id = 4,
                    Name = "Sk�ne Roast - BRYGGMALET",
                    CategoryId = 2,
                    Details = "Kraftfullt och m�rkrostat - 500g",
                    Price = 124,
                    DateAdded = DateTime.Today
                },
                new Product()
                {
                    Id = 5,
                    Name = "Arvid Nordquist - Classic",
                    CategoryId = 2,
                    Details = "Mellanrost frisk & fruktig - 500g",
                    Price = 39.90m,
                    DateAdded = DateTime.Today
                },
                new Product()
                {
                    Id = 6,
                    Name = "Nescaf� - Lyx",
                    CategoryId = 3,
                    Details = "Snabbkaffe Lyx Mellanrost - 200g",
                    Price = 59.90m,
                    DateAdded = DateTime.Today
                }
                );
        }
    }
}
