using Application.Territories;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TerritoriesController : BaseApiController
    {
        

        [HttpGet] //api/territories
        public async Task<ActionResult<List<Territory>>> GetTerritories()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] //api/territories/{id}
        public async Task<ActionResult<Territory>> GetTerritory(Guid id)
        {
            // Implementation for getting a single territory
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateTerritory(Territory territory)
        {
            await Mediator.Send(new Create.Command { Territory = territory });

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTerritory(Guid id, Territory territory)
        {
            territory.Id = id;
            await Mediator.Send(new Edit.Command { Territory = territory });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTerritory(Guid id)
        {
            await Mediator.Send(new Delete.Command { Id = id });
            return Ok();
        }

    }
}