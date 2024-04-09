using AutoMapper; 
using FilmoSearch.Application.Reviews.Queries.GetReviewDetails;
using FilmoSearch.Persistance;
using FilmoSearch.Tests.Common;
using Shouldly; 
using Xunit;

namespace FilmoSearch.Tests.Reviews.Queries
{
    [Collection("QueryCollection")]
    public class GetReviewDetailsQueryHandlerTests : TestCommandBase
    {
        private readonly FilmoSearchDbContext Context;
        private readonly IMapper Mapper;

        public GetReviewDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetReviewDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetReviewDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetReviewDetailsQuery
                {
                    Id = 3
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ReviewDetailsVm>();
            result.Title.ShouldBe("Title3");
        }
    }
}
