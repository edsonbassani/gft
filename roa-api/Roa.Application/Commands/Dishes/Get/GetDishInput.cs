using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Roa.Application.DTOs;

using Roa.Domain.Repositories;

namespace Roa.Application.Commands.Dishes.Get
{
    public class GetDishInput
    {
        public int? DishId { get; set; }
    }
}
