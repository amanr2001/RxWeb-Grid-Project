using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Interfaces
{
    public interface IGeneric<T> where T: class
    {

        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        }
}
