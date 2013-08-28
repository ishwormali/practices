using System;
using System.Collections.Generic;
namespace MVCDemo.Models
{
    public interface IBlobService
    {
        IList<string> GetFileNames(string containerPath);
    }
}
