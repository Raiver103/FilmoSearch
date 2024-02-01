using FilmoSearch.WebApi.Core.Application.Repositories;
using FilmoSearch.WebApi.Core.Domain.Models;
using FilmoSearch.WebApi.Persistence;
using FluentAssertions;
using Microsoft.EntityFrameworkCore; 
using Xunit;

namespace FilmoSearchT.Tests.Repositories
{
    public class ActorRepositoryTests
    {
        private async Task<FilmoSearchDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<FilmoSearchDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new FilmoSearchDbContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Actors.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Actors.Add(
                    new Actor()
                    {
                        FirstName = "FirstName",
                        LastName = "LastName",
                        Films = new List<Film>()
                        {
                            new Film {
                                Title = "Title",
                                Reviews = new List<Review>
                                {
                                    new Review { Description = "Description", Title = "Title", Stars = 2 }
                                },
                            }
                        }
                    });
                
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }


        [Fact]
        public async void ActorRepository_GetActor_ReturnActor()
        {
            //Arrange
            var id = 1; 
            var dbContext = await GetDbContext();
            var pokemonRepository = new ActorRepository(dbContext);

            //Act
            var result = pokemonRepository.GetActor(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Actor>();
        }
    }
}
