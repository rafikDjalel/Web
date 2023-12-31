using applicationWeb.Data;
using applicationWeb.Models;
using applicationWeb.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace applicationWeb.Repository
{
    public class VolRepository : Repository<Vol>, IVolRepository
    {

        private ApplicationDbContext _db;

        public VolRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Vol obj)
        {
            _db.vol.Update(obj);
        }


        public IEnumerable<Pilote> GetPiloteList()
        {
            return _db.pilote.ToList();
        }

        public IEnumerable<Avion> GetAvionList()
        {
            return _db.avion.ToList();
        }
    }
}
