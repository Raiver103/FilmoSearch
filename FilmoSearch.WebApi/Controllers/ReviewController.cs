using AutoMapper; 
using FilmoSearch.Application.Reviews.Commands.CreateReview;
using FilmoSearch.Application.Reviews.Commands.DeleteReview;
using FilmoSearch.Application.Reviews.Commands.UpdateReview;
using FilmoSearch.Application.Reviews.Queries.GetReviewDetails;
using FilmoSearch.Application.Reviews.Queries.GetReviewList;
using FilmoSearch.WebApi.Models; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 

namespace FilmoSearch.WebApi.Controllers
{ 
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ReviewController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly CreateReviewCommandValidator _createReviewCommandValidator;
        private readonly DeleteReviewCommandValidator _deleteReviewCommandValidator;
        private readonly UpdateReviewCommandValidator _updateReviewCommandValidator;
        private readonly GetReviewDetailsQueryValidator _getReviewDetailsQueryValidator;

        public ReviewController(IMapper mapper,
            CreateReviewCommandValidator createReviewCommandValidator,
            DeleteReviewCommandValidator deleteReviewCommandValidator,
            UpdateReviewCommandValidator updateReviewCommandValidator,
            GetReviewDetailsQueryValidator getReviewDetailsQueryValidator)
        {
            _mapper = mapper;
            _createReviewCommandValidator = createReviewCommandValidator;
            _deleteReviewCommandValidator = deleteReviewCommandValidator;
            _updateReviewCommandValidator = updateReviewCommandValidator;
            _getReviewDetailsQueryValidator = getReviewDetailsQueryValidator;
        }

        /// <summary>
        /// Get the review by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /review/1
        /// </remarks>
        /// <param name="id">Review id (int)</param>
        /// <returns>Returns ReviewDetailsVm</returns>
        /// <response code="200">Success</response> 
        /// <response code="400">If the query is incorrect</response> 
        /// <response code="401">If the user is unauthorized</response>  
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ReviewDetailsVm>> Get(int id)
        {
            var query = new GetReviewDetailsQuery
            {
                Id = id,
            };

            var result = _getReviewDetailsQueryValidator.Validate(query);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the list of reviews
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /review
        /// </remarks>
        /// <returns>Returns ReviewListVm</returns>
        /// <response code="200">Success</response>  
        /// <response code="401">If the user is unauthorized</response>    
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ReviewListVm>> GetAll()
        {
            var query = new GetReviewListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create the review
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /review
        /// {
        ///     Title: "review Title", 
        ///     Description: "review Description", 
        ///     Stars: "review Stars", 
        ///     FilmId: "film FilmId", 
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
        public async Task<ActionResult<int>> Create([FromBody] CreateReviewDto createReviewDto)
        {
            var command = _mapper.Map<CreateReviewCommand>(createReviewDto);

            var result = _createReviewCommandValidator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var reviewId = await Mediator.Send(command);
            return Ok(reviewId);
        }

        /// <summary>
        /// Updates the review
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /review
        /// {
        ///     Title: "review Title", 
        ///     Description: "review Description", 
        ///     Stars: "review Stars", 
        ///     FilmId: "film FilmId", 
        /// }
        /// </remarks>
        /// <param name="updateReviewDto">UpdateReviewDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="400">If the command is incorrect</response> 
        /// <response code="401">If the user is unauthorized</response> 
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateReviewDto updateReviewDto)
        {
            var command = _mapper.Map<UpdateReviewCommand>(updateReviewDto);

            var result = _updateReviewCommandValidator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the review by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /review/1
        /// </remarks>
        /// <param name="id">Id of the review(int)</param>
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
            var command = new DeleteReviewCommand
            {
                Id = id,
            };

            var result = _deleteReviewCommandValidator.Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
