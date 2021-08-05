using Dapper;
using CleanCodeDapper.ApplicationCore.Intefaces.Repository.RepositoryDapper;
using CleanCodeDapper.ApplicationCore.Models;
using CleanCodeDAPPER.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CleanCodeDAPPER.Infrastructure.Repository.RepositoryDapper
{
    public abstract class DapperRepository<T> : IDapperRepository<T> where T : Entity
    {
        protected readonly IDbConnection dbConn;
        protected readonly IDbTransaction dbTransaction;
        protected abstract string InsertQuery { get; }
        protected abstract string InsertQueryReturnInserted { get; }
        protected abstract string UpdateByIdQuery { get; }
        protected abstract string DeleteByIdQuery { get; }
        protected abstract string SelectByIdQuery { get; }
        protected abstract string SelectAllQuery { get; }

        protected DapperRepository(BDContext db)
        {
            dbConn = db.Database.GetDbConnection();
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
        }
        public void Dispose()
        {
            dbConn.Close();
            dbConn.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual T Add(T obj)
        {
            T entity = dbConn.QuerySingle<T>(InsertQueryReturnInserted, obj, transaction: dbTransaction);
            
            return entity;
        }
        public virtual int AddRange(IEnumerable<T> entities)
        {
            var result = dbConn.Execute(InsertQuery, entities, transaction: dbTransaction);
            
            return result;
        }

        public virtual IEnumerable<T> GetAll()
        {
            var result = dbConn.Query<T>(SelectAllQuery, transaction: dbTransaction);
            
            return result;
        }

        public virtual  T GetById(object id)
        {
            var entity =  dbConn.Query<T>(SelectByIdQuery, new { Id = id }, transaction: dbTransaction);
            
            return entity.FirstOrDefault();
        }
        public virtual T GetFirstByStringSql(string sql)
        {
            var entity = dbConn.Query<T>(sql, transaction: dbTransaction);

            return entity.FirstOrDefault();
        }
        public virtual IEnumerable<T> GetListBytStringSql(string sql)
        {
            var result = dbConn.Query<T>(sql, transaction: dbTransaction);

            return result;
        }

        public virtual bool Remove(object id)
        {
            var entity = GetById(id);

            if (entity == null)
                return false;

            
            return Remove(entity) > 0 ? true : false;
        }

        public virtual int Remove(T obj)
        {
            var result = dbConn.Execute(DeleteByIdQuery, new { obj.id }, transaction: dbTransaction);
            
            return result;
        }

        public virtual int RemoveRange(IEnumerable<T> entities)
        {
            var result = dbConn.Execute(DeleteByIdQuery, entities.Select(obj => new { obj.id }), transaction: dbTransaction);
            
            return result;
        }

        public virtual int Update(T obj)
        {
            var result = dbConn.Execute(UpdateByIdQuery, obj, transaction: dbTransaction);
            
            return result;
        }

        public virtual int UpdateRange(IEnumerable<T> entities)
        {
            var result = dbConn.Execute(UpdateByIdQuery, entities.Select(obj => obj), transaction: dbTransaction);
            
            return result;
        }
    }
}