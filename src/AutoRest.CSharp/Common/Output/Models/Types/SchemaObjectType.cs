// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Bicep;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal abstract class SchemaObjectType : SerializableObjectType
    {
        private readonly SerializationBuilder _serializationBuilder;
        private readonly InputModelTypeUsage _usage;
        private readonly TypeFactory _typeFactory;
        private ObjectTypeProperty? _additionalPropertiesProperty;
        private CSharpType? _implementsDictionaryType;
        private readonly IReadOnlyList<string> _supportedSerializationFormats;

        protected SchemaObjectType(InputModelType inputModel, string defaultNamespace, TypeFactory typeFactory, SourceInputModel? sourceInputModel, SerializableObjectType? defaultDerivedType = null)
            : base(defaultNamespace, sourceInputModel)
        {
            _typeFactory = typeFactory;
            DefaultName = inputModel.CSharpName();
            InputModel = inputModel;
            _serializationBuilder = new SerializationBuilder();
            _usage = inputModel.Usage;

            DefaultAccessibility = inputModel.Accessibility ?? "public";

            // Update usage from code attribute
            if (ModelTypeMapping?.Usage != null)
            {
                foreach (var usage in ModelTypeMapping.Usage)
                {
                    _usage |= Enum.Parse<InputModelTypeUsage>(usage, true);
                }
            }

            _supportedSerializationFormats = GetSupportedSerializationFormats();
            _defaultDerivedType = defaultDerivedType ?? (inputModel.IsUnknownDiscriminatorModel ? this : null);
            IsUnknownDerivedType = inputModel.IsUnknownDiscriminatorModel;
            // we skip the init ctor when there is an extension telling us to, or when this is an unknown derived type in a discriminated set
            SkipInitializerConstructor = IsUnknownDerivedType;

            // TODO: handle this later
            IsInheritableCommonType = false;
            //IsInheritableCommonType = InputModel is { Extensions: { } extensions } && (extensions.MgmtReferenceType || extensions.MgmtTypeReferenceType);

            JsonConverter = _usage.HasFlag(InputModelTypeUsage.Converter) ? new JsonConverterProvider(this, _sourceInputModel) : null;
        }

        internal InputModelType InputModel { get; }

        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; } = "public";

        private SerializableObjectType? _defaultDerivedType;
        protected override bool IsAbstract => !Configuration.SuppressAbstractBaseClasses.Contains(DefaultName) && InputModel.DiscriminatorPropertyName != null;

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
                var existingMember = ModelTypeMapping?.GetMemberByOriginalName("$AdditionalProperties");

                _additionalPropertiesProperty = new ObjectTypeProperty(
                    BuilderHelpers.CreateMemberDeclaration("AdditionalProperties", ImplementsDictionaryType, "public", existingMember, _typeFactory),
                    "Additional Properties",
                    true,
                    null
                    );

                return _additionalPropertiesProperty;
            }
        }

        private ObjectTypeProperty? _rawDataField;
        protected internal override InputModelTypeUsage GetUsage() => (InputModelTypeUsage) _usage;

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
            if (InputModel.DerivedModels.Count > 0)
                return true;

            if (InputModel.DiscriminatorPropertyName is not null)
                return true;

            return false;
        }

        protected override ObjectTypeConstructor BuildSerializationConstructor()
        {
            bool ownsDiscriminatorProperty = false;

            List<Parameter> serializationConstructorParameters = new List<Parameter>();
            List<ObjectPropertyInitializer> serializationInitializers = new List<ObjectPropertyInitializer>();
            ObjectTypeConstructor? baseSerializationCtor = null;
            List<ValueExpression> baseParameterInitializers = new List<ValueExpression>();

            if (Inherits is { IsFrameworkType: false, Implementation: ObjectType objectType })
            {
                baseSerializationCtor = objectType.SerializationConstructor;
                foreach (var p in baseSerializationCtor.Signature.Parameters)
                {
                    if (p.IsRawData && AdditionalPropertiesProperty != null)
                    {
                        baseParameterInitializers.Add(Snippets.Null);
                        // do not add into the list
                    }
                    else
                    {
                        baseParameterInitializers.Add(p);
                        serializationConstructorParameters.Add(p);
                    }
                }
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
                    ValidationType.None,
                    null
                );

                ownsDiscriminatorProperty |= property == Discriminator?.Property;

                serializationConstructorParameters.Add(deserializationParameter);

                serializationInitializers.Add(new ObjectPropertyInitializer(property, deserializationParameter, GetPropertyDefaultValue(property)));
            }

            // add the raw data to serialization ctor parameter list
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
                serializationConstructorParameters.Add(deserializationParameter);
                serializationInitializers.Add(new ObjectPropertyInitializer(RawDataField, deserializationParameter, null));
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
                    if (discriminatorParameter.Type.CanBeInitializedInline(Discriminator.Value))
                    {
                        defaultValue = Discriminator.Value;
                    }
                    serializationInitializers.Add(new ObjectPropertyInitializer(Discriminator.Property, discriminatorParameter, defaultValue));
                }
            }

            var initializer = new ConstructorInitializer(true, baseParameterInitializers);

            var signature = new ConstructorSignature(
                Type,
                $"Initializes a new instance of {Type:C}",
                null,
                IsInheritableCommonType ? Protected : Internal,
                serializationConstructorParameters,
                Initializer: initializer);

            return new ObjectTypeConstructor(
                signature,
                serializationInitializers,
                baseSerializationCtor);
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

        protected override ObjectTypeConstructor BuildInitializationConstructor()
        {
            List<Parameter> defaultCtorParameters = new List<Parameter>();
            List<ObjectPropertyInitializer> defaultCtorInitializers = new List<ObjectPropertyInitializer>();

            ObjectTypeConstructor? baseCtor = GetBaseObjectType()?.InitializationConstructor;
            if (baseCtor is not null)
                defaultCtorParameters.AddRange(baseCtor.Signature.Parameters);

            foreach (var property in Properties)
            {
                // we do not need to add intialization for raw data field
                if (property == RawDataField)
                {
                    continue;
                }
                // Only required properties that are not discriminators go into default ctor
                // skip the flattened properties, we should never include them in the constructors
                if (property == Discriminator?.Property || property is FlattenedObjectTypeProperty)
                {
                    continue;
                }

                ReferenceOrConstant? initializationValue;
                Constant? defaultInitializationValue = null;

                var propertyType = property.Declaration.Type;
                if (property.InputModelProperty?.ConstantValue is not null && property.IsRequired)
                {
                    // Turn constants into initializers
                    initializationValue = BuilderHelpers.ParseConstant(property.InputModelProperty!.ConstantValue.Value, propertyType);
                }
                else if (IsStruct || property.InputModelProperty?.IsRequired == true)
                {
                    // For structs all properties become required
                    Constant? defaultParameterValue = null;
                    var constantValue = property.InputModelProperty?.ConstantValue;
                    Constant? clientDefaultValue = constantValue != null ? BuilderHelpers.ParseConstant(constantValue.Value, _typeFactory.CreateType(constantValue.Type)) : null;
                    if (clientDefaultValue is object defaultValueObject)
                    {
                        defaultInitializationValue = BuilderHelpers.ParseConstant(defaultValueObject, propertyType);
                    }

                    var inputType = propertyType.InputType;
                    if (defaultParameterValue != null && !property.ValueType.CanBeInitializedInline(defaultParameterValue))
                    {
                        inputType = inputType.WithNullable(true);
                        defaultParameterValue = Constant.Default(inputType);
                    }

                    var validate = property.InputModelProperty?.Type.IsNullable != true && !inputType.IsValueType && property.InputModelProperty?.IsReadOnly != true ? ValidationType.AssertNotNull : ValidationType.None;
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

                    if (initializationValue == null && propertyType.IsCollection)
                    {
                        if (propertyType.IsReadOnlyMemory)
                        {
                            initializationValue = propertyType.IsNullable ? null : Constant.FromExpression($"{propertyType}.{nameof(ReadOnlyMemory<object>.Empty)}", propertyType);
                        }
                        else
                        {
                            initializationValue = Constant.NewInstanceOf(propertyType.PropertyInitializationType);
                        }
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
                defaultCtorInitializers.Add(new ObjectPropertyInitializer(AdditionalPropertiesProperty, Constant.NewInstanceOf(AdditionalPropertiesProperty.Declaration.Type.InitializationType)));
            }

            return new ObjectTypeConstructor(
                Type,
                IsAbstract ? Protected : _usage.HasFlag(InputModelTypeUsage.Input) ? Public : Internal,
                defaultCtorParameters,
                defaultCtorInitializers,
                baseCtor);
        }

        public CSharpType? ImplementsDictionaryType => _implementsDictionaryType ??= CreateInheritedDictionaryType();
        protected override IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            // Skip initialization ctor if this instance is used to support forward compatibility in polymorphism.
            if (!SkipInitializerConstructor)
                yield return InitializationConstructor;

            // Skip serialization ctor if they are the same
            if (InitializationConstructor != SerializationConstructor)
                yield return SerializationConstructor;

            if (EmptyConstructor != null)
                yield return EmptyConstructor;
        }

        protected override ObjectTypeDiscriminator? BuildDiscriminator()
        {
            var discriminatorPropertyName = InputModel.DiscriminatorPropertyName;
            if (discriminatorPropertyName is null)
            {
                discriminatorPropertyName = InputModel.GetAllBaseModels().FirstOrDefault(m => m.DiscriminatorPropertyName != null)?.DiscriminatorPropertyName;
            }
            if (discriminatorPropertyName is null)
            {
                return null;
            }

            var parentDiscriminator = GetBaseObjectType()?.Discriminator;
            var property = Properties.FirstOrDefault(p => p.InputModelProperty is not null && p.InputModelProperty.IsDiscriminator)
                ?? parentDiscriminator?.Property;

            //neither me nor my parent are discriminators so I can bail
            if (property is null)
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

        private IReadOnlyList<string> GetSupportedSerializationFormats()
        {
            var formats = InputModel.SerializationFormats.ToList();
            if (Configuration.SkipSerializationFormatXml)
            {
                formats.Remove("Xml");
            }
            if (ModelTypeMapping?.Formats is { } formatsDefinedInSource)
            {
                foreach (var format in formatsDefinedInSource)
                {
                    formats.Add(format);
                }
            }

            return formats.Distinct().ToArray();
        }

        private HashSet<string?> GetParentPropertySerializedNames()
        {
            // TODO -- this is not really getting the serialized name of the properties as advertised in the method name
            // this is just getting the name of the schema property.
            // this is a guard of not having compilation errors because we cannot define the properties with the same name as properties defined in base types, therefore here we should get the set by the declaration name of the property
            return EnumerateHierarchy()
                .Skip(1)
                .SelectMany(type => type.Properties)
                .Select(p => p.InputModelProperty?.Name)
                .ToHashSet();
        }

        private HashSet<string> GetParentPropertyDeclarationNames()
        {
            return EnumerateHierarchy()
                .Skip(1)
                .SelectMany(type => type.Properties)
                .Select(p => p.Declaration.Name)
                .ToHashSet();
        }

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            var propertiesFromSpec = GetParentPropertyDeclarationNames();
            var existingProperties = GetParentPropertySerializedNames();

            foreach (var inputModel in GetCombinedSchemas())
            {
                foreach (InputModelProperty property in inputModel.Properties!)
                {
                    if (existingProperties.Contains(property.Name))
                    {
                        continue;
                    }
                    var prop = CreateProperty(property);
                    propertiesFromSpec.Add(prop.Declaration.Name);
                    yield return prop;
                }
            }

            if (AdditionalPropertiesProperty is ObjectTypeProperty additionalPropertiesProperty)
            {
                propertiesFromSpec.Add(additionalPropertiesProperty.Declaration.Name);
                yield return additionalPropertiesProperty;
            }

            if (ModelTypeMapping != null)
            {
                foreach (var propertyWithSerialization in ModelTypeMapping.GetPropertiesWithSerialization())
                {
                    if (propertiesFromSpec.Contains(propertyWithSerialization.Name))
                        continue;

                    var csharpType = BuilderHelpers.GetTypeFromExisting(propertyWithSerialization, typeof(object), _typeFactory);
                    var isReadOnly = BuilderHelpers.IsReadOnlyFromExisting(propertyWithSerialization);
                    var accessibility = propertyWithSerialization.DeclaredAccessibility == Accessibility.Public ? "public" : "internal";
                    yield return new ObjectTypeProperty(
                        new MemberDeclarationOptions(accessibility, propertyWithSerialization.Name, csharpType),
                        string.Empty,
                        isReadOnly,
                        null);
                }
            }
        }

        protected ObjectTypeProperty CreateProperty(InputModelProperty property)
        {
            var name = BuilderHelpers.DisambiguateName(Type, property.CSharpName());
            var existingMember = ModelTypeMapping?.GetMemberByOriginalName(name);

            var accessibility = property.IsDiscriminator == true ? "internal" : "public";

            var propertyType = GetDefaultPropertyType(property);

            // We represent property being optional by making it nullable
            // Except in the case of collection where there is a special handling
            bool optionalViaNullability = !property.IsRequired &&
                                          !property.Type.IsNullable &&
                                          !propertyType.IsCollection;

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

            bool isCollection = type is { IsCollection: true, IsReadOnlyMemory: false };

            bool propertyShouldOmitSetter = IsStruct ||
                              !_usage.HasFlag(InputModelTypeUsage.Input) ||
                              property.IsReadOnly;


            if (isCollection)
            {
                propertyShouldOmitSetter |= !property.Type.IsNullable;
            }
            else
            {
                // In mixed models required properties are not readonly
                propertyShouldOmitSetter |= property.IsRequired &&
                              _usage.HasFlag(InputModelTypeUsage.Input) &&
                              !_usage.HasFlag(InputModelTypeUsage.Output);
            }

            // we should remove the setter of required constant
            if (property.ConstantValue is not null && property.IsRequired)
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
                optionalViaNullability);
            return objectTypeProperty;
        }

        private CSharpType GetDefaultPropertyType(InputModelProperty property)
        {
            var valueType = _typeFactory.CreateType(property.Type, property.Format, property);
            if (!_usage.HasFlag(InputModelTypeUsage.Input) ||
                property.IsReadOnly)
            {
                valueType = valueType.OutputType;
            }

            return valueType;
        }

        // Enumerates all schemas that were merged into this one, excludes the inherited schema
        protected internal IEnumerable<InputModelType> GetCombinedSchemas() => InputModel.GetSelfAndBaseModels();

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

            var objectSchemas = InputModel.GetImmediateBaseModels().ToArray();

            InputModelType? selectedSchema = null;

            foreach (var objectSchema in objectSchemas)
            {
                // Take first schema or the one with discriminator
                selectedSchema ??= objectSchema;

                if (objectSchema.DiscriminatorPropertyName != null)
                {
                    selectedSchema = objectSchema;
                    break;
                }
            }

            if (selectedSchema != null)
            {
                CSharpType type = _typeFactory.CreateType(selectedSchema);
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

        public ObjectTypeProperty GetPropertyBySerializedName(string serializedName, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.InputModelProperty?.SerializedName == serializedName, out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property with serialized name '{serializedName}' in schema {DefaultName}");
            }

            return objectProperty;
        }

        public ObjectTypeProperty GetPropertyForGroupedParameter(string groupedParameterName, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(
                    p => p.InputModelProperty?.FlattenedNames != null && p.InputModelProperty.FlattenedNames.Any(name => name == groupedParameterName),
                    out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property for grouped parameter {groupedParameterName} in schema {DefaultName}");
            }

            return objectProperty;
        }

        protected bool TryGetPropertyForSchemaProperty(Func<ObjectTypeProperty, bool> propertySelector, [NotNullWhen(true)] out ObjectTypeProperty? objectProperty, bool includeParents = false)
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
            return $"{InputModel.Description}";
        }

        protected override bool EnsureIncludeSerializer()
        {
            // TODO -- this should always return true when use model reader writer is enabled.
            return Configuration.UseModelReaderWriter || _usage.HasFlag(InputModelTypeUsage.Input);
        }

        protected override bool EnsureIncludeDeserializer()
        {
            // TODO -- this should always return true when use model reader writer is enabled.
            return Configuration.UseModelReaderWriter || _usage.HasFlag(InputModelTypeUsage.Output);
        }

        protected override JsonObjectSerialization? BuildJsonSerialization()
        {
            return _supportedSerializationFormats.Contains("Json") ? _serializationBuilder.BuildJsonObjectSerialization(InputModel, this) : null;
        }

        protected override BicepObjectSerialization? BuildBicepSerialization(JsonObjectSerialization? json)
        {
            if (json == null)
                return null;
            // if this.Usages does not contain Output bit, then return null
            // alternate - is one of ancestors resource data or contained on a resource data
            var usage = GetUsage();

            return Configuration.AzureArm && Configuration.UseModelReaderWriter && Configuration.EnableBicepSerialization &&
                   usage.HasFlag(InputModelTypeUsage.Output)
                ? _serializationBuilder.BuildBicepObjectSerialization(this, json) : null;
        }

        // TODO: implement this
        protected override XmlObjectSerialization? BuildXmlSerialization()
        {
            return _supportedSerializationFormats.Contains("Xml")
                ? SerializationBuilder.BuildXmlObjectSerialization(InputModel.Serialization?.Xml?.Name ?? InputModel.Name, this, _typeFactory)
                : null;
        }

        protected override IEnumerable<Method> BuildMethods()
        {
            foreach (var method in SerializationMethodsBuilder.BuildSerializationMethods(this))
            {
                yield return method;
            }
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
