using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc; 
using Xunit;
using FilmoSearchT.Dto;
using FilmoSearchT.Controllers;
using FilmoSearch.WebApi.Core.Domain.Models;
using FilmoSearch.WebApi.Core.Application.Interfaces;

namespace FilmoSearchT.Tests.Controllers
{
    public class ActorControllerTests
    { 
        private readonly IActorRepository actorRepository;
        private readonly IMapper mapper;

        public ActorControllerTests()
        {
            actorRepository = A.Fake<IActorRepository>();
            mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void ActorController_GetActors_ReturnOK()
        {
            //Arrange
            var actors = A.Fake<ICollection<ActorDto>>();
            var actorList = A.Fake<List<ActorDto>>();
            A.CallTo(() => mapper.Map<List<ActorDto>>(actors)).Returns(actorList);
            var controller = new ActorController(actorRepository, mapper);

            //Act
            var result = controller.GetActors();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ActorController_CreatePokemonActor_ReturnOK()
        {
            //Arrange
            var actorMap = A.Fake<Actor>();
            var actor = A.Fake<Actor>();

            var actorCreate = A.Fake<ActorDto>();
            var actors = A.Fake<ICollection<ActorDto>>();
            var actorList = A.Fake<IList<ActorDto>>();

            A.CallTo(() => actorRepository.GetActor(actorCreate.Id)).Returns(actor);
            A.CallTo(() => mapper.Map<Actor>(actorCreate)).Returns(actor);
            A.CallTo(() => actorRepository.CreateActor(actorMap)).Returns(true);

            var controller = new ActorController(actorRepository, mapper);

            //Act
            var result = controller.CreateActor(actorCreate);

            //Assert
            result.Should().NotBeNull();
        }
    }
}
