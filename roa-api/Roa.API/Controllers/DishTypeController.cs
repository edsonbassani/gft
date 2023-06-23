using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roa.Application.Commands.Dishes.Get;
using Roa.Application.Commands.Dishes.List;
using Roa.Application.Commands.DishType.List;
using Roa.Application.Commands.DishTypes.Get;
using Roa.Application.DTOs;
using Roa.Application.Repositories;

namespace Roa.API.Controllers.DishTypes;

[ApiController]
[Route("[controller]")]
public class DishTypesController : Controller
{
    private readonly IMapper _mapper;
    public readonly IRepositoryDTO<DishTypeDto> _dishTypeRepositoryDTO;
    private readonly GetDishTypeHandler _getDishTypesHandler;
    private readonly ListDishTypeHandler _listDishTypesHandler;

    public DishTypesController(IMapper mapper, IRepositoryDTO<DishTypeDto> dishTypeRepositoryDTO, ListDishTypeHandler listDishTypeHandler, GetDishTypeHandler getDishTypeHandler)
    {
        _mapper = mapper;
        _dishTypeRepositoryDTO = dishTypeRepositoryDTO;
        _listDishTypesHandler = listDishTypeHandler;
        _getDishTypesHandler = getDishTypeHandler;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<DishDto>), StatusCodes.Status200OK)]
    [Route("~/dishtypes/getall")]
    public async Task<ActionResult<List<DishTypeDto>>> GetAll()
    {
        ListDishTypeInput listDishTypeInput = new ListDishTypeInput();
        var result = await _listDishTypesHandler.Handle(listDishTypeInput);

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
    [Route("~/dishtypes/getsingle")]
    public async Task<ActionResult<DishTypeDto>> GetById(int id)
    {
        GetDishTypeInput getDishTypeInput = new GetDishTypeInput() { DishTypeId = id };
        var result = await _getDishTypesHandler.Handle(getDishTypeInput);

        if (result.Success) return Ok(result.Data);

        return BadRequest(new
        {
            result.Message,
            result.Notifications
        });
    }

    [HttpGet("~/odata/dishtypes/getbyid/{dishId}")]
    [EnableQueryWithCount(MaxAnyAllExpressionDepth = 2, MaxExpansionDepth = 5)]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DishDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<DishDto>>> ODataGetById(int dishId)
    {
        GetDishTypeInput getDishTypeInput = new GetDishTypeInput() { DishTypeId = dishId };
        var result = await _getDishTypesHandler.Handle(getDishTypeInput);

        if (result.Success) return Ok(result.Data);

        return BadRequest(new
        {
            result.Message,
            result.Notifications
        });
    }
}
