using FilmoSearch.Application.Interfaces;
using FilmoSearch.Domain;
using MediatR; 

namespace FilmoSearch.Application.Actors.Commands.CreateActor
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, int>
    {
        private readonly IFilmoSearchDbContext _dbContext;

        public CreateActorCommandHandler(IFilmoSearchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var actor = new Actor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,   
            }; 
              
            await _dbContext.Actors.AddAsync(actor, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return actor.Id;
        }
    }
}
