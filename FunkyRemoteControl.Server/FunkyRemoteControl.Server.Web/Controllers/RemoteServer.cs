using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace FunkyRemoteControl.Server.Web.Controllers
{
    public class RemoteServer : Hub
    {
        public void SendCommand(string command,string parameters,string requestToken)
        {
            Clients.All.commandReceived(command, parameters, requestToken);
        }
    }
}