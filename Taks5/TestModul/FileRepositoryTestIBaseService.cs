using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using FileManager;
using System.Collections.Generic;

namespace TestModul
{
    [TestClass]
    public class FileRepositoryTestIBaseService
    {
        [TestMethod]
        public void GetExistedFileID()
        {
            File file = FileRepository.array.FirstOrDefault();
            int FileID = file.ID;

            File file2 = new FileRepository().Get<File>(FileID);

            Assert.AreEqual(file, file2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetNotExistFileID()
        {
            FileRepository fileRepo = new FileRepository();
            int NotExistedID = FileRepository.array.Max(p => p.ID)+1;

            fileRepo.Get<File>(NotExistedID);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetWithoutID()
        {
            FileRepository repository = new FileRepository();

            repository.Get<File>();
        }

        [TestMethod]
        public void GetAll()
        {
            bool equals = true;
            FileRepository repository = new FileRepository();
            List<File> GetFiles = repository.GetAll<File>();

            Assert.AreEqual(GetFiles.Count, FileRepository.array.Count);
            foreach (var item in GetFiles)
            {
                if (!FileRepository.array.Contains(item)) equals=false;
            }

            Assert.IsTrue(equals);
        }

        [TestMethod]
        public void SaveFile()
        {
            FileRepository repository = new FileRepository();

            Assert.IsTrue(repository.Save<File>(new File()));
        }
       
        [TestMethod]
        public void SaveNotFile()
        {
            FileRepository repository = new FileRepository();

            Assert.IsFalse(repository.Save<User>(new User()));
        }

        [TestMethod]
        public void SaveNullReference()
        {
            FileRepository repository = new FileRepository();

            Assert.IsFalse(repository.Save<File>(null));
        }

        [TestMethod]
        public void DeleteExistedFileID()
        {
            FileRepository repository = new FileRepository();
            bool deleted = true;

            int fileID = FileRepository.array.FirstOrDefault().ID;

            Assert.IsTrue(repository.Delete(fileID));

            foreach (var item in FileRepository.array)
            {
                if (item.ID == fileID) deleted = false;
            }

            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void DeleteNotExistedFileID()
        {
            FileRepository repository = new FileRepository();
            int fileID = FileRepository.array.Max(p => p.ID) + 1;
            
            Assert.IsFalse(repository.Delete(fileID));

        }

        [TestMethod]
        public void DeleteWithoutID()
        {
            FileRepository repository = new FileRepository();

            Assert.IsFalse(repository.Delete());
        }
    }
}
