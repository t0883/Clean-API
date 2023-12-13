using API.Controllers.DogsController;
using Application.Commands.Dogs;
using Application.Dtos;
using Application.Validators;
using Application.Validators.Dog;
using FakeItEasy;
using MediatR;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class AddDogTests
    {
        private DogsController _controller;
        private IMediator _mediator;
        private GuidValidator _guidValidator;
        private DogValidator _dogValidator;

        [SetUp]
        public void SetUp()
        {
            _mediator = A.Fake<IMediator>();
            _guidValidator = new GuidValidator();
            _dogValidator = new DogValidator();
            _controller = new DogsController(_mediator, _dogValidator, _guidValidator);
        }

        [Test]
        public async Task Controller_Add_Dog()
        {
            // Arrange
            var dogName = "Stefan";

            var dto = new DogDto();

            dto.Name = dogName;

            var command = new AddDogCommand(dto);

            // Act 

            var result = await _controller.AddDog(dto);

            // Assert

            Assert.IsNotNull(result);
        }
    }
}
