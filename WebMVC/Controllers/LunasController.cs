using Biblioteca_De_Clases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceBusApi;

namespace WebMVC.Controllers
{
    public class LunasController : Controller
    {
        private string url = "https://localhost:7109/api/lunas";
        private crud<luna> crud { get; set; }

        public LunasController()
        {
            crud = new crud<luna>();
        }
        // GET: LunaController
        public ActionResult Index()
        {
            var datos = crud.Select(url);
            return View(datos);
        }

        // GET: LunaController/Details/5
        public ActionResult Details(string id)
        {
            var datos = crud.Select_ById(url, id);
            return View(datos);
        }

        // GET: LunaController/Create
        public ActionResult Create()
        {
            var listaPlanetas = new crud<planeta>()
            .Select(url.Replace("lunas", "planetas"))
            .Select(planet => new SelectListItem
            {
                Value = planet.codigo_planeta,
                Text = planet.nombre_planeta
            })
            .ToList();

            ViewBag.listaPlanetas = listaPlanetas;
            return View();
        }

        // POST: LunaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(luna datos)
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

        // GET: LunaController/Edit/5
        public ActionResult Edit(string id)
        {
            var datos = crud.Select_ById(url, id);
            return View(datos);
        }

        // POST: LunaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, luna luna)
        {
            try
            {
                crud.Update(url, id, luna);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(luna);
            }
        }

        // GET: LunaController/Delete/5
        public ActionResult Delete(string id)
        {
            var datos = crud.Select_ById(url, id);
            return View(datos);
        }

        // POST: LunaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, luna luna)
        {
            try
            {
                crud.Delete(url, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(luna);
            }
        }
    }
}
