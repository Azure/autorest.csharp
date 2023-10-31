// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelTypeProvider : SerializableObjectType
    {
        private ConstructorSignature? _publicConstructor;
        private ConstructorSignature? _serializationConstructor;
        private ObjectTypeProperty? _additionalPropertiesProperty;
        private readonly InputModelType _inputModel;
        private readonly TypeFactory _typeFactory;
        private readonly IReadOnlyList<InputModelType> _derivedTypes;
        private readonly SerializableObjectType? _defaultDerivedType;
        private readonly ModelTypeMapping? _modelTypeMapping;
        private readonly InputModelTypeUsage _inputModelUsage;
        private readonly InputTypeSerialization _inputModelSerialization;
        private readonly IReadOnlyList<InputModelProperty> _inputModelProperties;
        private ModelTypeProviderFields? _fields;

        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }
        protected override TypeKind TypeKind { get; }
        public override bool IncludeConverter => _inputModelSerialization.IncludeConverter;
        protected override bool IsAbstract => !Configuration.SuppressAbstractBaseClasses.Contains(DefaultName) && _inputModel.DiscriminatorPropertyName is not null && _inputModel.BaseModel is null && _inputModel.InheritedDictionaryType is null;

        public ModelTypeProviderFields Fields => _fields ??= new ModelTypeProviderFields(_inputModelProperties, Declaration.Name, _inputModelUsage, _typeFactory, _modelTypeMapping, GetBaseObjectType(), _inputModel.InheritedDictionaryType, IsStruct, _inputModel.IsPropertyBag);
        public ConstructorSignature InitializationConstructorSignature => _publicConstructor ??= EnsurePublicConstructorSignature();
        public ConstructorSignature SerializationConstructorSignature => _serializationConstructor ??= EnsureSerializationConstructorSignature();

        public override ObjectTypeProperty? AdditionalPropertiesProperty => _additionalPropertiesProperty ??= EnsureAdditionalPropertiesProperty();

        private ObjectTypeProperty? EnsureAdditionalPropertiesProperty()
            => Fields.AdditionalProperties is { } additionalPropertiesField
                ? Properties.Last(p => p.Declaration.Name == additionalPropertiesField.Name)
                : null;

        private ObjectTypeProperty? _rawDataField;
        public override ObjectTypeProperty? RawDataField
        {
            get
            {
                if (_rawDataField != null)
                    return _rawDataField;

                if (AdditionalPropertiesProperty != null || !ShouldHaveRawData)
                    return null;

                // when this model has derived types, the accessibility should change from private to `protected internal`
                string accessibility = HasDerivedTypes() ? "protected internal" : "private";

                _rawDataField = new ObjectTypeProperty(
                    BuilderHelpers.CreateMemberDeclaration(_privateAdditionalPropertiesPropertyName,
                        _privateAdditionalPropertiesPropertyType, accessibility, null, _typeFactory),
                    _privateAdditionalPropertiesPropertyDescription,
                    true,
                    null);

                return _rawDataField;
            }
        }

        private bool HasDerivedTypes()
        {
            if (_derivedTypes is not null && _derivedTypes.Any())
                return true;

            if (_inputModel.DiscriminatorPropertyName is not null)
                return true;

            return false;
        }

        public ModelTypeProvider(InputModelType inputModel, string defaultNamespace, SourceInputModel? sourceInputModel, TypeFactory typeFactory, SerializableObjectType? defaultDerivedType = null)
            : base(Configuration.Generation1ConvenienceClient ? inputModel.Namespace ?? defaultNamespace : defaultNamespace, sourceInputModel)
        {
            _typeFactory = typeFactory;
            _inputModel = inputModel;

            _deprecated = inputModel.Deprecated;
            _derivedTypes = inputModel.DerivedModels;
            _defaultDerivedType = inputModel.DerivedModels.Any() && inputModel.BaseModel is not null
                ? this //if I have children and parents then I am my own defaultDerivedType
                : defaultDerivedType ?? (inputModel.IsUnknownDiscriminatorModel ? this : null);

            DefaultName = inputModel.Name.ToCleanName();
            DefaultAccessibility = inputModel.Accessibility ?? "public";
            TypeKind = IsStruct ? TypeKind.Struct : TypeKind.Class;

            _modelTypeMapping = sourceInputModel?.CreateForModel(ExistingType);
            _inputModelUsage = UpdateInputModelUsage(inputModel, _modelTypeMapping);
            _inputModelSerialization = UpdateInputSerialization(inputModel, _modelTypeMapping);
            _inputModelProperties = UpdateInputModelProperties(inputModel, GetSourceBaseType(), Declaration.Namespace, sourceInputModel);
        }

        private static InputModelTypeUsage UpdateInputModelUsage(InputModelType inputModel, ModelTypeMapping? modelTypeMapping)
        {
            var usage = inputModel.Usage;
            if (modelTypeMapping?.Usage is { } usageDefinedInSource)
            {
                foreach (var schemaTypeUsage in usageDefinedInSource.Select(u => Enum.Parse<SchemaTypeUsage>(u, true)))
                {
                    usage |= schemaTypeUsage switch
                    {
                        SchemaTypeUsage.Input => InputModelTypeUsage.Input,
                        SchemaTypeUsage.Output => InputModelTypeUsage.Output,
                        SchemaTypeUsage.RoundTrip => InputModelTypeUsage.RoundTrip,
                        _ => InputModelTypeUsage.None
                    };
                }
            }

            return usage;
        }

        private static InputTypeSerialization UpdateInputSerialization(InputModelType inputModel, ModelTypeMapping? modelTypeMapping)
        {
            var serialization = inputModel.Serialization;

            if (modelTypeMapping?.Formats is { } formatsDefinedInSource)
            {
                foreach (var format in formatsDefinedInSource)
                {
                    var mediaType = Enum.Parse<KnownMediaType>(format, true);
                    if (mediaType == KnownMediaType.Json)
                    {
                        serialization = serialization with { Json = true };
                    }
                    else if (mediaType == KnownMediaType.Xml)
                    {
                        serialization = serialization with { Xml = new InputTypeXmlSerialization(inputModel.Name, false, false, false) };
                    }
                }
            }

            if (modelTypeMapping?.Usage is { } usage && usage.Contains(nameof(SchemaTypeUsage.Converter), StringComparer.OrdinalIgnoreCase))
            {
                serialization = serialization with { IncludeConverter = true };
            }

            return serialization;
        }

        private static IReadOnlyList<InputModelProperty> UpdateInputModelProperties(InputModelType inputModel, INamedTypeSymbol? existingBaseType, string ns, SourceInputModel? sourceInputModel)
        {
            if (inputModel.BaseModel is not { } baseModel)
            {
                return inputModel.Properties;
            }

            var properties = inputModel.Properties.ToList();
            var compositionModels = inputModel.CompositionModels;

            if (existingBaseType is not null && existingBaseType.Name != baseModel.Name && !SymbolEqualityComparer.Default.Equals(sourceInputModel?.FindForType(ns, baseModel.Name.ToCleanName()), existingBaseType))
            {
                // First try to find composite type by name
                // If failed, try find existing type with CodeGenModel that has expected name
                var baseTypeReplacement = inputModel.CompositionModels.FirstOrDefault(m => m.Name == existingBaseType.Name);
                if (baseTypeReplacement is null && sourceInputModel is not null)
                {
                    baseTypeReplacement = inputModel.CompositionModels.FirstOrDefault(m => SymbolEqualityComparer.Default.Equals(sourceInputModel.FindForType(ns, m.Name.ToCleanName()), existingBaseType));
                }

                if (baseTypeReplacement is null)
                {
                    throw new InvalidOperationException($"Base type `{existingBaseType.Name}` is not one of the `{inputModel.Name}` composite types.");
                }

                compositionModels = inputModel.CompositionModels
                    .Except(baseTypeReplacement.GetSelfAndBaseModels())
                    .Concat(baseModel.GetSelfAndBaseModels())
                    .ToList();
            }

            foreach (var property in compositionModels.SelectMany(m => m.Properties))
            {
                if (properties.All(p => p.Name != property.Name))
                {
                    properties.Add(property);
                }
            }

            return properties;
        }

        public bool HasFromOperationResponseMethod => HasJsonSerialization && !Configuration.AzureArm && (!Configuration.Generation1ConvenienceClient || Configuration.ProtocolMethodList.Any());

        public bool HasToRequestBodyMethod => HasJsonSerialization && !Configuration.AzureArm && (!Configuration.Generation1ConvenienceClient || Configuration.ProtocolMethodList.Any());

        private MethodSignatureModifiers GetFromResponseModifiers()
        {
            var signatures = MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static;
            var parent = GetBaseObjectType();
            if (parent is ModelTypeProvider { HasFromOperationResponseMethod: true })
            {
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
                signatures |= parentModelType.HasToRequestBodyMethod
                    ? MethodSignatureModifiers.Override
                    : MethodSignatureModifiers.Virtual;
            }
            return signatures;
        }

        protected override FormattableString CreateDescription()
        {
            return string.IsNullOrEmpty(_inputModel.Description) ? (FormattableString)$"The {_inputModel.Name}." : $"{_inputModel.Description}";
        }

        private ConstructorSignature EnsurePublicConstructorSignature()
        {
            //get base public ctor params
            GetConstructorParameters(Fields.PublicConstructorParameters, out var fullParameterList, out var parametersToPassToBase, true);

            FormattableString summary = $"Initializes a new instance of <see cref=\"{Type.ToStringForDocs()}\"/>";
            var accessibility = _inputModel.Usage.HasFlag(InputModelTypeUsage.Input)
                ? MethodSignatureModifiers.Public
                : MethodSignatureModifiers.Internal;

            if (_inputModel.DiscriminatorPropertyName is not null)
                accessibility = MethodSignatureModifiers.Protected;

            return new ConstructorSignature(
                Type,
                summary,
                null,
                accessibility,
                fullParameterList,
                Initializer: new(true, parametersToPassToBase));
        }

        private ConstructorSignature EnsureSerializationConstructorSignature()
        {
            // if there is additional properties property, we need to append it to the parameter list
            var parameters = Fields.SerializationParameters;
            if (RawDataField != null)
            {
                var deserializationParameter = new Parameter(
                    RawDataField.Declaration.Name.ToVariableName(),
                    RawDataField.ParameterDescription,
                    RawDataField.Declaration.Type,
                    null,
                    Validation.None,
                    null
                );
                parameters = parameters.Append(deserializationParameter).ToList();
            }

            //get base public ctor params
            GetConstructorParameters(parameters, out var fullParameterList, out var parametersToPassToBase, false);

            return new ConstructorSignature(
                Type,
                $"Initializes a new instance of <see cref=\"{Type}\"/>",
                null,
                MethodSignatureModifiers.Internal,
                fullParameterList,
                Initializer: new(true, parametersToPassToBase));
        }

        private IEnumerable<JsonPropertySerialization> CreatePropertySerializations()
        {
            foreach (var objType in EnumerateHierarchy())
            {
                foreach (var property in objType.Properties)
                {
                    if (property.InputModelProperty is not { } inputModelProperty)
                        continue;

                    var declaredName = property.Declaration.Name;
                    var serializedName = inputModelProperty.SerializedName;
                    var valueSerialization = SerializationBuilder.BuildJsonSerialization(inputModelProperty.Type, property.Declaration.Type, false, property.SerializationFormat);

                    yield return new JsonPropertySerialization(
                        declaredName.ToVariableName(),
                        new TypedMemberExpression(null, declaredName, property.Declaration.Type),
                        serializedName,
                        property.ValueType.IsNullable && property.OptionalViaNullability ? property.ValueType.WithNullable(false) : property.ValueType,
                        valueSerialization,
                        property.IsRequired,
                        ShouldExcludeInWireSerialization(property, inputModelProperty),
                        customSerializationMethodName: property.SerializationMapping?.SerializationValueHook,
                        customDeserializationMethodName: property.SerializationMapping?.DeserializationValueHook);
                    ;
                }
            }
        }

        private static bool ShouldExcludeInWireSerialization(ObjectTypeProperty property, InputModelProperty inputProperty)
        {
            if (inputProperty.IsDiscriminator)
            {
                return false;
            }

            if (property.InitializationValue is not null)
            {
                return false;
            }

            return inputProperty.IsReadOnly;
        }

        private void GetConstructorParameters(IEnumerable<Parameter> parameters, out List<Parameter> fullParameterList, out IEnumerable<Parameter> parametersToPassToBase, bool isInitializer)
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
            fullParameterList.AddRange(parameters.Select(p => p with { Description = $"{p.Description}{BuilderHelpers.CreateDerivedTypesDescription(p.Type)}" }));
        }

        protected override ObjectTypeConstructor BuildInitializationConstructor()
        {
            ObjectTypeConstructor? baseCtor = GetBaseObjectType()?.InitializationConstructor;
            return new ObjectTypeConstructor(InitializationConstructorSignature, GetPropertyInitializers(InitializationConstructorSignature.Parameters, true), baseCtor);
        }

        protected override ObjectTypeConstructor BuildSerializationConstructor()
        {
            // the property bag never needs deserialization, therefore we return the initialization constructor here so that we do not write it in the generated code
            if (IsPropertyBag)
            {
                return InitializationConstructor;
            }

            // verifies the serialization ctor has the same parameter list as the public one, we return the initialization ctor
            if (!SerializationConstructorSignature.Parameters.Any(p => TypeFactory.IsList(p.Type)) && InitializationConstructorSignature.Parameters.SequenceEqual(SerializationConstructorSignature.Parameters, Parameter.EqualityComparerByType))
            {
                return InitializationConstructor;
            }

            ObjectTypeConstructor? baseCtor = GetBaseObjectType()?.SerializationConstructor;

            return new ObjectTypeConstructor(SerializationConstructorSignature, GetPropertyInitializers(SerializationConstructorSignature.Parameters, false), baseCtor);
        }

        private ObjectPropertyInitializer[] GetPropertyInitializers(IReadOnlyList<Parameter> parameters, bool includeDiscriminator)
        {
            List<ObjectPropertyInitializer> defaultCtorInitializers = new List<ObjectPropertyInitializer>();

            if (!Configuration.Generation1ConvenienceClient && includeDiscriminator && Discriminator?.Value is { } discriminatorValue && !_inputModel.IsUnknownDiscriminatorModel)
            {
                defaultCtorInitializers.Add(new ObjectPropertyInitializer(Discriminator.Property, discriminatorValue));
            }

            Dictionary<string, Parameter> parameterMap = parameters.ToDictionary(
                parameter => parameter.Name,
                parameter => parameter);

            foreach (var property in Properties)
            {
                ReferenceOrConstant? initializationValue = null;

                var propertyName = property.Declaration.Name;
                var propertyType = property.Declaration.Type;
                if (parameterMap.TryGetValue(propertyName.ToVariableName(), out var parameter) || IsStruct)
                {
                    // For structs all properties become required
                    Constant? defaultParameterValue = null;
                    var inputType = parameter?.Type ?? TypeFactory.GetInputType(propertyType);
                    if (defaultParameterValue != null && !TypeFactory.CanBeInitializedInline(property.ValueType, defaultParameterValue))
                    {
                        inputType = inputType.WithNullable(true);
                        defaultParameterValue = Constant.Default(inputType);
                    }

                    var validation = parameter?.Validation ?? Validation.None;
                    var defaultCtorParameter = new Parameter(propertyName.ToVariableName(), property.ParameterDescription, inputType, defaultParameterValue, validation, null);

                    initializationValue = defaultCtorParameter;
                }
                else if (initializationValue == null && TypeFactory.IsCollectionType(propertyType))
                {
                    initializationValue = Constant.NewInstanceOf(TypeFactory.GetPropertyImplementationType(propertyType));
                }
                else if (Configuration.Generation1ConvenienceClient && property.InputModelProperty?.ConstantValue is { } constant && !propertyType.IsNullable)
                {
                    defaultCtorInitializers.Add(new ObjectPropertyInitializer(property, BuilderHelpers.ParseConstant(constant.Value, propertyType)));
                }

                if (initializationValue != null)
                {
                    defaultCtorInitializers.Add(new ObjectPropertyInitializer(property, initializationValue.Value));
                }
            }

            if (Configuration.Generation1ConvenienceClient)
            {
                if (Discriminator is { } discriminator)
                {
                    if (defaultCtorInitializers.All(i => i.Property != discriminator.Property) && parameterMap.TryGetValue(discriminator.Property.Declaration.Name.ToVariableName(), out var discriminatorParameter))
                    {
                        defaultCtorInitializers.Add(new ObjectPropertyInitializer(discriminator.Property, discriminatorParameter, discriminator.Value));
                    }
                    else if (!_inputModel.IsUnknownDiscriminatorModel && discriminator.Value is { } value)
                    {
                        defaultCtorInitializers.Add(new ObjectPropertyInitializer(Discriminator.Property, value));
                    }
                }
            }

            return defaultCtorInitializers.ToArray();
        }

        protected override CSharpType? CreateInheritedType()
        {
            if (GetSourceBaseType() is { } sourceBaseType && _typeFactory.TryCreateType(sourceBaseType, out CSharpType? baseType))
            {
                return baseType;
            }

            return _inputModel.BaseModel is { } baseModel
                ? _typeFactory.CreateType(baseModel)
                : null;
        }

        private INamedTypeSymbol? GetSourceBaseType()
            => ExistingType?.BaseType is { } sourceBaseType && sourceBaseType.SpecialType != SpecialType.System_ValueType && sourceBaseType.SpecialType != SpecialType.System_Object ? sourceBaseType : null;

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            foreach (var field in Fields)
                yield return new ObjectTypeProperty(field, Fields.GetInputByField(field));

            if (RawDataField is { } rawData)
                yield return rawData;
        }

        protected override IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            if (!_inputModel.IsUnknownDiscriminatorModel)
            {
                yield return InitializationConstructor;
            }

            if (SerializationConstructor != InitializationConstructor && !Configuration.Generation1ConvenienceClient)
            {
                yield return SerializationConstructor;
            }

            // add an extra empty ctor if we do not have a ctor with no parameters
            var accessibility = IsStruct ? MethodSignatureModifiers.Public : MethodSignatureModifiers.Internal;
            if (InitializationConstructor.Signature.Parameters.Count > 0 && SerializationConstructor.Signature.Parameters.Count > 0)
                yield return new(
                    new ConstructorSignature(Type, null, $"Initializes a new instance of <see cref=\"{Type}\"/> for deserialization.", accessibility, Array.Empty<Parameter>()),
                    Array.Empty<ObjectPropertyInitializer>(),
                    null);
        }

        protected override bool EnsureHasJsonSerialization()
        {
            if (IsPropertyBag)
                return false;
            return _inputModelSerialization.Json;
        }

        protected override bool EnsureHasXmlSerialization() => _inputModelSerialization.Xml is not null;

        protected override JsonObjectSerialization EnsureJsonSerialization()
        {
            // Serialization uses field and property names that first need to verified for uniqueness
            // For that, FieldDeclaration instances must be written in the main partial class before JsonObjectSerialization is created for the serialization partial class
            var properties = SerializationBuilder.GetPropertySerializations(this, _typeFactory);
            var additionalProperties = CreateAdditionalPropertySerialization();
            return new(Type, SerializationConstructor.Signature.Parameters, properties, additionalProperties, Discriminator, IncludeConverter);
        }

        private JsonAdditionalPropertiesSerialization? CreateAdditionalPropertySerialization()
        {
            foreach (var model in EnumerateHierarchy().OfType<ModelTypeProvider>())
            {
                if (model is { AdditionalPropertiesProperty: { } additionalProperties, _inputModel.InheritedDictionaryType: { } inheritedDictionaryType })
                {
                    var dictionaryValueType = additionalProperties.Declaration.Type.Arguments[1];
                    Debug.Assert(!dictionaryValueType.IsNullable, $"{typeof(JsonSerializationMethodsBuilder)} implicitly relies on {additionalProperties.Declaration.Name} dictionary value being non-nullable");

                    var type = new CSharpType(typeof(Dictionary<,>), additionalProperties.Declaration.Type.Arguments);
                    var valueSerialization = SerializationBuilder.BuildJsonSerialization(inheritedDictionaryType.ValueType, dictionaryValueType, false);

                    return new JsonAdditionalPropertiesSerialization(additionalProperties, valueSerialization, type);
                }
            }

            return null;
        }

        protected override XmlObjectSerialization? EnsureXmlSerialization()
        {
            return SerializationBuilder.BuildXmlObjectSerialization(_inputModelSerialization.Xml?.Name ?? _inputModel.Name, this, _typeFactory);
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            // TODO -- move this thing to SerializationBuilder
            if (XmlSerialization is { } xmlSerialization)
            {
                yield return XmlSerializationMethodsBuilder.BuildXmlSerializableWrite(xmlSerialization);
                yield return XmlSerializationMethodsBuilder.BuildDeserialize(Declaration, xmlSerialization);
            }

            if (JsonSerialization is { } jsonSerialization)
            {
                foreach (var method in JsonSerializationMethodsBuilder.BuildJsonSerializationMethods(this, jsonSerialization))
                {
                    yield return method;
                }
                foreach (var method in JsonSerializationMethodsBuilder.BuildIModelMethods(this, HasJsonSerialization, HasXmlSerialization))
                {
                    yield return method; // TODO -- this is not entirely correct
                }

                if (JsonSerializationMethodsBuilder.BuildDeserialize(Declaration, jsonSerialization, ExistingType) is { } jsonDeserialize)
                {
                    yield return jsonDeserialize;
                }

                if (HasFromOperationResponseMethod)
                {
                    yield return Snippets.Extensible.Model.BuildFromOperationResponseMethod(this, GetFromResponseModifiers());
                }

                if (HasToRequestBodyMethod)
                {
                    yield return Snippets.Extensible.Model.BuildConversionToRequestBodyMethod(GetToRequestContentModifiers());
                }
            }
        }

        public override ObjectTypeProperty GetPropertyBySerializedName(string serializedName, bool includeParents = false)
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
            var parentDiscriminator = GetBaseObjectType()?.Discriminator;
            var property = Properties.FirstOrDefault(p => p.InputModelProperty is not null && p.InputModelProperty.IsDiscriminator)
                ?? parentDiscriminator?.Property;

            var discriminatorPropertyName = _inputModel.DiscriminatorPropertyName ?? parentDiscriminator?.SerializedName;

            //neither me nor my parent are discriminators so I can bail
            if (property is null || discriminatorPropertyName is null)
            {
                return null;
            }

            Constant? value = null;

            //only load implementations for the base type
            // [TODO]: OrderBy(i => i.Key) is needed only to preserve the order. Remove it in a separate PR.
            var implementations = Configuration.Generation1ConvenienceClient
                ? GetDerivedTypes(_derivedTypes).OrderBy(i => i.Key).ToArray()
                : GetDerivedTypes(_derivedTypes).ToArray();


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

        private IEnumerable<ObjectTypeDiscriminatorImplementation> GetDerivedTypes(IReadOnlyList<InputModelType> derivedInputTypes)
        {
            foreach (var derivedInputType in derivedInputTypes)
            {
                var derivedType = (ModelTypeProvider)_typeFactory.CreateType(derivedInputType).Implementation;
                foreach (var discriminatorImplementation in GetDerivedTypes(derivedType._derivedTypes))
                {
                    yield return discriminatorImplementation;
                }

                yield return new ObjectTypeDiscriminatorImplementation(derivedInputType.DiscriminatorValue!, derivedType.Type);
            }
        }
    }
}
