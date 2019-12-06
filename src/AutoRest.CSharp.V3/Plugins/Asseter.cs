// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Plugins
{
    // ReSharper disable once StringLiteralTypo
    [PluginName("cs-asseter")]
    // ReSharper disable once IdentifierTypo
    internal class Asseter : IPlugin
    {
        public async Task<bool> Execute(IAutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            if (configuration.IncludeCsProj)
            {
                var writer = new CsProjWriter();
                writer.WriteCsProj(configuration);
                await autoRest.WriteFile($"{configuration.Title}.csproj", writer.ToString() ?? String.Empty, "source-file-csharp");
            }

            if (configuration.IncludeAssets)
            {
                var assetDirectory = Path.Join(Directory.GetCurrentDirectory(), "src/assets").Replace("\\", "/");
                foreach (var asset in Directory.GetFiles(assetDirectory, "*.cs", SearchOption.AllDirectories))
                {
                    var directory = Path.GetDirectoryName(asset)?.Replace("\\", "/").Replace(assetDirectory, String.Empty);
                    var fileName = Path.GetFileName(asset);
                    var outputPath = Path.Join("Generated", directory, fileName).Replace("\\", "/");
                    var contents = File.ReadAllText(asset);
                    await autoRest.WriteFile(outputPath, contents, "source-file-csharp");
                }
            }

            return true;
        }

        public bool ReserializeCodeModel => false;
    }
}
