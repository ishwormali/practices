using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunkyRemoteControl.Core
{
    public class BaseCommandExecutor:ICommandExecutor
    {
        public virtual bool CanExecuteCommand(RemoteCommand command)
        {
            var commands = GetCommands(command);
            var canExecuteCommand = commands.Contains(command.CommandName, StringComparer.OrdinalIgnoreCase);
            return canExecuteCommand;
        }

        public virtual CommandExecutionResult ExecuteCommand(RemoteCommand command)
        {
            return new CommandExecutionResult();
        }

        protected virtual IList<string> GetCommands(RemoteCommand command)
        {
            return new List<string>();
        }
    }
}
