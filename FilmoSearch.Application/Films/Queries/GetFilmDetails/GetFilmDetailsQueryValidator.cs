using FluentValidation; 

namespace FilmoSearch.Application.Films.Queries.GetFilmDetails
{
    public class GetFilmDetailsQueryValidator : AbstractValidator<GetFilmDetailsQuery>
    {
        public GetFilmDetailsQueryValidator()
        {
            RuleFor(film => film.Id).NotEmpty();
        }
    }
}
