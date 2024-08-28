using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using NagarPalika.Application.Repository;
using NagarPalika.Application.UnitOfWork;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace NagarPalika.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private  IDbConnection dbcon = null;
         private IDbTransaction dbtran = null;

        private readonly IBaseUnitOfWork _unitOfWork;
        public GenericRepository(IBaseUnitOfWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }
        protected IDbTransaction _DbTransaction => _unitOfWork.DbTransaction;

        protected IDbConnection _DbConnection => _unitOfWork.DbConnection;

        public async Task<int> Add(TEntity entity)
        {
            var result = await _DbConnection.InsertAsync<TEntity>(entity, _DbTransaction);
            return result;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            var result = await _DbConnection.DeleteAsync<TEntity>(entity, _DbTransaction);
            return result;
        }

        public async Task<IEnumerable<TEntity>> Get(object conditions)
        {
            var query = $"SELECT * FROM {typeof(TEntity).Name}";
            if (conditions != null)
            {
                var whereClauses = conditions.GetType()
                    .GetProperties()
                    .Select(prop => $"{prop.Name} = @{prop.Name}");

                query += " WHERE " + string.Join(" AND ", whereClauses);
            }
            return await _DbConnection.QueryAsync<TEntity>(query, conditions);
        }


        public async Task<IEnumerable<TEntity>> GetALL()
        {
            var result = await _DbConnection.GetAllAsync<TEntity>(_DbTransaction);
            return result;
        }

        public async Task<TEntity> GetById(Object id)
        {
            var result = await _DbConnection.GetAsync<TEntity>(id, _DbTransaction);
            return result;
        }

        public async Task<bool> Update(TEntity entity)
        {
            var result = await _DbConnection.UpdateAsync<TEntity>(entity, _DbTransaction);
            return result;
        }

        public async Task<TEntity> GetByClause(object conditions)
        {
            var query = $"SELECT * FROM {typeof(TEntity).Name}";
            if (conditions != null)
            {
                var dynamicParameters = new DynamicParameters();
                var whereClauses = new List<string>();

                foreach (var prop in conditions.GetType().GetProperties())
                {
                    var paramName = $"@{prop.Name}";

                    if (prop.GetValue(conditions) != null)
                    {
                        if (prop.Name.EndsWith("_neq"))
                        {
                            dynamicParameters.Add(paramName, prop.GetValue(conditions));
                            whereClauses.Add($"{prop.Name.Replace("_neq", "")} != {paramName}");
                        }
                        else if (prop.Name.EndsWith("_lte"))
                        {
                            dynamicParameters.Add(paramName, prop.GetValue(conditions));
                            whereClauses.Add($"{prop.Name.Replace("_lte", "")} <= {paramName}");
                        }
                        else if (prop.Name.EndsWith("_gte"))
                        {
                            dynamicParameters.Add(paramName, prop.GetValue(conditions));
                            whereClauses.Add($"{prop.Name.Replace("_gte", "")} >= {paramName}");
                        }
                        else if (prop.Name.EndsWith("_lt"))
                        {
                            dynamicParameters.Add(paramName, prop.GetValue(conditions));
                            whereClauses.Add($"{prop.Name.Replace("_lt", "")} < {paramName}");
                        }
                        else if (prop.Name.EndsWith("_gt"))
                        {
                            dynamicParameters.Add(paramName, prop.GetValue(conditions));
                            whereClauses.Add($"{prop.Name.Replace("_gt", "")} > {paramName}");
                        }
                        else
                        {
                            dynamicParameters.Add(paramName, prop.GetValue(conditions));
                            whereClauses.Add($"{prop.Name} = {paramName}");
                        }
                    }
                    else
                    {
                        whereClauses.Add($"{prop.Name} IS NULL");
                    }
                }

                if (whereClauses.Any())
                {
                    query += " WHERE " + string.Join(" AND ", whereClauses);
                }

                return await _DbConnection.QueryFirstOrDefaultAsync<TEntity>(query, dynamicParameters);
            }

            return await _DbConnection.QueryFirstOrDefaultAsync<TEntity>(query);
        }
        public async Task<IEnumerable<TEntity>> GetByClauseList(object conditions)
        {
            var query = $"SELECT * FROM {typeof(TEntity).Name}";
            if (conditions != null)
            {
                var dynamicParameters = new DynamicParameters();
                var whereClauses = new List<string>();

                foreach (var prop in conditions.GetType().GetProperties())
                {
                    var paramName = $"@{prop.Name}";

                    if (prop.GetValue(conditions) != null)
                    {
                        if (prop.Name.EndsWith("_neq"))
                        {
                            dynamicParameters.Add(paramName, prop.GetValue(conditions));
                            whereClauses.Add($"{prop.Name.Replace("_neq", "")} != {paramName}");
                        }
                        else if (prop.Name.EndsWith("_lte"))
                        {
                            dynamicParameters.Add(paramName, prop.GetValue(conditions));
                            whereClauses.Add($"{prop.Name.Replace("_lte", "")} <= {paramName}");
                        }
                        else if (prop.Name.EndsWith("_gte"))
                        {
                            dynamicParameters.Add(paramName, prop.GetValue(conditions));
                            whereClauses.Add($"{prop.Name.Replace("_gte", "")} >= {paramName}");
                        }
                        else if (prop.Name.EndsWith("_lt"))
                        {
                            dynamicParameters.Add(paramName, prop.GetValue(conditions));
                            whereClauses.Add($"{prop.Name.Replace("_lt", "")} < {paramName}");
                        }
                        else if (prop.Name.EndsWith("_gt"))
                        {
                            dynamicParameters.Add(paramName, prop.GetValue(conditions));
                            whereClauses.Add($"{prop.Name.Replace("_gt", "")} > {paramName}");
                        }
                        else
                        {
                            dynamicParameters.Add(paramName, prop.GetValue(conditions));
                            whereClauses.Add($"{prop.Name} = {paramName}");
                        }
                    }
                    else
                    {
                        whereClauses.Add($"{prop.Name} IS NULL");
                    }
                }

                if (whereClauses.Any())
                {
                    query += " WHERE " + string.Join(" AND ", whereClauses);
                }

                return await _DbConnection.QueryAsync<TEntity>(query, dynamicParameters);
            }

            return await _DbConnection.QueryAsync<TEntity>(query);
        }
    }
}
