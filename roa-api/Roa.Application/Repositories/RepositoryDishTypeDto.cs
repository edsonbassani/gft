using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Roa.Application.DTOs;
using Roa.Domain.Entities;
using Roa.Domain.Repositories;

namespace Roa.Application.Repositories
{
    public class RepositoryDishTypeDto : IRepositoryDTO<DishTypeDto>
    {
        private readonly IMapper _mapper;
        public readonly IRepository<DishType> _dishTypeRepository;

        public RepositoryDishTypeDto(IMapper mapper, IRepository<DishType> dishTypeRepository)
        {
            _mapper = mapper;
            _dishTypeRepository = dishTypeRepository;
        }

        public IQueryable<DishTypeDto> GetAll()
        {
            var disheTypes = _dishTypeRepository.GetAll();
            var disheTypesDTO = _mapper.Map<List<DishTypeDto>>(disheTypes);
            return disheTypesDTO.AsQueryable();
        }

        public async Task<DishTypeDto> GetById(int id)
        {
            var dishType = await _dishTypeRepository.GetById(id);
            var dishTypeDTO = _mapper.Map<DishTypeDto>(dishType);
            return dishTypeDTO;
        }

        public IQueryable<DishTypeDto> GetAllWithRelated()
        {
            var dishTypes = _dishTypeRepository
                .GetAll()
                .Include(dt => dt.Dishes);

            var dishTypesDTO = _mapper.Map<List<DishTypeDto>>(dishTypes);
            return dishTypesDTO.AsQueryable();
        }
    }
}
