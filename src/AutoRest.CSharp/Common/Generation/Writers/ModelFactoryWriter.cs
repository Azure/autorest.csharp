// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class ModelFactoryWriter
    {
        public static string WriteModelFactory(CodeWriter writer, BuildContext context, IEnumerable<SchemaObjectType> objectTypes)
        {
            var clientPrefix = ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context);
            var modelFactoryName = $"{clientPrefix}ModelFactory";
            var @namespace = context.DefaultNamespace;

            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary($"Model factory for {clientPrefix} read-only models.");
                using (writer.Scope($"public static partial class {modelFactoryName}"))
                {
                    foreach (var objectType in objectTypes)
                    {
                        WriteFactoryMethodForSchemaObjectType(writer, objectType);
                        writer.Line();
                    }
                }
            }

            return modelFactoryName;
        }

        private static void WriteFactoryMethodForSchemaObjectType(CodeWriter writer, SchemaObjectType objectType)
        {
            var parameters = objectType.SerializationConstructor.Parameters;
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
                writer.WriteParameter(parameter, enforceDefaultValue: true);
            }
            writer.RemoveTrailingComma();
            writer.Append($")");

            using (writer.Scope())
            {
                foreach (var parameter in parameters)
                {
                    if (parameter.DefaultValue != null && !TypeFactory.CanBeInitializedInline(parameter.Type, parameter.DefaultValue))
                    {
                        writer.Line($"{parameter.Name} ??= {parameter.DefaultValue}");
                    }
                    else if (TypeFactory.IsDictionary(parameter.Type))
                    {
                        writer.Line($"{parameter.Name} ??= new Dictionary<{parameter.Type.Arguments[0]}, {parameter.Type.Arguments[1]}>();");
                    }
                    else if (TypeFactory.IsList(parameter.Type))
                    {
                        writer.Line($"{parameter.Name} ??= new List<{parameter.Type.Arguments[0]}>();");
                    }
                }

                writer.Append($"return new {objectType.Type}(");
                foreach (var parameter in parameters)
                {
                    writer.Identifier(parameter.Name);
                    writer.AppendRaw(", ");
                }
                writer.RemoveTrailingComma();
                writer.Append($");");
                writer.Line();
            }
        }
    }
}
