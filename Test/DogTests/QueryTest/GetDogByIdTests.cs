using Domain.Models;
using Infrastructure.Database.SqlServer;
using Infrastructure.Repositories.Dogs;
using Moq;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetDogByIdTests
    {
        private DogRepository _dogRepository;
        private Mock<SqlDatabase> _mockSqlDatabase = new Mock<SqlDatabase>();

        [SetUp]
        public void SetUp()
        {
            _mockSqlDatabase.Setup(db => db.Dogs.FirstOrDefault()).Returns(new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "Pär" });
            _dogRepository = new DogRepository(_mockSqlDatabase.Object);
        }

        [Test]
        public async Task Get_Dog_By_Id()
        {
            //Arrange 
            var dogId = new Guid("12345678-1234-5678-1234-567812345678");

            //Act
            var result = await _dogRepository.GetDogById(dogId);

            //Assert
            Assert.That(dogId, Is.EqualTo(result.Id));
        }

    }
}
