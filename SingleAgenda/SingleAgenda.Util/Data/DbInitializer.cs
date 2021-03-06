using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SingleAgenda.Entities.UsersAndRoles;
using SingleAgenda.Infra.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingleAgenda.Util.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<SingleAgendaDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<SingleAgendaDbContext>())
                {

                    if (!context.Users.Any())
                    {
                        var adminUser = new User
                        {
                            Name = "Admin",
                            Password = "123456", 
                            Email = "admin@admin"
                        };
                        context.Users.Add(adminUser);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
