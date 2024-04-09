using FilmoSearch.Application.Actors.Commands.UpdateActor;
using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Tests.Common;
using Microsoft.EntityFrameworkCore; 
using Xunit;

namespace FilmoSearch.Tests.Actors.Commands
{
    public class UpdateActorCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateActorCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateActorCommandHandler(Context);
            var updatedFirstName = "new FirstName";
            var updatedLastName = "new LastName";

            // Act
            await handler.Handle(new UpdateActorCommand
            {
                Id = FilmoSearchContextFactory.ActorIdForUpdate,  
                FirstName = updatedFirstName,
                LastName = updatedLastName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Actors.SingleOrDefaultAsync(actor =>
                actor.Id == FilmoSearchContextFactory.ActorIdForUpdate &&
                actor.FirstName == updatedFirstName && actor.LastName == updatedLastName));
        }

        [Fact]
        public async Task UpdateActorCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateActorCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateActorCommand
                    {
                        Id = 52, 
                    },
                    CancellationToken.None));
        }
    }
}
