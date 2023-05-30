using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roa.Application.DTOs;
using Roa.Domain.Entities;
using Roa.Domain.Repositories;

namespace Roa.API.Controllers.Programs;

[ApiController]
[Route("[controller]")]
public class DishesController : Controller
{
    private readonly IMapper _mapper;
    public readonly IRepository<Dish> _dishRepository;

    public DishesController(IMapper mapper, IRepository<Dish> dishRepository)
    {
        _mapper = mapper;
        _dishRepository = dishRepository;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<DishDto>), StatusCodes.Status200OK)]
    public ActionResult<List<DishDto>> GetAll()
    {
        var dishes = _dishRepository.GetAll();
        var dishesDTO = _mapper.Map<List<DishDto>>(dishes);

        return Ok(dishesDTO);
    }
}
