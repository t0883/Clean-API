using Application.Commands.Cats.DeleteCat;
using Domain.Models;
using FakeItEasy;
using Infrastructure.Repositories.Cats;
namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class DeleteCatTests
    {


        [Test]
        public async Task Handle_Delete_Incorrect_Id()
        {

            //Arrange

            var cat = new Cat
            {
                Name = "Hans",
                AnimalId = Guid.NewGuid()
            };

            var catRepository = A.Fake<ICatRepository>();

            var handler = new DeleteCatByIdCommandHandler(catRepository);

            A.CallTo(() => catRepository.DeleteCatById(cat.AnimalId)).Returns(cat);


            var command = new DeleteCatByIdCommand(cat.AnimalId);

            //Act

            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name.Equals("Hans"));
            Assert.That(result, Is.TypeOf<Cat>());
            Assert.That(result.AnimalId.Equals(cat.AnimalId));
        }
    }
}
