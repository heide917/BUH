using System;
using System.Collections.Generic;
using AutoMapper;
using BUH.DAL.Models;
using BUH.Domain.Repositories;

namespace BUH.DAL.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly BUHContext context;
        private readonly IMapper mapper;
        private bool disposed = false;

        public ContractRepository(IMapper mapper)
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

        public Domain.Models.Contract GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Contract> GetCollection()
        {
            return this.mapper.Map<IEnumerable<Contract>, IEnumerable<Domain.Models.Contract>>(this.context.Contracts);
        }

        public int Insert(Domain.Models.Contract entity)
        {
            Contract entityToInsert = this.context.Contracts.Create();
            this.mapper.Map(entity, entityToInsert);
            this.context.Contracts.Add(entityToInsert);
            this.context.SaveChanges();
            return entityToInsert.Id;
        }

        public void Update(Domain.Models.Contract entity)
        {
            throw new NotImplementedException();
        }
    }
}
