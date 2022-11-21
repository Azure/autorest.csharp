// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using Configuration = AutoRest.CSharp.Input.Configuration;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelFactoryTypeProvider : TypeProvider
    {
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }
        public IEnumerable<MethodSignature> Methods { get; }

        public string FullName => $"{Type.Namespace}.{Type.Name}";

        private ModelFactoryTypeProvider(IEnumerable<MethodSignature> methods, string defaultClientName, string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            Methods = methods;

            DefaultName = $"{defaultClientName}ModelFactory".ToCleanName();
            DefaultAccessibility = "public";
        }

        public static ModelFactoryTypeProvider? TryCreate(string rootNamespaceName, IEnumerable<TypeProvider> models, SourceInputModel? sourceInputModel)
        {
            var schemaObjectTypes = models.OfType<SchemaObjectType>()
                .Where(RequiresModelFactory)
                .ToArray();

            if (!schemaObjectTypes.Any())
            {
                return null;
            }

            var defaultClientName = ClientBuilder.GetClientPrefix(Configuration.LibraryName, rootNamespaceName);
            var defaultNamespace = GetDefaultModelNamespace(null, rootNamespaceName);

            return new ModelFactoryTypeProvider(schemaObjectTypes.Select(CreateMethod), defaultClientName, defaultNamespace, sourceInputModel);
        }

        private static MethodSignature CreateMethod(SchemaObjectType modelType)
        {
            var ctor = modelType.SerializationConstructor.Signature;
            var methodParameters = new Parameter[ctor.Parameters.Count];

            for (var i = 0; i < ctor.Parameters.Count; i++)
            {
                var ctorParameter = ctor.Parameters[i];
                var inputType = TypeFactory.GetInputType(ctorParameter.Type);
                if (!inputType.IsValueType)
                {
                    inputType = inputType.WithNullable(true);
                }

                methodParameters[i] = ctorParameter with
                {
                    Type = inputType,
                    DefaultValue = Constant.Default(inputType),
                    Initializer = inputType.GetParameterInitializer(ctorParameter.DefaultValue)
                };
            }

            FormattableString returnDescription = $"A new <see cref=\"{modelType.Declaration.Namespace}.{modelType.Declaration.Name}\"/> instance for mocking.";
            return new MethodSignature(ctor.Name, ctor.Summary, ctor.Description, Public | Static, modelType.Type, returnDescription, methodParameters);
        }

        private static bool RequiresModelFactory(SchemaObjectType model)
        {
            if (model.Declaration.Accessibility != "public" || !model.IncludeDeserializer || model.Declaration.IsAbstract)
            {
                return false;
            }

            if (model.Properties.Any(p => p.Declaration.Accessibility != "public" && p.SchemaProperty?.IsDiscriminator != true))
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
                .Where(c => c.Signature.Modifiers.HasFlag(Public))
                .All(c => readOnlyProperties.Any(property => c.FindParameterByInitializedProperty(property) == default));
        }
    }
}
