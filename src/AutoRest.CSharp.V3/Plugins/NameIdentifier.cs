using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Plugins
{
    [PluginName("name-identifier")]
    internal class NameIdentifier : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            return true;
        }
    }
}