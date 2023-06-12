// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Decorator;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class SchemaObjectType : SerializableObjectType
    {
        private readonly SerializationBuilder _serializationBuilder;
        private readonly TypeFactory _typeFactory;
        protected readonly SchemaTypeUsage _usage;

        private readonly ModelTypeMapping? _sourceTypeMapping;
        private readonly IReadOnlyList<KnownMediaType> _supportedSerializationFormats;

        private ObjectTypeProperty? _additionalPropertiesProperty;
        private CSharpType? _implementsDictionaryType;

        private BuildContext _context;

        public SchemaObjectType(ObjectSchema objectSchema, BuildContext context)
            : base(context)
        {
            _context = context;
            DefaultName = objectSchema.CSharpName();
            DefaultNamespace = GetDefaultNamespace(objectSchema.Extensions?.Namespace, context);
            ObjectSchema = objectSchema;
            _typeFactory = context.TypeFactory;
            _serializationBuilder = new SerializationBuilder();
            _usage = context.SchemaUsageProvider.GetUsage(ObjectSchema);

            var hasUsage = _usage.HasFlag(SchemaTypeUsage.Model);

            DefaultAccessibility = objectSchema.Extensions?.Accessibility ?? (hasUsage ? "public" : "internal");

            _sourceTypeMapping = context.SourceInputModel?.CreateForModel(ExistingType);

            // Update usage from code attribute
            if (_sourceTypeMapping?.Usage != null)
            {
                foreach (var usage in _sourceTypeMapping.Usage)
                {
                    _usage |= Enum.Parse<SchemaTypeUsage>(usage, true);
                }
            }

            // Update usage from the extension as the model doesn't exist at the time of constructing the BuildContext
            if (objectSchema.Extensions?.Usage is not null)
            {
                _usage |= Enum.Parse<SchemaTypeUsage>(objectSchema.Extensions?.Usage!, true);
            }

            _supportedSerializationFormats = GetSupportedSerializationFormats(objectSchema, _sourceTypeMapping);
        }

        internal ObjectSchema ObjectSchema { get; }

        protected override string DefaultName { get; }
        protected override string DefaultNamespace { get; }
        protected override string DefaultAccessibility { get; } = "public";
        protected override TypeKind TypeKind => IsStruct ? TypeKind.Struct : TypeKind.Class;

        private ObjectType? _defaultDerivedType;
        private bool _hasCalculatedDefaultDerivedType;
        public ObjectType? DefaultDerivedType => _defaultDerivedType ??= BuildDefaultDerviedType();

        protected override bool IsAbstract => !Configuration.SuppressAbstractBaseClasses.Contains(DefaultName) && ObjectSchema.Discriminator?.All != null && ObjectSchema.Parents?.All.Count == 0;

        public bool IsInheritableCommonType => ObjectSchema != null &&
            ObjectSchema.Extensions != null &&
            (ObjectSchema.Extensions.MgmtReferenceType || ObjectSchema.Extensions.MgmtTypeReferenceType);

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
                SourceMemberMapping? memberMapping = _sourceTypeMapping?.GetForMember("$AdditionalProperties");

                _additionalPropertiesProperty = new ObjectTypeProperty(
                    BuilderHelpers.CreateMemberDeclaration("AdditionalProperties", ImplementsDictionaryType, "public", memberMapping?.ExistingMember, _typeFactory),
                    "Additional Properties",
                    true,
                    null
                    );

                return _additionalPropertiesProperty;
            }
        }

        protected override ConstructorSignature EnsurePublicConstructorSignature()
        {
            return CreatePublicConstructorSignature(Declaration.Name, _usage, Fields.PublicConstructorParameters);
        }

        protected override ConstructorSignature EnsureSerializationConstructorSignature()
        {
            var serializationCtorSignature = CreateSerializationConstructorSignature(Declaration.Name, Fields.SerializationParameters);

            // verifies if this new ctor is the same as the public one
            if (!serializationCtorSignature.Parameters.Any(p => TypeFactory.IsList(p.Type)) && InitializationConstructorSignature.Parameters.SequenceEqual(serializationCtorSignature.Parameters, Parameter.EqualityComparerByType))
                return InitializationConstructorSignature;

            return serializationCtorSignature;
        }

        private IObjectTypeFields<Property>? _fields;
        public IObjectTypeFields<Property> Fields => _fields ??= EnsureFields();

        private IObjectTypeFields<Property> EnsureFields()
            => new SchemaObjectTypeFields(Type, ObjectSchema, _usage, _typeFactory, _context.SourceInputModel?.CreateForModel(ExistingType));

        private ConstructorSignature CreatePublicConstructorSignature(string name, SchemaTypeUsage usage, IEnumerable<Parameter> parameters)
        {
            //get base public ctor params
            GetConstructorParameters(parameters, out var fullParameterList, out var parametersToPassToBase, true, CreatePublicConstructorParameter);

            var accessibility = usage.HasFlag(SchemaTypeUsage.Input)
                ? MethodSignatureModifiers.Public
                : MethodSignatureModifiers.Internal;

            if (ObjectSchema.Discriminator is not null)
                accessibility = MethodSignatureModifiers.Protected;

            FormattableString[] baseInitializers = GetInitializersFromParameters(parametersToPassToBase);

            return new ConstructorSignature(
                name,
                $"Initializes a new instance of {name}",
                null,
                accessibility,
                fullParameterList,
                Initializer: new(true, baseInitializers));
        }

        private ConstructorSignature CreateSerializationConstructorSignature(string name, IReadOnlyList<Parameter> serializationParameters)
        {
            //get base public ctor params
            GetConstructorParameters(serializationParameters, out var fullParameterList, out var parametersToPassToBase, false, CreateSerializationConstructorParameter);

            FormattableString[] baseInitializers = GetInitializersFromParameters(parametersToPassToBase);

            return new ConstructorSignature(
                name,
                $"Initializes a new instance of {name}",
                null,
                MethodSignatureModifiers.Internal,
                fullParameterList,
                Initializer: new(true, baseInitializers));
        }

        protected override void GetConstructorParameters(IEnumerable<Parameter> parameters, out List<Parameter> fullParameterList, out IEnumerable<Parameter> parametersToPassToBase, bool isInitializer, Func<Parameter, Parameter> creator)
        {
            fullParameterList = new List<Parameter>();
            var parent = GetBaseObjectType();
            parametersToPassToBase = Array.Empty<Parameter>();
            if (parent is not null)
            {
                var ctor = isInitializer ? parent.InitializationConstructor : parent.SerializationConstructor;
                parametersToPassToBase = ctor.Signature.Parameters;
                // we add all the parameters to the base ctor invocation when it does not have a discriminator or is the unknown class with a discriminator
                if (ObjectSchema.IsUnknownDiscriminatorModel || Discriminator is null)
                {
                    fullParameterList.AddRange(parametersToPassToBase);
                }
                else
                {
                    // we it has a discriminator and this class is not the unknown one, we exclude the discriminator parameter into the base invocation because we will do this:
                    // internal Salmon(/* properties on salmon other than discriminator */) : base("salmon")
                    foreach (var parameter in ctor.Signature.Parameters)
                    {
                        var property = ctor.FindPropertyInitializedByParameter(parameter);
                        if (property != Discriminator.Property)
                            fullParameterList.Add(parameter);
                    }
                }
            }
            // we need to explicitly exclude the parameters passed into base
            // this happens when the base is a SystemObjectType
            // in this case, the type is not in the model hierarchy as in swagger, but an extra layer we created
            if (parent is SystemObjectType)
            {
                var parameterNamesToBase = parametersToPassToBase.Select(parameter => parameter.Name).ToHashSet();
                parameters = parameters.Where(p => !parameterNamesToBase.Contains(p.Name));
            }
            fullParameterList.AddRange(parameters.Select(creator));
        }

        private static Parameter CreatePublicConstructorParameter(Parameter p)
            => p with { Type = TypeFactory.GetInputType(p.Type) };

        private static Parameter CreateSerializationConstructorParameter(Parameter p) // we don't validate parameters for serialization constructor
            => p with { Validation = ValidationType.None };

        private FormattableString[] GetInitializersFromParameters(IEnumerable<Parameter> parametersToPassToBase)
        {
            var baseInitializers = ConstructorInitializer.ParametersToFormattableString(parametersToPassToBase).ToArray();
            if (Discriminator is not null && Discriminator.Value is { } discriminatorValue && !ObjectSchema.IsUnknownDiscriminatorModel)
            {
                FormattableString discriminatorInitializer = discriminatorValue.GetConstantFormattable();
                for (int i = 0; i < baseInitializers.Length; i++)
                {
                    if (baseInitializers[i].ToString() == Discriminator.Property.Declaration.Name.ToVariableName())
                        baseInitializers[i] = discriminatorInitializer;
                }
            }

            return baseInitializers;
        }

        protected override ObjectPropertyInitializer[] GetPropertyInitializers(IReadOnlyList<Parameter> parameters, bool includeDiscriminator)
        {
            List<ObjectPropertyInitializer> defaultCtorInitializers = new List<ObjectPropertyInitializer>();

            if (includeDiscriminator && Discriminator is not null && Discriminator.Value is { } discriminatorValue && !ObjectSchema.IsUnknownDiscriminatorModel)
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

                var variableName = property.Declaration.Name.ToVariableName();
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
                        variableName,
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

        public override bool IncludeConverter => _usage.HasFlag(SchemaTypeUsage.Converter);

        protected override bool SkipInitializerConstructor => ObjectSchema != null &&
            ObjectSchema.Extensions != null &&
            ObjectSchema.Extensions.SkipInitCtor;

        public CSharpType? ImplementsDictionaryType => _implementsDictionaryType ??= CreateInheritedDictionaryType();

        protected override ObjectTypeDiscriminator? BuildDiscriminator()
        {
            Discriminator? schemaDiscriminator = ObjectSchema.Discriminator;
            ObjectTypeDiscriminatorImplementation[] implementations = Array.Empty<ObjectTypeDiscriminatorImplementation>();
            Constant? value = null;

            if (schemaDiscriminator == null)
            {
                schemaDiscriminator = ObjectSchema.Parents!.All.OfType<ObjectSchema>().FirstOrDefault(p => p.Discriminator != null)?.Discriminator;

                if (schemaDiscriminator == null)
                {
                    return null;
                }
            }
            else
            {
                implementations = CreateDiscriminatorImplementations(schemaDiscriminator);
            }

            ObjectType defaultDerivedType = DefaultDerivedType!;

            var property = GetPropertyForSchemaProperty(schemaDiscriminator.Property, includeParents: true);

            if (ObjectSchema.DiscriminatorValue != null)
            {
                value = BuilderHelpers.ParseConstant(ObjectSchema.DiscriminatorValue, property.Declaration.Type.GetNonNullable());
            }

            return new ObjectTypeDiscriminator(
                property,
                schemaDiscriminator.Property.SerializedName,
                implementations,
                value,
                defaultDerivedType
            );
        }

        private static IReadOnlyList<KnownMediaType> GetSupportedSerializationFormats(ObjectSchema objectSchema, ModelTypeMapping? sourceTypeMapping)
        {
            var formats = objectSchema.SerializationFormats;
            if (Configuration.SkipSerializationFormatXml)
                formats.Remove(KnownMediaType.Xml);

            if (objectSchema.Extensions != null)
            {
                foreach (var format in objectSchema.Extensions.Formats)
                {
                    formats.Add(Enum.Parse<KnownMediaType>(format, true));
                }
            }

            if (sourceTypeMapping?.Formats is { } formatsDefinedInSource)
            {
                foreach (var format in formatsDefinedInSource)
                {
                    formats.Add(Enum.Parse<KnownMediaType>(format, true));
                }
            }

            return formats.Distinct().ToArray();
        }

        private ObjectTypeDiscriminatorImplementation[] CreateDiscriminatorImplementations(Discriminator schemaDiscriminator)
        {
            return schemaDiscriminator.All.Select(implementation => new ObjectTypeDiscriminatorImplementation(
                implementation.Key,
                _typeFactory.CreateType(implementation.Value, false)
            )).ToArray();
        }

        private HashSet<string?> GetParentPropertySerializedNames()
        {
            return EnumerateHierarchy()
                .Skip(1)
                .SelectMany(type => type.Properties)
                .Select(p => p.SchemaProperty?.Language.Default.Name)
                .ToHashSet();
        }

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            foreach (var field in Fields)
                yield return new ObjectTypeProperty(field, Fields.GetInputByField(field), this, field.SerializationFormat);

            if (AdditionalPropertiesProperty is ObjectTypeProperty additionalPropertiesProperty)
            {
                yield return additionalPropertiesProperty;
            }
        }

        protected ObjectTypeProperty CreateProperty(Property property)
        {
            var name = BuilderHelpers.DisambiguateName(Type, property.CSharpName());
            SourceMemberMapping? memberMapping = _sourceTypeMapping?.GetForMember(name);

            var serializationMapping = _sourceTypeMapping?.GetForMemberSerialization(memberMapping?.ExistingMember);

            var accessibility = property.IsDiscriminator == true ? "internal" : "public";

            var propertyType = GetDefaultPropertyType(property);

            // We represent property being optional by making it nullable
            // Except in the case of collection where there is a special handling
            bool optionalViaNullability = !property.IsRequired &&
                                          !property.IsNullable &&
                                          !TypeFactory.IsCollectionType(propertyType);

            if (optionalViaNullability)
            {
                propertyType = propertyType.WithNullable(true);
            }

            var memberDeclaration = BuilderHelpers.CreateMemberDeclaration(
                name,
                propertyType,
                accessibility,
                memberMapping?.ExistingMember,
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
                propertyShouldOmitSetter |= !property.IsNullable;
            }
            else
            {
                // In mixed models required properties are not readonly
                propertyShouldOmitSetter |= property.IsRequired &&
                              _usage.HasFlag(SchemaTypeUsage.Input) &&
                              !_usage.HasFlag(SchemaTypeUsage.Output);
            }

            // we should remove the setter of required constant
            if (property.Schema is ConstantSchema && property.IsRequired)
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
                BuilderHelpers.EscapeXmlDescription(property.Language.Default.Description),
                propertyShouldOmitSetter,
                property,
                valueType,
                optionalViaNullability,
                serializationMapping);
            return objectTypeProperty;
        }

        private CSharpType GetDefaultPropertyType(Property property)
        {
            var valueType = _typeFactory.CreateType(property.Schema, property.IsNullable, property.Schema is AnyObjectSchema ? property.Extensions?.Format : property.Schema.Extensions?.Format, property: property);

            if (!_usage.HasFlag(SchemaTypeUsage.Input) ||
                property.IsReadOnly)
            {
                valueType = TypeFactory.GetOutputType(valueType);
            }

            return valueType;
        }

        // Enumerates all schemas that were merged into this one, excludes the inherited schema
        protected internal IEnumerable<ObjectSchema> GetCombinedSchemas()
        {
            yield return ObjectSchema;

            foreach (var parent in ObjectSchema.Parents!.All)
            {
                if (parent is ObjectSchema objectParent)
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

            var objectSchemas = ObjectSchema.Parents!.Immediate.OfType<ObjectSchema>().ToArray();

            ObjectSchema? selectedSchema = null;

            foreach (var objectSchema in objectSchemas)
            {
                // Take first schema or the one with discriminator
                selectedSchema ??= objectSchema;

                if (objectSchema.Discriminator != null)
                {
                    selectedSchema = objectSchema;
                    break;
                }
            }

            if (selectedSchema != null)
            {
                CSharpType type = _typeFactory.CreateType(selectedSchema, false);
                Debug.Assert(!type.IsFrameworkType);
                return type;
            }
            return null;
        }

        private CSharpType? CreateInheritedDictionaryType()
        {
            foreach (ComplexSchema complexSchema in ObjectSchema.Parents!.Immediate)
            {
                if (complexSchema is DictionarySchema dictionarySchema)
                {
                    return new CSharpType(
                        _usage.HasFlag(SchemaTypeUsage.Input) ? typeof(IDictionary<,>) : typeof(IReadOnlyDictionary<,>),
                        typeof(string),
                        _typeFactory.CreateType(dictionarySchema.ElementType, false));
                };
            }

            return null;
        }

        public virtual ObjectTypeProperty GetPropertyForSchemaProperty(Property property, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.SchemaProperty == property, out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property for schema property {property.SerializedName} in schema {DefaultName}");
            }

            return objectProperty;
        }

        public ObjectTypeProperty GetPropertyBySerializedName(string serializedName, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.SchemaProperty?.SerializedName == serializedName, out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property with serialized name '{serializedName}' in schema {DefaultName}");
            }

            return objectProperty;
        }

        public ObjectTypeProperty GetPropertyForGroupedParameter(string groupedParameterName, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(
                    p => p.SchemaProperty is GroupProperty groupProperty && groupProperty.OriginalParameter.Any(p => p.Language.Default.Name == groupedParameterName),
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

        protected override string CreateDescription()
        {
            return ObjectSchema.CreateDescription();
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
            return _serializationBuilder.BuildJsonObjectSerialization(ObjectSchema, this);
        }

        protected override XmlObjectSerialization EnsureXmlSerialization()
        {
            return _serializationBuilder.BuildXmlObjectSerialization(ObjectSchema, this);
        }

        private ObjectType? BuildDefaultDerviedType()
        {
            if (_hasCalculatedDefaultDerivedType)
                return _defaultDerivedType;

            _hasCalculatedDefaultDerivedType = true;
            if (_context.BaseLibrary is null)
                return null;

            var defaultDerivedSchema = ObjectSchema.GetDefaultDerivedSchema();
            if (defaultDerivedSchema is null)
                return null;

            return _context.BaseLibrary.FindTypeProviderForSchema(defaultDerivedSchema) as ObjectType;
        }
    }
}
