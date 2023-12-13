using API.Controllers.BirdsController;
using Application.Dtos;
using Application.Validators;
using Application.Validators.Bird;
using FakeItEasy;
using MediatR;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class AddBirdTests
    {
        private BirdsController _controller;
        private IMediator _mediator;
        private GuidValidator _guidValidator;
        private BirdValidator _birdValidator;

        [SetUp]
        public void SetUp()
        {
            _mediator = A.Fake<IMediator>();
            _guidValidator = new GuidValidator();
            _birdValidator = new BirdValidator();
            _controller = new BirdsController(_mediator, _birdValidator, _guidValidator);
        }

        [Test]
        public async Task Handle_Add_Bird_To_MockDatabase()
        {
            //Arrange
            var birdName = "Tage";

            var dto = new BirdDto();

            dto.Name = birdName;

            dto.CanFly = false;

            //Act 
            var result = await _controller.AddBird(dto);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
