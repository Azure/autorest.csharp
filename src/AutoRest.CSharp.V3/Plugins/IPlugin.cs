using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutoRest.CSharp.V3.Plugins
{
    internal interface IPlugin
    {
        Task<bool> Execute();
    }
}
