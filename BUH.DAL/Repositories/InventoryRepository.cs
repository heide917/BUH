using System;
using System.Collections.Generic;
using AutoMapper;
using BUH.DAL.Models;
using BUH.Domain.Repositories;

namespace BUH.DAL.Repositories
{
    public class InentoryRepository : IInventoryRepository
    {
        private readonly BUHContext context;
        private readonly IMapper mapper;
        private bool disposed = false;

        public InentoryRepository(IMapper mapper)
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

        public Domain.Models.Inventory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Inventory> GetCollection()
        {
            return this.mapper.Map<IEnumerable<Inventory>, IEnumerable<Domain.Models.Inventory>>(this.context.Inventories);
        }

        public int Insert(Domain.Models.Inventory entity)
        {
            Inventory entityToInsert = this.context.Inventories.Create();
            this.mapper.Map(entity, entityToInsert);
            this.context.Inventories.Add(entityToInsert);
            this.context.SaveChanges();
            return entityToInsert.Id;
        }

        public void Update(Domain.Models.Inventory entity)
        {
            throw new NotImplementedException();
        }
    }
}
