using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SingleAgenda.Entities.Contact;
using SingleAgenda.Entities.Location;
using SingleAgenda.Infra.Base;
using SingleAgenda.Infra.Configuration;
using SingleAgenda.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Xunit;

namespace SingleAgenda.DataAccess.Tests.Repositories
{
    [TestFixture]
    public class PersonRepositoryUnitTest
    {
        [Test]
        public void IncludeANaturalPerson()
        {
            var options = new DbContextOptionsBuilder<SingleAgendaDbContext>()
                .UseInMemoryDatabase(databaseName: "SingleAgendaTests")
                .Options;

            using (var context = new SingleAgendaDbContext(options))
            {
                var naturalPerson = new Person()
                {
                    PersonType = PersonType.Natural,
                    Gender = Gender.Male,
                    Birthday = new DateTime(1983, 06, 12),
                    Document = "14950349090",
                    Name = "Fernando",
                };
                context.Persons.Add(naturalPerson);
                var inserted = context.SaveChanges();

                Assert.IsTrue(inserted > 0, "It was not possible to insert the natural person.");

                var address = new Address()
                {
                    ZipCode = "01310200",
                    Country = "BRA",
                    State = "São Paulo (SP)",
                    City = "São Paulo",
                    Description = "Av. Paulista, 890 - 1º Andar - Bela Vista",
                    PersonId = inserted
                };

                context.Addresses.Add(address);
                Assert.IsTrue(context.SaveChanges() > 0, "It was not possible to insert the address for the person.");
            }

        }
    }
}
