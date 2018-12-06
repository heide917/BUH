using System;
using System.Collections.Generic;
using AutoMapper;
using BUH.DAL.Models;
using BUH.Domain.Repositories;

namespace BUH.DAL.Repositories
{
    public class JournalRepository : IJournalRepository
    {
        private readonly BUHContext context;
        private readonly IMapper mapper;
        private bool disposed = false;

        public JournalRepository(IMapper mapper)
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

        public Domain.Models.Journal GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Journal> GetCollection()
        {
            return this.mapper.Map<IEnumerable<Journal>, IEnumerable<Domain.Models.Journal>>(this.context.Journals);
        }

        public int Insert(Domain.Models.Journal entity)
        {
            Journal entityToInsert = this.context.Journals.Create();
            this.mapper.Map(entity, entityToInsert);
            this.context.Journals.Add(entityToInsert);
            this.context.SaveChanges();
            return entityToInsert.Id;
        }

        public void Update(Domain.Models.Journal entity)
        {
            throw new NotImplementedException();
        }
    }
}
