using AppAnimales;
using AppAnimalesConsumeAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.Intrinsics.Arm;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppAnimalesMVC.Controllers
{
    public class AnimalesController : Controller
    {
        private string urlApi;
        private string urlbase;
        public AnimalesController(IConfiguration configuration)
        {
            urlbase = configuration.GetValue("APIURLBASE", "").ToString();
            urlApi = configuration.GetValue("APIURLBASE", "").ToString() + "/Animales";
        }
        // GET: AnimalesController
        public ActionResult Index()
        {
            var data = Crud<Animal>.Read(urlApi);
            return View(data);
        }

        // GET: AnimalesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Animal>.Read_ByUd(urlApi, id);
            return View(data);
        }

        // GET: AnimalesController/Create
        public ActionResult Create()
        {
            ViewBag.Grupos = ObtenerListaGrupos().Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Nombre
            }).ToList();
            return View();
        }

        private Grupo[] ObtenerListaGrupos()
        {

            return Crud<Grupo>.Read(urlbase + "/Grupos");
        }

        // POST: AnimalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Animal data)
        {

            try
            {
                ViewBag.Animal = data;

                var newdata = Crud<Animal>.Create(urlApi, data);

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: AnimalesController/Edit/5
        public ActionResult Edit(int id)
        {

            ViewBag.Grupos = ObtenerListaGrupos().Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Nombre
            }).ToList();
            var data = Crud<Animal>.Read_ByUd(urlApi, id);
            return View(data);
        }

        // POST: AnimalesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Animal data)
        {
            try
            {
                Crud<Animal>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: AnimalesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Animal>.Read_ByUd(urlApi, id);
            return View(data);
        }

        // POST: AnimalesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Animal data)
        {
            try
            {
                Crud<Animal>.Delete(urlApi, id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
