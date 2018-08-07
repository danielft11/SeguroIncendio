using SeguroIncendio.Contexto;
using SeguroIncendio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SeguroIncendio.Controllers
{
    public class OrcamentosController : Controller
    {
        private EFContext context = new EFContext();

        public ActionResult Index()
        {
            return View(context.Orcamentos.OrderBy(o => o.OrcamentoId));
        }

        public ActionResult Create()
     {
            ViewBag.IdentificacaoCategoria = new SelectList(context.CategoriasImovel.OrderBy(c => c.CategoriaImovelId), "CategoriaImovelId", "CategoriaDesc");
            ViewBag.TipoImovelId = new SelectList(context.TiposImovel.OrderBy(t => t.TipoImovelDesc), "TipoImovelId", "TipoImovelDesc");
            return View();
        }

        public ActionResult Details(int? id)
        {
            return View(context.Orcamentos.Where(o => o.OrcamentoId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Orcamento orcamento)
        {
            context.Orcamentos.Add(orcamento);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult ObterTipoImovel(int id)
        {
            var TiposImoveis = context.TiposImovel.Where(c => c.CategoriaImovelId == id).ToList();
            var result = (from r in TiposImoveis
                          select new
                          {
                              id = r.TipoImovelId,
                              name = r.TipoImovelDesc,
                              Text = r.TipoImovelDesc
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObterTaxaImovel(int id)
        {
            var Consulta = context.TiposImovel.Where(c => c.TipoImovelId == id).ToList();
            var Retorno = (from t in Consulta
                              select new
                              {
                                  Taxa = t.TipoImovelTaxa
                              }).ToList();

            return Json(Retorno, JsonRequestBehavior.AllowGet);
        }
    }
}