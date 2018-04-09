using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeveloopPrueba.Controllers
{
    public class EncargosController : BaseController
    {
        // GET: Encargos
        public ActionResult Index()
        {
            return View();
        }
    }
}