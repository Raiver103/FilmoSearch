using FilmoSearch.Application.Common.Exceptions;
using FilmoSearch.Application.Interfaces;
using FilmoSearch.Domain;
using MediatR; 

namespace FilmoSearch.Application.Actors.Commands.DeleteActor
{
    public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand, int>
    {
        private readonly IFilmoSearchDbContext _dbContext;

        public DeleteActorCommandHandler(IFilmoSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Actors
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Actor), request.Id);
            }

            _dbContext.Actors.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
