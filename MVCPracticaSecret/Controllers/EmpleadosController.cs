using Microsoft.AspNetCore.Mvc;
using MVCPracticaSecret.Filters;
using MVCPracticaSecret.Models;
using MVCPracticaSecret.Services;

namespace MVCPracticaSecret.Controllers
{
    public class EmpleadosController : Controller
    {
        private ServiceApiEmpleados service;

        public EmpleadosController(ServiceApiEmpleados service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Empleado> empleados = await
                this.service.GetEmpleadosAsync();
            return View(empleados);
        }

        public async Task<IActionResult> Details(int id)
        {
            Empleado empleado = await
                    this.service.FindEmpleadoAsync(id);
            return View(empleado);
        }


        public async Task<IActionResult> Perfil()
        {
            Empleado empleado =
                await this.service.GetPerfilEmpleadoAsync();
            return View(empleado);
        }



        public async Task<IActionResult> EmpleadosOficios()
        {
            List<string> oficios =
                await this.service.GetOficiosAsync();
            ViewData["OFICIOS"] = oficios;
            return View();
        }

        
    }
}