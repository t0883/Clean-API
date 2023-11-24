using Application.Commands.Dogs.DeleteDog;
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
    public class DeleteDog
    {
        private DeleteDogByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new DeleteDogByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_Delete_Correct_Dog_By_Id()
        {
            // Arrange
            var dogId = new Guid("12345678-1234-5678-1234-567812345678");

            var command = new DeleteDogByIdCommand(dogId);

            // Act

            var result = await _handler.Handle(command, CancellationToken.None);


            // Assert

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task Handle_Delete_Incorrect_Id()
        {
            // Arrange
            var dogId = new Guid();

            var command = new DeleteDogByIdCommand(dogId);

            // Act

            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert

            Assert.That(result, Is.Null);
        }
    }
}
