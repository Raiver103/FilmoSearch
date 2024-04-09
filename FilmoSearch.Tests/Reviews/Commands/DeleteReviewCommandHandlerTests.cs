using FilmoSearch.Application.Common.Exceptions; 
using FilmoSearch.Application.Reviews.Commands.DeleteReview;
using FilmoSearch.Tests.Common; 
using Xunit;

namespace FilmoSearch.Tests.Reviews.Commands
{
    public class DeleteReviewCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteReviewCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteReviewCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteReviewCommand
            {
                Id = FilmoSearchContextFactory.ReviewIdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Reviews.SingleOrDefault(review =>
                review.Id == FilmoSearchContextFactory.ReviewIdForDelete));
        }

        [Fact]
        public async Task DeleteReviewCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteReviewCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteReviewCommand
                    {
                        Id = 52,
                    },
                    CancellationToken.None));
        }
    }
}
