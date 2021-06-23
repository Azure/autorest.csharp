// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class ModelFactoryWriter
    {
        public static void WriteModelFactory(CodeWriter writer, ModelFactoryTypeProvider modelFactoryType)
        {
            using (writer.Namespace(modelFactoryType.Type.Namespace))
            {
                writer.WriteXmlDocumentationSummary($"Model factory for read-only models.");
                using (writer.Scope($"{modelFactoryType.Declaration.Accessibility} static partial class {modelFactoryType.Type.Name}"))
                {
                    foreach (var model in modelFactoryType.Models)
                    {
                        WriteFactoryMethodForSchemaObjectType(writer, model);
                        writer.Line();
                    }
                }
            }
        }

        private static void WriteFactoryMethodForSchemaObjectType(CodeWriter writer, SchemaObjectType objectType)
        {
            var parameters = objectType.SerializationConstructor.Signature.Parameters;
            writer.WriteXmlDocumentationSummary($"Initializes new instance of {objectType.Type.Name} {(objectType.IsStruct ? "structure" : "class")}.");
            foreach (var parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }
            writer.WriteXmlDocumentationRequiredParametersException(parameters);
            writer.WriteXmlDocumentationReturns($"A new <see cref=\"{objectType.Declaration.Namespace}.{objectType.Type.Name}\"/> instance for mocking.");

            writer.Append($"public static {objectType.Type} {objectType.Type.Name}(");
            foreach (var parameter in parameters)
            {
                writer.WriteParameter(parameter, enforceDefaultValue: true, parameterInPublicMethod: true);
            }
            writer.RemoveTrailingComma();
            writer.Append($")");

            using (writer.Scope())
            {
                var ctorParameterNames = new List<string>();
                foreach (var parameter in parameters)
                {
                    var ctorParameterName = parameter.Name;
                    if (parameter.DefaultValue != null && !TypeFactory.CanBeInitializedInline(parameter.Type, parameter.DefaultValue))
                    {
                        writer.Append($"{parameter.Name} ??= ");
                        writer.WriteConstant(parameter.DefaultValue.Value);
                        writer.Line($";");
                    }
                    else if (TypeFactory.IsDictionary(parameter.Type))
                    {
                        writer.Line($"{parameter.Name} ??= new {TypeFactory.GetImplementationType(parameter.Type)}();");
                    }
                    else if (TypeFactory.IsList(parameter.Type))
                    {
                        ctorParameterName = $"{parameter.Name}List";
                        writer.UseNamespace(typeof(System.Linq.Enumerable).Namespace!);
                        writer.Line($"var {ctorParameterName} = {parameter.Name}?.ToList() ?? new {TypeFactory.GetImplementationType(parameter.Type)}();");
                    }

                    ctorParameterNames.Add(ctorParameterName);
                }

                writer.Append($"return new {objectType.Type}(");
                foreach (var ctorParameterName in ctorParameterNames)
                {
                    writer.Identifier(ctorParameterName).AppendRaw(", ");
                }
                writer.RemoveTrailingComma();
                writer.Append($");");
                writer.Line();
            }
        }
    }
}
