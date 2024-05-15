using AppAnimales;
using AppAnimalesConsumeAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppAnimalesMVC.Controllers
{
    public class GruposController : Controller
    {
        
        private string urlApi;
        public GruposController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("APIURLBASE", "").ToString() + "/Grupos";
        }
        // GET: GruposController
        public ActionResult Index()
        {
            var data = Crud<Grupo>.Read(urlApi);
            return View(data);
        }

        // GET: GruposController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Grupo>.Read_ByUd(urlApi, id);
            return View(data);
        }

        // GET: GruposController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GruposController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Grupo data)
        {
            try
            {
                var newdata = Crud<Grupo>.Create(urlApi, data);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: GruposController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Grupo>.Read_ByUd(urlApi, id);
            return View(data);
        }

        // POST: GruposController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Grupo data)
        {
            try
            {
                Crud<Grupo>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: GruposController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Grupo>.Read_ByUd(urlApi, id);
            return View(data);
        }

        // POST: GruposController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Grupo data)
        {
            try
            {
                Crud<Grupo>.Delete(urlApi, id);
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
