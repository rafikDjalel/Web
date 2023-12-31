using applicationWeb.Models;
using applicationWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace applicationWeb.Controllers
{
    public class PiloteController : Controller
    {
        private readonly IPiloteRepository _piloteRepo;
        public PiloteController(IPiloteRepository db)
        {
            _piloteRepo = db;
        }
        public IActionResult Index()
        {
            List<Pilote> objPiloteList = _piloteRepo.GetAll().ToList();

            return View(objPiloteList);
        }

        public IActionResult Create()
        {
            return View();
        }





        [HttpPost]
        public IActionResult Create(Pilote obj)
        {
            //_db.Database.OpenConnection();
            try
            {

                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT avions ON;");
                _piloteRepo.Add(obj);
                _piloteRepo.Save();
                TempData["success"] = "Un Pilote a été ajouté avec succès";


            }
            finally
            {
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT avions OFF;");
                // _db.Database.CloseConnection();
            }
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {

                return NotFound();

            }

            Pilote? piloteFromDb = _piloteRepo.Get(u => u.Numpilote == id);

            if (piloteFromDb == null)
            {
                return NotFound();
            }

            return View(piloteFromDb);
        }





        [HttpPost]
        public IActionResult Edit(Pilote obj)
        {
            //_db.Database.OpenConnection();
            try
            {

                // _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT avions ON;");
                _piloteRepo.Update(obj);
                _piloteRepo.Save();
                TempData["success"] = "Un Pilote a été modifie avec succès";

            }
            finally
            {
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT avions OFF;");
                // _db.Database.CloseConnection();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {

                return NotFound();

            }

            Pilote? piloteFromDb = _piloteRepo.Get(u => u.Numpilote == id);

            if (piloteFromDb == null)
            {
                return NotFound();
            }

            return View(piloteFromDb);
        }





        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            //  _db.Database.OpenConnection();

            Pilote? obj = _piloteRepo.Get(u => u.Numpilote == id);

            if (obj == null)
            {
                return NotFound(id);
            }


            try
            {

                // _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT avions ON;");
                _piloteRepo.Remove(obj);
                _piloteRepo.Save();
                TempData["success"] = "Un Pilote a été suprime avec succès";

            }
            finally
            {
                // _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT avions OFF;");
                // _db.Database.CloseConnection();
            }
            return RedirectToAction("Index");
        }
    }
}
