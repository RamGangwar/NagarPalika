using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagarPalika.Application.UnitOfWork
{
    public interface IBaseUnitOfWork : IDisposable
    {
        IDbTransaction BeginDbTransaction();
        IDbConnection DbConnection { get; }
        IDbTransaction DbTransaction { get; }
        void Rollback();
        void Commit();
    }
}
