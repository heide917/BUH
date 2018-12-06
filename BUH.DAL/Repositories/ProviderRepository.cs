using System;
using System.Collections.Generic;
using AutoMapper;
using BUH.DAL.Models;
using BUH.Domain.Repositories;

namespace BUH.DAL.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly BUHContext context;
        private readonly IMapper mapper;
        private bool disposed = false;

        public ProviderRepository(IMapper mapper)
        {
            this.context = new BUHContext();
            this.mapper = mapper;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }

        public Domain.Models.Provider GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Provider> GetCollection()
        {
            return this.mapper.Map<IEnumerable<Provider>, IEnumerable<Domain.Models.Provider>>(this.context.Providers);
        }

        public int Insert(Domain.Models.Provider entity)
        {
            Provider entityToInsert = this.context.Providers.Create();
            this.mapper.Map(entity, entityToInsert);
            this.context.Providers.Add(entityToInsert);
            this.context.SaveChanges();
            return entityToInsert.Id;
        }

        public void Update(Domain.Models.Provider entity)
        {
            throw new NotImplementedException();
        }
    }
}
