using System;
using System.Collections.Generic;
using AutoMapper;
using BUH.DAL.Models;
using BUH.Domain.Repositories;

namespace BUH.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BUHContext context;
        private readonly IMapper mapper;
        private bool disposed = false;

        public UserRepository(IMapper mapper)
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

        public Domain.Models.User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.User> GetCollection()
        {
            return this.mapper.Map<IEnumerable<User>, IEnumerable<Domain.Models.User>>(this.context.Users);
        }

        public int Insert(Domain.Models.User entity)
        {
            User entityToInsert = this.context.Users.Create();
            this.mapper.Map(entity, entityToInsert);
            this.context.Users.Add(entityToInsert);
            this.context.SaveChanges();
            return entityToInsert.Id;
        }

        public void Update(Domain.Models.User entity)
        {
            throw new NotImplementedException();
        }
    }
}
