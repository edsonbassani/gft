using Roa.Application.DTOs;
using Roa.Domain.Entities;

namespace Roa.Application.DTOs;
public class DishDto : BaseDto
{
    public string Name { get; set; }
    public int DishTypeId { get; set; }
    public DishTypeDto DishTypeDto { get; set; }
    public int PeriodId { get; set; }
    public PeriodDto PeriodDto { get; set; }
}
