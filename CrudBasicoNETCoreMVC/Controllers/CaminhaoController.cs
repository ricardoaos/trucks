using CrudBasicoNETCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CrudBasicoNETCoreMVC.Controllers
{
    public class CaminhaoController : Controller
    {
        private CrudDbContext _crudContext;

        public CaminhaoController(CrudDbContext crudContext)
        {
            _crudContext = crudContext;
        }

        public IActionResult Index()
        {
            var Caminhao = _crudContext
                .Caminhao
                .Include(i => i.Modelo)
                .AsNoTracking()
                .ToList();

            return View(Caminhao);
        }

        public IActionResult Excluir(int id)
        {
            var caminhao = _crudContext.Caminhao.Single(p => p.Id == id);
            _crudContext.Remove(caminhao);
            _crudContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            ViewBag.Modelo = _crudContext
                .Modelo
                .Select(c => new SelectListItem() { Text = c.Descricao, Value = c.Id.ToString() })
                .ToList();

            var cliente = _crudContext.Caminhao.FirstOrDefault(p => p.Id == id) ?? new Caminhao();

            return View(cliente);
        }

        public IActionResult Gravar(Caminhao caminhao)
        {

            if (caminhao.Id > 0)
            {
                _crudContext.Update(caminhao);
            }
            else
            {
                _crudContext.Add(caminhao);
            }

            _crudContext.SaveChanges();

            return RedirectToAction("Editar", new { id = caminhao.Id });
        }
    }
}
