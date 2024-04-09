using AutoMapper; 
using FilmoSearch.Application.Films.Queries.GetFilmDetails;
using FilmoSearch.Persistance;
using FilmoSearch.Tests.Common;
using Shouldly; 
using Xunit;

namespace FilmoSearch.Tests.Films.Queries
{
    [Collection("QueryCollection")]
    public class GetFilmDetailsQueryHandlerTests : TestCommandBase
    {
        private readonly FilmoSearchDbContext Context;
        private readonly IMapper Mapper;

        public GetFilmDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetFilmDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetFilmDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetFilmDetailsQuery
                {
                    Id = 3
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<FilmDetailsVm>();
            result.Title.ShouldBe("Brother 1"); 
        }
    }
}
