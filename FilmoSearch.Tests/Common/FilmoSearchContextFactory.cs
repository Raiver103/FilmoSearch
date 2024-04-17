using FilmoSearch.Domain;
using FilmoSearch.Persistance;
using Microsoft.EntityFrameworkCore; 

namespace FilmoSearch.Tests.Common
{
    internal class FilmoSearchContextFactory
    { 
        public static int ActorIdForDelete = 1;
        public static int ActorIdForUpdate = 2;

        public static int FilmIdForDelete = 1;
        public static int FilmIdForUpdate = 2;

        public static int ReviewIdForDelete = 1;
        public static int ReviewIdForUpdate = 2; 
         
        public static FilmoSearchDbContext Create()
        {
            var options = new DbContextOptionsBuilder<FilmoSearchDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new FilmoSearchDbContext(options);
            context.Database.EnsureCreated();
             
            context.Actors.AddRange(
                new Actor
                { 
                    Id = 3, 
                    FirstName = "Foo",
                    LastName = "Bar", 
                },
                new Actor
                { 
                    Id = 4,
                    FirstName = "Ben",
                    LastName = "Wach",
                },
                new Actor
                { 
                    Id = ActorIdForDelete, 
                    FirstName= "Freddy",
                    LastName= "Mercury",
                },
                new Actor
                { 
                    Id = ActorIdForUpdate,
                    FirstName = "Ivan",
                    LastName = "Rudskoy"
                }
            );

            context.Films.AddRange(
                new Film
                {
                    Id = 3,
                    Title = "Brother 1", 
                },
                new Film
                {
                    Id = 4,
                    Title = "Brother 2",

                },
                new Film
                {
                    Id = ActorIdForDelete,
                    Title = "Puss in boots",
                },
                new Film
                {
                    Id = ActorIdForUpdate,
                    Title = "Interstellar",
                    
                }
            );

            context.Reviews.AddRange(
                new Review
                {
                    Id = 3,
                    Title = "Title3",
                    Description = "Description3",
                    Stars = 1,
                    FilmId = 1,
                },
                new Review
                {
                    Id = 4,
                    Title = "Title4",
                    Description = "Description4",
                    Stars = 1,
                    FilmId = 1
                },
                new Review
                {
                    Id = ActorIdForDelete,
                    Title = "Title1",
                    Description = "Description1",
                    Stars = 1,
                    FilmId = 1

                },
                new Review
                {
                    Id = ActorIdForUpdate,
                    Title = "Title2",
                    Description = "Description2",
                    Stars = 1,
                    FilmId = 1
                }
            ); 

            context.SaveChanges(); 

            var film = context.Films.FirstOrDefault(film =>
            film.Title == "Interstellar");
            var actor = context.Actors.FirstOrDefault(Actor =>
            Actor.FirstName == "Ivan");

            var actorFilm = new FilmoSearch.Domain.ActorFilm
            {
                ActorId = actor.Id,
                FilmId = film.Id,
                Actor = actor,
                Film = film,
            };
            context.ActorFilm.Add(actorFilm);

            context.SaveChanges();
            return context;
        }

        public static void Destroy(FilmoSearchDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
