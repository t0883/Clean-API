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

            var catRepository = A.Fake<ICatRepository>();

            var handler = new AddCatCommandHandler(catRepository);

            A.CallTo(() => catRepository.AddCat(cat)).Returns(cat);

            var catName = "Herman";

            var dto = new CatDto();

            dto.Name = catName;

            var command = new AddCatCommand(dto);

            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name.Equals("Herman"));
            Assert.That(result, Is.TypeOf<Cat>());
        }
    }
}
