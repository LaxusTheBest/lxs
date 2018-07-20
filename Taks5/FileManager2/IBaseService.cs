using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public interface IBaseService
    {
        T Get<T>(int id) where T : class, new();
        List<T> GetAll<T>() where T : class, new();
        bool Save<T>(T entity);
        bool Delete(int id);

        
    }
}
