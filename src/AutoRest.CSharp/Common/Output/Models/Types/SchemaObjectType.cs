// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.InputTypes;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Serialization.Multipart;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.Output;
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

        protected SchemaObjectType(InputModelType inputModel, string defaultNamespace, TypeFactory typeFactory, SourceInputModel? sourceInputModel, SerializableObjectType? defaultDerivedType = null)
            : base(defaultNamespace, sourceInputModel)
        {
            _typeFactory = typeFactory;
            DefaultName = inputModel.CSharpName();
            DefaultNamespace = GetDefaultModelNamespace(null, defaultNamespace);
            InputModel = inputModel;
            _serializationBuilder = new SerializationBuilder();
            _usage = inputModel.Usage;

            DefaultAccessibility = inputModel.Access ?? "public";

            // Update usage from code attribute
            if (ModelTypeMapping?.Usage != null)
            {
                foreach (var usage in ModelTypeMapping.Usage)
                {
                    _usage |= Enum.Parse<InputModelTypeUsage>(usage, true);
                }
            }

            _defaultDerivedType = defaultDerivedType
                //if I have children and parents then I am my own defaultDerivedType
                ?? (inputModel.DerivedModels.Any() && inputModel.BaseModel is { DiscriminatorProperty: not null } ? this :(inputModel.IsUnknownDiscriminatorModel ? this : null));
            IsUnknownDerivedType = inputModel.IsUnknownDiscriminatorModel;
            // we skip the init ctor when there is an extension telling us to, or when this is an unknown derived type in a discriminated set
            SkipInitializerConstructor = IsUnknownDerivedType;
            IsInheritableCommonType = MgmtReferenceType.IsTypeReferenceType(InputModel) || MgmtReferenceType.IsReferenceType(InputModel);

            JsonConverter = InputModel.UseSystemTextJsonConverter ? new JsonConverterProvider(this, _sourceInputModel) : null;
        }

        internal InputModelType InputModel { get; }

        protected override string DefaultName { get; }
        protected override string DefaultNamespace { get; }
        protected override string DefaultAccessibility { get; } = "public";

        private SerializableObjectType? _defaultDerivedType;

        protected override bool IsAbstract => MgmtReferenceType.IsReferenceType(InputModel) || (!Configuration.SuppressAbstractBaseClasses.Contains(DefaultName) && InputModel.DiscriminatorProperty != null && InputModel.DiscriminatorValue == null);

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

                // find the type of the additional properties
                var additionalPropertiesType = BuilderHelpers.CreateAdditionalPropertiesPropertyType(ImplementsDictionaryType, _typeFactory.UnknownType);

                _additionalPropertiesProperty = new ObjectTypeProperty(
                    BuilderHelpers.CreateMemberDeclaration("AdditionalProperties", additionalPropertiesType, "public", existingMember, _typeFactory),
                    "Additional Properties",
                    true,
                    null
                    );

                return _additionalPropertiesProperty;
            }
        }

        protected internal override InputModelTypeUsage GetUsage() => (InputModelTypeUsage)_usage;

        private ObjectTypeProperty? _rawDataField;
        public override ObjectTypeProperty? RawDataField
        {
            get
            {
                if (_rawDataField != null)
                    return _rawDataField;

                if (!ShouldHaveRawData)
                    return null;

                // if we have an additional properties property, and its value type is also BinaryData, we should not have a raw data field
                if (AdditionalPropertiesProperty != null)
                {
                    var valueType = AdditionalPropertiesProperty.Declaration.Type.ElementType;
                    if (valueType.EqualsIgnoreNullable(_typeFactory.UnknownType))
                    {
                        return null;
                    }
                }

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

            if (InputModel.DiscriminatorProperty is not null)
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

                    var validate = property.InputModelProperty?.Type is not InputNullableType && !inputType.IsValueType && property.InputModelProperty?.IsReadOnly != true ? ValidationType.AssertNotNull : ValidationType.None;
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
            var discriminatorProperty = InputModel.DiscriminatorProperty;
            if (discriminatorProperty is null)
            {
                discriminatorProperty = GetCombinedSchemas().FirstOrDefault(m => m.DiscriminatorProperty != null)?.DiscriminatorProperty;
            }
            if (discriminatorProperty is null)
            {
                return null;
            }

            // If the parent discriminator exists, the current discriminator should have the same name
            var parentDiscriminator = GetBaseObjectType()?.Discriminator;
            var property = Properties.FirstOrDefault(p => p.InputModelProperty is not null && p.InputModelProperty.IsDiscriminator && (parentDiscriminator is null || (parentDiscriminator != null && p.InputModelProperty.Name == parentDiscriminator.Property.SerializedName)))
                ?? parentDiscriminator?.Property;

            //neither me nor my parent are discriminators so I can bail
            if (property is null)
            {
                return null;
            }

            Constant? value = null;

            //only load implementations for the base type
            // TODO: remove the order by
            var implementationDictionary = new Dictionary<string, ObjectTypeDiscriminatorImplementation>();
            GetDerivedTypes(InputModel.DerivedModels, implementationDictionary);
            var implementations = implementationDictionary.Values.OrderBy(x => x.Key).ToArray();

            if (InputModel.DiscriminatorValue != null)
            {
                value = BuilderHelpers.ParseConstant(InputModel.DiscriminatorValue, property.Declaration.Type.WithNullable(false));
            }

            return new ObjectTypeDiscriminator(
                property,
                discriminatorProperty.SerializedName,
                implementations,
                value,
                _defaultDerivedType!
            );
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

            foreach (var model in InputModel.GetSelfAndBaseModels())
            {
                foreach (var property in model.Properties)
                {
                    if (existingProperties.Contains(property.Name))
                    {
                        continue;
                    }
                    var prop = CreateProperty(property);

                    // If "Type" property is "String" and "ResourceType" exists in parents properties, skip it since they are the same.
                    // This only applies for TypeSpec input, for swagger input we have renamed "type" property to "resourceType" in FrameworkTypeUpdater.ValidateAndUpdate
                    if (property.CSharpName() == "Type" && prop.ValueType.Name == "String" && existingProperties.Contains("ResourceType"))
                    {
                        continue;
                    }
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
                    var isReadOnly = BuilderHelpers.IsReadOnly(propertyWithSerialization, csharpType);
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
                                          property.Type is not InputNullableType &&
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
                propertyShouldOmitSetter |= property.Type is not InputNullableType;
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
            var valueType = _typeFactory.CreateType(property.Type);
            if (!_usage.HasFlag(InputModelTypeUsage.Input) ||
                property.IsReadOnly)
            {
                valueType = valueType.OutputType;
            }

            return valueType;
        }

        protected internal IEnumerable<InputModelType> GetCombinedSchemas()
        {
            if (InputModel.IsUnknownDiscriminatorModel)
            {
                if (InputModel.BaseModel is not null)
                {
                    yield return InputModel.BaseModel;
                }
            }
            else
            {
                foreach (var inputModel in InputModel.GetAllBaseModels())
                {
                    yield return inputModel;
                }
            }
        }

        protected override CSharpType? CreateInheritedType()
        {
            if (GetExistingBaseType() is { } existingBaseType)
            {
                return existingBaseType;
            }

            return InputModel.BaseModel is { } baseModel
                ? _typeFactory.CreateType(baseModel)
                : null;
        }

        protected CSharpType? GetExistingBaseType()
        {
            INamedTypeSymbol? existingBaseType = GetSourceBaseType();

            if (existingBaseType is { } type && _typeFactory.TryCreateType(type, out CSharpType? baseType))
            {
                return baseType;
            }

            return null;
        }

        private INamedTypeSymbol? GetSourceBaseType()
        {
            return ExistingType?.BaseType is { } sourceBaseType && sourceBaseType.SpecialType != SpecialType.System_ValueType && sourceBaseType.SpecialType != SpecialType.System_Object
                ? sourceBaseType
                : null;
        }

        private CSharpType? CreateInheritedDictionaryType()
        {
            if (InputModel.AdditionalProperties is not null)
            {
                return new CSharpType(
                        _usage.HasFlag(InputModelTypeUsage.Input) ? typeof(IDictionary<,>) : typeof(IReadOnlyDictionary<,>),
                        typeof(string),
                        _typeFactory.CreateType(InputModel.AdditionalProperties));
            }

            return null;
        }

        public virtual ObjectTypeProperty GetPropertyForSchemaProperty(InputModelProperty property, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.InputModelProperty == property, out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property for schema property {property.SerializedName} in schema {DefaultName}");
            }

            return objectProperty;
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
                    p => p.InputModelProperty?.Name == groupedParameterName,
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
            return !MgmtReferenceType.IsReferenceType(InputModel) && (Configuration.UseModelReaderWriter || _usage.HasFlag(InputModelTypeUsage.Output));
        }

        protected override JsonObjectSerialization? BuildJsonSerialization()
        {
            return !InputModel.Serialization.Json ? null : _serializationBuilder.BuildJsonObjectSerialization(InputModel, this);
        }

        protected override ObjectTypeSerialization BuildSerialization()
        {
            bool isReference = MgmtReferenceType.IsReferenceType(InputModel);
            var json = BuildJsonSerialization();
            var xml = isReference ? null : BuildXmlSerialization();
            var bicep = isReference ? null : BuildBicepSerialization(json);
            var multipart = isReference ? null : BuildMultipartSerialization();
            // select interface model type here
            var modelType = IsUnknownDerivedType && Inherits is { IsFrameworkType: false, Implementation: { } baseModel } ? baseModel.Type : Type;
            var interfaces = isReference ? null : new SerializationInterfaces(IncludeSerializer, IsStruct, modelType, json is not null, xml is not null);
            return new ObjectTypeSerialization(this, json, xml, bicep, multipart, interfaces);
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

        protected override XmlObjectSerialization? BuildXmlSerialization()
        {
            return InputModel.Serialization?.Xml is not null
                ? SerializationBuilder.BuildXmlObjectSerialization(InputModel.Serialization.Xml.Name ?? InputModel.Name, this, _typeFactory)
                : null;
        }

        protected override MultipartObjectSerialization? BuildMultipartSerialization()
        {
            return InputModel.Usage.HasFlag(InputModelTypeUsage.MultipartFormData) ? _serializationBuilder.BuildMultipartObjectSerialization(InputModel, this) : null;
        }
        protected override IEnumerable<Method> BuildMethods()
        {
            foreach (var method in SerializationMethodsBuilder.BuildSerializationMethods(this))
            {
                yield return method;
            }
        }

        // There are derived models with duplicate discriminator values, which is not allowed
        // Follow the same logic as modelerfour to remove derived models with duplicate discriminator values
        private void GetDerivedTypes(IReadOnlyList<InputModelType> derivedInputTypes, Dictionary<string, ObjectTypeDiscriminatorImplementation> implementations)
        {
            foreach (var derivedInputType in derivedInputTypes)
            {
                var derivedType = (SchemaObjectType)_typeFactory.CreateType(derivedInputType).Implementation;
                var derivedTypeImplementation = new Dictionary<string, ObjectTypeDiscriminatorImplementation>();
                GetDerivedTypes(derivedType.InputModel.DerivedModels, derivedTypeImplementation);
                foreach (var discriminatorImplementation in derivedTypeImplementation)
                {
                    implementations[discriminatorImplementation.Key] = discriminatorImplementation.Value;
                }

                implementations[derivedInputType.DiscriminatorValue!] = new ObjectTypeDiscriminatorImplementation(derivedInputType.DiscriminatorValue!, derivedType.Type);
            }
        }
    }
}
