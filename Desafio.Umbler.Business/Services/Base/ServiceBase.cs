using Desafio.Umbler.Data.Models;
using Desafio.Umbler.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Umbler.Business.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : BaseEntity
    {
        protected readonly IRepositoryBase<TEntity> _repository;

        protected ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public virtual void AddRange(List<TEntity> entity)
        {
            _repository.AddRange(entity);
        }

        public virtual TEntity Get(int id)
        {
            return _repository.Get(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IEnumerable<TEntity> GetAllWhere(Func<TEntity, bool> predicate)
        {
            return _repository.GetAllWhere(predicate);
        }

        public virtual void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
