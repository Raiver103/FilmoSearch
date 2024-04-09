using FilmoSearch.Application.Reviews.Commands.CreateReview;
using FilmoSearch.Tests.Common;
using Microsoft.EntityFrameworkCore; 
using Xunit;

namespace FilmoSearch.Tests.Reviews.Commands
{
    public class CreateReviewCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateReviewCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateReviewCommandHandler(Context);
            var reviewTitle = "review Title";
            var reviewDescription = "review Description";
            var reviewStars = 1;

            // Act
            var filmId = await handler.Handle(
                new CreateReviewCommand
                {
                    Title = reviewTitle,
                    Description = reviewDescription,
                    Stars = reviewStars
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Reviews.SingleOrDefaultAsync(
                    film => film.Id == filmId  
                    && film.Title == reviewTitle 
                    && film.Description == reviewDescription
                    && film.Stars == reviewStars));
        }
    }
}
