using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roa.Application.DTOs;
using Roa.Application.Repositories;

namespace Roa.API.Controllers.Programs;

[ApiController]
[Route("[controller]")]
public class DishTypesController : Controller
{
    private readonly IMapper _mapper;
    public readonly IRepositoryDTO<DishTypeDto> _dishTypeRepositoryDTO;

    public DishTypesController(IMapper mapper, IRepositoryDTO<DishTypeDto> dishTypeRepositoryDTO)
    {
        _mapper = mapper;
        _dishTypeRepositoryDTO = dishTypeRepositoryDTO;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<DishTypeDto>), StatusCodes.Status200OK)]
    [Route("~/DishTypes/GetAll")]
    public ActionResult<List<DishTypeDto>> GetAll()
    {
        var dishTypes = _dishTypeRepositoryDTO.GetAll().OrderBy(x => x.Id);

        if (dishTypes == null)
            return NotFound();

        return Ok(dishTypes);
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(DishTypeDto), StatusCodes.Status200OK)]
    [Route("~/DishTypes/GetSingle")]
    public ActionResult<DishTypeDto> GetById(int id)
    {
        var dishType = _dishTypeRepositoryDTO.GetById(id);

        if (dishType == null)
            return NotFound();

        return Ok(dishType.Result);
    }
}
