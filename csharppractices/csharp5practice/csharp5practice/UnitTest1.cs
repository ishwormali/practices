using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace csharp5practice
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var cls = new MyClass();
            await cls.SomeAsyncFunctionB();
            
            //System.Threading.Thread.Sleep(1000);
            int a = 0;
        }
    }
}
