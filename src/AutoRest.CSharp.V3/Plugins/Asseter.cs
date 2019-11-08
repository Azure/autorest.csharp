using System;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Plugins
{
    // ReSharper disable once StringLiteralTypo
    [PluginName("cs-asseter")]
    // ReSharper disable once IdentifierTypo
    internal class Asseter : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            var writer = new CsProjWriter();
            writer.WriteCsProj();
            await autoRest.WriteFile("AutoRest.CSharp.V3.Test.csproj", writer.ToString() ?? String.Empty, "source-file-csharp");

            return true;
        }

        public bool ReserializeCodeModel => false;
    }
}
