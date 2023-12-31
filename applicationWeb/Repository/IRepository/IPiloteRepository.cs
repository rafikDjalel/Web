using applicationWeb.Models;

namespace applicationWeb.Repository.IRepository
{
    public interface IPiloteRepository :IRepository<Pilote>
    {

        void Update(Pilote obj);
        void Save();
    }
}
