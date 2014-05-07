using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FunkyRemoteControl.Core
{
    public class FileSystemCommandExecutor:BaseCommandExecutor
    {

        public override bool CanExecuteCommand(RemoteCommand command)
        {
            return base.CanExecuteCommand(command);
        }

        public override CommandExecutionResult ExecuteCommand(RemoteCommand command)
        {
            var lowerCommand=command.CommandName.ToLowerInvariant();
            switch (lowerCommand)
            {
                case CoreCommands.FolderList:
                    
                    return ExecuteFolderListCommand(command);
                    break;
                default:
                    break;
            }

            return new CommandExecutionResult();
        }

        protected virtual CommandExecutionResult ExecuteFolderListCommand(RemoteCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.CommandParameters))
            {
                return new CommandExecutionResult("Parameter not supplied");

            }

            try
            {
                var listparameters=command.CommandParameters.Split(';');

                var directories=Directory.EnumerateDirectories(listparameters[0],listparameters.Length>1?listparameters[1]:"*");
                var result = new CommandExecutionResult();
                result.Result.Add(directories);
                return result;
            }
            catch (Exception ex)
            {
                return new CommandExecutionResult(ex.Message);
                throw;
            }

            return new CommandExecutionResult();

        }

        protected override IList<string> GetCommands(RemoteCommand command)
        {
            return new List<string>() { CoreCommands.FolderList };
        }
    }
}
