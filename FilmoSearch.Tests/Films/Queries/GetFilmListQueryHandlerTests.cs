using AutoMapper;
using FilmoSearch.Application.Actors.Queries.GetActorList;
using FilmoSearch.Application.Films.Queries.GetFilmList;
using FilmoSearch.Persistance;
using FilmoSearch.Tests.Common;
using Shouldly; 
using Xunit;

namespace FilmoSearch.Tests.Films.Queries
{
    [Collection("QueryCollection")]
    public class GetFilmListQueryHandlerTests : TestCommandBase
    {
        private readonly FilmoSearchDbContext Context;
        private readonly IMapper Mapper;

        public GetFilmListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetFilmListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetFilmListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetFilmListQuery
                {
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<FilmListVm>();
            result.Films.Count.ShouldBe(4);
        }
    }
} 