namespace Test.UserTests.CommandTest
{
    /*
    [TestFixture]
    public class AddUserTests
    {
        private AddUserCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new AddUserCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_Add_User_To_MockDatabase()
        {
            //Arrange
            var username = "Bert";
            var password = "password";
            var role = "admin";

            var dto = new UserDto
            {
                UserName = username,
                Password = password
            };

            var command = new AddUserCommand(dto);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);

        }

    }
    */
}
