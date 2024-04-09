using FilmoSearch.Application.Actors.Commands.DeleteActor;
using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Tests.Common; 
using Xunit;

namespace FilmoSearch.Tests.Actors.Commands
{
    public class DeleteActorCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteActorCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteActorCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteActorCommand
            {
                Id = FilmoSearchContextFactory.ActorIdForDelete,  
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Actors.SingleOrDefault(actor =>
                actor.Id == FilmoSearchContextFactory.ActorIdForDelete));
        }

        [Fact]
        public async Task DeleteActorCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteActorCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteActorCommand
                    {
                        Id = 52, 
                    },
                    CancellationToken.None));
        } 
    }
}
