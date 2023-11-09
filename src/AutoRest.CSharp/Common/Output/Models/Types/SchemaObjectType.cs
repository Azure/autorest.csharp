// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class SchemaObjectType : SerializableObjectType
    {
        private readonly BuildContext? _context;
        private readonly SerializationBuilder _serializationBuilder;
        private readonly TypeFactory _typeFactory;
        private readonly InputModelTypeUsage _usage;

        private readonly ModelTypeMapping? _sourceTypeMapping;
        private readonly IReadOnlyList<KnownMediaType> _supportedSerializationFormats;

        private ObjectTypeProperty? _additionalPropertiesProperty;
        private CSharpType? _implementsDictionaryType;

        protected SchemaObjectType(InputModelType inputModel, TypeFactory typeFactory, BuildContext context, string? newName = default)
            : base(context.DefaultNamespace, context.SourceInputModel)
        {
            DefaultName = (newName ?? inputModel.Name).ToCleanName();
            DefaultNamespace = GetDefaultModelNamespace(inputModel.Namespace, context.DefaultNamespace);
            InputModel = inputModel;

            _context = context;
            _typeFactory = typeFactory;
            _serializationBuilder = new SerializationBuilder();
            _usage = inputModel.Usage;

            var hasUsage = _usage.HasFlag(InputModelTypeUsage.RoundTrip);

            DefaultAccessibility = inputModel.Accessibility ?? (hasUsage ? "public" : "internal");

            _sourceTypeMapping = context.SourceInputModel?.CreateForModel(ExistingType);

            // Update usage from code attribute
            if (_sourceTypeMapping?.Usage != null)
            {
                foreach (var usage in _sourceTypeMapping.Usage)
                {
                    _usage |= Enum.Parse<InputModelTypeUsage>(usage, true);
                }
            }

            _supportedSerializationFormats = GetSupportedSerializationFormats(inputModel, _sourceTypeMapping);
        }

        internal InputModelType InputModel { get; }

        protected override string DefaultName { get; }
        protected override string DefaultNamespace { get; }
        protected override string DefaultAccessibility { get; } = "public";
        protected override TypeKind TypeKind => IsStruct ? TypeKind.Struct : TypeKind.Class;

        private SerializableObjectType? _defaultDerivedType;
        private bool _hasCalculatedDefaultDerivedType;

        public SerializableObjectType? DefaultDerivedType => _defaultDerivedType ??= BuildDefaultDerivedType();

        // TODO: handle this while regen resource manager
        //public bool IsInheritableCommonType => InputModel is { Extensions: {} } && (InputModel.Extensions.MgmtReferenceType || InputModel.Extensions.MgmtTypeReferenceType);

        public override ObjectTypeProperty? AdditionalPropertiesProperty
        {
            get
            {
                if (_additionalPropertiesProperty != null || ImplementsDictionaryType == null)
                {
                    return _additionalPropertiesProperty;
                }

                // We use a $ prefix here as AdditionalProperties comes from a swagger concept
                // and not a swagger model/operation name to disambiguate from a possible property with
                // the same name.
                var existingMember = _sourceTypeMapping?.GetMemberByOriginalName("$AdditionalProperties");

                _additionalPropertiesProperty = new ObjectTypeProperty(
                    BuilderHelpers.CreateMemberDeclaration("AdditionalProperties", ImplementsDictionaryType, "public", existingMember, _typeFactory),
                    "Additional Properties",
                    true,
                    null
                    );

                return _additionalPropertiesProperty;
            }
        }

        protected override ObjectTypeConstructor BuildSerializationConstructor()
        {
            bool ownsDiscriminatorProperty = false;

            List<Parameter> serializationConstructorParameters = new List<Parameter>();
            List<ObjectPropertyInitializer> serializationInitializers = new List<ObjectPropertyInitializer>();
            ObjectTypeConstructor? baseSerializationCtor = null;

            if (Inherits is { IsFrameworkType: false, Implementation: ObjectType objectType })
            {
                baseSerializationCtor = objectType.SerializationConstructor;
                serializationConstructorParameters.AddRange(baseSerializationCtor.Signature.Parameters);
            }

            foreach (var property in Properties)
            {
                // skip the flattened properties, we should never include them in serialization
                if (property is FlattenedObjectTypeProperty)
                    continue;

                var type = property.Declaration.Type;

                var deserializationParameter = new Parameter(
                    property.Declaration.Name.ToVariableName(),
                    property.ParameterDescription,
                    type,
                    null,
                    Validation.None,
                    null
                );

                ownsDiscriminatorProperty |= property == Discriminator?.Property;

                serializationConstructorParameters.Add(deserializationParameter);

                serializationInitializers.Add(new ObjectPropertyInitializer(property, deserializationParameter, GetPropertyDefaultValue(property)));
            }

            if (InitializationConstructor.Signature.Parameters
                .Select(p => p.Type)
                .SequenceEqual(serializationConstructorParameters.Select(p => p.Type)))
            {
                return InitializationConstructor;
            }

            if (Discriminator != null)
            {
                // Add discriminator initializer to constructor at every level of hierarchy
                if (!ownsDiscriminatorProperty &&
                    baseSerializationCtor != null)
                {
                    var discriminatorParameter = baseSerializationCtor.FindParameterByInitializedProperty(Discriminator.Property);
                    Debug.Assert(discriminatorParameter != null);
                    ReferenceOrConstant? defaultValue = null;
                    if (TypeFactory.CanBeInitializedInline(discriminatorParameter.Type, Discriminator.Value))
                    {
                        defaultValue = Discriminator.Value;
                    }
                    serializationInitializers.Add(new ObjectPropertyInitializer(Discriminator.Property, discriminatorParameter, defaultValue));
                }
            }

            return new ObjectTypeConstructor(
                Type,
                // TODO: handle this while regen resource manager
                //IsInheritableCommonType ? Protected : Internal,
                Protected,
                serializationConstructorParameters.ToArray(),
                serializationInitializers.ToArray(),
                baseSerializationCtor
            );
        }

        private ReferenceOrConstant? GetPropertyDefaultValue(ObjectTypeProperty property)
        {
            if (property == Discriminator?.Property &&
                Discriminator.Value != null)
            {
                return Discriminator.Value;
            }

            return null;
        }

        protected override IEnumerable<Method> BuildMethods()
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

            if (JsonSerialization is { } serialization)
            {
                if (IncludeSerializer)
                {
                    yield return JsonSerializationMethodsBuilder.BuildUtf8JsonSerializableWrite(serialization);
                }

                if (IncludeDeserializer && JsonSerializationMethodsBuilder.BuildDeserialize(Declaration, serialization, ExistingType) is {} jsonDeserialize)
                {
                    yield return jsonDeserialize;
                }
            }
        }

        protected override ObjectTypeConstructor BuildInitializationConstructor()
        {
            List<Parameter> defaultCtorParameters = new List<Parameter>();
            List<ObjectPropertyInitializer> defaultCtorInitializers = new List<ObjectPropertyInitializer>();

            ObjectTypeConstructor? baseCtor = GetBaseObjectType()?.InitializationConstructor;
            if (baseCtor is not null)
                defaultCtorParameters.AddRange(baseCtor.Signature.Parameters);

            foreach (var property in Properties)
            {
                // Only required properties that are not discriminators go into default ctor
                // skip the flattened properties, we should never include them in the constructors
                if (property == Discriminator?.Property || property is FlattenedObjectTypeProperty)
                {
                    continue;
                }

                ReferenceOrConstant? initializationValue;
                Constant? defaultInitializationValue = null;

                var propertyType = property.Declaration.Type;
                if (property.InputModelProperty!.ConstantValue is not null && property.IsRequired)
                {
                    // Turn constants into initializers
                    initializationValue = BuilderHelpers.ParseConstant(property.InputModelProperty!.ConstantValue, propertyType);
                }
                else if (IsStruct || property.InputModelProperty?.IsRequired == true)
                {
                    // For structs all properties become required
                    Constant? defaultParameterValue = null;
                    var constantValue = property.InputModelProperty?.ConstantValue;
                    Constant? clientDefaultValue = constantValue != null ? BuilderHelpers.ParseConstant(constantValue.Value, _typeFactory.CreateType(constantValue.Type)) : null;
                    if (clientDefaultValue is object defaultValueObject)
                    {
                        defaultParameterValue = BuilderHelpers.ParseConstant(defaultValueObject, propertyType);
                        defaultInitializationValue = defaultParameterValue;
                    }

                    var inputType = TypeFactory.GetInputType(propertyType);
                    if (defaultParameterValue != null && !TypeFactory.CanBeInitializedInline(property.ValueType, defaultParameterValue))
                    {
                        inputType = inputType.WithNullable(true);
                        defaultParameterValue = Constant.Default(inputType);
                    }

                    var validate = property.InputModelProperty?.Type.IsNullable != true && !inputType.IsValueType ? Validation.AssertNotNull : Validation.None;
                    var defaultCtorParameter = new Parameter(
                        property.Declaration.Name.ToVariableName(),
                        property.ParameterDescription,
                        inputType,
                        defaultParameterValue,
                        validate,
                        null
                    );

                    defaultCtorParameters.Add(defaultCtorParameter);
                    initializationValue = defaultCtorParameter;
                }
                else
                {
                    initializationValue = GetPropertyDefaultValue(property);

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

            if (Discriminator?.Value != null)
            {
                defaultCtorInitializers.Add(new ObjectPropertyInitializer(Discriminator.Property, Discriminator.Value.Value));
            }

            if (AdditionalPropertiesProperty != null &&
                !defaultCtorInitializers.Any(i => i.Property == AdditionalPropertiesProperty))
            {
                defaultCtorInitializers.Add(new ObjectPropertyInitializer(AdditionalPropertiesProperty, Constant.NewInstanceOf(TypeFactory.GetImplementationType(AdditionalPropertiesProperty.Declaration.Type))));
            }

            return new ObjectTypeConstructor(
                Type,
                IsAbstract ? Protected : _usage.HasFlag(SchemaTypeUsage.Input) ? Public : Internal,
                defaultCtorParameters.ToArray(),
                defaultCtorInitializers.ToArray(),
                baseCtor);
        }

        public override bool IncludeConverter => _usage.HasFlag(SchemaTypeUsage.Converter);
        protected bool SkipSerializerConstructor => !IncludeDeserializer;
        private CSharpType? ImplementsDictionaryType => _implementsDictionaryType ??= CreateInheritedDictionaryType();
        protected override IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            // TODO: Skip initialization ctor if this instance is used to support forward compatibility in polymorphism.
            yield return InitializationConstructor;

            // Skip serialization ctor if they are the same
            if (!SkipSerializerConstructor && InitializationConstructor != SerializationConstructor)
            {
                yield return SerializationConstructor;
            }
        }

        protected override ObjectTypeDiscriminator? BuildDiscriminator()
        {
            var parentDiscriminator = GetBaseObjectType()?.Discriminator;
            var property = Properties.FirstOrDefault(p => p.InputModelProperty is not null && p.InputModelProperty.IsDiscriminator)
                ?? parentDiscriminator?.Property;

            var discriminatorPropertyName = InputModel.DiscriminatorPropertyName ?? parentDiscriminator?.SerializedName;

            //neither me nor my parent are discriminators so I can bail
            if (property is null || discriminatorPropertyName is null)
            {
                return null;
            }

            Constant? value = null;

            //only load implementations for the base type
            // [TODO]: OrderBy(i => i.Key) is needed only to preserve the order. Remove it in a separate PR.
            var implementations = Configuration.Generation1ConvenienceClient
                ? GetDerivedTypes(InputModel.DerivedModels).OrderBy(i => i.Key).ToArray()
                : GetDerivedTypes(InputModel.DerivedModels).ToArray();


            if (InputModel.DiscriminatorValue != null)
            {
                value = BuilderHelpers.ParseConstant(InputModel.DiscriminatorValue, property.Declaration.Type);
            }

            return new ObjectTypeDiscriminator(
                property,
                discriminatorPropertyName,
                implementations,
                value,
                _defaultDerivedType!
            );
        }

        private static IReadOnlyList<KnownMediaType> GetSupportedSerializationFormats(InputModelType inputModel, ModelTypeMapping? sourceTypeMapping)
        {
            var formats = new HashSet<KnownMediaType>();
            if (true == inputModel.Serialization?.Json)
            {
                formats.Add(KnownMediaType.Json);
            }
            if (inputModel.Serialization?.Xml is not null)
            {
                formats.Add(KnownMediaType.Xml);
            }
            if (Configuration.SkipSerializationFormatXml)
            {
                formats.Remove(KnownMediaType.Xml);
            }
            if (sourceTypeMapping?.Formats is { } formatsDefinedInSource)
            {
                foreach (var format in formatsDefinedInSource)
                {
                    formats.Add(Enum.Parse<KnownMediaType>(format, true));
                }
            }

            return formats.ToArray();
        }

        private HashSet<string> GetParentPropertySerializedNames()
        {
            return EnumerateHierarchy()
                .Skip(1)
                .SelectMany(type => type.Properties)
                .Select(p => p.InputModelProperty!.Name)
                .ToHashSet();
        }

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            var existingProperties = GetParentPropertySerializedNames();

            foreach (var objectSchema in GetCombinedSchemas())
            {
                foreach (InputModelProperty property in objectSchema.Properties!)
                {
                    if (existingProperties.Contains(property.Name))
                    {
                        continue;
                    }


                    yield return CreateProperty(property);
                }
            }

            if (AdditionalPropertiesProperty is { } additionalPropertiesProperty)
            {
                yield return additionalPropertiesProperty;
            }
        }

        protected ObjectTypeProperty CreateProperty(InputModelProperty property)
        {
            var name = BuilderHelpers.DisambiguateName(Type.Name, property.Type.Name);
            var existingMember = _sourceTypeMapping?.GetMemberByOriginalName(name);

            var serializationMapping = _sourceTypeMapping?.GetForMemberSerialization(existingMember);

            var accessibility = property.IsDiscriminator == true ? "internal" : "public";

            var propertyType = GetDefaultPropertyType(property);

            // We represent property being optional by making it nullable
            // Except in the case of collection where there is a special handling
            bool optionalViaNullability = !property.IsRequired &&
                                          !property.Type.IsNullable &&
                                          !TypeFactory.IsCollectionType(propertyType);

            if (optionalViaNullability)
            {
                propertyType = propertyType.WithNullable(true);
            }

            var memberDeclaration = BuilderHelpers.CreateMemberDeclaration(
                name,
                propertyType,
                accessibility,
                existingMember,
                _typeFactory);

            var type = memberDeclaration.Type;

            var valueType = type;
            if (optionalViaNullability)
            {
                valueType = valueType.WithNullable(false);
            }

            bool isCollection = TypeFactory.IsCollectionType(type);

            bool propertyShouldOmitSetter = IsStruct ||
                              !_usage.HasFlag(SchemaTypeUsage.Input) ||
                              property.IsReadOnly;


            if (isCollection)
            {
                propertyShouldOmitSetter |= !property.Type.IsNullable;
            }
            else
            {
                // In mixed models required properties are not readonly
                propertyShouldOmitSetter |= property.IsRequired &&
                              _usage.HasFlag(SchemaTypeUsage.Input) &&
                              !_usage.HasFlag(SchemaTypeUsage.Output);
            }

            // we should remove the setter of required constant
            if (property.Type is InputModelType && property.IsRequired)
            {
                propertyShouldOmitSetter = true;
            }

            if (property.IsDiscriminator == true)
            {
                // Discriminator properties should be writeable
                propertyShouldOmitSetter = false;
            }

            var objectTypeProperty = new ObjectTypeProperty(
                memberDeclaration,
                BuilderHelpers.EscapeXmlDocDescription(property.Description),
                propertyShouldOmitSetter,
                property,
                valueType,
                optionalViaNullability,
                serializationMapping);
            return objectTypeProperty;
        }

        private CSharpType GetDefaultPropertyType(InputModelProperty property)
        {
            var valueType = _typeFactory.CreateType(property.Type);

            if (!_usage.HasFlag(SchemaTypeUsage.Input) ||
                property.IsReadOnly)
            {
                valueType = TypeFactory.GetOutputType(valueType);
            }

            return valueType;
        }

        // Enumerates all schemas that were merged into this one, excludes the inherited schema
        protected internal IEnumerable<InputModelType> GetCombinedSchemas()
        {
            yield return InputModel;

            foreach (var parent in InputModel.DerivedModels)
            {
                if (parent is InputModelType objectParent)
                {
                    yield return objectParent;
                }
            }
        }

        protected override CSharpType? CreateInheritedType()
        {
            var sourceBaseType = ExistingType?.BaseType;
            if (sourceBaseType != null &&
                sourceBaseType.SpecialType != SpecialType.System_ValueType &&
                sourceBaseType.SpecialType != SpecialType.System_Object &&
                _typeFactory.TryCreateType(sourceBaseType, out CSharpType? baseType))
            {
                return baseType;
            }

            var objectSchemas = InputModel.DerivedModels.OfType<InputModelType>();

            InputModelType? selectedType = null;

            foreach (var objectSchema in objectSchemas)
            {
                // Take first schema or the one with discriminator
                selectedType ??= objectSchema;

                if (objectSchema.DiscriminatorPropertyName != null)
                {
                    selectedType = objectSchema;
                    break;
                }
            }

            if (selectedType != null)
            {
                CSharpType type = _typeFactory.CreateType(selectedType);
                Debug.Assert(!type.IsFrameworkType);
                return type;
            }
            return null;
        }

        private CSharpType? CreateInheritedDictionaryType()
        {
            if (InputModel.InheritedDictionaryType is not null)
            {
                return new CSharpType(
                        _usage.HasFlag(InputModelTypeUsage.Input) ? typeof(IDictionary<,>) : typeof(IReadOnlyDictionary<,>),
                        typeof(string),
                        _typeFactory.CreateType(InputModel.InheritedDictionaryType));
            }

            return null;
        }

        public override ObjectTypeProperty GetPropertyBySerializedName(string serializedName, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.InputModelProperty!.SerializedName == serializedName, out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property with serialized name '{serializedName}' in schema {DefaultName}");
            }

            return objectProperty;
        }

        // TODO: handle it later
        //public ObjectTypeProperty GetPropertyForGroupedParameter(string groupedParameterName, bool includeParents = false)
        //{
        //    if (!TryGetPropertyForSchemaProperty(
        //            p => p.InputModelProperty is GroupProperty groupProperty && groupProperty.OriginalParameter.Any(p => p.Language.Default.Name == groupedParameterName),
        //            out ObjectTypeProperty? objectProperty, includeParents))
        //    {
        //        throw new InvalidOperationException($"Unable to find object property for grouped parameter {groupedParameterName} in schema {DefaultName}");
        //    }

        //    return objectProperty;
        //}

        private bool TryGetPropertyForSchemaProperty(Func<ObjectTypeProperty, bool> propertySelector, [NotNullWhen(true)] out ObjectTypeProperty? objectProperty, bool includeParents = false)
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

        protected override FormattableString CreateDescription()
        {
            return $"{InputModel.DerivedModels}";
        }

        protected override bool EnsureHasJsonSerialization()
        {
            return _supportedSerializationFormats.Contains(KnownMediaType.Json);
        }

        protected override bool EnsureHasXmlSerialization()
        {
            return _supportedSerializationFormats.Contains(KnownMediaType.Xml);
        }

        protected override bool EnsureIncludeSerializer()
        {
            return _usage.HasFlag(SchemaTypeUsage.Input);
        }

        protected override bool EnsureIncludeDeserializer()
        {
            return _usage.HasFlag(SchemaTypeUsage.Output);
        }

        protected override JsonObjectSerialization EnsureJsonSerialization()
        {
            return _serializationBuilder.BuildJsonObjectSerialization(InputModel, this);
        }

        protected override XmlObjectSerialization EnsureXmlSerialization()
        {
            var serializationName = InputModel.Serialization?.Xml?.Name ?? InputModel.Name;
            return SerializationBuilder.BuildXmlObjectSerialization(serializationName, this, _typeFactory);
        }

        private SerializableObjectType? BuildDefaultDerivedType()
        {
            if (_hasCalculatedDefaultDerivedType)
                return _defaultDerivedType;

            _hasCalculatedDefaultDerivedType = true;
            var library = _context?.BaseLibrary;

            if (library is null)
                return null;

            var defaultDerivedType = InputModel.BaseModel;
            if (defaultDerivedType is null)
                return null;

            return library.FindTypeProviderForInputType(defaultDerivedType) as SerializableObjectType;
        }

        private IEnumerable<ObjectTypeDiscriminatorImplementation> GetDerivedTypes(IReadOnlyList<InputModelType> derivedInputTypes)
        {
            foreach (var derivedInputType in derivedInputTypes)
            {
                var derivedType = (SchemaObjectType)_typeFactory.CreateType(derivedInputType).Implementation;
                foreach (var discriminatorImplementation in GetDerivedTypes(derivedType.InputModel.DerivedModels))
                {
                    yield return discriminatorImplementation;
                }

                yield return new ObjectTypeDiscriminatorImplementation(derivedInputType.DiscriminatorValue!, derivedType.Type);
            }
        }
    }
}
