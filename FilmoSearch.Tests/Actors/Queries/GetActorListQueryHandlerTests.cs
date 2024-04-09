using AutoMapper;
using FilmoSearch.Application.Actors.Queries.GetActorList;
using FilmoSearch.Persistance;
using FilmoSearch.Tests.Common;
using Shouldly; 
using Xunit;

namespace FilmoSearch.Tests.Actors.Queries
{
    [Collection("QueryCollection")]
    public class GetActorListQueryHandlerTests
    {
        private readonly FilmoSearchDbContext Context;
        private readonly IMapper Mapper;

        public GetActorListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetActorListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetActorListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetActorListQuery
                { 
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ActorListVm>();
            result.Actors.Count.ShouldBe(4);
        }
    }
}
