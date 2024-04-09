using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Application.Films.Commands.DeleteFilm;
using FilmoSearch.Tests.Common; 
using Xunit;

namespace FilmoSearch.Tests.Films.Commands
{
    public class DeleteFilmCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteFilmCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteFilmCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteFilmCommand
            {
                Id = FilmoSearchContextFactory.ActorIdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Films.SingleOrDefault(film =>
                film.Id == FilmoSearchContextFactory.FilmIdForDelete));
        }

        [Fact]
        public async Task DeleteFilmCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteFilmCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteFilmCommand
                    {
                        Id = 52,
                    },
                    CancellationToken.None));
        }
    }
}
