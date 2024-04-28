using WebAppZoo.Models;

namespace WebAppZoo.Services
{
    public interface ApiService
    {
        Task<List<Animal>> All();
        Task<Animal> GetById(int id);
        Task<bool> Save(Animal entity);
        Task<bool> Update(Animal entity);
        Task<bool> Delete(int id);
    }
}
