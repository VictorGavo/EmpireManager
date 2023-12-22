using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class TerritoriesController : BaseApiController
    {
        private readonly DataContext context;
        public TerritoriesController(DataContext context)
        {
            this.context = context;
            
        }

        [HttpGet] //api/territories
        public async Task<ActionResult<List<Territory>>> GetTerritories()
        {
            return await this.context.Territories.ToListAsync();
        }

        [HttpGet("{id}")] //api/territories/[PLACEHOLDER]
        public async Task<ActionResult<Territory>> GetTerritory(Guid id)
        {
            return await this.context.Territories.FindAsync(id);
        }
    }
}