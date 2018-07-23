using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public class UserRepository : IBaseService, IBaseService2<User>
    {
        private const int Defalut = 0;

        public static List<User> array = new List<User>()
        {
            new User(){ID=1},
            new User(){ID=2},
            new User(){ID=3},
            new User(){ID=4},
            new User(){ID=5},
            new User(){ID=6},
            new User(){ID=7},
            new User(){ID=8},
            new User(){ID=9},
        };

        public IEnumerable<User> GetAllUsers() { return null; }
        public User GetUser(int id) { return null; }
        public User GetUser(string login) { return null; }
        public void RemoveUser(User user) { }
        public void CreateUser() { }
        public void SaveChanges(int id) { } //todo pn в качестве заглушек принято использовать throw new NotImplementedException();

        //IBaseService methods
        #region
        public T Get<T>(int id = Defalut) where T : class, new()
        {
            foreach (User item in array)
            {
                if (item.ID == id)
                {
                    return item as T;
                }
            }

            throw new NotImplementedException("Не удалось найти пользователя.");///todo pn неправильно выбран тип исключения (либо базовое, либо собственное, но точно не этот)
		}

		public List<T> GetAll<T>() where T : class, new()
        {
            List<T> res = new List<T>();
            foreach (User item in array)
            {
                res.Add(item as T);
            }

            return res;

            throw new NotImplementedException("Не удалось получить список пользователей.");
        }

        public bool Save<T>(T entity)
        {
            try
            {
                if (entity == null) return false;
                if (typeof(T) == typeof(User))
                {
                    array.Add(entity as User);

                    return true;
                }
                else return false;
            }
            catch (FormatException)
            {
                return false;
            }
            throw new NotImplementedException();
        }

        public bool Delete(int id = Defalut)
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
            throw new NotImplementedException("Не удалось удалить пользователя");
        }
        #endregion


        //IBaseService2 methods
        #region
        public User Get(int id=Defalut)
        {
            if(id==Defalut) throw new NotImplementedException("Не удалось найти пользователя.");
            foreach (User item in array)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            throw new NotImplementedException("Не удалось найти пользователя.");
        }

        public List<User> GetAll()
        {
            List<User> res = new List<User>();
            foreach (User item in array)
            {
                res.Add(item);
            }

            return res;

            throw new NotImplementedException("Не удалось получить список пользователей.");
        }

        public bool Save(User entity)
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
