using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileManager
{
    public class FileRepository : IBaseService2<File>, IBaseService
    {
        private const int Default = 0;

        private static Permission[] UserPermissions = new Permission[]
        {
           new Permission()
           {
               Key = "Add new file",
               Method = new Action<File>(AddNewFile)
           },
           new Permission(){ Key="Remove File", Method = new Action<File[]>(RemoveFiles) },
           new Permission() {Key = "Get file by id" , Method = new Func<int,File>(GetFile) },
           new Permission() {Key = "Get file by link", Method = new Func<string,File>(GetFile)},
           new Permission() {Key = "My files", Method = new Func<User,IEnumerable<File>>(GetFiles) },
           new Permission() {Key = "My private files", Method = new Func<User,IEnumerable<File>>(GetPrivateFiles)},
           new Permission() {Key = "My public files", Method = new Func<User,IEnumerable<File>>(GetPrivateFiles)},
        };
        private static Permission[] AdminPermissons = new Permission[]
        {
           new Permission() {Key = "Add new file",Method = new Action<File>(AddNewFile)},
           new Permission() {Key= "Remove File", Method = new Action<File[]>(RemoveFiles) },
           new Permission() {Key = "Get file by id" , Method = new Func<int,File>(GetFile) },
           new Permission() {Key = "Get file by link", Method = new Func<string,File>(GetFile)},
           new Permission() {Key = "My files", Method = new Func<User,IEnumerable<File>>(GetFiles) },
           new Permission() {Key = "My private files", Method = new Func<User,IEnumerable<File>>(GetPrivateFiles)},
           new Permission() {Key = "My public files", Method = new Func<User,IEnumerable<File>>(GetPrivateFiles)},
           new Permission() {Key = "User's files", Method= new Func<User,IEnumerable<File>>(GetFiles)},
           new Permission() {Key = "All public files", Method = new Func<IEnumerable<File>>(GetAllPubFiles)},
           new Permission() {Key="All private files", Method = new Func<IEnumerable<File>>(GetAllPrivateFiles)},
        };

        public Permission[] PermissionList;

        public FileRepository(string premission)
        {
            if (premission == User.Permissions) { PermissionList = UserPermissions; }
            if (premission == Admin.Permissions) { PermissionList = UserPermissions; }
        }
        public FileRepository() { }

        public static List<File> array = new List<File>()
        {
            new File(){ID=1},
            new File(){ID=2},
            new File(){ID=3},
            new File(){ID=4},
            new File(){ID=5},
            new File(){ID=6},
            new File(){ID=7},
            new File(){ID=8},
            new File(){ID=9}
        };

        public static List<File> EmptyArray = new List<File>();

        #region
        public static IEnumerable<File> GetAllFiles() => null;
        public static IEnumerable<File> GetFiles(User user) => null;
        public static void RemoveFiles(params File[] Files) { }
        public static void AddNewFile(File file) { }
        public static File GetFile(int id) => null;
        public static File GetFile(string link) => null;
        public static IEnumerable<File> GetPubFiles(User user) => null;
        public static IEnumerable<File> GetAllPubFiles() => null;
        public static IEnumerable<File> GetPrivateFiles(User user) => null;
        public static IEnumerable<File> GetAllPrivateFiles() => null;
        #endregion


        // IBaseService methods
        #region
        public T Get<T>(int id = Default) where T : class, new()
        {

            foreach (File item in array)
            {
                if (item.ID == id)
                {
                    return item as T;
                }
            }

            throw new NotImplementedException("Не удалось найти файл.");
        }

        public List<T> GetAll<T>() where T : class, new()
        {
            List<T> res = new List<T>();
            foreach (File item in array)
            {
                res.Add(item as T);
            }

            return res;

            throw new NotImplementedException("Не удалось получить список файлов.");

        }

        public bool Save<T>(T entity)
        {
            try
            {
                if (entity == null) return false;
                if (typeof(T) == typeof(File))
                {
                    array.Add(entity as File);

                    return true;
                }
                else return false;
            }
            catch (FormatException)
            {
                return false;
            }

        }
        
        public bool Delete(int id = Default)
        {
            for (int i = 0; i < array.Count - 1; i++)
            {
                if (array[i].ID == id)
                {
                    array.RemoveAt(i);
                    return true;
                }
            }

            return false;

            throw new NotImplementedException("Файл с данным ID не существует.");

        }
        #endregion

        // IBaseService2 methods
        #region
        public File Get(int id = Default)
        {
            if (id == Default) { throw new NotImplementedException("Не удалось найти файл."); }
            foreach (File item in array)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            throw new NotImplementedException("Не удалось найти файл.");
        }

        public List<File> GetAll()
        {
            List<File> res = new List<File>();
            foreach (File item in array)
            {
                res.Add(item);
            }

            return res;

            throw new NotImplementedException("Не удалось получить список файлов.");
        }

        public bool Save(File entity)
        {
            try
            {
                if (entity == null) return false;
                array.Add(entity);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
