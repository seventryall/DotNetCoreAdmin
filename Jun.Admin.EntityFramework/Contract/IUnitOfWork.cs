using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Jun.Admin.EntityFramework
{
    public interface IUnitOfWork
    {
        bool Commit();

        Task<bool> CommitAsync();

        DbTransaction BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

    }
}
