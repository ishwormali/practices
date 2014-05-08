using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunkyRemoteControl.Core
{
    public class CommandExecutionResult
    {
        public CommandExecutionResult():this(new string[0])
        {

        }

        public CommandExecutionResult(params string[] errors)
        {
            errors.ToList().ForEach(m => Errors.Add(m));

        }
        /// <summary>
        /// Indicates whether the operation was successfull based on the number of errors
        /// </summary>
        public bool WasSuccessfull
        {
            get { return Errors.Count == 0; }
        }

        private IList<string> errors;
        /// <summary>
        /// List of errors that occured while executing command
        /// </summary>
        public IList<string> Errors
        {
            get { return errors ?? (errors = new List<string>()); }
            set { errors = value; }
        }

        private IList<object> result;

        public IList<object> Result
        {
            get { return result??(result=new List<object>()); }
            set { result = value; }
        }
        
        
    }
}
