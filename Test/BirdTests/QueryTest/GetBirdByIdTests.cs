using Application.Queries.Birds.GetById;
using Application.Queries.Cats.GetById;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetBirdByIdTests
    {
        private GetBirdByIdQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetBirdByIdQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_ValidId_ReturnCorrectBird()
        {
            //Arrange
            var birdId = new Guid("12345678-1234-5678-1234-567812345603");

            var query = new GetBirdByIdQuery(birdId);

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(birdId));
        }
        [Test]
        public async Task Handle_InvalidId_ReturnNull()
        {
            //Arrange
            var invalidBirdId = Guid.NewGuid();

            var query = new GetBirdByIdQuery(invalidBirdId);

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.IsNull(result);
        }

    }
}
