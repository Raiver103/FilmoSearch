using AutoMapper; 
using FilmoSearch.Application.Actors.Commands.CreateActor;
using FilmoSearch.Application.Actors.Commands.DeleteActor;
using FilmoSearch.Application.Actors.Commands.UpdateActor;
using FilmoSearch.Application.Actors.Queries.GetActorDetails;
using FilmoSearch.Application.Actors.Queries.GetActorList;
using FilmoSearch.Application.Interfaces;
using FilmoSearch.WebApi.Models; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 

namespace FilmoSearch.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ActorController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly CreateActorCommandValidator _createActorCommandValidator;
        private readonly DeleteActorCommandValidator _deleteActorCommandValidator;
        private readonly UpdateActorCommandValidator _updateActorCommandValidator;
        private readonly GetActorDetailsQueryValidator _getActorDetailsQueryValidator;

        public ActorController(IMapper mapper,
            CreateActorCommandValidator createActorCommandValidator,
            DeleteActorCommandValidator deleteActorCommandValidator,
            UpdateActorCommandValidator updateActorCommandValidator,
            GetActorDetailsQueryValidator getActorDetailsQueryValidator)
        {
            _mapper = mapper;
            _createActorCommandValidator = createActorCommandValidator;
            _deleteActorCommandValidator = deleteActorCommandValidator;
            _updateActorCommandValidator = updateActorCommandValidator;
            _getActorDetailsQueryValidator = getActorDetailsQueryValidator;
        }

        /// <summary>
        /// Get the actor by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /actor/1
        /// </remarks>
        /// <param name="id">Actor id (int)</param>
        /// <returns>Returns ActorDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="400">If the query is incorrect</response> 
        /// <response code="401">If the user is unauthorized</response>  
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ActorDetailsVm>> Get(int id)
        {
            var query = new GetActorDetailsQuery
            {
                Id = id,
            };

            var result = _getActorDetailsQueryValidator.Validate(query);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var vm = await Mediator.Send(query);
            return Ok(vm); 
        }

        /// <summary>
        /// Gets the list of actors
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /actor
        /// </remarks>
        /// <returns>Returns ActorListVm</returns>
        /// <response code="200">Success</response> 
        /// <response code="401">If the user is unauthorized</response>   
        [HttpGet] 
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ActorListVm>> GetAll()
        {
            var query = new GetActorListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create the actor
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /actor
        /// {
        ///     FirstName: "actor FirstName",
        ///     LastName: "actor LastName"
        /// }
        /// </remarks>
        /// <returns>Returns id(int)</returns>
        /// <response code="200">Success</response>
        /// <response code="400">If the command is incorrect</response> 
        /// <response code="401">If the user is unauthorized</response>  
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create([FromBody] CreateActorDto createActorDto)
        {
            var command = _mapper.Map<CreateActorCommand>(createActorDto);

            var result = _createActorCommandValidator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var actorId = await Mediator.Send(command);
            return Ok(actorId);
        }

        /// <summary>
        /// Updates the actor
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /actor
        /// {
        ///     FirstName: "updated actor FirstName"
        ///     LastName: "updated actor LastName"
        /// }
        /// </remarks>
        /// <param name="updateActorDto">UpdateActorDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">If the command is incorrect</response> 
        /// <response code="401">If the user is unauthorized</response>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateActorDto updateActorDto)
        {
            var command = _mapper.Map<UpdateActorCommand>(updateActorDto);

            var result = _updateActorCommandValidator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the actor by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /actor/1
        /// </remarks>
        /// <param name="id">Id of the actor (int)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">If the command is incorrect</response> 
        /// <response code="401">If the user is unauthorized</response> 
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] 
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteActorCommand
            {
                Id = id, 
            };

            var result = _deleteActorCommandValidator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            await Mediator.Send(command);
            return NoContent();
        }
    }
}