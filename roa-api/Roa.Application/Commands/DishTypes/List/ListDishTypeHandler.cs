using AutoMapper;
using Roa.Application.Commands.DishType.List;
using Roa.Application.DTOs;
using Roa.Domain.Repositories;

namespace Roa.Application.Commands.Dishes.List
{
    public class ListDishTypeHandler : ICommandHandler<ListDishTypeInput, IQueryable<DishTypeDto>>
    {
        private readonly IRepository<Roa.Domain.Entities.DishType> _dishTypesRepository;
        private readonly IMapper _mapper;

        public ListDishTypeHandler(IRepository<Roa.Domain.Entities.DishType> dishTypesRepository, IMapper mapper)
        {
            _dishTypesRepository = dishTypesRepository;
            _mapper = mapper;
        }

        public async Task<ICommandResult<IQueryable<DishTypeDto>>> Handle(ListDishTypeInput command, bool keepTransaction = false, string transactionName = "")
        { 
            IEnumerable<Roa.Domain.Entities.DishType> dishTypes = _dishTypesRepository.GetAll();
            IEnumerable<DishTypeDto> dishTypesDto = _mapper.Map<IEnumerable<DishTypeDto>>(dishTypes);
            return await Task.Run(() => CommandResult<IQueryable<DishTypeDto>>.CreateSuccess(dishTypesDto.AsQueryable()));
        }
    }
}
