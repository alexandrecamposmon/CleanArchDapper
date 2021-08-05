using CleanCodeDapper.ApplicationCore.Intefaces.Repository.RepositoryDapper;
using CleanCodeDapper.ApplicationCore.Intefaces.Services;
using CleanCodeDapper.ApplicationCore.Models;
using System.Collections.Generic;

namespace CleanCodeDapper.ApplicationCore.Services
{
    public abstract class Service<T> : IService<T> where T : Entity
    {
        private readonly IDapperRepository<T> repository;

        protected Service(IDapperRepository<T> repository)
        {
            this.repository = repository;
        }

        public T Add(T obj)
        {
            return repository.Add(obj);
        }

        public int AddRange(IEnumerable<T> entities)
        {
            return repository.AddRange(entities);
        }
        public IEnumerable<T> GetAll()
        {
            return repository.GetAll();
        }

        public T GetById(object id)
        {
            return repository.GetById(id);
        }

        public bool Remove(object id)
        {
            return repository.Remove(id);
        }

        public int Remove(T obj)
        {
            return repository.Remove(obj);
        }

        public int RemoveRange(IEnumerable<T> entities)
        {
            return repository.RemoveRange(entities);
        }

        public int Update(T obj)
        {
            return repository.Update(obj);
        }

        public int UpdateRange(IEnumerable<T> entities)
        {
            return repository.UpdateRange(entities);
        }
    }
}