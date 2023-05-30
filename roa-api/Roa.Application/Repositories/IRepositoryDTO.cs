using Roa.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roa.Application.Repositories
{
    public interface IRepositoryDTO<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        IQueryable<T> GetAllWithRelated();
    }
}
