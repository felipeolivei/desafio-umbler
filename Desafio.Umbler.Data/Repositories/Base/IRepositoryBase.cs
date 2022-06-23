using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Umbler.Data.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(List<TEntity> entity);
        TEntity Get(int id);
        TEntity GetWhere(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllWhere(Func<TEntity, bool> predicate);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        void SaveChanges();
    }
}
