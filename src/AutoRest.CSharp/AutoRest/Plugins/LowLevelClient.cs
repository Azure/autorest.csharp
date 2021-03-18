// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class LowLevelClient
    {
        public static void ExecuteAsync(GeneratedCodeWorkspace project, BuildContext context, Configuration configuration)
        {
            foreach (var client in context.Library.Clients)
            {
                var codeWriter = new CodeWriter();
                var lowLevelClientWriter = new LowLevelClientWriter ();
                lowLevelClientWriter.WriteClient(codeWriter, client, context);
                project.AddGeneratedFile($"{client.Type.Name}.cs", codeWriter.ToString());
            }

            foreach (var model in context.Library.Models.Where(x => x.Type.Implementation is EnumType))
            {
                var codeWriter = new CodeWriter();
                var modelWriter = new ModelWriter();
                modelWriter.WriteModel(codeWriter, model);

                var name = model.Type.Name;
                project.AddGeneratedFile($"Models/{name}.cs", codeWriter.ToString());
            }
        }
    }
}
