using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roa.Application.Commands.Dishes.Get;
using Roa.Application.DTOs;
using Roa.Application.Repositories;
using Roa.Domain.Entities;
using Roa.Domain.Repositories;

namespace Roa.API.Controllers.Programs;

[ApiController]
[Route("[controller]")]
public class DishesController : Controller
{
    private readonly IMapper _mapper;
    private readonly IRepository<Dish> _dishRepository;
    private readonly GetDishHandler _getDishHandler;


    /// <param name="mapper"></param>
    /// <param name="repository"></param>
    /// <param name="getDishHandler"></param>

    public DishesController(IMapper mapper, IRepository<Dish> dishRepository, GetDishHandler getDishHandler)
    {
        _mapper = mapper;
        _dishRepository = dishRepository;
        _getDishHandler = getDishHandler;        
    }

    //[HttpGet]
    //[Produces("application/json")]
    //[ProducesResponseType(typeof(IEnumerable<DishDto>), StatusCodes.Status200OK)]
    //[Route("~/Dishes/GetAll")]
    //public ActionResult<List<DishDto>> GetAll()
    //{
    //    var dishes = _dishRepositoryDTO.GetAll().OrderBy(x => x.Id);

    //    if(dishes == null)
    //        return NotFound();

    //    return Ok(dishes);
    //}

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DishDto), StatusCodes.Status200OK)]
    [Route("~/Dishes/GetSingle")]
    public async Task<ActionResult<DishDto>> GetById(int dishId)
    {
        GetDishInput getDishInput = new GetDishInput() { DishId = dishId };
        var result = await _getDishHandler.Handle(getDishInput);

        if (result.Success) return Ok(result.Data);

        return BadRequest(new
        {
            result.Message,
            result.Notifications
        });
    }

    //[HttpGet]
    //[Produces("application/json")]
    //[ProducesResponseType(typeof(IEnumerable<DishDto>), StatusCodes.Status200OK)]
    //[Route("~/Dishes/GetAllWithRelated")]
    //public ActionResult<List<DishDto>> GetAllWithRelated()
    //{
    //    var dishes = _dishRepositoryDTO.GetAllWithRelated();

    //    if (dishes == null)
    //        return NotFound();

    //    return Ok(dishes);
    //}
}
