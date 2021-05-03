// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class ModelFactoryWriter
    {
        public static IReadOnlyCollection<ObjectType> ObjectTypesThatRequireFactory(IEnumerable<TypeProvider> models)
            => models.OfType<ObjectType>().Where(ObjectTypeRequiresFactory).ToArray();

        public static string WriteModelFactory(CodeWriter writer, BuildContext context, IEnumerable<ObjectType> objectTypes)
        {
            var clientPrefix = ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context);
            var modelFactoryName = $"{clientPrefix}ModelFactory";
            var @namespace = context.DefaultNamespace;

            writer.UseNamespace("System.Linq");
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary($"Model factory for {clientPrefix} read-only models.");
                using (writer.Class(modelFactoryName, isStatic: true))
                {
                    foreach (var objectType in objectTypes)
                    {
                        WriteFactoryMethodForObjectType(writer, objectType);
                        writer.Line();
                    }
                }
            }

            return modelFactoryName;
        }

        private static void WriteFactoryMethodForObjectType(CodeWriter writer, ObjectType objectType)
        {
            var methodName = objectType.Type.Name;
            var documentationSummary = $"Initializes new instance of {objectType.Type.Name} {(objectType.IsStruct ? "structure" : "class")}.";
            var documentationReturns = $"A new <see cref=\"{objectType.Declaration.Namespace}.{objectType.Type.Name}\"/> instance for mocking.";
            var parameters = objectType.SerializationConstructor.Parameters;
            using (writer.Method(methodName, documentationSummary, returnType: objectType.Type, documentationReturns: documentationReturns, isStatic: true, parameters: parameters))
            {
                writer.Line($"return new {objectType.Type}({string.Join(", ", parameters.Select(p => p.Name))});");
            }
        }

        private static bool ObjectTypeRequiresFactory(ObjectType objectType)
        {
            if (objectType.Declaration.Accessibility != "public" || !objectType.IncludeDeserializer)
            {
                return false;
            }

            var readOnlyProperties = objectType.Properties
                .Where(p => p.IsReadOnly && !TypeFactory.IsReadWriteDictionary(p.ValueType) && !TypeFactory.IsReadWriteList(p.ValueType))
                .ToList();

            if (!readOnlyProperties.Any())
            {
                return false;
            }

            return objectType.Constructors
                .Where(c => c.Declaration.Accessibility == "public")
                .All(c => readOnlyProperties.Any(property => c.FindParameterByInitializedProperty(property) == default));
        }
    }
}
