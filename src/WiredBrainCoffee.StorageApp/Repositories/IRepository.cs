using System.Collections.Generic;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{


    public interface IWriteRepository<in T>{
        void Add(T item);
        void Remove(T item);
        void Save();
    }

    public interface IReadRepository<out T> {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }

    public interface IRepository<T>  : IReadRepository<T>, IWriteRepository<T> where T : IEntity
    {
        new void Add(T item);
        new void Remove(T item);
        new void Save();
    }
}