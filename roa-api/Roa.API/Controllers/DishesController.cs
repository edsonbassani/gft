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
    [Route("~/GetAll")]
    public ActionResult<List<DishDto>> GetAll()
    {
        var dishes = _dishRepositoryDTO.GetAll();
        return Ok(dishes);
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DishDto), StatusCodes.Status200OK)]
    [Route("~/GetSingle")]
    public ActionResult<DishDto> GetById(int id)
    {
        var dishes = _dishRepositoryDTO.GetById(id);
        return Ok(dishes.Result);
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<DishDto>), StatusCodes.Status200OK)]
    [Route("~/GetAllWithRelated")]
    public ActionResult<List<DishDto>> GetAllWithRelated()
    {
        var dishes = _dishRepositoryDTO.GetAllWithRelated();
        return Ok(dishes);
    }
}
