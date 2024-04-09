using FluentValidation; 

namespace FilmoSearch.Application.Actors.Queries.GetActorDetails
{
    public class GetActorDetailsQueryValidator : AbstractValidator<GetActorDetailsQuery>
    {
        public GetActorDetailsQueryValidator()
        { 
            RuleFor(actor => actor.Id).NotEmpty(); 
        }
    }
}
