using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace RemoteControlServer.Controllers
{
    public class RemoteHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }


    }
}