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
    public class UserRepositoryTestIBaseService
    {
        [TestMethod]
        public void GetExistedUserID()
        {
            User user = UserRepository.array.FirstOrDefault();
            int userID = user.ID;

            User user2 = new UserRepository().Get<User>(userID);

            Assert.AreEqual(user, user2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetNotExistUserID()
        {
            UserRepository userRepo = new UserRepository();
            int NotExistedID = UserRepository.array.Max(p => p.ID) + 1;

            userRepo.Get<User>(NotExistedID);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetWithoutID()
        {
            UserRepository repository = new UserRepository();

            repository.Get<User>();
        }

        [TestMethod]
        public void GetAll()
        {
            bool equals = true;
            UserRepository repository = new UserRepository();
            List<User> GetUsers = repository.GetAll<User>();

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
        public void SaveNotUser()
        {
            UserRepository repository = new UserRepository();

            Assert.IsFalse(repository.Save(new File()));
        }

        [TestMethod]
        public void SaveNullReference()
        {
            UserRepository repository = new UserRepository();

            Assert.IsFalse(repository.Save<User>(null));
        }

        [TestMethod]
        public void DeleteExistedUserID()
        {
            UserRepository repository = new UserRepository();
            bool deleted = true;

            int UserID = UserRepository.array.FirstOrDefault().ID;

            Assert.IsTrue(repository.Delete(UserID));

            foreach (var item in UserRepository.array)
            {
                if (item.ID == UserID) deleted = false;
            }

            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void DeleteNotExistedUserID()
        {
            UserRepository repository = new UserRepository();
            int UserID = UserRepository.array.Max(p => p.ID) + 1;

            Assert.IsFalse(repository.Delete(UserID));

        }

        [TestMethod]
        public void DeleteWithoutID()
        {
            UserRepository repository = new UserRepository();

            Assert.IsFalse(repository.Delete());
        }

    }
}
