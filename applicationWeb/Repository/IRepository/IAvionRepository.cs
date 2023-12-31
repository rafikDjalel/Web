using applicationWeb.Models;

namespace applicationWeb.Repository.IRepository
{
    public interface IAvionRepository : IRepository<Avion>
    {
        void Update(Avion obj);
        void Save();
    }
}
