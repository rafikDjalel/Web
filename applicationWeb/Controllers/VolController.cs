using applicationWeb.Models;
using applicationWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace applicationWeb.Controllers
{
    public class VolController : Controller
    {
        private readonly IVolRepository _volRepo;
        public VolController(IVolRepository db)
        {
            _volRepo = db;
        }
        public IActionResult Index()
        {
            List<Vol> objVolList = _volRepo.GetAll().ToList();
           

            return View(objVolList);
        }

        public IActionResult Create()
        {
            
            IEnumerable<SelectListItem> PiloteList = 
                                                     
                _volRepo.GetPiloteList().Select(p => new SelectListItem
                {
                    Value = p.Numpilote.ToString(),
                    Text = p.Numpilote.ToString() 
                });

            
            IEnumerable<SelectListItem> AvionList = 
                                                    
                _volRepo.GetAvionList().Select(a => new SelectListItem
                {
                    Value = a.Numavion.ToString(),
                    Text = a.Numavion.ToString() 
                });

           
            ViewBag.PiloteList = PiloteList;
            ViewBag.AvionList = AvionList;

            return View();
        }





        [HttpPost]
        public IActionResult Create(Vol obj)
        {
            //_db.Database.OpenConnection();
            try
            {

                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT avions ON;");
                _volRepo.Add(obj);
                _volRepo.Save();
                TempData["success"] = "Un Vol a été ajouté avec succès";


            }
            finally
            {
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT avions OFF;");
                // _db.Database.CloseConnection();
            }
            return RedirectToAction("Index");
        }


        public IActionResult Edit(string? id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }

            Vol? volFromDb = _volRepo.Get(u => u.Numvol == id);

            if (volFromDb == null)
            {
                return NotFound();
            }

            
            IEnumerable<SelectListItem> PiloteList = _volRepo.GetPiloteList().Select(p => new SelectListItem
            {
                Value = p.Numpilote.ToString(),
                Text = p.Numpilote.ToString()
            });

            // Récupérer la liste des avions
            IEnumerable<SelectListItem> AvionList = _volRepo.GetAvionList().Select(a => new SelectListItem
            {
                Value = a.Numavion.ToString(),
                Text = a.Numavion.ToString()
            });

            
            ViewBag.PiloteList = PiloteList;
            ViewBag.AvionList = AvionList;

            return View(volFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Vol obj)
        {
            try
            {
                _volRepo.Update(obj);
                _volRepo.Save();
                TempData["success"] = "Un Vol a été modifié avec succès";
            }
            catch (Exception ex)
            {
                // Gérer les erreurs, par exemple, en ajoutant ModelState.AddModelError
                TempData["error"] = "Une erreur s'est produite lors de la modification du vol.";
                return View(obj);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string? id)
        {

            if (id == null || id == "")
            {

                return NotFound();

            }

            Vol? volFromDb = _volRepo.Get(u => u.Numvol == id);

            if (volFromDb == null)
            {
                return NotFound();
            }

            return View(volFromDb);
        }





        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(string? id)
        {
            //  _db.Database.OpenConnection();

            Vol? obj = _volRepo.Get(u => u.Numvol == id);

            if (obj == null)
            {
                return NotFound(id);
            }


            try
            {

                // _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT avions ON;");
                _volRepo.Remove(obj);
                _volRepo.Save();
                TempData["success"] = "Un Vol a été suprime avec succès";

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
