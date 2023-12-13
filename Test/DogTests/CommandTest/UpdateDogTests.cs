using API.Controllers.DogsController;
using Application.Dtos;
using Application.Validators;
using Application.Validators.Dog;
using FakeItEasy;
using MediatR;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class UpdateDogTests
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
        public async Task Controller_Update_Correct_Dog_By_Id()
        {
            // Arrange
            var dogId = new Guid("12345678-1234-5678-1234-567812345678");

            var dogName = "Hasse";

            var dto = new DogDto();

            dto.Name = dogName;

            // Act

            var result = await _controller.UpdateDog(dto, dogId);

            // Assert
            Assert.That(result, Is.Not.Null);

        }


    }
}
