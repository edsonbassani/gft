using AutoMapper;
using Roa.Application.DTOs;
using Roa.Domain.Entities;
using Roa.Domain.Repositories;

namespace Roa.Application.Commands.Dishes.Get
{
    public class GetDishHandler : ICommandHandler<GetDishInput, DishDto>
    {
        private readonly IRepository<Dish> _repository;
        private readonly IMapper _mapper;

        public GetDishHandler(IRepository<Dish> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult<DishDto>> Handle(GetDishInput command, bool keepTransaction = false, string transactionName = "")
        {
            Dish dish = await _repository.GetById(1);
            DishDto dishDto = _mapper.Map<DishDto>(dish);
            return CommandResult<DishDto>.CreateSuccess(dishDto);
        }
    }
}
