using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roa.Application.Commands.Dishes.Get;
using Roa.Application.Commands.Dishes.List;
using Roa.Application.DTOs;
using Roa.Application.Repositories;
using Roa.Domain.Entities;
using Roa.Domain.Repositories;

namespace Roa.API.Controllers.Dishes;

[ApiController]
[Route("[controller]")]
public class DishesController : Controller
{
    private readonly IMapper _mapper;
    private readonly IRepositoryDTO<DishDto> _dishRepositoryDTO;
    private readonly GetDishHandler _getDishHandler;
    private readonly ListDishHandler _listDishHandler;


    public DishesController(IMapper mapper, IRepositoryDTO<DishDto> dishRepositoryDTO, ListDishHandler listDishHandler, GetDishHandler getDishHandler)
    {
        _mapper = mapper;
        _dishRepositoryDTO = dishRepositoryDTO;
        _listDishHandler = listDishHandler;
        _getDishHandler = getDishHandler;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<DishDto>), StatusCodes.Status200OK)]
    [Route("~/dishes/getall")]
    public async Task<ActionResult<List<DishDto>>> GetAll()
    {
        ListDishInput listDishInput = new ListDishInput();
        var result = await _listDishHandler.Handle(listDishInput);

        if (result.Success) return Ok(result.Data);

        return BadRequest(new
        {
            result.Message,
            result.Notifications
        });
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DishDto), StatusCodes.Status200OK)]
    [Route("~/dishes/getsingle")]
    public async Task<ActionResult<DishDto>> GetById(int id)
    {
        GetDishInput getDishInput = new GetDishInput() { DishId = id };
        var result = await _getDishHandler.Handle(getDishInput);

        if (result.Success) return Ok(result.Data);

        return BadRequest(new
        {
            result.Message,
            result.Notifications
        });
    }

    [HttpGet("~/odata/dishes/getbyid/{dishId}")]
    [EnableQueryWithCount(MaxAnyAllExpressionDepth = 2, MaxExpansionDepth = 5)]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DishDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<DishDto>>> ODataGetById(int dishId)
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
}
