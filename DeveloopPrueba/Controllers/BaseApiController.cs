using DeveloopPrueba.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DeveloopPrueba.Controllers
{
    public class BaseApiController : ApiController
    {
        private ApplicationDbContext _dbContext = null;

        protected ApplicationDbContext DbContext
        {
            get
            {
                return _dbContext ?? HttpContext.Current.Request.GetOwinContext().Get<ApplicationDbContext>();
            }
        }

        public BaseApiController()
        {

        }
    }
}
