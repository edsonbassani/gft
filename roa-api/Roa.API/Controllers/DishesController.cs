using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public readonly IRepositoryDTO<DishDto> _dishRepositoryDTO;

    public DishesController(IMapper mapper, IRepositoryDTO<DishDto> dishRepositoryDTO)
    {
        _mapper = mapper;
        _dishRepositoryDTO = dishRepositoryDTO;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<DishDto>), StatusCodes.Status200OK)]
    [Route("~/Dishes/GetAll")]
    public ActionResult<List<DishDto>> GetAll()
    {
        var dishes = _dishRepositoryDTO.GetAll().OrderBy(x => x.Id);

        if(dishes == null)
            return NotFound();

        return Ok(dishes);
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DishDto), StatusCodes.Status200OK)]
    [Route("~/Dishes/GetSingle")]
    public ActionResult<DishDto> GetById(int id)
    {
        var dish = _dishRepositoryDTO.GetById(id);

        if (dish == null)
            return NotFound();

        return Ok(dish.Result);
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<DishDto>), StatusCodes.Status200OK)]
    [Route("~/Dishes/GetAllWithRelated")]
    public ActionResult<List<DishDto>> GetAllWithRelated()
    {
        var dishes = _dishRepositoryDTO.GetAllWithRelated();

        if (dishes == null)
            return NotFound();

        return Ok(dishes);
    }
}
