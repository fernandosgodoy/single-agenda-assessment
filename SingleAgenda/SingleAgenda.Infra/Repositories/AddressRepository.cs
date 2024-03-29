﻿using SingleAgenda.EFPersistence.Base;
using SingleAgenda.EFPersistence.Configuration;
using SingleAgenda.Entities.Location;

namespace SingleAgenda.EFPersistence.Repositories
{
    public class AddressRepository
        : RepositoryBase<Address>
    {

        public AddressRepository(SingleAgendaDbContext context)
            : base(context)
        {
        }
    }
}
