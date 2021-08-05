using CleanCodeDapper.ApplicationCore.Models;
using System;
using System.Collections.Generic;

namespace CleanCodeDapper.ApplicationCore.Intefaces.Repository.RepositoryDapper
{
    public interface IDapperRepository<T> : IDisposable where T : Entity
    {
        T Add(T obj);
        int AddRange(IEnumerable<T> entities);
        IEnumerable<T> GetAll();
        T GetById(object id);
        bool Remove(object id);
        int Remove(T obj);
        int RemoveRange(IEnumerable<T> entities);
        int Update(T obj);
        int UpdateRange(IEnumerable<T> entities);
        
        //queries by sql
        T GetFirstByStringSql(string sql);
        IEnumerable<T> GetListBytStringSql(string sql);
    }
}