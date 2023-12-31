using applicationWeb.Models;

namespace applicationWeb.Repository.IRepository
{
    public interface IVolRepository : IRepository<Vol>
    {

        IEnumerable<Pilote> GetPiloteList();
        IEnumerable<Avion> GetAvionList();


        void Update(Vol obj);
        void Save();



        
    }
}
