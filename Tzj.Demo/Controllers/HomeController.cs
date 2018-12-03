using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;
using Tzj.Domain.Core.Service.Crm;

namespace Tzj.Demo.Controllers
{
    public class HomeController : BaseController
    {

        // GET: Home
        public ActionResult Index()
        {
            
            return CreateView();
        }
        [Route("login")]
        public async Task<ActionResult> Login()
        {
            //var a = AccountService.GetInstance().GetModelById(1);
            return CreateView();
        }
        [Route("reg")]
        public async Task<ActionResult> Reg()
        {
            return CreateView();
        }
        [Route("DashBoard")]
        public async Task<ActionResult> DashBoard()
        {
            return CreateView();
        }
    }
}