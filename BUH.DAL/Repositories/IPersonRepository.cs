using System;
using System.Collections.Generic;
using AutoMapper;
using BUH.DAL.Models;
using BUH.Domain.Repositories;

namespace BUH.DAL.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly BUHContext context;
        private readonly IMapper mapper;
        private bool disposed = false;

        public PersonRepository(IMapper mapper)
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

        public Domain.Models.Person GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Person> GetCollection()
        {
            return this.mapper.Map<IEnumerable<Person>, IEnumerable<Domain.Models.Person>>(this.context.People);
        }

        public int Insert(Domain.Models.Person entity)
        {
            Person entityToInsert = this.context.People.Create();
            this.mapper.Map(entity, entityToInsert);
            this.context.People.Add(entityToInsert);
            this.context.SaveChanges();
            return entityToInsert.Id;
        }

        public void Update(Domain.Models.Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
