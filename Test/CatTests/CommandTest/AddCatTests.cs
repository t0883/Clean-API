using Application.Commands.Cats.AddCat;
using Application.Dtos;
using Domain.Models;
using FakeItEasy;
using Infrastructure.Repositories.Cats;
namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class AddCatTests
    {
        [Test]
        public async Task Handle_Add_Cat_To_Database()
        {
            //Arrange
            var cat = new Cat { Name = "Herman" };
            var requestGuid = Guid.NewGuid();

            var catRepository = A.Fake<ICatRepository>();

            var handler = new AddCatCommandHandler(catRepository);

            A.CallTo(() => catRepository.AddCat(cat, requestGuid)).Returns(cat);

            var catName = "Herman";

            var dto = new CatDto();

            dto.Name = catName;
            dto.Breed = "Huskatt";
            dto.Weight = 1;

            var command = new AddCatCommand(dto, requestGuid);

            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name.Equals("Herman"));
            Assert.That(result, Is.TypeOf<Cat>());
        }
    }
}
