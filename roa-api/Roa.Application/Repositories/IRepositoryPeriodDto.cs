using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Roa.Application.DTOs;
using Roa.Domain.Entities;
using Roa.Domain.Repositories;

namespace Roa.Application.Repositories
{
    public class RepositoryPeriodDto : IRepositoryDTO<PeriodDto>
    {
        private readonly IMapper _mapper;
        public readonly IRepository<Period> _periodRepository;

        public RepositoryPeriodDto(IMapper mapper, IRepository<Period> periodRepository)
        {
            _mapper = mapper;
            _periodRepository = periodRepository;
        }

        public IQueryable<PeriodDto> GetAll()
        {
            var periods = _periodRepository.GetAll();
            var periodsDTO = _mapper.Map<List<PeriodDto>>(periods);
            return periodsDTO.AsQueryable();
        }

        public async Task<PeriodDto> GetById(int id)
        {
            var period = await _periodRepository.GetById(id);
            var periodDto = _mapper.Map<PeriodDto>(period);
            return periodDto;
        }

        public IQueryable<PeriodDto> GetAllWithRelated()
        {
            var periods = _periodRepository
                .GetAll()
                .Include(dt => dt.Dishes);

            var periodsDTO = _mapper.Map<List<PeriodDto>>(periods);
            return periodsDTO.AsQueryable();
        }
    }
}
