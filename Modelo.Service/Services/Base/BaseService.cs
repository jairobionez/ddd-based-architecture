using FluentValidation;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;

namespace Modelo.Service.Services.Base
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return _repository.Select(id);
        }

        public IList<T> Get() => _repository.SelectAll();

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Update(obj);
            return obj;
        }
        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            _repository.Remove(id);
        }

        private void Validate<V>(T obj, V v) where V : AbstractValidator<T>
        {
            if (obj == null)
                throw new Exception("Registros não detectados");

            v.ValidateAndThrow(obj);
        }
    }
}
