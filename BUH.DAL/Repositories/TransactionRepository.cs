using System;
using System.Collections.Generic;
using AutoMapper;
using BUH.DAL.Models;
using BUH.Domain.Repositories;

namespace BUH.DAL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BUHContext context;
        private readonly IMapper mapper;
        private bool disposed = false;

        public TransactionRepository(IMapper mapper)
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

        public Domain.Models.Transaction GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Transaction> GetCollection()
        {
            return this.mapper.Map<IEnumerable<Transaction>, IEnumerable<Domain.Models.Transaction>>(this.context.Transactions);
        }

        public int Insert(Domain.Models.Transaction entity)
        {
            Transaction entityToInsert = this.context.Transactions.Create();
            this.mapper.Map(entity, entityToInsert);
            this.context.Transactions.Add(entityToInsert);
            this.context.SaveChanges();
            return entityToInsert.Id;
        }

        public void Update(Domain.Models.Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
