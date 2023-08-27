// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models;
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
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal sealed class ModelTypeProvider : SerializableObjectType
    {
        private ConstructorSignature? _publicConstructor;
        private ConstructorSignature? _serializationConstructor;
        private readonly InputModelType _inputModel;
        private readonly TypeFactory _typeFactory;
        private readonly IReadOnlyList<InputModelType> _derivedTypes;
        private readonly ObjectType? _defaultDerivedType;
        private readonly ModelTypeMapping? _modelTypeMapping;
        private readonly InputModelTypeUsage _inputModelUsage;
        private readonly InputTypeSerialization _inputModelSerialization;
        private readonly IReadOnlyList<InputModelProperty> _inputModelProperties;
        private ModelTypeProviderFields? _fields;

        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; }
        protected override TypeKind TypeKind { get; }
        public override bool IncludeConverter => _inputModelSerialization.IncludeConverter;
        protected override bool IsAbstract => !Configuration.SuppressAbstractBaseClasses.Contains(DefaultName) && _inputModel.DiscriminatorPropertyName is not null && _inputModel.BaseModel is null;

        public ModelTypeProviderFields Fields => _fields ??= new ModelTypeProviderFields(_inputModelProperties, Declaration.Name, _inputModelUsage, _typeFactory, _modelTypeMapping, _inputModel.InheritedDictionaryType, IsStruct, _inputModel.IsPropertyBag);
        public ConstructorSignature InitializationConstructorSignature => _publicConstructor ??= EnsurePublicConstructorSignature();
        public ConstructorSignature SerializationConstructorSignature => _serializationConstructor ??= EnsureSerializationConstructorSignature();

        public override ObjectTypeProperty? AdditionalPropertiesProperty => Fields.AdditionalProperties is {} additionalProperties
                ? Properties.First(p => p.Declaration.Name == additionalProperties.Name)
                : null;

        public bool IsPropertyBag => _inputModel.IsPropertyBag;

        public ModelTypeProvider(InputModelType inputModel, string defaultNamespace, SourceInputModel? sourceInputModel, TypeFactory typeFactory, ObjectType? defaultDerivedType = null)
            : base(defaultNamespace, sourceInputModel)
        {
            _typeFactory = typeFactory;
            _inputModel = inputModel;

            _deprecated = inputModel.Deprecated;
            _derivedTypes = inputModel.DerivedModels;
            _defaultDerivedType = defaultDerivedType ?? (inputModel.IsUnknownDiscriminatorModel ? this : null);

            DefaultName = inputModel.Name;
            DefaultAccessibility = inputModel.Accessibility ?? "public";
            TypeKind = IsStruct ? TypeKind.Struct : TypeKind.Class;

            _modelTypeMapping = sourceInputModel?.CreateForModel(ExistingType);
            _inputModelUsage = UpdateInputModelUsage(inputModel, _modelTypeMapping);
            _inputModelSerialization = UpdateInputSerialization(inputModel, _modelTypeMapping);
            _inputModelProperties = UpdateInputModelProperties(inputModel, GetSourceBaseType());
        }

        private static InputModelTypeUsage UpdateInputModelUsage(InputModelType inputModel, ModelTypeMapping? modelTypeMapping)
        {
            var usage = inputModel.Usage;
            if (modelTypeMapping?.Usage is {} usageDefinedInSource)
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
                        serialization = serialization with {Json = true};
                    }
                    else if (mediaType == KnownMediaType.Xml)
                    {
                        serialization = serialization with {Xml = new InputTypeXmlSerialization(inputModel.Name, false, false, false)};
                    }
                }
            }

            if (modelTypeMapping?.Usage is {} usage && usage.Contains(nameof(SchemaTypeUsage.Converter), StringComparer.OrdinalIgnoreCase))
            {
                serialization = serialization with {IncludeConverter = true};
            }

            return serialization;
        }

        private static IReadOnlyList<InputModelProperty> UpdateInputModelProperties(InputModelType inputModel, INamedTypeSymbol? existingBaseType)
        {
            if (inputModel.BaseModel is not {} baseModel)
            {
                return inputModel.Properties;
            }

            var properties = inputModel.Properties.ToList();
            var compositionModels = inputModel.CompositionModels;

            if (existingBaseType is not null && existingBaseType.Name != baseModel.Name)
            {
                var baseTypeReplacement = inputModel.CompositionModels.FirstOrDefault(m => m.Name == existingBaseType.Name);
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

        private ConstructorSignature EnsurePublicConstructorSignature()
        {
            var name = Declaration.Name;
            //get base public ctor params
            GetConstructorParameters(Fields.PublicConstructorParameters, out var fullParameterList, out var parametersToPassToBase, true);

            var summary = $"Initializes a new instance of {name}";
            var accessibility = IsAbstract
                ? MethodSignatureModifiers.Protected
                : _inputModelUsage.HasFlag(InputModelTypeUsage.Input)
                    ? MethodSignatureModifiers.Public
                    : MethodSignatureModifiers.Internal;

            return new ConstructorSignature(
                name,
                summary,
                null,
                accessibility,
                fullParameterList,
                Initializer: new(true, parametersToPassToBase));
        }

        private ConstructorSignature EnsureSerializationConstructorSignature()
        {
            var name = Declaration.Name;

            //get base public ctor params
            GetConstructorParameters(Fields.SerializationParameters, out var fullParameterList, out var parametersToPassToBase, false);

            return new ConstructorSignature(
                name,
                $"Initializes a new instance of {name}",
                null,
                MethodSignatureModifiers.Internal,
                fullParameterList,
                Initializer: new(true, parametersToPassToBase));
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
            fullParameterList.AddRange(parameters.Select(p => p with {Description = p.Description + BuilderHelpers.CreateDerivedTypesDescription(p.Type)}));
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
                else if (Configuration.Generation1ConvenienceClient && property.InputModelProperty?.ConstantValue is {} constant && !propertyType.IsNullable)
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
                    else if (!_inputModel.IsUnknownDiscriminatorModel && discriminator.Value is {} value)
                    {
                        defaultCtorInitializers.Add(new ObjectPropertyInitializer(Discriminator.Property, value));
                    }
                }
            }

            return defaultCtorInitializers.ToArray();
        }

        protected override CSharpType? CreateInheritedType()
        {
            if (GetSourceBaseType() is {} sourceBaseType && _typeFactory.TryCreateType(sourceBaseType, out CSharpType? baseType))
            {
                return baseType;
            }

            return _inputModel.BaseModel is {} baseModel
                ? _typeFactory.CreateType(baseModel)
                : null;
        }

        private INamedTypeSymbol? GetSourceBaseType()
            => ExistingType?.BaseType is {} sourceBaseType && sourceBaseType.SpecialType != SpecialType.System_ValueType && sourceBaseType.SpecialType != SpecialType.System_Object ? sourceBaseType : null;

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
            => Fields.Select(f => new ObjectTypeProperty(f, Fields.GetInputByField(f)));

        protected override IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            if (!_inputModel.IsUnknownDiscriminatorModel)
            {
                yield return InitializationConstructor;
            }

            if (SerializationConstructor != InitializationConstructor && (!Configuration.Generation1ConvenienceClient || IncludeDeserializer))
            {
                yield return SerializationConstructor;
            }
        }

        protected override bool EnsureHasJsonSerialization()
        {
            if (IsPropertyBag)
                return false;
            return _inputModelSerialization.Json;
        }

        protected override bool EnsureHasXmlSerialization() => _inputModelSerialization.Xml is not null;

        protected override bool EnsureIncludeSerializer() => _inputModelUsage.HasFlag(InputModelTypeUsage.Input) && !_inputModel.IsUnknownDiscriminatorModel;

        protected override bool EnsureIncludeDeserializer() => _inputModelUsage.HasFlag(InputModelTypeUsage.Output);

        protected override JsonObjectSerialization EnsureJsonSerialization()
        {
            // Serialization uses field and property names that first need to verified for uniqueness
            // For that, FieldDeclaration instances must be written in the main partial class before JsonObjectSerialization is created for the serialization partial class
            var properties = SerializationBuilder.GetPropertySerializations(this, _inputModelUsage);
            var additionalProperties = CreateAdditionalPropertySerialization();
            return new(Type, SerializationConstructor.Signature.Parameters, properties, additionalProperties, Discriminator, IncludeConverter);
        }

        private JsonAdditionalPropertiesSerialization? CreateAdditionalPropertySerialization()
        {
            foreach (var model in EnumerateHierarchy().OfType<ModelTypeProvider>())
            {
                if (model is { AdditionalPropertiesProperty: {} additionalProperties, _inputModel.InheritedDictionaryType: {} inheritedDictionaryType })
                {
                    var dictionaryValueType = additionalProperties.Declaration.Type.Arguments[1];
                    Debug.Assert(!dictionaryValueType.IsNullable, $"{typeof(JsonCodeWriterExtensions)} implicitly relies on {additionalProperties.Declaration.Name} dictionary value being non-nullable");

                    var type = new CSharpType(typeof(Dictionary<,>), additionalProperties.Declaration.Type.Arguments);
                    var valueSerialization = SerializationBuilder.BuildJsonSerialization(inheritedDictionaryType.ValueType, dictionaryValueType, false);

                    return new JsonAdditionalPropertiesSerialization(additionalProperties, valueSerialization, type);
                }
            }

            return null;
        }

        protected override XmlObjectSerialization? EnsureXmlSerialization()
        {
            return SerializationBuilder.BuildXmlObjectSerialization(_inputModelSerialization.Xml?.Name ?? _inputModel.Name, this);
        }

        protected override IEnumerable<Method> BuildSerializationMethods()
        {
            if (XmlSerialization is {} xmlSerialization)
            {
                if (IncludeSerializer)
                {
                    yield return XmlSerializationMethodsBuilder.BuildXmlSerializableWrite(xmlSerialization);
                }

                if (IncludeDeserializer)
                {
                    yield return XmlSerializationMethodsBuilder.BuildDeserialize(Declaration, xmlSerialization);
                }
            }

            if (JsonSerialization is {} jsonSerialization)
            {
                if (IncludeSerializer)
                {
                    yield return JsonSerializationMethodsBuilder.BuildUtf8JsonSerializableWrite(jsonSerialization);
                }

                if (IncludeDeserializer)
                {
                    yield return JsonSerializationMethodsBuilder.BuildDeserialize(Declaration, jsonSerialization);
                }

                if (!Configuration.Generation1ConvenienceClient)
                {
                    if (IncludeDeserializer)
                    {
                        yield return JsonSerializationMethodsBuilder.BuildFromResponse(this, GetFromResponseModifiers());
                    }

                    if (IncludeSerializer)
                    {
                        yield return JsonSerializationMethodsBuilder.BuildToRequestContent(GetToRequestContentModifiers());
                    }
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
            if (derivedInputTypes == null)
            {
                yield break;
            }

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
