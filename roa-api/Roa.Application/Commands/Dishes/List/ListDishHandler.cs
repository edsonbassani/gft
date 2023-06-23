using AutoMapper;
using Roa.Application.DTOs;
using Roa.Domain.Entities;
using Roa.Domain.Repositories;

namespace Roa.Application.Commands.Dishes.List
{
    public class ListDishHandler : ICommandHandler<ListDishInput, IQueryable<DishDto>>
    {
        private readonly IRepository<Dish> _dishRepository;
        private readonly IMapper _mapper;

        public ListDishHandler(IRepository<Dish> dishRepository, IMapper mapper)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
        }

        public async Task<ICommandResult<IQueryable<DishDto>>> Handle(ListDishInput command, bool keepTransaction = false, string transactionName = "")
        {
            IEnumerable<Dish> dishes = _dishRepository.GetAll();
            IEnumerable<DishDto> dishesDto = _mapper.Map<IEnumerable<DishDto>>(dishes);
            return await Task.Run(() => CommandResult<IQueryable<DishDto>>.CreateSuccess(dishesDto.AsQueryable()));
        }
    }
}
