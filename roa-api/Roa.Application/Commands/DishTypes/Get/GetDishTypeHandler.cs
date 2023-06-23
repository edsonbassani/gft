using AutoMapper;
using Roa.Application.Commands.Dishes.Get;
using Roa.Application.DTOs;
using Roa.Domain.Entities;
using Roa.Domain.Repositories;

namespace Roa.Application.Commands.DishTypes.Get
{
    public class GetDishTypeHandler : ICommandHandler<GetDishTypeInput, DishTypeDto>
    {
        private readonly IRepository<Roa.Domain.Entities.DishType> _dishTypeRepository;
        private readonly IMapper _mapper;

        public GetDishTypeHandler(IRepository<Roa.Domain.Entities.DishType> dishTypeRepository, IMapper mapper)
        {
            _dishTypeRepository = dishTypeRepository;
            _mapper = mapper;
        }

        public async Task<ICommandResult<DishTypeDto>> Handle(GetDishTypeInput command, bool keepTransaction = false, string transactionName = "")
        {
            Roa.Domain.Entities.DishType dishType = await Task.Run(() => _dishTypeRepository.GetById((int)command.DishTypeId));
            return CommandResult<DishTypeDto>.CreateSuccess(_mapper.Map<DishTypeDto>(dishType));
        }
    }
}
