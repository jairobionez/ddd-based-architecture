using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Infra.Data.Transactions
{
    public interface IUnitOfWork
    {
        void Begin();

        bool Commit();

        void Rollback();
    }
}
