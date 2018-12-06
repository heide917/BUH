using System;
using System.Collections.Generic;
using AutoMapper;
using BUH.DAL.Models;
using BUH.Domain.Repositories;

namespace BUH.DAL.Repositories
{
    public class SourceRepository : ISourceRepository
    {
        private readonly BUHContext context;
        private readonly IMapper mapper;
        private bool disposed = false;

        public SourceRepository(IMapper mapper)
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

        public Domain.Models.Source GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Source> GetCollection()
        {
            return this.mapper.Map<IEnumerable<Source>, IEnumerable<Domain.Models.Source>>(this.context.Sources);
        }

        public int Insert(Domain.Models.Source entity)
        {
            Source entityToInsert = this.context.Sources.Create();
            this.mapper.Map(entity, entityToInsert);
            this.context.Sources.Add(entityToInsert);
            this.context.SaveChanges();
            return entityToInsert.Id;
        }

        public void Update(Domain.Models.Source entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
