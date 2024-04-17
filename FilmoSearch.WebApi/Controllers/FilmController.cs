using AutoMapper; 
using FilmoSearch.Application.Films.Commands.CreateFilm;
using FilmoSearch.Application.Films.Commands.DeleteFilm;
using FilmoSearch.Application.Films.Commands.UpdateFilm;
using FilmoSearch.Application.Films.Queries.GetFilmDetails;
using FilmoSearch.Application.Films.Queries.GetFilmList; 
using FilmoSearch.WebApi.Models; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
namespace FilmoSearch.WebApi.Controllers
{ 
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class FilmController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly CreateFilmCommandValidator _createFilmCommandValidator;
        private readonly DeleteFilmCommandValidator _deleteFilmCommandValidator;
        private readonly UpdateFilmCommandValidator _updateFilmCommandValidator; 
        private readonly GetFilmDetailsQueryValidator _getFilmDetailsQueryValidator;

        public FilmController(IMapper mapper, 
            CreateFilmCommandValidator createFilmCommandValidator,
            DeleteFilmCommandValidator deleteFilmCommandValidator,
            UpdateFilmCommandValidator updateFilmCommandValidator,
            GetFilmDetailsQueryValidator getFilmDetailsQueryValidator)
        {
            _mapper = mapper;
            _createFilmCommandValidator = createFilmCommandValidator;
            _deleteFilmCommandValidator = deleteFilmCommandValidator;
            _updateFilmCommandValidator = updateFilmCommandValidator;
            _getFilmDetailsQueryValidator = getFilmDetailsQueryValidator;
        }
        /// <summary>
        /// Get the film by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /film/1
        /// </remarks>
        /// <param name="id">Film id (int)</param>
        /// <returns>Returns FilmDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="400">If the query is incorrect</response>  
        /// <response code="401">If the user is unauthorized</response>   
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<FilmDetailsVm>> Get(int id)
        {
            var query = new GetFilmDetailsQuery
            {
                Id = id,
            }; 

            var result = _getFilmDetailsQueryValidator.Validate(query);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of films
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /film
        /// </remarks>
        /// <returns>Returns FilmListVm</returns>
        /// <response code="200">Success</response> 
        /// <response code="401">If the user is unauthorized</response>    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<FilmListVm>> GetAll()
        {
            var query = new GetFilmListQuery(); 
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create the film
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /film
        /// {
        ///     Title: "film Title", 
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
        public async Task<ActionResult<int>> Create([FromBody] CreateFilmDto createFilmDto)
        {
           
            var command = _mapper.Map<CreateFilmCommand>(createFilmDto);

            var result = _createFilmCommandValidator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors); 
            }

            var filmId = await Mediator.Send(command);
            return Ok(filmId); 

        }

        /// <summary>
        /// Updates the film
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /film
        /// {
        ///     Title: "film Title", 
        /// }
        /// </remarks>
        /// <param name="updateFilmDto">UpdateFilmDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">If the command is incorrect</response> 
        /// <response code="401">If the user is unauthorized</response> 
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateFilmDto updateFilmDto)
        {
            var command = _mapper.Map<UpdateFilmCommand>(updateFilmDto);

            var result = _updateFilmCommandValidator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the film by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /film/1
        /// </remarks>
        /// <param name="id">Id of the film (int)</param>
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
            var command = new DeleteFilmCommand
            {
                Id = id,
            };

            var result = _deleteFilmCommandValidator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
