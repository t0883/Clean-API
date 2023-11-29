using Application.Commands.Birds.DeleteBird;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class DeleteBirdTests
    {
        private DeleteBirdByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteBirdByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_Delete_Correct_Bird_By_Id()
        {
            //Arrange
            var birdId = new Guid("12345678-1234-5678-1234-567812345604");

            var command = new DeleteBirdByIdCommand(birdId);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public async Task Handle_Delete_Incorrect_Id()
        {
            //Arrange
            var birdId = Guid.NewGuid();

            var command = new DeleteBirdByIdCommand(birdId);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //
            Assert.That(result, Is.Null);
        }
    }
}
