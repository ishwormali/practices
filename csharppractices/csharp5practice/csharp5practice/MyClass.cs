using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp5practice
{
    public class MyClass
    {
        public async Task SomeAsyncFunctionB()
        {
            await SomeAsyncFunctionA();
        }

        public async Task SomeAsyncFunctionA()
        {
            int i=0;
            await Task.Run(() => {
                for (i = 0; i < 5; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    System.Diagnostics.Debug.Print((i).ToString());
                }
               
            });
        }
    }
}
