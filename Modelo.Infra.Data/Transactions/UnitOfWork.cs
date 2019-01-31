using Microsoft.EntityFrameworkCore.Storage;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Infra.Data.Context;
using Modelo.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Infra.Data.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {        
        private readonly ModeloContext _context;
        private IDbContextTransaction transaction;

        public UnitOfWork(ModeloContext context)
        {
            _context = context;
        }

        public void Begin()
        {
            transaction = _context.Database.BeginTransaction();
        }

        public bool Commit()
        {
            try{
                if (transaction != null)
                    _context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }

        public void Rollback()
        {
            if (transaction == null)
                transaction.Rollback();
        }
    }
}
