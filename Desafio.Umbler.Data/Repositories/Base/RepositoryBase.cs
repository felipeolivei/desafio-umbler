using Desafio.Umbler.Data.Context;
using Desafio.Umbler.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Desafio.Umbler.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        private readonly DatabaseContext context;
        private DbSet<TEntity> DbSet;

        public RepositoryBase(DatabaseContext dbContext)
        {
            this.context = dbContext;
            DbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
            SaveChanges();
        }

        public void AddRange(List<TEntity> entity)
        {
            DbSet.AddRange(entity);
            SaveChanges();
        }

        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public TEntity GetWhere(Func<TEntity, bool> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public IEnumerable<TEntity> GetAllWhere(Func<TEntity, bool> predicate)
        {
            return DbSet.ToList().Where(predicate);
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            SaveChanges();
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}
