//using Strings.Application;
//using Strings.Application.Interfaces;
//using Strings.Data.Context;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Storage;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.SqlClient;

//namespace Strings.Data.Repository
//{
//    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
//    {
//        private readonly ApplicationDbContext _dbContext;
//        private IDbContextTransaction _transaction;
//        protected DbSet<T> Data { get; private set; }
//        public GenericRepositoryAsync(ApplicationDbContext dbContext)
//        {
//            _dbContext = dbContext;
//            Data = dbContext.Set<T>() ?? throw new InvalidOperationException("DbContext has no entity");
//        }
//        public void BeginTrasaction()
//        {
//            _transaction = _dbContext.Database.BeginTransaction();
//        }
//        public void Commit()
//        {
//            _transaction.Commit();
//        }
//        public void Rollback()
//        {
//            _transaction.Rollback();
//        }
//        public async Task<T> AddAsync(T entity)
//        {
//            await _dbContext.Set<T>().AddAsync(entity);
//            await _dbContext.SaveChangesAsync();
//            return entity;
//        }
//        public T AddSync(T entity)
//        {
//            _dbContext.Set<T>().Add(entity);
//            _dbContext.SaveChanges();
//            return entity;
//        }
//        public async Task AddAsync(List<T> entity)
//        {
//            _dbContext.Set<T>().AddRange(entity);
//            await _dbContext.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(T entity)
//        {
//            _dbContext.Set<T>().Remove(entity);
//            await _dbContext.SaveChangesAsync();
//        }
        
//        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
//        {
//            var list = _dbContext.Set<T>().Where(predicate);
//            _dbContext.Set<T>().RemoveRange(list);
//            await _dbContext.SaveChangesAsync();
//        }

//        public async Task<IQueryable<T>> Get(Expression<Func<T, bool>> predicate)
//        {
//            return await Task.FromResult(_dbContext.Set<T>().Where(predicate));
//        }

//        public async Task<IQueryable<T>> GetAllAsync()
//        {
//            return await Task.FromResult(_dbContext
//                .Set<T>()
//                .AsQueryable());
//        }

//        public async Task<IQueryable<T>> GetAllBySP(string procname, string param)
//        {
//            return await Task.FromResult(_dbContext
//                .Set<T>().FromSqlRaw(string.Format("{0} {1}", procname, param))
//                .AsQueryable());
//        }

//        public async Task<DataSet> GetBySqlProc(string ProcedureName, List<QueryParameter> Parameter)
//        {
//            var connection = (SqlConnection)_dbContext.Database.GetDbConnection();
//            var command = connection.CreateCommand();
//            command.CommandType = CommandType.StoredProcedure;
//            command.CommandText = ProcedureName;
//            SqlDataAdapter da = new SqlDataAdapter();
//            DataSet ds = new DataSet();
//            foreach (var item in Parameter)
//            {
//                command.Parameters.AddWithValue(item.ParameterName, item.ParameterValue);
//            }
//            await Task.Delay(0);
//            da.SelectCommand = command;
//            da.Fill(ds);
//            return ds;

//        }

//        public async Task<T> GetByIdAsync(int id)
//        {
//            return await _dbContext.Set<T>().FindAsync(id);
//        }

        

//        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
//        {
//            return await _dbContext
//               .Set<T>()
//               .Skip((pageNumber - 1) * pageSize)
//               .Take(pageSize)
//               .AsNoTracking()
//               .ToListAsync();
//        }

//        public async Task<T> UpdateAsync(T entity)
//        {
//            _dbContext.Entry(entity).State = EntityState.Modified;
//            await _dbContext.SaveChangesAsync();
//            return entity;
//        }

//        public async Task UpdateAsync(List<T> entity)
//        {

//            _dbContext.Set<T>().UpdateRange(entity);
//            await _dbContext.SaveChangesAsync();
//        }
//        public int GetMaxValueWithWhereClause(Expression<Func<T, int>> predicate, Expression<Func<T, bool>> wherepredicate)
//        {
//            return _dbContext.Set<T>().Where(wherepredicate).Select(predicate).DefaultIfEmpty().Max();
//        }
//        public  int GetMaxValue(Expression<Func<T, int>> predicate)
//        {
//            return _dbContext.Set<T>().Select(predicate).DefaultIfEmpty().Max();
//        }
//        public void Dispose()
//        {
//            _dbContext.Dispose();
//        }

        
//    }
//}
