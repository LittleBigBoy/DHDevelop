using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tzj.Demo.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {

        }

        public void BaseBind()
        {
            //g各个网页添加js及css
            ViewBag.Js = new string[] { };
            ViewBag.Css = new string[] { };
        }

        public ViewResult CreateView()
        {
            BaseBind();
            return View();
        }
    }
}