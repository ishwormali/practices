using System;
using System.Collections.Generic;
namespace MVCDemo2.Models
{
    public interface IBlobService
    {
        IList<string> GetFileNames(string containerPath);
    }
}
