using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JESUS_ESTEVEZ.Models;
using JESUS_ESTEVEZ.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JESUS_ESTEVEZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBService DBServices;

        public HomeController(ILogger<HomeController> logger, DBService _DBServices)
        {
            _logger = logger;
            DBServices = _DBServices;
        }

        public async Task<IActionResult> Index()
        {
            var results = await DBServices.GetDepartments();

            List<SelectListItem> Departamentos = new List<SelectListItem>();
            foreach (var depart in results)
            {
                Departamentos.Add(new SelectListItem { Value = $"{depart.Codigo}", Text = depart.Nombre });
            }
            ViewBag.Departamentos = Departamentos;
            return View();
        } 

        [HttpPost]
        public async Task<IActionResult> Index(Usuario user)
        {

            if (ModelState.IsValid)
            {
                DBServices.AddUser(user);
                ModelState.Clear();

                var results = await DBServices.GetDepartments();

                List<SelectListItem> Departamentos = new List<SelectListItem>();
                foreach (var depart in results)
                {
                    Departamentos.Add(new SelectListItem { Value = $"{depart.Codigo}", Text = depart.Nombre });
                }
                ViewBag.Departamentos = Departamentos;

                ViewBag.Message = "Usuario registrado correctamente.";
                return View();
            }

            ViewBag.ErrorMessage = "Ocurrio un error al tratar de registrar el usuario.";
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
