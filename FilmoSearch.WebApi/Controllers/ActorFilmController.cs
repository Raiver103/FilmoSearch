using AutoMapper;
using FilmoSearch.Application.ActorFilm.Commands.AddFilmToActor;
using FilmoSearch.Application.ActorFilm.Commands.DeleteFilmFromActor;
using FilmoSearch.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmoSearch.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ActorFilmController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly AddFilmToActorCommandValidator _addFilmToActorCommandValidator;
        private readonly DeleteFilmFromActorCommandValidator _deleteFilmFromActorCommandValidator;

        public ActorFilmController(IMapper mapper, 
            AddFilmToActorCommandValidator addFilmToActorCommandValidator, 
            DeleteFilmFromActorCommandValidator deleteFilmFromActorCommandValidator)
        {
            _mapper = mapper;
            _addFilmToActorCommandValidator = addFilmToActorCommandValidator;
            _deleteFilmFromActorCommandValidator = deleteFilmFromActorCommandValidator;
        }


        /// <summary>
        /// Add the film to the actor by actor firstname, actor lastname and film title
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /ActorFilm 
        /// {
        ///     ActorFirstName: "Actor FirstName"
        ///     ActorLastName: "Actor LastName"
        ///     FilmTitle: "Film Title"
        /// }
        /// </remarks>
        /// <param name = "AddFilmToActorDto" > AddFilmToActorDto object</param> 
        /// <returns>Returns actor id(int)</returns>
        /// <response code="200">Success</response>
        /// <response code="400">If the data is inacorrect</response> 
        /// <response code="401">If the user is unauthorized</response> 
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Add([FromBody] AddFilmToActorDto addFilmToActorDto)
        {
            var command = _mapper.Map<AddFilmToActorCommand>(addFilmToActorDto);

            var result = _addFilmToActorCommandValidator.Validate(command);
            if(!result.IsValid)
            { 
                return BadRequest(result.Errors);
            }

            var actorId = await Mediator.Send(command);
            return Ok(actorId);
        }

        /// <summary>
        /// Delete the film from the actor by actor firstname, actor lastname and film title
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /ActorFilm 
        /// {
        ///     ActorFirstName: "Actor FirstName"
        ///     ActorLastName: "Actor LastName"
        ///     FilmTitle: "Film Title"
        /// }
        /// </remarks>
        /// <param name = "DeleteFilmFromActorDto" > DeleteFilmFromActorDto object</param> 
        /// <returns>Returns actor id(int)</returns>
        /// <response code="200">Success</response>
        /// <response code="400">If the data is inacorrect</response> 
        /// <response code="401">If the user is unauthorized</response> 
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete([FromBody] DeleteFilmFromActorDto deleteFilmFromActorDto)
        {
            var command = _mapper.Map<DeleteFilmFromActorCommand>(deleteFilmFromActorDto);

            var result = _deleteFilmFromActorCommandValidator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var actorId = await Mediator.Send(command);
            return Ok(actorId);
        }
    }
}
