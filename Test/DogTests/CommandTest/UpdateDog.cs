using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class UpdateDog
    {
        private UpdateDogByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new UpdateDogByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_Update_Correct_Dog()
        {
            // Arrange
            var dogId = new Guid("12345678-1234-5678-1234-567812345678");

            var dogName = "Göran";

            var dto = new DogDto();

            dto.Name = dogName;

            var command = new UpdateDogByIdCommand(dto, dogId);

            // Act

            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.Name, Is.EqualTo(dogName));

        }


    }
}
