using API.Controllers.DogsController;
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
            // Initialize the handler and mock database before each test
            _mediator = A.Fake<IMediator>();
            _guidValidator = new GuidValidator();
            _dogValidator = new DogValidator();
            _controller = new DogsController(_mediator, _dogValidator, _guidValidator);

        }
        [Test]
        public async Task Add_Dog_Controller()
        {
            //Arrange
            //A.CallTo(() => _mediator.Send(A<Dog>._, A<CancellationToken>._)).Returns(true);
            var dto = new DogDto { Name = "B" };

            //Act
            var result = await _controller.AddDog(dto);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
