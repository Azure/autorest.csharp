// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static Azure.Core.HttpHeader;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelTypeProvider : SerializableObjectType
    {
        private static readonly Parameter[] _fromResponseParameters = { new Parameter("response", "The response to deserialize the model from.", new CSharpType(typeof(Response)), null, ValidationType.None, null) };
        private MethodSignature FromResponseSignature => new MethodSignature("FromResponse", null, "Deserializes the model from a raw response.", GetFromResponseModifiers(), Type, null, _fromResponseParameters);

        private static readonly Parameter[] _toRequestContentParameters = Array.Empty<Parameter>();
        private MethodSignature ToRequestContentSignature => new MethodSignature("ToRequestContent", null, "Convert into a Utf8JsonRequestContent.", GetToRequestContentModifiers(), typeof(RequestContent), null, _toRequestContentParameters);

        private ModelTypeProviderFields? _fields;
        private ConstructorSignature? _publicConstructor;
        private ConstructorSignature? _serializationConstructor;
        private InputModelType _inputModel;
        private TypeFactory _typeFactory;
        private SourceInputModel? _sourceInputModel;
        private InputModelType[]? _derivedTypes;
        private ObjectType? _defaultDerivedType;

        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }
        public override bool IncludeConverter => false;
        protected override bool IsAbstract => !Configuration.SuppressAbstractBaseClasses.Contains(DefaultName) && _inputModel.DiscriminatorPropertyName is not null;

        public IObjectTypeFields<InputModelProperty> Fields => _fields ??= EnsureFields();
        private ConstructorSignature InitializationConstructorSignature => _publicConstructor ??= EnsurePublicConstructorSignature();
        private ConstructorSignature SerializationConstructorSignature => _serializationConstructor ??= EnsureSerializationConstructorSignature();

        public override ObjectTypeProperty? AdditionalPropertiesProperty => throw new NotImplementedException();

        public bool IsPropertyBag => _inputModel.IsPropertyBag;

        public ModelTypeProvider(InputModelType inputModel, string defaultNamespace, SourceInputModel? sourceInputModel, TypeFactory? typeFactory = null, InputModelType[]? derivedTypes = null, ObjectType? defaultDerivedType = null)
            : base(defaultNamespace, sourceInputModel)
        {
            _typeFactory = typeFactory!;
            _inputModel = inputModel;
            _sourceInputModel = sourceInputModel;
            DefaultName = inputModel.Name;
            DefaultAccessibility = inputModel.Accessibility ?? "public";
            _deprecated = inputModel.Deprecated;
            _derivedTypes = derivedTypes;
            _defaultDerivedType = defaultDerivedType ?? (inputModel.IsUnknownDiscriminatorModel ? this : null);
        }

        private MethodSignatureModifiers GetFromResponseModifiers()
        {
            var signatures = MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static;
            var parent = GetBaseObjectType();
            if (parent is ModelTypeProvider parentModelType)
            {
                if (parentModelType.Methods.Any(m => m.Signature.Name == "FromResponse"))
                    signatures |= MethodSignatureModifiers.New;
            }
            return signatures;
        }

        private MethodSignatureModifiers GetToRequestContentModifiers()
        {
            //TODO if no one inherits from this we can omit the virtual
            var signatures = MethodSignatureModifiers.Internal;
            var parent = GetBaseObjectType();
            if (parent is null)
            {
                signatures |= MethodSignatureModifiers.Virtual;
            }
            else if (parent is ModelTypeProvider parentModelType)
            {
                signatures |= (parentModelType.Methods.Any(m => m.Signature.Name == "ToRequestContent"))
                    ? MethodSignatureModifiers.Override
                    : MethodSignatureModifiers.Virtual;
            }
            return signatures;
        }

        protected override string CreateDescription()
        {
            return _inputModel.Description ?? $"The {_inputModel.Name}.";
        }

        private ModelTypeProviderFields EnsureFields()
        {
            return new ModelTypeProviderFields(_inputModel, _typeFactory, _sourceInputModel?.CreateForModel(ExistingType));
        }

        private ConstructorSignature EnsurePublicConstructorSignature()
        {
            var name = Declaration.Name;
            //get base public ctor params
            GetConstructorParameters(Fields.PublicConstructorParameters, out var fullParameterList, out var parametersToPassToBase, true, CreatePublicConstructorParameter);

            var summary = $"Initializes a new instance of {name}";
            var accessibility = _inputModel.Usage.HasFlag(InputModelTypeUsage.Input)
                ? MethodSignatureModifiers.Public
                : MethodSignatureModifiers.Internal;

            if (_inputModel.DiscriminatorPropertyName is not null)
                accessibility = MethodSignatureModifiers.Protected;

            FormattableString[] baseInitializers = GetInitializersFromParameters(parametersToPassToBase);

            return new ConstructorSignature(
                name,
                summary,
                null,
                accessibility,
                fullParameterList,
                Initializer: new(true, baseInitializers));
        }

        private ConstructorSignature EnsureSerializationConstructorSignature()
        {
            var name = Declaration.Name;

            //get base public ctor params
            GetConstructorParameters(Fields.SerializationParameters, out var fullParameterList, out var parametersToPassToBase, false, CreateSerializationConstructorParameter);

            FormattableString[] baseInitializers = GetInitializersFromParameters(parametersToPassToBase);

            return new ConstructorSignature(
                name,
                $"Initializes a new instance of {name}",
                null,
                MethodSignatureModifiers.Internal,
                fullParameterList,
                Initializer: new(true, baseInitializers));
        }

        private IEnumerable<JsonPropertySerialization> CreatePropertySerializations()
        {
            List<JsonPropertySerialization> result = new List<JsonPropertySerialization>();
            foreach (var objType in EnumerateHierarchy())
            {
                foreach (var property in objType.Properties)
                {
                    if (property.InputModelProperty is not { } inputModelProperty)
                        continue;

                    var declaredName = property.Declaration.Name;
                    var serializedName = property.InputModelProperty.SerializedName ?? property.InputModelProperty.Name;
                    var optionalViaNullability = !inputModelProperty.IsRequired && !inputModelProperty.Type.IsNullable && !TypeFactory.IsCollectionType(property.ValueType);
                    var valueSerialization = SerializationBuilder.BuildJsonSerialization(property.InputModelProperty.Type, property.ValueType, false, property.InputModelProperty.SerializationFormat);
                    var paramName = declaredName.StartsWith("_", StringComparison.OrdinalIgnoreCase) ? declaredName.Substring(1) : declaredName.FirstCharToLowerCase();
                    //TODO we should change this property name on the JsonPropertySerialization since it isn't whether it is "readonly"
                    //or not it indicates if we should serialize this or not which is different.  Lists are readonly
                    //in the sense that the don't have setters but they aren't necessarily always readonly in the spec and therefore
                    //should be serialized based on the spec not based on the presence of a setter
                    bool shouldSkipSerialization = ShouldSkipSerialization(property);
                    result.Add(new JsonPropertySerialization(
                        paramName,
                        declaredName,
                        serializedName,
                        property.Declaration.Type,
                        property.ValueType,
                        valueSerialization,
                        property.IsRequired,
                        shouldSkipSerialization,
                        ShouldSkipDeserialization(property),
                        optionalViaNullability));
                }
            }
            return result;
        }

        private bool ShouldSkipSerialization(ObjectTypeProperty property)
        {
            if (property.InputModelProperty!.IsDiscriminator)
            {
                return false;
            }

            if (property.InputModelProperty.Type is InputLiteralType)
            {
                return false;
            }

            if (property.InputModelProperty!.IsReadOnly)
            {
                return true;
            }

            if (property.Declaration.Type.IsCollectionType())
            {
                return _inputModel.Usage is InputModelTypeUsage.Output;
            }

            return property.IsReadOnly && _inputModel.Usage is not InputModelTypeUsage.Input;
        }

        private bool ShouldSkipDeserialization(ObjectTypeProperty property) => property.InputModelProperty?.Type is InputLiteralType;

        private void GetConstructorParameters(IEnumerable<Parameter> parameters, out List<Parameter> fullParameterList, out IEnumerable<Parameter> parametersToPassToBase, bool isInitializer, Func<Parameter, Parameter> creator)
        {
            fullParameterList = new List<Parameter>();
            var parent = GetBaseObjectType();
            parametersToPassToBase = Array.Empty<Parameter>();
            if (parent is not null)
            {
                var ctor = isInitializer ? parent.InitializationConstructor : parent.SerializationConstructor;
                parametersToPassToBase = ctor.Signature.Parameters;
                fullParameterList.AddRange(parametersToPassToBase);
            }
            fullParameterList.AddRange(parameters.Select(creator));
        }

        private FormattableString[] GetInitializersFromParameters(IEnumerable<Parameter> parametersToPassToBase)
            => ConstructorInitializer.ParametersToFormattableString(parametersToPassToBase).ToArray();

        private static Parameter CreatePublicConstructorParameter(Parameter p)
            => p with { Type = TypeFactory.GetInputType(p.Type) };

        private static Parameter CreateSerializationConstructorParameter(Parameter p) // we don't validate parameters for serialization constructor
            => p with { Validation = ValidationType.None };

        protected override ObjectTypeConstructor BuildInitializationConstructor()
        {
            ObjectTypeConstructor? baseCtor = GetBaseObjectType()?.InitializationConstructor;

            return new ObjectTypeConstructor(InitializationConstructorSignature, GetPropertyInitializers(InitializationConstructorSignature.Parameters, true), baseCtor);
        }

        protected override ObjectTypeConstructor BuildSerializationConstructor()
        {
            // the property bag never needs deserialization, therefore we return the initialization constructor here so that we do not write it in the generated code
            if (IsPropertyBag)
                return InitializationConstructor;

            // verifies the serialization ctor has the same parameter list as the public one, we return the initialization ctor
            if (!SerializationConstructorSignature.Parameters.Any(p => TypeFactory.IsList(p.Type)) && InitializationConstructorSignature.Parameters.SequenceEqual(SerializationConstructorSignature.Parameters, Parameter.EqualityComparerByType))
                return InitializationConstructor;

            ObjectTypeConstructor? baseCtor = GetBaseObjectType()?.SerializationConstructor;

            return new ObjectTypeConstructor(SerializationConstructorSignature, GetPropertyInitializers(SerializationConstructorSignature.Parameters, false), baseCtor);
        }

        private ObjectPropertyInitializer[] GetPropertyInitializers(IReadOnlyList<Parameter> parameters, bool includeDiscriminator)
        {
            List<ObjectPropertyInitializer> defaultCtorInitializers = new List<ObjectPropertyInitializer>();

            if (includeDiscriminator && Discriminator is not null && Discriminator.Value is { } discriminatorValue && !_inputModel.IsUnknownDiscriminatorModel)
            {
                defaultCtorInitializers.Add(new ObjectPropertyInitializer(Discriminator.Property, discriminatorValue));
            }

            Dictionary<string, Parameter> parameterMap = parameters.ToDictionary(
                parameter => parameter.Name,
                parameter => parameter);

            foreach (var property in Properties)
            {
                ReferenceOrConstant? initializationValue = null;
                Constant? defaultInitializationValue = null;

                var propertyType = property.Declaration.Type;
                if (parameterMap.TryGetValue(property.Declaration.Name.ToVariableName(), out var parameter) || IsStruct)
                {
                    // For structs all properties become required
                    Constant? defaultParameterValue = null;
                    if (property.SchemaProperty?.ClientDefaultValue is object defaultValueObject)
                    {
                        defaultParameterValue = BuilderHelpers.ParseConstant(defaultValueObject, propertyType);
                        defaultInitializationValue = defaultParameterValue;
                    }

                    var inputType = parameter?.Type ?? TypeFactory.GetInputType(propertyType);
                    if (defaultParameterValue != null && !TypeFactory.CanBeInitializedInline(property.ValueType, defaultParameterValue))
                    {
                        inputType = inputType.WithNullable(true);
                        defaultParameterValue = Constant.Default(inputType);
                    }

                    var validate = property.SchemaProperty?.Nullable != true && !inputType.IsValueType ? ValidationType.AssertNotNull : ValidationType.None;
                    var defaultCtorParameter = new Parameter(
                        property.Declaration.Name.ToVariableName(),
                        property.ParameterDescription,
                        inputType,
                        defaultParameterValue,
                        validate,
                        null
                    );

                    initializationValue = defaultCtorParameter;
                }
                else
                {
                    if (initializationValue == null && TypeFactory.IsCollectionType(propertyType))
                    {
                        initializationValue = Constant.NewInstanceOf(TypeFactory.GetPropertyImplementationType(propertyType));
                    }
                }

                if (initializationValue != null)
                {
                    defaultCtorInitializers.Add(new ObjectPropertyInitializer(property, initializationValue.Value, defaultInitializationValue));
                }
            }

            return defaultCtorInitializers.ToArray();
        }

        protected override CSharpType? CreateInheritedType()
        {
            if (_inputModel.BaseModel is not null)
                return _typeFactory.CreateType(_inputModel.BaseModel!);

            return null;
        }

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            foreach (var field in Fields)
                yield return new ObjectTypeProperty(field, Fields.GetInputByField(field), this, field.SerializationFormat);
        }

        protected override IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            yield return InitializationConstructor;
            if (SerializationConstructor != InitializationConstructor)
                yield return SerializationConstructor;
        }

        protected override bool EnsureHasJsonSerialization()
        {
            if (IsPropertyBag)
                return false;
            return true;
        }

        protected override bool EnsureHasXmlSerialization()
        {
            return false;
        }

        protected override bool EnsureIncludeSerializer()
        {
            return _inputModel.Usage.HasFlag(InputModelTypeUsage.Input);
        }

        protected override bool EnsureIncludeDeserializer()
        {
            return _inputModel.Usage.HasFlag(InputModelTypeUsage.Output);
        }

        protected override JsonObjectSerialization EnsureJsonSerialization()
        {
            // Serialization uses field and property names that first need to verified for uniqueness
            // For that, FieldDeclaration instances must be written in the main partial class before JsonObjectSerialization is created for the serialization partial class
            return new(Type, SerializationConstructorSignature, CreatePropertySerializations().ToArray(), null, Discriminator, false, EnsureIncludeSerializer(), EnsureIncludeDeserializer());
        }

        protected override XmlObjectSerialization? EnsureXmlSerialization()
        {
            return null;
        }

        protected override IEnumerable<ModelMethodDefinition> BuildMethods()
        {
            if (EnsureIncludeDeserializer())
                yield return new ModelMethodDefinition(FromResponseSignature, SerializationWriter.JsonFromResponseMethod);
            if (EnsureIncludeSerializer())
                yield return new ModelMethodDefinition(ToRequestContentSignature, SerializationWriter.JsonToRequestContentMethod);
        }

        public ObjectTypeProperty GetPropertyBySerializedName(string serializedName, bool includeParents = false)
        {
            if (!TryGetPropertyForInputModelProperty(p => p.InputModelProperty?.SerializedName == serializedName, out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property with serialized name '{serializedName}' in schema {DefaultName}");
            }

            return objectProperty;
        }

        private bool TryGetPropertyForInputModelProperty(Func<ObjectTypeProperty, bool> propertySelector, [NotNullWhen(true)] out ObjectTypeProperty? objectProperty, bool includeParents = false)
        {
            objectProperty = null;

            foreach (var type in EnumerateHierarchy())
            {
                objectProperty = type.Properties.SingleOrDefault(propertySelector);
                if (objectProperty != null || !includeParents)
                {
                    break;
                }
            }

            return objectProperty != null;
        }

        protected override ObjectTypeDiscriminator? BuildDiscriminator()
        {
            string? discriminatorPropertyName = _inputModel.DiscriminatorPropertyName;
            ObjectTypeDiscriminatorImplementation[] implementations = Array.Empty<ObjectTypeDiscriminatorImplementation>();
            Constant? value = null;
            ObjectTypeProperty property;

            if (discriminatorPropertyName == null)
            {
                var parent = GetBaseObjectType();
                if (parent is null || parent.Discriminator is null)
                {
                    //neither me nor my parent are discriminators so I can bail
                    return null;
                }

                discriminatorPropertyName = parent.Discriminator.SerializedName;
                property = parent.Discriminator.Property;
            }
            else
            {
                //only load implementations for the base type
                implementations = _derivedTypes!.Select(child => new ObjectTypeDiscriminatorImplementation(child.DiscriminatorValue!, _typeFactory.CreateType(child))).ToArray();
                property = Properties.First(p => p.InputModelProperty is not null && p.InputModelProperty.IsDiscriminator);
            }

            if (_inputModel.DiscriminatorValue != null)
            {
                value = BuilderHelpers.ParseConstant(_inputModel.DiscriminatorValue, property.Declaration.Type);
            }

            return new ObjectTypeDiscriminator(
                property,
                discriminatorPropertyName,
                implementations,
                value,
                _defaultDerivedType!
            );
        }
    }
}
