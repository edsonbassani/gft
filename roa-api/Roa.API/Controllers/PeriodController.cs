using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roa.Application.DTOs;
using Roa.Application.Repositories;
using Roa.Domain.Entities;

namespace Roa.API.Controllers.Periods;

[ApiController]
[Route("[controller]")]
public class PeriodsController : Controller
{
    private readonly IMapper _mapper;
    public readonly IRepositoryDTO<PeriodDto> _periodRepositoryDTO;

    public PeriodsController(IMapper mapper, IRepositoryDTO<PeriodDto> periodRepositoryDTO)
    {
        _mapper = mapper;
        _periodRepositoryDTO = periodRepositoryDTO;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<PeriodDto>), StatusCodes.Status200OK)]
    [Route("~/Periods/GetAll")]
    public ActionResult<List<PeriodDto>> GetAll()
    {
        var periods = _periodRepositoryDTO.GetAll().OrderBy(x => x.Id);

        if (periods == null)
            return NotFound();

        return Ok(periods);
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(PeriodDto), StatusCodes.Status200OK)]
    [Route("~/Periods/GetSingle")]
    public ActionResult<PeriodDto> GetById(int id)
    {
        var period = _periodRepositoryDTO.GetById(id);

        if (period == null)
            return NotFound();

        return Ok(period.Result);
    }
}
