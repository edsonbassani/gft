using AutoMapper;
using Roa.Application.DTOs;
using Roa.Domain.Entities;
using Roa.Domain.Repositories;

namespace Roa.Application.Commands.Dishes.Get
{
    public class GetDishHandler : ICommandHandler<GetDishInput, DishDto>
    {
        private readonly IRepository<Dish> _dishRepository;
        private readonly IMapper _mapper;

        public GetDishHandler(IRepository<Dish> dishRepository, IMapper mapper)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
        }

        public async Task<ICommandResult<DishDto>> Handle(GetDishInput command, bool keepTransaction = false, string transactionName = "")
        {
            Dish dish = await Task.Run(() => _dishRepository.GetById((int)command.DishId));
            return CommandResult<DishDto>.CreateSuccess(_mapper.Map<DishDto>(dish));
        }
    }
}
