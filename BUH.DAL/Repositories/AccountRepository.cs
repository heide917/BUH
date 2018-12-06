using System;
using System.Collections.Generic;
using AutoMapper;
using BUH.DAL.Models;
using BUH.Domain.Repositories;

namespace BUH.DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BUHContext context;
        private readonly IMapper mapper;
        private bool disposed = false;

        public AccountRepository(IMapper mapper)
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

        public Domain.Models.Account GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Account> GetCollection()
        {
            return this.mapper.Map<IEnumerable<Account>, IEnumerable<Domain.Models.Account>>(this.context.Accounts);
        }

        public int Insert(Domain.Models.Account entity)
        {
            Account entityToInsert = this.context.Accounts.Create();
            this.mapper.Map(entity, entityToInsert);
            this.context.Accounts.Add(entityToInsert);
            this.context.SaveChanges();
            return entityToInsert.Id;
        }

        public void Update(Domain.Models.Account entity)
        {
            throw new NotImplementedException();
        }
    }
}
