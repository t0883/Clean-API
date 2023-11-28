using Domain.Models;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> Dogs
        {
            get { return allDogs; }
            set { allDogs = value; }
        }

        private static List<Dog> allDogs = new()
        {
            new Dog { Id = Guid.NewGuid(), Name = "Björn"},
            new Dog { Id = Guid.NewGuid(), Name = "Patrik"},
            new Dog { Id = Guid.NewGuid(), Name = "Alfred"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345679"), Name = "AnotherTestDogForUnitTests"}
        };

        public List<Cat> Cats
        {
            get { return allCats; }
            set { allCats = value; }
        }

        private static List<Cat> allCats = new()
        {
            new Cat { Id = Guid.NewGuid(), Name = "Morris" },
            new Cat { Id = Guid.NewGuid(), Name = "Pelle" },
            new Cat { Id = Guid.NewGuid(), Name = "Sillen" },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345601"), Name = "TestCatForUnitTests" },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345602"), Name = "AnotherTestCatForUnitTests" }
        };

        public List<User> Users
        {
            get { return allUsers; }
            set { allUsers = value; }
        }

        private static List<User> allUsers = new()
        {
            new User { Id = Guid.NewGuid(), Username = "Admin", Password = "123password", Authorized = true},
            new User { Id = Guid.NewGuid(), Username = "NotAnAdmin", Password = "123password", Authorized = false}
        };

    }
}
