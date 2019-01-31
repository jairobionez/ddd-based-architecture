using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Insert(T obj);

        T Update(T obj);

        void Remove(int id);

        T Select(int id);

        IList<T> SelectAll();        
    }
}
