using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Application.Films.Commands.UpdateFilm;
using FilmoSearch.Tests.Common;
using Microsoft.EntityFrameworkCore; 
using Xunit;

namespace FilmoSearch.Tests.Films.Commands
{
    public class UpdateFilmCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateFilmCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateFilmCommandHandler(Context);
            var updatedTitle = "new Title"; 

            // Act
            await handler.Handle(new UpdateFilmCommand
            {
                Id = FilmoSearchContextFactory.FilmIdForUpdate, 
                Title = updatedTitle,
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Films.SingleOrDefaultAsync(actor =>
                actor.Id == FilmoSearchContextFactory.ActorIdForUpdate &&
                actor.Title == updatedTitle));
        }

        [Fact]
        public async Task UpdateFilmCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateFilmCommandHandler(Context);

            // Act

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateFilmCommand
                    {
                        Id = 52,
                    },
                    CancellationToken.None));
        }
    }
}
