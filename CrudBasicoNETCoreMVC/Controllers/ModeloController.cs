using CrudBasicoNETCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CrudBasicoNETCoreMVC.Controllers
{
    public class ModeloController : Controller
    {
        private CrudDbContext _crudContext;

        public ModeloController(CrudDbContext crudContext)
        {
            _crudContext = crudContext;
        }

        public IActionResult Index()
        {
            var Modelo = _crudContext.Modelo.AsNoTracking().ToList();
            return View(Modelo);
        }

        public IActionResult Excluir(int id)
        {
            var situacao = _crudContext.Modelo.Single(p => p.Id == id);
            _crudContext.Remove(situacao);
            _crudContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var situacao = _crudContext.Modelo.FirstOrDefault(p => p.Id == id) ?? new Modelo();

            return View(situacao);
        }

        public IActionResult Gravar(Modelo situacao)
        {

            if (situacao.Id > 0)
            {
                _crudContext.Update(situacao);
            }
            else
            {
                _crudContext.Add(situacao);
            }

            _crudContext.SaveChanges();

            return RedirectToAction("Editar", new { id = situacao.Id });
        }
    }
}
