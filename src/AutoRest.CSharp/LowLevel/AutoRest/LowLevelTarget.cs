// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class LowLevelTarget
    {
        public static void Execute(GeneratedCodeWorkspace project, InputNamespace inputNamespace, SourceInputModel? sourceInputModel, bool cadlInput)
        {
            var library = new DpgOutputLibraryBuilder(inputNamespace, sourceInputModel).Build(cadlInput);
            foreach (var model in library.Models)
            {
                var codeWriter = new CodeWriter();
                LowLevelModelWriter.WriteModel(codeWriter, model);
                project.AddGeneratedFile($"{model.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var client in library.RestClients)
            {
                var codeWriter = new CodeWriter();
                var lowLevelClientWriter = new LowLevelClientWriter();
                lowLevelClientWriter.WriteClient(codeWriter, client);
                project.AddGeneratedFile($"{client.Type.Name}.cs", codeWriter.ToString());
            }

            var optionsWriter = new CodeWriter();
            ClientOptionsWriter.WriteClientOptions(optionsWriter, library.ClientOptions);
            project.AddGeneratedFile($"{library.ClientOptions.Type.Name}.cs", optionsWriter.ToString());
        }
    }
}
