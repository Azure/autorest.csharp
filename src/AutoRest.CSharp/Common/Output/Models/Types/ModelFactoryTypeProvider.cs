// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Models;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelFactoryTypeProvider : TypeProvider
    {
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }

        private IEnumerable<MethodSignature>? _methods;
        public IEnumerable<MethodSignature> Methods => _methods ??= Models.Select(CreateMethod);

        public IEnumerable<SerializableObjectType> Models { get; }

        public FormattableString Description => $"Model factory for generated models.";

        internal string FullName => $"{Type.Namespace}.{Type.Name}";

        private ModelFactoryTypeProvider(IEnumerable<SerializableObjectType> objectTypes, string defaultClientName, string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            Models = objectTypes;

            DefaultName = $"{defaultClientName}ModelFactory".ToCleanName();
            DefaultAccessibility = "public";
        }

        public static ModelFactoryTypeProvider? TryCreate(string defaultLibraryName, string rootNamespaceName, IEnumerable<TypeProvider> models, SourceInputModel? sourceInputModel)
        {
            var objectTypes = models.OfType<SerializableObjectType>()
                .Where(RequiresModelFactory)
                .ToArray();

            if (!objectTypes.Any())
            {
                return null;
            }

            var defaultClientName = ClientBuilder.GetClientPrefix(Configuration.LibraryName, defaultLibraryName);
            var defaultNamespace = GetDefaultModelNamespace(null, rootNamespaceName);

            return new ModelFactoryTypeProvider(objectTypes, defaultClientName, defaultNamespace, sourceInputModel);
        }

        private HashSet<MethodInfo>? _existingModelFactoryMethods;
        public HashSet<MethodInfo> ExistingModelFactoryMethods => _existingModelFactoryMethods ??= typeof(ResourceManagerModelFactory).GetMethods(BindingFlags.Static | BindingFlags.Public).ToHashSet();

        public (ObjectTypeProperty Property, FormattableString Assignment) GetPropertyAssignment(CodeWriter writer, SerializableObjectType model, Parameter parameter)
        {
            var propertyStack = _parameterPropertyCache[model][parameter];
            var assignmentProperty = propertyStack.Last();

            // determine whether this is a value type that changed to nullable because of other enclosing properties are nullable
            var isOverriddenValueType = assignmentProperty.FlattenedProperty != null && assignmentProperty.FlattenedProperty.IsOverriddenValueType;

            // iterate over the property stack to build a nested expression of variable assignment
            ObjectTypeProperty property, immediateParentProperty;
            property = propertyStack.Pop();
            FormattableString result = $"{parameter.Name:I}";

            if (isOverriddenValueType)
                result = $"{result}.Value";

            CSharpType from = parameter.Type;
            while (propertyStack.Count > 0)
            {
                immediateParentProperty = propertyStack.Pop();
                var parentPropertyType = immediateParentProperty.Declaration.Type;
                switch (parentPropertyType)
                {
                    case { IsFrameworkType: false, Implementation: SerializableObjectType serializableObjectType }:
                        // get the type of the first parameter of its ctor
                        var to = serializableObjectType.SerializationConstructor.Signature.Parameters.First().Type;
                        result = $"new {parentPropertyType}({result}{CodeWriterExtensions.GetConversion(writer, from, to)})";
                        break;
                    case { IsFrameworkType: false, Implementation: SystemObjectType systemObjectType }:
                        // for the case of SystemObjectType, the serialization constructor is internal and the definition of this class might be outside of this assembly, we need to use its corresponding model factory to construct it
                        // find the method in the list
                        var method = ExistingModelFactoryMethods.First(m => m.Name == systemObjectType.Type.Name);
                        result = $"{method.DeclaringType!}.{method.Name}({result})";
                        break;
                    default:
                        throw new InvalidOperationException($"The propertyType {parentPropertyType} (implementation type: {parentPropertyType.Implementation.GetType()}) is unhandled here, this should never happen");
                }

                // change the from type to the current type
                property = immediateParentProperty;
                from = parentPropertyType; // since this is the property type of the immediate parent property, we should never get another valid conversion
            }

            if (assignmentProperty.FlattenedProperty != null)
            {
                if (isOverriddenValueType)
                    result = $"{parameter.Name:I}.HasValue ? {result} : null";
                else if (parameter.Type.IsNullable)
                    result = $"{parameter.Name:I} != null ? {result} : null";
            }

            return (assignmentProperty, result);
        }

        private readonly Dictionary<SerializableObjectType, Dictionary<Parameter, Stack<ObjectTypeProperty>>> _parameterPropertyCache = new();

        private MethodSignature CreateMethod(SerializableObjectType modelType)
        {
            var ctor = modelType.SerializationConstructor;
            var ctorSignature = ctor.Signature;
            var methodParameters = new List<Parameter>(ctorSignature.Parameters.Count);
            var cache = new Dictionary<Parameter, Stack<ObjectTypeProperty>>();

            var discriminator = modelType.Discriminator;

            foreach (var ctorParameter in ctorSignature.Parameters)
            {
                var property = ctor.FindPropertyInitializedByParameter(ctorParameter);
                if (property == null)
                    continue;

                if (property.FlattenedProperty != null)
                    property = property.FlattenedProperty;

                var parameterName = property.Declaration.Name.ToVariableName();
                var inputType = property.Declaration.Type;
                Constant? overriddenDefaultValue = null;
                // check if the property is the discriminator, but skip the check if the configuration is on for HLC only
                if (discriminator != null && discriminator.Property == property && !Configuration.ModelFactoryForHlc.Contains(modelType.Declaration.Name))
                {
                    var value = discriminator.Value;
                    if (value != null)
                    {
                        // this is a derived class
                        continue;
                    }
                    else
                    {
                        // this is the base
                        if (inputType.TryCast<EnumType>(out var enumType))
                        {
                            inputType = enumType.ValueType;
                            overriddenDefaultValue = new Constant("Unknown", inputType);
                        }
                    }
                }

                inputType = TypeFactory.GetInputType(inputType);
                if (!inputType.IsValueType)
                {
                    inputType = inputType.WithNullable(true);
                }

                var modelFactoryMethodParameter = ctorParameter with
                {
                    Name = parameterName,
                    Type = inputType,
                    DefaultValue = overriddenDefaultValue ?? Constant.Default(inputType),
                    Initializer = inputType.GetParameterInitializer(ctorParameter.DefaultValue)
                };

                methodParameters.Add(modelFactoryMethodParameter);
                cache.Add(modelFactoryMethodParameter, property.BuildHierarchyStack());
            }

            _parameterPropertyCache.Add(modelType, cache);

            FormattableString returnDescription = $"A new <see cref=\"{modelType.Declaration.Namespace}.{modelType.Declaration.Name}\"/> instance for mocking.";

            return new MethodSignature(ctorSignature.Name, ctorSignature.Summary, ctorSignature.Description, Public | Static, modelType.Type, returnDescription, methodParameters);
        }

        private static bool RequiresModelFactory(SerializableObjectType model)
        {
            if (model.Declaration.Accessibility != "public" || !model.IncludeDeserializer)
            {
                return false;
            }

            if (model.Declaration.IsAbstract && model.Discriminator == null)
            {
                return false;
            }

            var properties = model.EnumerateHierarchy().SelectMany(obj => obj.Properties);
            // we skip the models with internal properties when the internal property is neither a discriminator or safe flattened
            if (properties.Any(p => p.Declaration.Accessibility != "public" && (model.Discriminator?.Property != p && p.FlattenedProperty == null)))
            {
                return false;
            }

            if (!properties.Any(p => p.IsReadOnly && !TypeFactory.IsReadWriteDictionary(p.ValueType) && !TypeFactory.IsReadWriteList(p.ValueType)))
            {
                return false;
            }

            if (model.SerializationConstructor.Signature.Parameters.Any(p => !p.Type.IsPublic))
            {
                return false;
            }

            return model.Constructors
                .Where(c => c.Signature.Modifiers.HasFlag(Public))
                .All(c => properties.Any(property => c.FindParameterByInitializedProperty(property) == default));
        }
    }
}
