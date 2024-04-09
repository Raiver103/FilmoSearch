using FilmoSearch.Application.Films.Commands.CreateFilm;
using FilmoSearch.Tests.Common;
using Microsoft.EntityFrameworkCore; 
using Xunit;

namespace FilmoSearch.Tests.Films.Commands
{
    public class CreateFilmoCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateFilmCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateFilmCommandHandler(Context);
            var filmTitle = "film Title"; 

            // Act
            var filmId = await handler.Handle(
                new CreateFilmCommand
                {
                    Title = filmTitle,
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Films.SingleOrDefaultAsync(film =>
                    film.Id == filmId && film.Title == filmTitle));
        }
    }
}
