using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Data.Models;
using FastFood.Services.Data.Interfaces;
using FastFood.Web.ViewModel.Positions;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Services.Data
{
    public class PositionService : IPositionService
    {
        //Dependency Injection
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public PositionService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task CreateAsync(CreatePositionInputModel inputModel)
        {
            Position position = this.mapper.Map<Position>(inputModel);

            await context.Positions.AddAsync(position);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PositionsAllViewModel>> GetAllAsync()
            => await this.context.Positions
                .ProjectTo<PositionsAllViewModel>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();
    }
}