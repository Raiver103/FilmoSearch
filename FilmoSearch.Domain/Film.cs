namespace FilmoSearch.Domain
{
    public class Film 
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<ActorFilm> ActorFilms { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
