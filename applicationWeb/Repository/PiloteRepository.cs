using applicationWeb.Data;
using applicationWeb.Models;
using applicationWeb.Repository.IRepository;

namespace applicationWeb.Repository
{
    public class PiloteRepository : Repository<Pilote>, IPiloteRepository
    {

        private ApplicationDbContext _db;

        public PiloteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Pilote obj)
        {
            _db.pilote.Update(obj);
        }

       
    }
}
