using applicationWeb.Data;
using applicationWeb.Models;
using applicationWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace applicationWeb.Repository
{
    public class AvionRepository : Repository<Avion>, IAvionRepository
    {
        private ApplicationDbContext _db;

       public AvionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Avion obj)
        {
            _db.avion.Update(obj);
        }
    }
}
