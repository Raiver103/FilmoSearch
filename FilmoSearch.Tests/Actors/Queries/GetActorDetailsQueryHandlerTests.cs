using AutoMapper;
using FilmoSearch.Application.Actors.Queries.GetActorDetails;
using FilmoSearch.Persistance;
using FilmoSearch.Tests.Common;
using Shouldly; 
using Xunit;

namespace FilmoSearch.Tests.Actors.Queries
{
    [Collection("QueryCollection")]
    public class GetActorDetailsQueryHandlerTests
    {
        private readonly FilmoSearchDbContext Context;
        private readonly IMapper Mapper;

        public GetActorDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetActorDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetActorDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetActorDetailsQuery
                { 
                    Id = 3
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<ActorDetailsVm>();
            result.FirstNane.ShouldBe("Foo");
            result.LastName.ShouldBe("Bar");
        }
    }
}
