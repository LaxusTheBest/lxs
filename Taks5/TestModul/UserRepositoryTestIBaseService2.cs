using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager;

namespace TestModul
{
    [TestClass]
    public class UserRepositoryTestIBaseService2
    {
        [TestMethod]
        public void GetExistedUserID()
        {
            User user = UserRepository.array.FirstOrDefault();
            int userID = user.ID;

            User user2 = new UserRepository().Get(userID);

            Assert.AreEqual(user, user2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetNotExistUserID()
        {
            UserRepository userRepo = new UserRepository();
            int NotExistedID = UserRepository.array.Max(p => p.ID) + 1;

            userRepo.Get(NotExistedID);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetWithoutID()
        {
            UserRepository repository = new UserRepository();

            repository.Get();
        }

        [TestMethod]
        public void GetAll()
        {
            bool equals = true;
            UserRepository repository = new UserRepository();
            List<User> GetUsers = repository.GetAll();

            Assert.AreEqual(GetUsers.Count, UserRepository.array.Count);

            foreach (var item in GetUsers)
            {
                if (!UserRepository.array.Contains(item)) equals = false;
            }

            Assert.IsTrue(equals);
        }

        [TestMethod]
        public void SaveUser()
        {
            UserRepository repository = new UserRepository();

            Assert.IsTrue(repository.Save(new User()));
        }

        [TestMethod]
        public void SaveNullReference()
        {
            UserRepository repository = new UserRepository();

            Assert.IsFalse(repository.Save(null));
        }

    }
}
