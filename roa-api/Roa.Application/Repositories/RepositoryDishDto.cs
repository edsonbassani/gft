using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Roa.Application.DTOs;
using Roa.Domain.Entities;
using Roa.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roa.Application.Repositories
{
    public class RepositoryDishDto : IRepositoryDTO<DishDto>
    {
        private readonly IMapper _mapper;
        public readonly IRepository<Dish> _dishRepository;

        public RepositoryDishDto(IMapper mapper, IRepository<Dish> dishRepository)
        {
            _mapper = mapper;
            _dishRepository = dishRepository;
        }

        public IQueryable<DishDto> GetAll()
        {
            var dishes = _dishRepository.GetAll();
            var dishesDTO = _mapper.Map<List<DishDto>>(dishes);
            return dishesDTO.AsQueryable();
        }

        public async Task<DishDto> GetById(int id)
        {
            var dish = await _dishRepository.GetById(id);
            var dishDTO = _mapper.Map<DishDto>(dish);
            return dishDTO;
        }

        public IQueryable<DishDto> GetAllWithRelated()
        {
            var dishes = _dishRepository
                .GetAll()
                .Include(dt => dt.DishType)
                .Include(p => p.Period);

            var dishesDTO = _mapper.Map<List<DishDto>>(dishes);
            return dishesDTO.AsQueryable();
        }

    }
}
