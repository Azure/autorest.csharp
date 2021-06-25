// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Output.Models;
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
                    foreach (var method in modelFactoryType.Methods)
                    {
                        WriteFactoryMethodForSchemaObjectType(writer, method);
                        writer.Line();
                    }
                }
            }
        }

        private static void WriteFactoryMethodForSchemaObjectType(CodeWriter writer, MethodSignature method)
        {
            var modelType = method.ReturnType?.Implementation as SchemaObjectType;
            Debug.Assert(modelType != null);

            var ctor = modelType.SerializationConstructor;
            var initializers = method.Parameters
                .Select(p => new PropertyInitializer(ctor.FindPropertyInitializedByParameter(p)!, w => w.Append($"{p.Name}"), p.Type));

            using (writer.WriteMethodDeclaration(method))
            {
                writer.WriteParameterNullChecks(method.Parameters);
                writer.WriteInitialization((w, v) => w.Line($"return {v};"), modelType, ctor, initializers);
            }
        }
    }
}
