using Application.Commands.Birds.AddBird;
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
    public class AddBirdTests
    {
        private AddBirdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new AddBirdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_Add_Bird_To_MockDatabase()
        {
            //Arrange
            var birdName = "Tage";

            var dto = new BirdDto();

            dto.Name = birdName;

            dto.CanFly = false;

            var command = new AddBirdCommand(dto);

            //Act 
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
