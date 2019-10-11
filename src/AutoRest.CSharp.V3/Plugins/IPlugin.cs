using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Plugins
{
    internal interface IPlugin
    {
        Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration);
    }

    [AttributeUsage(AttributeTargets.Class)]
    internal class PluginNameAttribute : Attribute
    {
        public string PluginName { get; }

        public PluginNameAttribute(string pluginName)
        {
            PluginName = pluginName;
        }
    }
}
