// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class LowLevelTarget
    {
        public static void Execute(GeneratedCodeWorkspace project, InputNamespace inputNamespace, SourceInputModel? sourceInputModel, bool cadlInput)
        {
            var library = new DpgOutputLibraryBuilder(inputNamespace, sourceInputModel).Build(cadlInput);

            foreach (var enumType in library.Enums)
            {
                if (enumType.IsExtensible)
                {
                    var codeWriter = new CodeWriter();
                    ModelWriter.WriteExtendableEnum(codeWriter, enumType);
                    project.AddGeneratedFile($"{enumType.Type.Name}.cs", codeWriter.ToString());
                }
                else
                {
                    var codeWriter = new CodeWriter();
                    ModelWriter.WriteEnum(codeWriter, enumType);
                    project.AddGeneratedFile($"{enumType.Type.Name}.cs", codeWriter.ToString());

                    var serializationWriter = new CodeWriter();
                    SerializationWriter.WriteEnumSerialization(serializationWriter, enumType);
                    project.AddGeneratedFile($"{enumType.Type.Name}.Serialization.cs", serializationWriter.ToString());
                }
            }

            foreach (var model in library.Models)
            {
                var codeWriter = new CodeWriter();
                LowLevelModelWriter.WriteType(codeWriter, model);
                project.AddGeneratedFile($"{model.Type.Name}.cs", codeWriter.ToString());

                var serializationWriter = new CodeWriter();
                SerializationWriter.WriteModelSerialization(serializationWriter, model);
                project.AddGeneratedFile($"{model.Type.Name}.Serialization.cs", serializationWriter.ToString());
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
