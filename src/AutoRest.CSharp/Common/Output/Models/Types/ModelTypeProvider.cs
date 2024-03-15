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
using AutoRest.CSharp.Output.Models.Serialization.Bicep;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelTypeProvider : SerializableObjectType
    {
        private ModelTypeProviderFields? _fields;
        private ConstructorSignature? _publicConstructor;
        private ConstructorSignature? _serializationConstructor;
        private ObjectTypeProperty? _additionalPropertiesProperty;
        private readonly InputModelTypeUsage _inputModelUsage;
        private readonly InputTypeSerialization _inputModelSerialization;
        private readonly IReadOnlyList<InputModelProperty> _inputModelProperties;
        private readonly InputModelType _inputModel;
        private readonly TypeFactory _typeFactory;
        private readonly IReadOnlyList<InputModelType> _derivedModels;
        private readonly SerializableObjectType? _defaultDerivedType;

        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }
        public bool IsAccessibilityOverridden { get; }

        protected override bool IsAbstract => !Configuration.SuppressAbstractBaseClasses.Contains(DefaultName) && _inputModel.DiscriminatorPropertyName is not null && _inputModel.DiscriminatorValue is null;

        public ModelTypeProviderFields Fields => _fields ??= EnsureFields();
        private ConstructorSignature InitializationConstructorSignature => _publicConstructor ??= EnsurePublicConstructorSignature();
        private ConstructorSignature SerializationConstructorSignature => _serializationConstructor ??= EnsureSerializationConstructorSignature();

        public override ObjectTypeProperty? AdditionalPropertiesProperty => _additionalPropertiesProperty ??= EnsureAdditionalPropertiesProperty();

        private ObjectTypeProperty? EnsureAdditionalPropertiesProperty()
            => Fields.AdditionalProperties is { } additionalPropertiesField
                ? new ObjectTypeProperty(additionalPropertiesField, null)
                : null;

        private ObjectTypeProperty? _rawDataField;
        protected internal override InputModelTypeUsage GetUsage() => _inputModelUsage;

        public override ObjectTypeProperty? RawDataField
        {
            get
            {
                if (_rawDataField != null)
                    return _rawDataField;

                if (AdditionalPropertiesProperty != null || !ShouldHaveRawData)
                    return null;

                // when this model has derived types, the accessibility should change from private to `protected internal`
                string accessibility = HasDerivedTypes() ? "private protected" : "private";

                _rawDataField = new ObjectTypeProperty(
                    BuilderHelpers.CreateMemberDeclaration(PrivateAdditionalPropertiesPropertyName,
                        _privateAdditionalPropertiesPropertyType, accessibility, null, _typeFactory),
                    PrivateAdditionalPropertiesPropertyDescription,
                    true,
                    null);

                return _rawDataField;
            }
        }

        private bool HasDerivedTypes()
        {
            if (_derivedModels.Any())
                return true;

            if (_inputModel.DiscriminatorPropertyName is not null)
                return true;

            return false;
        }

        public ModelTypeProvider(InputModelType inputModel, string defaultNamespace, SourceInputModel? sourceInputModel, TypeFactory typeFactory, SerializableObjectType? defaultDerivedType = null)
            : base(defaultNamespace, sourceInputModel)
        {
            DefaultName = inputModel.Name.ToCleanName();
            DefaultAccessibility = inputModel.Accessibility ?? "public";
            IsAccessibilityOverridden = inputModel.Accessibility != null;

            _typeFactory = typeFactory;
            _inputModel = inputModel;
            _deprecated = inputModel.Deprecated;
            _derivedModels = inputModel.DerivedModels;
            _defaultDerivedType = inputModel.DerivedModels.Any() && inputModel.BaseModel is {DiscriminatorPropertyName: not null}
                ? this //if I have children and parents then I am my own defaultDerivedType
                : defaultDerivedType ?? (inputModel.IsUnknownDiscriminatorModel ? this : null);

            _inputModelUsage = UpdateInputModelUsage(inputModel, ModelTypeMapping);
            _inputModelSerialization = UpdateInputSerialization(inputModel, ModelTypeMapping);
            _inputModelProperties = UpdateInputModelProperties(inputModel, GetSourceBaseType(), Declaration.Namespace, sourceInputModel);

            IsPropertyBag = inputModel.IsPropertyBag;
            IsUnknownDerivedType = inputModel.IsUnknownDiscriminatorModel;
            SkipInitializerConstructor = IsUnknownDerivedType;

            JsonConverter = _inputModelSerialization.IncludeConverter ? new JsonConverterProvider(this, _sourceInputModel) : null;
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

            foreach (var property in compositionModels.SelectMany(m => m.GetSelfAndBaseModels()).SelectMany(m => m.Properties))
            {
                if (properties.All(p => p.Name != property.Name))
                {
                    properties.Add(property);
                }
            }

            return properties;
        }

        private MethodSignatureModifiers GetFromResponseModifiers()
        {
            var signatures = MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static;
            var parent = GetBaseObjectType();
            if (parent is ModelTypeProvider parentModelType)
            {
                if (parentModelType.Methods.Any(m => m.Signature.Name == Configuration.ApiTypes.FromResponseName))
                    signatures |= MethodSignatureModifiers.New;
            }
            return signatures;
        }

        private MethodSignatureModifiers GetToRequestContentModifiers()
        {
            //TODO if no one inherits from this we can omit the virtual
            var signatures = MethodSignatureModifiers.Internal;
            // structs cannot have virtual members
            if (IsStruct)
            {
                return signatures;
            }

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

        protected override FormattableString CreateDescription()
        {
            return string.IsNullOrEmpty(_inputModel.Description) ? $"The {_inputModel.Name}." : FormattableStringHelpers.FromString(BuilderHelpers.EscapeXmlDocDescription(_inputModel.Description));
        }

        private ModelTypeProviderFields EnsureFields()
        {
            return new ModelTypeProviderFields(_inputModelProperties, Declaration.Name, _inputModelUsage, _typeFactory, ModelTypeMapping, GetBaseObjectType(), _inputModel.InheritedDictionaryType, IsStruct, _inputModel.IsPropertyBag);
        }

        private ConstructorSignature EnsurePublicConstructorSignature()
        {
            //get base public ctor params
            GetConstructorParameters(Fields.PublicConstructorParameters, out var fullParameterList, out var baseInitializers, true);

            var accessibility = IsAbstract
                ? MethodSignatureModifiers.Protected
                : _inputModelUsage.HasFlag(InputModelTypeUsage.Input)
                    ? MethodSignatureModifiers.Public
                    : MethodSignatureModifiers.Internal;

            return new ConstructorSignature(
                Type,
                $"Initializes a new instance of {Type:C}",
                null,
                accessibility,
                fullParameterList,
                Initializer: new(true, baseInitializers));
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
                    ValidationType.None,
                    null
                )
                {
                    IsRawData = true
                };
                parameters = parameters.Append(deserializationParameter).ToList();
            }

            //get base public ctor params
            GetConstructorParameters(parameters, out var fullParameterList, out var baseInitializers, false);

            return new ConstructorSignature(
                Type,
                $"Initializes a new instance of {Type:C}",
                null,
                MethodSignatureModifiers.Internal,
                fullParameterList,
                Initializer: new(true, baseInitializers));
        }

        private void GetConstructorParameters(IEnumerable<Parameter> parameters, out IReadOnlyList<Parameter> fullParameterList, out IReadOnlyList<ValueExpression> baseInitializers, bool isInitializer)
        {
            var parameterList = new List<Parameter>();
            var parent = GetBaseObjectType();
            baseInitializers = Array.Empty<ValueExpression>();
            if (parent is not null)
            {
                var discriminatorParameterName = Discriminator?.Property.Declaration.Name.ToVariableName();
                var ctor = isInitializer ? parent.InitializationConstructor : parent.SerializationConstructor;
                var baseParameters = new List<Parameter>();
                var baseParameterInitializers = new List<ValueExpression>();
                foreach (var p in ctor.Signature.Parameters)
                {
                    // we check if we should have the discriminator to our ctor only when we are building the initialization ctor
                    if (isInitializer && IsDiscriminatorInheritedOnBase && p.Name == discriminatorParameterName)
                    {
                        // if this is base
                        if (Discriminator is { Value: null })
                        {
                            baseParameterInitializers.Add(p); // pass it through
                            baseParameters.Add(p);
                        }
                        // if this is derived or unknown
                        else if (Discriminator is { Value: { } value })
                        {
                            baseParameterInitializers.Add(new ConstantExpression(value));
                            // do not add it into the list
                        }
                        else
                        {
                            throw new InvalidOperationException($"We have a inherited discriminator, but the discriminator is null, this will never happen");
                        }
                    }
                    else if (p.IsRawData && AdditionalPropertiesProperty != null)
                    {
                        baseParameterInitializers.Add(Snippets.Null);
                        // do not add it into the list
                    }
                    else
                    {
                        baseParameterInitializers.Add(p);
                        baseParameters.Add(p);
                    }
                }
                parameterList.AddRange(baseParameters);
                baseInitializers = baseParameterInitializers;
            }

            if (Configuration.Generation1ConvenienceClient)
            {
                parameterList.AddRange(parameters.Select(p => p with { Description = $"{p.Description}{BuilderHelpers.CreateDerivedTypesDescription(p.Type)}" }));
            }
            else
            {
                parameterList.AddRange(parameters);
            }

            fullParameterList = parameterList.DistinctBy(p => p.Name).ToArray(); // we filter out the parameters with the same name since we might have the same property both in myself and my base.
        }

        private bool? _isDiscriminatorInheritedOnBase;
        internal bool IsDiscriminatorInheritedOnBase => _isDiscriminatorInheritedOnBase ??= EnsureIsDiscriminatorInheritedOnBase();

        private bool EnsureIsDiscriminatorInheritedOnBase()
        {
            if (Discriminator is null)
            {
                return false;
            }

            if (Discriminator is { Value: not null })
            {
                var parent = GetBaseObjectType() as ModelTypeProvider;
                return parent?.IsDiscriminatorInheritedOnBase ?? false;
            }

            var property = Discriminator.Property;
            // if the property corresponding to the discriminator could not be found on this type, it means we are inheriting the discriminator
            return !Properties.Contains(property);
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
                return InitializationConstructor;

            // verifies the serialization ctor has the same parameter list as the public one, we return the initialization ctor
            if (!SerializationConstructorSignature.Parameters.Any(p => TypeFactory.IsList(p.Type)) && InitializationConstructorSignature.Parameters.SequenceEqual(SerializationConstructorSignature.Parameters, Parameter.EqualityComparerByType))
                return InitializationConstructor;

            ObjectTypeConstructor? baseCtor = GetBaseObjectType()?.SerializationConstructor;

            return new ObjectTypeConstructor(SerializationConstructorSignature, GetPropertyInitializers(SerializationConstructorSignature.Parameters, false), baseCtor);
        }

        private IReadOnlyList<ObjectPropertyInitializer> GetPropertyInitializers(IReadOnlyList<Parameter> parameters, bool isInitializer)
        {
            List<ObjectPropertyInitializer> defaultCtorInitializers = new();

            // only initialization ctor initializes the discriminator
            // and we should not initialize the discriminator again when the discriminator is inherited (it should show up in the ctor)
            if (!Configuration.Generation1ConvenienceClient && isInitializer && !IsDiscriminatorInheritedOnBase && Discriminator is {Value: {} discriminatorValue} && !IsUnknownDerivedType)
            {
                defaultCtorInitializers.Add(new ObjectPropertyInitializer(Discriminator.Property, discriminatorValue));
            }

            Dictionary<string, Parameter> parameterMap = parameters.ToDictionary(
                parameter => parameter.Name,
                parameter => parameter);

            foreach (var property in Properties)
            {
                // we do not need to add initialization for raw data field
                if (isInitializer && property == RawDataField)
                {
                    continue;
                }

                ReferenceOrConstant? initializationValue = null;
                Constant? defaultInitializationValue = null;

                var propertyType = property.Declaration.Type;
                if (parameterMap.TryGetValue(property.Declaration.Name.ToVariableName(), out var parameter) || IsStruct)
                {
                    // For structs all properties become required
                    Constant? defaultParameterValue = null;
                    if (property.SchemaProperty?.ClientDefaultValue is { } defaultValueObject)
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
                else if (initializationValue == null && TypeFactory.IsCollectionType(propertyType))
                {
                    if (TypeFactory.IsReadOnlyMemory(propertyType))
                    {
                        initializationValue = propertyType.IsNullable ? null : Constant.FromExpression($"{propertyType}.{nameof(ReadOnlyMemory<object>.Empty)}", propertyType);
                    }
                    else
                    {
                        initializationValue = Constant.NewInstanceOf(TypeFactory.GetPropertyImplementationType(propertyType));
                    }
                }
                else if (property.InputModelProperty?.ConstantValue is { } constant && !propertyType.IsNullable && Configuration.Generation1ConvenienceClient)
                {
                    initializationValue = BuilderHelpers.ParseConstant(constant.Value, propertyType);
                }

                if (initializationValue != null)
                {
                    defaultCtorInitializers.Add(new ObjectPropertyInitializer(property, initializationValue.Value, defaultInitializationValue));
                }
            }

            if (Configuration.Generation1ConvenienceClient && Discriminator is { } discriminator)
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

            return defaultCtorInitializers;
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

        private HashSet<string> GetParentPropertyNames()
        {
            return EnumerateHierarchy()
                .Skip(1)
                .SelectMany(type => type.Properties)
                .Select(p => p.Declaration.Name)
                .ToHashSet();
        }

        private INamedTypeSymbol? GetSourceBaseType()
            => ExistingType?.BaseType is { } sourceBaseType && sourceBaseType.SpecialType != SpecialType.System_ValueType && sourceBaseType.SpecialType != SpecialType.System_Object
                ? sourceBaseType
                : null;

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            var existingPropertyNames = GetParentPropertyNames();
            foreach (var field in Fields)
            {
                var property = new ObjectTypeProperty(field, Fields.GetInputByField(field));
                if (existingPropertyNames.Contains(property.Declaration.Name))
                    continue;
                yield return property;
            }

            if (AdditionalPropertiesProperty is { } additionalPropertiesProperty)
                yield return additionalPropertiesProperty;

            if (RawDataField is { } rawData)
                yield return rawData;
        }

        protected override IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            if (!SkipInitializerConstructor)
                yield return InitializationConstructor;

            if (SerializationConstructor != InitializationConstructor)
                yield return SerializationConstructor;

            if (EmptyConstructor != null)
                yield return EmptyConstructor;
        }

        protected override JsonObjectSerialization? BuildJsonSerialization()
        {
            if (IsPropertyBag || !_inputModelSerialization.Json)
                return null;
            // Serialization uses field and property names that first need to verified for uniqueness
            // For that, FieldDeclaration instances must be written in the main partial class before JsonObjectSerialization is created for the serialization partial class
            var properties = SerializationBuilder.GetPropertySerializations(this, _typeFactory);
            var additionalProperties = CreateAdditionalPropertiesSerialization();
            return new(this, SerializationConstructor.Signature.Parameters, properties, additionalProperties, Discriminator, JsonConverter);
        }

        protected override BicepObjectSerialization? BuildBicepSerialization(JsonObjectSerialization? json) => null;

        private JsonAdditionalPropertiesSerialization? CreateAdditionalPropertiesSerialization()
        {
            bool shouldExcludeInWireSerialization = false;
            ObjectTypeProperty? additionalPropertiesProperty = null;
            InputType? additionalPropertiesValueType = null;
            foreach (var model in EnumerateHierarchy())
            {
                additionalPropertiesProperty = model.AdditionalPropertiesProperty ?? (model as SerializableObjectType)?.RawDataField;
                if (additionalPropertiesProperty != null)
                {
                    // if this is a real "AdditionalProperties", we should NOT exclude it in wire
                    shouldExcludeInWireSerialization = additionalPropertiesProperty != model.AdditionalPropertiesProperty;
                    if (model is ModelTypeProvider { AdditionalPropertiesProperty: { } additionalProperties, _inputModel.InheritedDictionaryType: { } inheritedDictionaryType })
                    {
                        additionalPropertiesValueType = inheritedDictionaryType.ValueType;
                    }
                    break;
                }
            }

            if (additionalPropertiesProperty == null)
            {
                return null;
            }

            var dictionaryValueType = additionalPropertiesProperty.Declaration.Type.Arguments[1];
            Debug.Assert(!dictionaryValueType.IsNullable, $"{typeof(JsonCodeWriterExtensions)} implicitly relies on {additionalPropertiesProperty.Declaration.Name} dictionary value being non-nullable");
            JsonSerialization valueSerialization;
            if (additionalPropertiesValueType is not null)
            {
                // build the serialization when there is an input type corresponding to it
                valueSerialization = SerializationBuilder.BuildJsonSerialization(additionalPropertiesValueType, dictionaryValueType, false, SerializationFormat.Default);
            }
            else
            {
                // build a simple one from its type when there is not an input type corresponding to it (indicating it is a raw data field)
                valueSerialization = new JsonValueSerialization(dictionaryValueType, SerializationFormat.Default, true);
            }

            return new JsonAdditionalPropertiesSerialization(
                additionalPropertiesProperty,
                valueSerialization,
                new CSharpType(typeof(Dictionary<,>), additionalPropertiesProperty.Declaration.Type.Arguments),
                shouldExcludeInWireSerialization);
        }

        protected override XmlObjectSerialization? BuildXmlSerialization()
        {
            return _inputModelSerialization.Xml is {} xml ? SerializationBuilder.BuildXmlObjectSerialization(xml.Name ?? _inputModel.Name, this, _typeFactory) : null;
        }

        protected override bool EnsureIncludeSerializer()
        {
            // TODO -- this should always return true when use model reader writer is enabled.
            return Configuration.UseModelReaderWriter || _inputModelUsage.HasFlag(InputModelTypeUsage.Input);
        }

        protected override bool EnsureIncludeDeserializer()
        {
            // TODO -- this should always return true when use model reader writer is enabled.
            return Configuration.UseModelReaderWriter || _inputModelUsage.HasFlag(InputModelTypeUsage.Output);
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            foreach (var method in SerializationMethodsBuilder.BuildSerializationMethods(this))
            {
                yield return method;
            }

            if (Configuration.Generation1ConvenienceClient)
                yield break;

            if (IncludeDeserializer)
                yield return Snippets.Extensible.Model.BuildFromOperationResponseMethod(this, GetFromResponseModifiers());
            if (IncludeSerializer)
                yield return Snippets.Extensible.Model.BuildConversionToRequestBodyMethod(GetToRequestContentModifiers());
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
                implementations = GetDerivedTypes(_derivedModels).OrderBy(i => i.Key).ToArray();

                // find the discriminator corresponding property in this type or its base type or more
                property = GetPropertyForDiscriminator(discriminatorPropertyName);
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

        private ObjectTypeProperty GetPropertyForDiscriminator(string inputPropertyName)
        {
            foreach (var obj in EnumerateHierarchy())
            {
                var property = obj.Properties.FirstOrDefault(p => p.InputModelProperty is not null && (p.InputModelProperty.IsDiscriminator || p.InputModelProperty.Name == inputPropertyName));
                if (property is not null)
                    return property;
            }

            throw new InvalidOperationException($"Expecting discriminator property {inputPropertyName} on model {Declaration.Name}, but found none");
        }

        private IEnumerable<ObjectTypeDiscriminatorImplementation> GetDerivedTypes(IReadOnlyList<InputModelType> derivedInputTypes)
        {
            foreach (var derivedInputType in derivedInputTypes)
            {
                var derivedModel = (ModelTypeProvider)_typeFactory.CreateType(derivedInputType).Implementation;
                foreach (var discriminatorImplementation in GetDerivedTypes(derivedModel._derivedModels))
                {
                    yield return discriminatorImplementation;
                }

                yield return new ObjectTypeDiscriminatorImplementation(derivedInputType.DiscriminatorValue!, derivedModel.Type);
            }
        }

        internal ModelTypeProvider ReplaceProperty(InputModelProperty property, InputType inputType)
        {
            var result = new ModelTypeProvider(
                _inputModel.ReplaceProperty(property, inputType),
                DefaultNamespace,
                _sourceInputModel,
                _typeFactory,
                _defaultDerivedType);
            return result;
        }
    }
}
