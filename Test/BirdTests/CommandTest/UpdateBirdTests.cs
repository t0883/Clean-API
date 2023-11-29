using Application.Commands.Birds.UpdateBird;
using Application.Dtos;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class UpdateBirdTests
    {
        private UpdateBirdByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new UpdateBirdByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_Update_Correct_Bird_By_Id()
        {
            //Arrange
            var birdId = new Guid("12345678-1234-5678-1234-567812345603");

            var birdName = "Gunnar";

            var dto = new BirdDto();

            dto.Name = birdName;

            dto.CanFly = false;

            var command = new UpdateBirdByIdCommand(dto, birdId);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result.Name, Is.EqualTo(birdName));
            Assert.That(result.CanFly, Is.False);
        }
    }
}
