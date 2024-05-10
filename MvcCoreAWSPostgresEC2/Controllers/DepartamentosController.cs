using Microsoft.AspNetCore.Mvc;
using MvcCoreAWSPostgresEC2.Models;
using MvcCoreAWSPostgresEC2.Repositories;

namespace MvcCoreAWSPostgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;
        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Departamento> depts = await this.repo.GetDepartamentosAsync();
            return View(depts);
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento dept = await this.repo.FindDepartamentoAsync(id);
            return View(dept);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Departamento dept)
        {
            await this.repo.InsertDepartamentoAsync(dept.IdDepartamento,dept.Nombre,dept.Localidad);
            return RedirectToAction("Index");
        }
    }
}
