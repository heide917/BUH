using System;
using System.Collections.Generic;
using AutoMapper;
using BUH.DAL.Models;
using BUH.Domain.Repositories;

namespace BUH.DAL.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly BUHContext context;
        private readonly IMapper mapper;
        private bool disposed = false;

        public CategorieRepository(IMapper mapper)
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

        public Domain.Models.Categorie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Categorie> GetCollection()
        {
            return this.mapper.Map<IEnumerable<Categorie>, IEnumerable<Domain.Models.Categorie>>(this.context.Categories);
        }

        public int Insert(Domain.Models.Categorie entity)
        {
            Categorie entityToInsert = this.context.Categories.Create();
            this.mapper.Map(entity, entityToInsert);
            this.context.Categories.Add(entityToInsert);
            this.context.SaveChanges();
            return entityToInsert.Id;
        }

        public void Update(Domain.Models.Categorie entity)
        {
            throw new NotImplementedException();
        }
    }
}
