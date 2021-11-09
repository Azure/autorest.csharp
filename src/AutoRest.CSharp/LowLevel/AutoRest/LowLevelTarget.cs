// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class LowLevelTarget
    {
        public static void Execute(GeneratedCodeWorkspace project, CodeModel codeModel, SourceInputModel? sourceInputModel, Configuration configuration)
        {
            var context = new BuildContext<LowLevelOutputLibrary>(codeModel, configuration, sourceInputModel);
            var subClientsMap = context.Library.RestClients
                .Where(c => c.ParentClientTypeName != null)
                .GroupBy(c => c.ParentClientTypeName!)
                .ToDictionary(g => g.Key, g => g.ToArray());

            foreach (var client in context.Library.RestClients)
            {
                var codeWriter = new CodeWriter();
                var lowLevelClientWriter = new LowLevelClientWriter();
                lowLevelClientWriter.WriteClient(codeWriter, client, subClientsMap.TryGetValue(client.Type.Name, out var subClients) ? subClients : Array.Empty<LowLevelRestClient>(), context);
                project.AddGeneratedFile($"{client.Type.Name}.cs", codeWriter.ToString());
            }

            var optionsWriter = new CodeWriter();
            ClientOptionsWriter.WriteClientOptions(optionsWriter, context.Library.ClientOptions);
            project.AddGeneratedFile($"{context.Library.ClientOptions.Type.Name}.cs", optionsWriter.ToString());
        }
    }
}
