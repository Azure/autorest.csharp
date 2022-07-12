// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelFactoryTypeProvider : TypeProvider
    {
        protected override string DefaultName { get; }
        protected override string DefaultNamespace { get; }
        protected override string DefaultAccessibility { get; }
        public IEnumerable<MethodSignature> Methods { get; }
        public string DefaultClientName { get; }

        public ModelFactoryTypeProvider(BuildContext context, IEnumerable<MethodSignature> methods) : this(context, methods, ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context)) { }

        private ModelFactoryTypeProvider(BuildContext context, IEnumerable<MethodSignature> methods, string defaultClientName) : base(context)
        {
            Methods = methods;

            DefaultName = $"{defaultClientName}ModelFactory";
            DefaultNamespace = GetDefaultNamespace(default, context);
            DefaultClientName = defaultClientName;
            DefaultAccessibility = "public";
        }

        public static ModelFactoryTypeProvider? TryCreate(BuildContext context, IEnumerable<TypeProvider> models)
        {
            var schemaObjectTypes = models.OfType<SchemaObjectType>()
                .Where(RequiresModelFactory)
                .ToArray();

            return schemaObjectTypes.Any() ? new ModelFactoryTypeProvider(context, schemaObjectTypes.Select(CreateMethod)) : null;
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
                    Initializer = Parameter.GetParameterInitializer(inputType, ctorParameter.DefaultValue)
                };
            }

            FormattableString returnDescription = $"A new <see cref=\"{modelType.Declaration.Namespace}.{modelType.Declaration.Name}\"/> instance for mocking.";
            return new MethodSignature(ctor.Name, ctor.Description, ctor.Summary, Public | Static, modelType.Type, returnDescription, methodParameters);
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
