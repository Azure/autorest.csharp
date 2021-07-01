// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelFactoryTypeProvider : TypeProvider
    {
        protected override string DefaultName { get; }
        protected override string DefaultNamespace { get; }
        protected override string DefaultAccessibility { get; }
        public IEnumerable<MethodSignature> Methods { get; }
        public string DefaultClientName { get; }

        private ModelFactoryTypeProvider(BuildContext context, IEnumerable<MethodSignature> methods) : base(context)
        {
            Methods = methods;

            DefaultClientName = ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context);
            DefaultName = $"{DefaultClientName}ModelFactory";
            DefaultNamespace = GetDefaultNamespace(default, context);
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
            var methodParameters = new Parameter[ctor.Parameters.Length];

            for (var i = 0; i < ctor.Parameters.Length; i++)
            {
                var ctorParameter = ctor.Parameters[i];
                var inputType = TypeFactory.GetInputType(ctorParameter.Type);
                var implementationType = ctorParameter.DefaultValue?.Type ?? TypeFactory.GetImplementationType(inputType);
                if (!inputType.IsValueType)
                {
                    inputType = inputType.WithNullable(true);
                }

                var defaultValue = GetDefaultValue(inputType, implementationType, ctorParameter.DefaultValue);

                var methodParameter = new Parameter(
                    ctorParameter.Name,
                    ctorParameter.Description,
                    inputType,
                    defaultValue,
                    ctorParameter.ValidateNotNull,
                    ctorParameter.IsApiVersionParameter
                );

                methodParameters[i] = methodParameter;
            }

            var returnDescription = $"A new <see cref=\"{modelType.Declaration.Namespace}.{modelType.Declaration.Name}\"/> instance for mocking.";
            return new MethodSignature(ctor.Name, ctor.Description, "public static", modelType.Type, returnDescription, methodParameters);

            static Constant GetDefaultValue(CSharpType inputType, CSharpType implementationType, Constant? defaultValue)
            {
                // Special case for strings
                if (inputType.Equals(typeof(string)))
                {
                    return Constant.Default(inputType.WithNullable(true));
                }

                // Use default value if it is provided
                if (defaultValue != null)
                {
                    return defaultValue.Value;
                }

                // Non-null value types must be instantiated
                if (inputType.IsValueType && !inputType.IsNullable)
                {
                    return Constant.NewInstanceOf(implementationType);
                }

                // Collections must be instantiated
                if (TypeFactory.IsCollectionType(inputType))
                {
                    return Constant.NewInstanceOf(implementationType.WithNullable(false));
                }

                // Return typed null for everything else
                return Constant.Default(implementationType.WithNullable(true));
            }
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
                .Where(c => c.Signature.Modifiers == "public")
                .All(c => readOnlyProperties.Any(property => c.FindParameterByInitializedProperty(property) == default));
        }
    }
}
