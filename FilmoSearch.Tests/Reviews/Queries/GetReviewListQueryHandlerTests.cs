using AutoMapper; 
using FilmoSearch.Application.Reviews.Queries.GetReviewList;
using FilmoSearch.Persistance;
using FilmoSearch.Tests.Common;
using Shouldly; 
using Xunit;

namespace FilmoSearch.Tests.Reviews.Queries
{
    [Collection("QueryCollection")]
    public class GetReviewListQueryHandlerTests : TestCommandBase
    {
        private readonly FilmoSearchDbContext Context;
        private readonly IMapper Mapper;

        public GetReviewListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetReviewListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetReviewListQuery
                {
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ReviewListVm>();
            result.Reviews.Count.ShouldBe(4);
        }
    }
}
