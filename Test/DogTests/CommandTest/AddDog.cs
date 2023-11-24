using Application.Commands.Dogs;
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
    public class AddDog
    {
        private AddDogCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new AddDogCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_Add_Dog_To_MockDatabase()
        {
            // Arrange
            var dogName = "Stefan";

            var dto = new DogDto();

            dto.Name = dogName;

            var command = new AddDogCommand(dto);

            // Act 

            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert

            Assert.IsNotNull(result);
        }
    }
}
