using AutoMapper; 
using FilmoSearch.WebApi.Core.Application.Interfaces;
using FilmoSearch.WebApi.Core.Domain.Models;
using FilmoSearchT.Dto;
using Microsoft.AspNetCore.Mvc;
using Serilog; 

namespace FilmoSearchT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository actorRepository;
        private readonly IMapper mapper;

        public ActorController(IActorRepository actorRepository, IMapper mapper)
        {
            this.actorRepository = actorRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Actor>))]
        public IActionResult GetActors()
        {
            var actors = mapper.Map<List<ActorDto>>(actorRepository.GetActors());
             
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Log.Information($"Actors Request: GetActors Count: {@actors.Count}"); 
            return Ok(actors);
        } 

        [HttpGet("{actorId}")]
        [ProducesResponseType(200, Type = typeof(Actor))]
        [ProducesResponseType(400)]
        public IActionResult GetActor(int actorId)
        {
            if (!actorRepository.ActorExists(actorId))
                return NotFound();

            var actor = mapper.Map<ActorDto>(actorRepository.GetActor(actorId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Log.Information($"Actors Request: GetActor id: {actorId}"); 
            return Ok(actor);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateActor([FromBody] ActorDto actorCreate)
        {
            if (actorCreate == null)
                return BadRequest(ModelState);

            var actor = actorRepository.GetActors()
                .Where(c => c.FirstName.Trim().ToUpper() == actorCreate.FirstName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (actor != null)
            {
                ModelState.AddModelError("", "Actor already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
              
            var actorMap = mapper.Map<Actor>(actorCreate);

            if (!actorRepository.CreateActor(actorMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            Log.Information($"Actors Request: CreateActor id: {actorMap.Id}");
            return Ok("Successfully created");
        }

        [HttpPut("{actorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateActor(int actorId, [FromBody] ActorDto updatedActor)
        {
            if (updatedActor == null)
                return BadRequest(ModelState);

            if (actorId != updatedActor.Id)
                return BadRequest(ModelState); 

            if (!ModelState.IsValid)
                return BadRequest();

            var actorMap = mapper.Map<Actor>(updatedActor);

            if (!actorRepository.UpdateActor(actorMap))
            {
                ModelState.AddModelError("", "Something went wrong updating actor");
                return StatusCode(500, ModelState);
            }

            Log.Information($"Actors Request: UpdateActor id: {updatedActor.Id}");

            return NoContent();
        }

        [HttpDelete("{actorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteActor(int actorId)
        { 

            var actorToDelete = actorRepository.GetActor(actorId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!actorRepository.DeleteActor(actorToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting actor");
            }

            Log.Information($"Actors Request: DeleteActor id: {actorId}");

            return NoContent();
        }
    }
}
