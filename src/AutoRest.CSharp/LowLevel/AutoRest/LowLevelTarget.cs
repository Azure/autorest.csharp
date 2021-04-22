// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Common.Output.Builders;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class LowLevelTarget
    {
        public static void Execute(GeneratedCodeWorkspace project, CodeModel codeModel, SourceInputModel? sourceInputModel, Configuration configuration)
        {
            var context = new BuildContext<LowLevelOutputLibrary>(codeModel, configuration, sourceInputModel);
            foreach (var client in context.Library.RestClients)
            {
                var codeWriter = new CodeWriter();
                var lowLevelClientWriter = new LowLevelClientWriter ();
                lowLevelClientWriter.WriteClient(codeWriter, client, context);
                project.AddGeneratedFile($"{client.Type.Name}.cs", codeWriter.ToString());
            }

            var optionsWriter = new CodeWriter();
            ClientOptionsWriter.WriteClientOptions(optionsWriter, context);

            var clientOptionsName = ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context);
            project.AddGeneratedFile($"{clientOptionsName}ClientOptions.cs", optionsWriter.ToString());
        }
    }
}
