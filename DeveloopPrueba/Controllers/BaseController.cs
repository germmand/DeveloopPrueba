using DeveloopPrueba.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeveloopPrueba.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationDbContext _dbContext = null;

        protected ApplicationDbContext DbContext
        {
            get
            {
                return _dbContext ?? HttpContext.Request.GetOwinContext().Get<ApplicationDbContext>();
            }
        }

        public BaseController()
        {

        }
    }
}