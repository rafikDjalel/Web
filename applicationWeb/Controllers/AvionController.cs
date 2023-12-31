using applicationWeb.Data;
using applicationWeb.Models;
using applicationWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace applicationWeb.Controllers
{
    public class AvionController : Controller
    {
        private readonly IAvionRepository _avionRepo;
        public AvionController(IAvionRepository db)
        {
            _avionRepo = db;
        }
        public IActionResult Index()
        {
            List<Avion> objAvionList = _avionRepo.GetAll().ToList();

            return View(objAvionList);
        }

        public IActionResult Create()
        {
            return View();
        }





        [HttpPost]
        public IActionResult Create(Avion obj)
        {
            //_db.Database.OpenConnection();
            try
            {

                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT avions ON;");
                _avionRepo.Add(obj);
                _avionRepo.Save();
                    TempData["success"] = "Un Avion a été ajouté avec succès";
                
               
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
            
            if(id == null || id== 0) {
            
                return NotFound();
            
            }

            Avion? avionFromDb = _avionRepo.Get(u=>u.Numavion==id);

            if(avionFromDb == null)
            {
                return NotFound();
            }
            
            return View(avionFromDb);
        }





        [HttpPost]
        public IActionResult Edit(Avion obj)
        {
            //_db.Database.OpenConnection();
            try
            {

                // _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT avions ON;");
                _avionRepo.Update(obj);
                _avionRepo.Save();
                TempData["success"] = "Un Avion a été modifie avec succès";

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

            Avion? avionFromDb = _avionRepo.Get(u => u.Numavion == id);

            if (avionFromDb == null)
            {
                return NotFound();
            }

            return View(avionFromDb);
        }





        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
          //  _db.Database.OpenConnection();

            Avion? obj = _avionRepo.Get(u => u.Numavion == id);

            if (obj == null)
            {
                return NotFound(id);
            }

           
            try
            {

               // _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT avions ON;");
                _avionRepo.Remove(obj);
                _avionRepo.Save();
                TempData["success"] = "Un Avion a été suprime avec succès";

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
