using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ContractedClass
    {
        public void RequireParameterMethod(string firstParameter, int i)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(firstParameter));
            Contract.Requires(i > 0);
        }
    }
}
