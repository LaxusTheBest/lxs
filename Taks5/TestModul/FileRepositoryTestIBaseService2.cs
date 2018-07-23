using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestModul
{
    [TestClass]
    public class FileRepositoryTestIBaseService2
    {
        [TestMethod]
        public void GetExistedFileID()
        {
            File file = FileRepository.array.FirstOrDefault();
            int FileID = file.ID;

            File file2 = new FileRepository().Get(FileID);

            Assert.AreEqual(file, file2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetNotExistFileID()
        {
            FileRepository fileRepo = new FileRepository();
            int NotExistedID = FileRepository.array.Max(p => p.ID) + 1;

            fileRepo.Get(NotExistedID);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void GetWithoutID()
        {
            FileRepository repository = new FileRepository();

            repository.Get();
        }

        [TestMethod]
        public void GetAll()
        {
            bool equals = true;
            FileRepository repository = new FileRepository();
            List<File> GetFiles = repository.GetAll();

            Assert.AreEqual(GetFiles.Count, FileRepository.array.Count);
            foreach (var item in GetFiles)
            {
                if (!FileRepository.array.Contains(item)) equals = false;
            }

            Assert.IsTrue(equals);
        }

        [TestMethod]
        public void SaveFile()
        {
            FileRepository repository = new FileRepository();

            Assert.IsTrue(repository.Save(new File()));
        }

        [TestMethod]
        public void SaveNullReference()
        {
            FileRepository repository = new FileRepository();

            Assert.IsFalse(repository.Save<File>(null));
        }

    }
}
