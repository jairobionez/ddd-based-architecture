using FluentValidation;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Domain.Interfaces.Services
{
    public interface IServiceUser : IService<User>
    {
    }
}
