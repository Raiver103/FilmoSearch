using FilmoSearch.Application.Actors.Commands.CreateActor;
using FilmoSearch.Tests.Common;
using Microsoft.EntityFrameworkCore; 
using Xunit;

namespace FilmoSearch.Tests.Actors.Commands
{
    public class CreateActorCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateActorCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateActorCommandHandler(Context);
            var actorFirstName = "actor name";
            var actorLastName = "actor details";

            // Act
            var actorId = await handler.Handle(
                new CreateActorCommand
                {
                    FirstName = actorFirstName,
                    LastName = actorLastName,
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Actors.SingleOrDefaultAsync(actor =>
                    actor.Id == actorId && actor.FirstName == actorFirstName &&
                    actor.LastName == actorLastName));
        }
    }
}
