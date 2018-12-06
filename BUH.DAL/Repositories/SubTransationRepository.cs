using System;
using System.Collections.Generic;
using AutoMapper;
using BUH.DAL.Models;
using BUH.Domain.Repositories;

namespace BUH.DAL.Repositories
{
    public class SubTransactionRepository : ISubTransactionRepository
    {
        private readonly BUHContext context;
        private readonly IMapper mapper;
        private bool disposed = false;

        public SubTransactionRepository(IMapper mapper)
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

        public Domain.Models.SubTransaction GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.SubTransaction> GetCollection()
        {
            return this.mapper.Map<IEnumerable<SubTransaction>, IEnumerable<Domain.Models.SubTransaction>>(this.context.SubTransactions);
        }

        public int Insert(Domain.Models.SubTransaction entity)
        {
            SubTransaction entityToInsert = this.context.SubTransactions.Create();
            this.mapper.Map(entity, entityToInsert);
            this.context.SubTransactions.Add(entityToInsert);
            this.context.SaveChanges();
            return entityToInsert.Id;
        }

        public void Update(Domain.Models.SubTransaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
