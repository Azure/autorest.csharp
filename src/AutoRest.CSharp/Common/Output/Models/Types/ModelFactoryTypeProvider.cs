// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using Configuration = AutoRest.CSharp.Input.Configuration;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelFactoryTypeProvider : TypeProvider
    {
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }

        private IEnumerable<MethodSignature>? _methods;
        public IEnumerable<MethodSignature> Methods => _methods ??= Models.Select(CreateMethod);

        public IEnumerable<SerializableObjectType> Models { get; }

        internal string FullName => $"{Type.Namespace}.{Type.Name}";

        private ModelFactoryTypeProvider(IEnumerable<SerializableObjectType> objectTypes, string defaultClientName, string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            Models = objectTypes;

            DefaultName = $"{defaultClientName}ModelFactory".ToCleanName();
            DefaultAccessibility = "public";
        }

        public static ModelFactoryTypeProvider? TryCreate(string rootNamespaceName, IEnumerable<TypeProvider> models, SourceInputModel? sourceInputModel)
        {
            var objectTypes = models.OfType<SerializableObjectType>()
                .Where(RequiresModelFactory)
                .ToArray();

            if (!objectTypes.Any())
            {
                return null;
            }

            var defaultClientName = ClientBuilder.GetClientPrefix(Configuration.LibraryName, rootNamespaceName);
            var defaultNamespace = GetDefaultModelNamespace(null, rootNamespaceName);

            return new ModelFactoryTypeProvider(objectTypes, defaultClientName, defaultNamespace, sourceInputModel);
        }

        public (ObjectTypeProperty Property, FormattableString Assignment) GetPropertyAssignment(SerializableObjectType model, Parameter parameter)
        {
            var propertyStackDict = _parameterPropertyCache[model];
            var propertyStack = propertyStackDict[parameter];
            var assignmentProperty = propertyStack.Last();
            propertyStack.Pop();
            FormattableString result = $"{parameter.Name:I}";
            while (propertyStack.Count > 0)
            {
                var property = propertyStack.Pop();
                result = $"new {property.ValueType}({result})"; // TODO -- append the conversion
            }

            return (assignmentProperty, result);
        }

        private static string GetConversion(CodeWriter writer, CSharpType from, CSharpType to)
        {
            if (TypeFactory.RequiresToList(from, to))
            {
                writer.UseNamespace(typeof(Enumerable).Namespace!);
                return from.IsNullable ? "?.ToList()" : ".ToList()";
            }

            return string.Empty;
        }

        private readonly Dictionary<SerializableObjectType, Dictionary<Parameter, Stack<ObjectTypeProperty>>> _parameterPropertyCache = new();

        private MethodSignature CreateMethod(SerializableObjectType modelType)
        {
            var ctor = modelType.SerializationConstructor;
            var ctorSignature = ctor.Signature;
            var methodParameters = new List<Parameter>(ctorSignature.Parameters.Count);
            var cache = new Dictionary<Parameter, Stack<ObjectTypeProperty>>();

            foreach (var ctorParameter in ctorSignature.Parameters)
            {
                var property = ctor.FindPropertyInitializedByParameter(ctorParameter);
                if (property == null)
                    continue;

                (var parameterName, var propertyStack) = GetPropertyStack(property);

                // need to check the corresponding property
                var inputType = TypeFactory.GetInputType(propertyStack.Peek().Declaration.Type);
                if (!inputType.IsValueType)
                {
                    inputType = inputType.WithNullable(true);
                }

                var modelFactoryMethodParameter = ctorParameter with
                {
                    Name = parameterName,
                    Type = inputType,
                    DefaultValue = Constant.Default(inputType),
                    Initializer = inputType.GetParameterInitializer(ctorParameter.DefaultValue)
                };

                methodParameters.Add(modelFactoryMethodParameter);
                cache.Add(modelFactoryMethodParameter, propertyStack);
            }

            _parameterPropertyCache.Add(modelType, cache);

            FormattableString returnDescription = $"A new <see cref=\"{modelType.Declaration.Namespace}.{modelType.Declaration.Name}\"/> instance for mocking.";

            return new MethodSignature(ctorSignature.Name, ctorSignature.Summary, ctorSignature.Description, Public | Static, modelType.Type, returnDescription, methodParameters);
        }

        private (string ParameterName, Stack<ObjectTypeProperty> HierarchyStack) GetPropertyStack(ObjectTypeProperty property)
        {
            if (Configuration.AzureArm)
            {
                var hierarchyStack = property.GetHierarchyStack();

                return (GetPropertyName(hierarchyStack), hierarchyStack);
            }

            var stack = new Stack<ObjectTypeProperty>();
            stack.Push(property);
            return (property.Declaration.Name, stack);
        }

        private string GetPropertyName(Stack<ObjectTypeProperty> hierarchyStack)
        {
            if (hierarchyStack.Count > 1)
            {
                var innerProperty = hierarchyStack.Pop();
                var immediateParent = hierarchyStack.Pop();
                var parameterName = innerProperty.GetCombinedPropertyName(immediateParent).ToVariableName();
                hierarchyStack.Push(immediateParent);
                hierarchyStack.Push(innerProperty);

                return parameterName;
            }

            return hierarchyStack.Peek().Declaration.Name.ToVariableName();
        }

        private static bool RequiresModelFactory(SerializableObjectType model)
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
