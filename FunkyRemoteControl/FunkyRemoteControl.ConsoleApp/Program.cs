using FunkyRemoteControl.Core;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FunkyRemoteControl.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var loginManager=new LoginManager();
            //Console.WriteLine("User Name : ");

            var uName = "ishwor";// Console.ReadLine();
           // Console.WriteLine("Password : ");

            var pwd = "passw0rd";// Console.ReadLine();

            var authCookie = new Cookie();
            var loginSuccess = loginManager.Login(uName, pwd, out authCookie);
            if (!loginSuccess)
            {
                return;
            }

            HubConnection hub = new HubConnection(System.Configuration.ConfigurationManager.AppSettings["RemoteServer"]);
            hub.CookieContainer = new CookieContainer();
            hub.CookieContainer.Add(authCookie);
            
            var prxy = hub.CreateHubProxy("RemoteServer");
            prxy.On<string, string,string>("commandReceived", (command, parameters,requestToken) =>
            {
                Console.WriteLine(string.Format("Command : {0}, Parameters : {1} ", command, parameters));
                if (!string.IsNullOrWhiteSpace(command))
                {
                    var remoteCommand=new RemoteCommand(){CommandName=command,CommandParameters=parameters};
                    var executor = GetCommandExecutor(remoteCommand);
                    var responses = new List<CommandExecutionResult>();
                    if(executor !=null)
                    {
                        var response = executor.ExecuteCommand(remoteCommand);
                        if (response==null)
                        {
                            response = new CommandExecutionResult();
                        }
                        
                        
                    }
                    else
                    {
                        //return new CommandExecutionResult(string.Format(CultureInfo.InvariantCulture,"No command executor found for the command named : {0}",remoteCommand.CommandName);
                    }
                }
                else
                {
                    
                }
                
            });

            hub.Start().Wait();

            try
            {
                prxy.Invoke("SendCommand", "tempcommand", "tempparameter", "nothing").Wait();
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    return true;
                });
                throw;
            }
            

            Console.ReadLine();
        }

        static ICommandExecutor GetCommandExecutor(RemoteCommand command)
        {
            var executors = new List<ICommandExecutor>() { new FileSystemCommandExecutor(), new CmdPromptCommandExecutor() };
            return executors.FirstOrDefault(m => m.CanExecuteCommand(command));

        }
    }
}
