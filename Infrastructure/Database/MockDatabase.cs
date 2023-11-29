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
            new Cat { Id = Guid.NewGuid(), Name = "Morris", LikesToPlay = true },
            new Cat { Id = Guid.NewGuid(), Name = "Pelle", LikesToPlay = true},
            new Cat { Id = Guid.NewGuid(), Name = "Sillen", LikesToPlay = true},
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345601"), Name = "TestCatForUnitTests", LikesToPlay = true },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345602"), Name = "AnotherTestCatForUnitTests", LikesToPlay = false }
        };

        public List<Bird> Birds
        {
            get { return allBirds; }
            set { allBirds = value; }
        }

        private static List<Bird> allBirds = new()
        {
            new Bird { Id = Guid.NewGuid(), Name = "Pappe", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Flappe", CanFly = true },
            new Bird { Id = Guid.NewGuid(), Name = "Crazze", CanFly = false },
            new Bird { Id = Guid.NewGuid(), Name = "Gurka", CanFly = true },
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345603"), Name = "TestBirdForUnitTests", CanFly = true },
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345604"), Name = "AnotherTestBirdForUnitTests", CanFly = false }
        };

        public List<User> Users
        {
            get { return allUsers; }
            set { allUsers = value; }
        }

        private static List<User> allUsers = new()
        {
            new User { Id = new Guid("08260479-52a0-4c0e-a588-274101a2c3be"), Username = "Tobias", Password = "123password", Authorized = true, Role = "Admin" },
            new User { Id = new Guid("047425eb-15a5-4310-9d25-e281ab036868"), Username = "NotAnAdmin", Password = "123password", Authorized = false, Role = "User"}
        };

    }
}
