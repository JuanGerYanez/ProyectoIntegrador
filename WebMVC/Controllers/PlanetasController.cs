using Biblioteca_De_Clases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceBusApi;

namespace WebMVC.Controllers
{
    public class PlanetasController : Controller
    {
        private string url = "https://localhost:7109/api/planetas";
        private crud<planeta> crud { get; set; }

        public PlanetasController()
        {
            crud = new crud<planeta>();
        }
        // GET: PlanetasController
        public ActionResult Index()
        {
            var datos = crud.Select(url);
            return View(datos);
        }

        // GET: PlanetasController/Details/5
        public ActionResult Details(string id)
        {
            var datos = crud.Select_ById(url, id);
            return View(datos);
        }

        // GET: PlanetasController/Create
        public ActionResult Create()
        {
            var listaGalaxias = new crud<galaxia>()
            .Select(url.Replace("planetas", "galaxias"))
            .Select(galaxi => new SelectListItem
            {
                Value = galaxi.codigo_galaxia,
                Text = galaxi.nombre_galaxia
            })
            .ToList();

            ViewBag.listaGalaxias = listaGalaxias;
            return View();
        }

        // POST: PlanetasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(planeta datos)
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

        // GET: PlanetasController/Edit/5
        public ActionResult Edit(string id)
        {
            var datos = crud.Select_ById(url, id);
            return View(datos);
        }

        // POST: PlanetasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, planeta planeta)
        {
            try
            {
                crud.Update(url, id, planeta);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(planeta);
            }
        }

        // GET: PlanetasController/Delete/5
        public ActionResult Delete(string id)
        {
            var datos = crud.Select_ById(url, id);
            return View(datos);
        }

        // POST: PlanetasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, planeta planeta)
        {
            try
            {
                crud.Delete(url, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(planeta);
            }
        }
    }
}
