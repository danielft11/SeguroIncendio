using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeguroIncendio.Controllers
{
    public class PropostasController : Controller
    {
        // GET: Propostas
        public ActionResult Index()
        {
            return View();
        }
    }
}