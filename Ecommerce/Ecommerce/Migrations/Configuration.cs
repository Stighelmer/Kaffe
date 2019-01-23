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
                new Category() { Id = 1, Name = "Kaffebönor" },
                new Category() { Id = 2, Name = "Bryggmalet" },
                new Category() { Id = 3, Name = "Snabbkaffe" }
                );

            context.Products.AddOrUpdate(p => p.Id,
                new Product()
                {
                    Id = 1,
                    Name = "Johan & Nyström - Sumatra Gayo",
                    CategoryId = 1,
                    Details = "Nobelkaffet 2018 - Mellanrostade kaffebönor - 250g",
                    Price = 75,
                    DateAdded = DateTime.Today
                },
                new Product()
                {
                    Id = 2,
                    Name = "Johan & Nyström - Bourbon Jungle",
                    CategoryId = 1,
                    Details = "Kraftfulla mörkrostade kaffebönor - 500g",
                    Price = 109,
                    DateAdded = DateTime.Today
                },
                new Product()
                {
                    Id = 3,
                    Name = "Lidingö Rosteri - Peru Peringos",
                    CategoryId = 1,
                    Details = "Mellanrostade kaffebönor - 250g",
                    Price = 99,
                    DateAdded = DateTime.Today
                },
                new Product()
                {
                    Id = 4,
                    Name = "Skåne Roast - BRYGGMALET",
                    CategoryId = 2,
                    Details = "Kraftfullt och mörkrostat - 500g",
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
                    Name = "Nescafé - Lyx",
                    CategoryId = 3,
                    Details = "Snabbkaffe Lyx Mellanrost - 200g",
                    Price = 59.90m,
                    DateAdded = DateTime.Today
                }
                );
        }
    }
}
