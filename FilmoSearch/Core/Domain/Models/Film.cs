using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace FilmoSearch.WebApi.Core.Domain.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Actor> Actors { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
