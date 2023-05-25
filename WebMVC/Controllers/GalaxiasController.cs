using Biblioteca_De_Clases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBusApi;

namespace WebMVC.Controllers
{
    public class GalaxiasController : Controller
    {
        private string url = "https://localhost:7109/api/galaxias";
        private crud<galaxia> crud { get; set; }

        public GalaxiasController()
        {
            crud = new crud<galaxia>();
        }

        // GET: GalaxiasController
        public ActionResult Index()
        {
            var datos = crud.Select(url);
            return View(datos);
        }

        // GET: GalaxiasController/Details/5
        public ActionResult Details(string id)
        {
            var datos = crud.Select_ById(url, id);
            return View(datos);
        }

        // GET: GalaxiasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GalaxiasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(galaxia datos)
        {
            try
            {
                crud.Insert(url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: GalaxiasController/Edit/5
        public ActionResult Edit(string id)
        {
            var datos = crud.Select_ById(url, id);
            return View(datos);
        }

        // POST: GalaxiasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, galaxia galaxia)
        {
            try
            {
                crud.Update(url, id, galaxia);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(galaxia);
            }
        }

        // GET: GalaxiasController/Delete/5
        public ActionResult Delete(string id)
        {
            var datos = crud.Select_ById(url, id);
            return View(datos);
        }

        // POST: GalaxiasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, galaxia galaxia)
        {
            try
            {
                crud.Delete(url, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(galaxia);
            }
        }
    }
}
