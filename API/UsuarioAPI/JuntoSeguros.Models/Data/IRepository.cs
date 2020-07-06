using System.Collections.Generic;

namespace JuntoSeguros.Models.Data
{
    public interface IRepository<T>
    {
        T Add(T model);

        T GetById(int id);

        IEnumerable<T> GetAll();

        void Remove(T model);

        void Update(T model);
    }
}
