// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelFactoryTypeProvider : TypeProvider
    {
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }
        public IEnumerable<SchemaObjectType> Models { get; }
        public string DefaultClientName { get; }

        public ModelFactoryTypeProvider(BuildContext context, IEnumerable<SchemaObjectType> models) : base(context)
        {
            Models = models;

            DefaultClientName = ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context);
            DefaultName = $"{DefaultClientName}ModelFactory";
            DefaultAccessibility = "public";
        }

        public static ModelFactoryTypeProvider? TryCreate(BuildContext context, IEnumerable<TypeProvider> models)
        {
            var schemaObjectTypes = models.OfType<SchemaObjectType>()
                .Where(RequiresModelFactory)
                .ToArray();

            return schemaObjectTypes.Any() ? new ModelFactoryTypeProvider(context, schemaObjectTypes) : default;
        }

        private static bool RequiresModelFactory(SchemaObjectType model)
        {
            if (model.Declaration.Accessibility != "public" || !model.IncludeDeserializer || model.Declaration.IsAbstract)
            {
                return false;
            }

            var readOnlyProperties = model.Properties
                .Where(p => p.IsReadOnly && !TypeFactory.IsReadWriteDictionary(p.ValueType) && !TypeFactory.IsReadWriteList(p.ValueType))
                .ToList();

            if (!readOnlyProperties.Any())
            {
                return false;
            }

            if (model.SerializationConstructor.Signature.Parameters.Any(p => !p.Type.IsPublic))
            {
                return false;
            }

            return model.Constructors
                .Where(c => c.Signature.Modifiers == "public")
                .All(c => readOnlyProperties.Any(property => c.FindParameterByInitializedProperty(property) == default));
        }
    }
}
