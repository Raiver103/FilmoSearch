using FilmoSearch.Application.Common.Exceptions; 
using FilmoSearch.Application.Reviews.Commands.UpdateReview;
using FilmoSearch.Tests.Common;
using Microsoft.EntityFrameworkCore; 
using Xunit;

namespace FilmoSearch.Tests.Reviews.Commands
{
    public class UpdateReviewCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateReviewCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateReviewCommandHandler(Context);
            var updatedTitle = "review Title";
            var reviewDescription = "review Description";
            var reviewStars = 1;

            // Act
            await handler.Handle(new UpdateReviewCommand
            {
                Id = FilmoSearchContextFactory.ReviewIdForUpdate,
                Title = updatedTitle,
                Description = reviewDescription,
                Stars = reviewStars
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Reviews.SingleOrDefaultAsync(actor =>
                actor.Id == FilmoSearchContextFactory.ReviewIdForUpdate 
                && actor.Title == updatedTitle
                && actor.Description == reviewDescription
                && actor.Stars == reviewStars));
        }

        [Fact]
        public async Task UpdateReviewCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateReviewCommandHandler(Context);

            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateReviewCommand
                    {
                        Id = 52,
                    },
                    CancellationToken.None));
        }
    }
}
