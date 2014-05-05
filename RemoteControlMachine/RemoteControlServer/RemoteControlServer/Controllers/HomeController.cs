using RemoteControlServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;

namespace RemoteControlServer.Controllers
{
    public class HomeController : Controller
    {
        private IHubContext _hubContext;
        //
        // GET: /Home/

        public HomeController()
        {
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<RemoteHub>();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ServerCommand cmd)
        {
            if (cmd!=null && !string.IsNullOrEmpty(cmd.Command))
            {
                _hubContext.Clients.All.commandReceived(cmd.Command,cmd.Parameters);
            }

            return View(cmd);
        }

    }
}
