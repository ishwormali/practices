using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkyRemoteControl.Core
{
    /// <summary>
    /// Base interface for CommandExecutor
    /// </summary>
    public interface ICommandExecutor
    {
        /// <summary>
        /// Indicates whether the command executer can execute the command or not
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        bool CanExecuteCommand(RemoteCommand command);

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        CommandExecutionResult ExecuteCommand(RemoteCommand command);

    }
}
