using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FunkyRemoteControl.Core
{
    public class CmdPromptCommandExecutor : BaseCommandExecutor
    {
        public override bool CanExecuteCommand(RemoteCommand command)
        {
            return base.CanExecuteCommand(command);
        }

        public override CommandExecutionResult ExecuteCommand(RemoteCommand command)
        {
            var commandPrompt = new Process();

            commandPrompt.StartInfo.FileName=  "CMD.exe";
            commandPrompt.StartInfo.Arguments = command.CommandParameters;
            //commandPrompt.StartInfo.RedirectStandardOutput = true;
            commandPrompt.Start();
           // var output = commandPrompt.StandardOutput.ReadToEnd();
            var result = new CommandExecutionResult();
          //  result.Result.Add(output);
            return result;
        }

        protected override IList<string> GetCommands(RemoteCommand command)
        {
            return new List<string>() { CoreCommands.CommandPrompt };
        }
    }
}
