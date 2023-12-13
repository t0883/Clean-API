using API.Controllers.BirdsController;
using Application.Validators;
using Application.Validators.Bird;
using FakeItEasy;
using MediatR;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetBirdByIdTests
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
        public async Task Controller_Get_Bird_By_Id()
        {
            //Arrange
            var birdId = new Guid("12345678-1234-5678-1234-567812345603");


            //Act
            var result = await _controller.GetBirdById(birdId);

            //Assert
            Assert.NotNull(result);
        }


    }
}
