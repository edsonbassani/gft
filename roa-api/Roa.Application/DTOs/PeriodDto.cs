namespace Roa.Application.DTOs;
public class PeriodDto : BaseDto
{
    public string Name { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

}
