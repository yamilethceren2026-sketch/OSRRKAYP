using Microsoft.AspNetCore.Mvc;

namespace OSRRKAYP.WebApplication.Controllers
{
    public class UserController : Controller
    {
        // LISTAR
        public IActionResult Index()
        {
            return View();
        }

        // CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // GUARDAR
        [HttpPost]
        public IActionResult Create(object request)
        {
            return RedirectToAction(nameof(Index));
        }

        // EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        // ACTUALIZAR
        [HttpPost]
        public IActionResult Edit(int id, object request)
        {
            return RedirectToAction(nameof(Index));
        }

        // DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }

        // CONFIRMAR DELETE
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        // DETAILS
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}