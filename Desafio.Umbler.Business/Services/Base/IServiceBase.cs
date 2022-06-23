using Desafio.Umbler.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Umbler.Business.Services
{
    public interface IServiceBase<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void AddRange(List<TEntity> entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllWhere(Func<TEntity, bool> predicate);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
