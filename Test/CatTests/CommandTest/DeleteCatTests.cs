using Application.Commands.Cats.DeleteCat;
using Infrastructure.Database;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class DeleteCatTests
    {
        private DeleteCatByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new DeleteCatByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_Delete_Correct_Cat_By_Id()
        {
            //Arrange
            var catId = new Guid("12345678-1234-5678-1234-567812345602");

            var command = new DeleteCatByIdCommand(catId);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task Handle_Delete_Incorrect_Id()
        {
            //Arrange
            var catId = Guid.NewGuid();

            var command = new DeleteCatByIdCommand(catId);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert 
            Assert.That(result, Is.Null);
        }
    }
}
