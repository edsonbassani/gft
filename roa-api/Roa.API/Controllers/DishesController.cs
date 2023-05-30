using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Data;
using System.Text.Json;
using Roa.Application.DTOs;
using Roa.Domain.Repositories;
using Roa.Domain.Entities;

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
    public ActionResult<List<Dish>> GetAll()
    {
        var dishes = _dishRepository.GetAll();
        return Ok(dishes);
    }
}
