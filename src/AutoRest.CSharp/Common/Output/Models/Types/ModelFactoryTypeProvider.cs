// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Expressions.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core.Expressions.DataFactory;
using Azure.ResourceManager.Models;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelFactoryTypeProvider : TypeProvider
    {
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }

        private IEnumerable<Method>? _methods;
        public IEnumerable<Method> Methods => _methods ??= Models.Select(CreateMethod);

        public IEnumerable<SerializableObjectType> Models { get; }

        public FormattableString Description => $"Model factory for models.";

        internal string FullName => $"{Type.Namespace}.{Type.Name}";

        private ModelFactoryTypeProvider(IEnumerable<SerializableObjectType> objectTypes, string defaultClientName, string defaultNamespace, SourceInputModel? sourceInputModel) : base(defaultNamespace, sourceInputModel)
        {
            Models = objectTypes;

            DefaultName = $"{defaultClientName}ModelFactory".ToCleanName();
            DefaultAccessibility = "public";
            ExistingModelFactoryMethods = typeof(ResourceManagerModelFactory).GetMethods(BindingFlags.Static | BindingFlags.Public).ToHashSet();
            ExistingModelFactoryMethods.UnionWith(typeof(DataFactoryModelFactory).GetMethods(BindingFlags.Static | BindingFlags.Public).ToHashSet());
        }

        public static ModelFactoryTypeProvider? TryCreate(IEnumerable<TypeProvider> models, SourceInputModel? sourceInputModel)
        {
            if (!Configuration.GenerateModelFactory)
                return null;

            var objectTypes = models.OfType<SerializableObjectType>()
                .Where(RequiresModelFactory)
                .ToArray();

            if (!objectTypes.Any())
            {
                return null;
            }

            var defaultNamespace = GetDefaultNamespace();
            var defaultRPName = GetRPName(defaultNamespace);

            defaultNamespace = GetDefaultModelNamespace(null, defaultNamespace);

            return new ModelFactoryTypeProvider(objectTypes, defaultRPName, defaultNamespace, sourceInputModel);
        }

        public static string GetRPName(string defaultNamespace)
        {
            // for mgmt plane packages, we always have the prefix `Arm` on the name of model factories, except for Azure.ResourceManager
            var prefix = Configuration.AzureArm && !Configuration.MgmtConfiguration.IsArmCore ? "Arm" : string.Empty;
            return $"{prefix}{ClientBuilder.GetRPName(defaultNamespace)}";
        }

        private static string GetDefaultNamespace()
        {
            // we have this because the Azure.ResourceManager package is generated using batch, which generates multiple times, and each time Configuration.Namespace has a different value.
            if (Configuration.AzureArm && Configuration.MgmtConfiguration.IsArmCore)
                return "Azure.ResourceManager";

            return Configuration.Namespace;
        }

        public HashSet<MethodInfo> ExistingModelFactoryMethods { get; }

        private ValueExpression BuildPropertyAssignmentExpression(Parameter parameter, ObjectTypeProperty property)
        {
            ValueExpression p = parameter;
            var propertyStack = property.BuildHierarchyStack();

            if (propertyStack.Count == 1)
                return p;

            var assignmentProperty = propertyStack.Last();
            Debug.Assert(assignmentProperty.FlattenedProperty != null);

            // determine whether this is a value type that changed to nullable because of other enclosing properties are nullable
            var isOverriddenValueType = assignmentProperty.FlattenedProperty.IsOverriddenValueType;

            // iterate over the property stack to build a nested expression of variable assignment
            ObjectTypeProperty immediateParentProperty;
            property = propertyStack.Pop();
            // <parameterName> or <parameterName>.Value
            ValueExpression result = isOverriddenValueType
                ? p.NullableStructValue(parameter.Type) // when it is changed to nullable, we call .Value because its constructor will only take the non-nullable value
                : p;

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
                        result = New.Instance(parentPropertyType, result.GetConversion(from, to));
                        break;
                    case { IsFrameworkType: false, Implementation: SystemObjectType systemObjectType }:
                        // for the case of SystemObjectType, the serialization constructor is internal and the definition of this class might be outside of this assembly, we need to use its corresponding model factory to construct it
                        // find the method in the list
                        var method = ExistingModelFactoryMethods.First(m => m.Name == systemObjectType.Type.Name);
                        result = new InvokeStaticMethodExpression(method.DeclaringType!, method.Name, new[] { result });
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
                    result = new TernaryConditionalOperator(
                        p.Property(nameof(Nullable<int>.HasValue)),
                        result,
                        Null);
                else if (parameter.Type.IsNullable)
                    result = new TernaryConditionalOperator(
                        NotEqual(p, Null),
                        result,
                        Null);
            }

            return result;
        }

        private Method CreateMethod(SerializableObjectType model)
        {
            var ctor = model.SerializationConstructor;
            var ctorToCall = ctor;
            var discriminator = model.Discriminator;
            if (model.Declaration.IsAbstract && discriminator != null)
            {
                // the model factory entry method `RequiresModelFactory` makes sure this: if this model is abstract, the discriminator must not be null
                ctorToCall = discriminator.DefaultObjectType.SerializationConstructor;
            }
            var methodParameters = new List<Parameter>(ctor.Signature.Parameters.Count);
            var methodArguments = new List<ValueExpression>(ctor.Signature.Parameters.Count);

            foreach (var ctorParameter in ctorToCall.Signature.Parameters)
            {
                var property = ctorToCall.FindPropertyInitializedByParameter(ctorParameter);
                if (property == null)
                {
                    // if the property is not found, in order not to introduce compilation errors, we need to add a `default` into the argument list
                    methodArguments.Add(Default);
                    continue;
                }

                if (property == model.RawDataField)
                {
                    // we do not want to include the raw data as a parameter of the model factory entry method, therefore here we skip the parameter, and use empty dictionary as argument
                    methodArguments.Add(New.Instance(TypeFactory.GetImplementationType(ctorParameter.Type)));
                    continue;
                }

                if (property.FlattenedProperty != null)
                    property = property.FlattenedProperty;

                var parameterName = property.Declaration.Name.ToVariableName();
                var inputType = property.Declaration.Type;
                Constant? overriddenDefaultValue = null;
                // check if the property is the discriminator, but skip the check if the configuration is on for HLC only
                if (discriminator != null && discriminator.Property == property && !Configuration.ModelFactoryForHlc.Contains(model.Declaration.Name))
                {
                    if (discriminator.Value is { } value)
                    {
                        // this is a derived class, we do not add this parameter to the method, but we need an argument for the invocation
                        methodArguments.Add(new ConstantExpression(value));
                        continue;
                    }
                    // this class is the base in a discriminated set
                    switch (inputType)
                    {
                        case { IsFrameworkType: false, Implementation: EnumType { IsExtensible: true } extensibleEnum }:
                            inputType = extensibleEnum.ValueType;
                            overriddenDefaultValue = new Constant("Unknown", inputType);
                            break;
                        case { IsFrameworkType: false, Implementation: EnumType { IsExtensible: false } }:
                            // we skip the parameter if the discriminator is a sealed choice because we can never pass in a "Unknown" value.
                            // but we still need to add it to the method argument list as a `default`
                            methodArguments.Add(Default);
                            continue;
                        default:
                            break;
                    }
                }

                inputType = TypeFactory.GetInputType(inputType);
                if (!inputType.IsValueType)
                {
                    inputType = inputType.WithNullable(true);
                }

                var parameter = ctorParameter with
                {
                    Name = parameterName,
                    Type = inputType,
                    DefaultValue = overriddenDefaultValue ?? Constant.Default(inputType),
                    Initializer = inputType.GetParameterInitializer(ctorParameter.DefaultValue)
                };

                methodParameters.Add(parameter);

                var expression = BuildPropertyAssignmentExpression(parameter, property).GetConversion(parameter.Type, ctorParameter.Type);
                methodArguments.Add(expression);
            }

            FormattableString returnDescription = $"A new <see cref=\"{model.Type}\"/> instance for mocking.";

            var signature = new MethodSignature(
                ctor.Signature.Name,
                ctor.Signature.Summary,
                ctor.Signature.Description,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type,
                returnDescription,
                methodParameters);

            var methodBody = new MethodBodyStatement[]
            {
                // write the initializers and validations
                new ParameterValidationBlock(methodParameters, true),
                Return(New.Instance(ctorToCall.Signature, methodArguments))
            };

            return new(signature, methodBody);
        }

        private static bool RequiresModelFactory(SerializableObjectType model)
        {
            if (model.Declaration.Accessibility != "public")
            {
                return false;
            }

            if (model.Declaration.IsAbstract && model.Discriminator == null)
            {
                return false;
            }

            var properties = model.EnumerateHierarchy().SelectMany(obj => obj.Properties.Where(p => p != (obj as SerializableObjectType)?.RawDataField));
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
                .Where(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public))
                .All(c => properties.Any(property => c.FindParameterByInitializedProperty(property) == default));
        }
    }
}
