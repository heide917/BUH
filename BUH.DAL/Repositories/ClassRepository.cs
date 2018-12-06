using System;
using System.Collections.Generic;
using AutoMapper;
using BUH.DAL.Models;
using BUH.Domain.Repositories;

namespace BUH.DAL.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly BUHContext context;
        private readonly IMapper mapper;
        private bool disposed = false;

        public ClassRepository(IMapper mapper)
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

        public Domain.Models.Class GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Class> GetCollection()
        {
            return this.mapper.Map<IEnumerable<Class>, IEnumerable<Domain.Models.Class>>(this.context.Classes);
        }

        public int Insert(Domain.Models.Class entity)
        {
            Class entityToInsert = this.context.Classes.Create();
            this.mapper.Map(entity, entityToInsert);
            this.context.Classes.Add(entityToInsert);
            this.context.SaveChanges();
            return entityToInsert.Id;
        }

        public void Update(Domain.Models.Class entity)
        {
            throw new NotImplementedException();
        }
    }
}
