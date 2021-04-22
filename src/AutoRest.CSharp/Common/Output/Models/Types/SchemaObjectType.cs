// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class SchemaObjectType : ObjectType
    {
        private readonly SerializationBuilder _serializationBuilder;
        private readonly TypeFactory _typeFactory;
        private readonly SchemaTypeUsage _usage;

        private readonly ModelTypeMapping? _sourceTypeMapping;
        private ObjectTypeProperty? _additionalPropertiesProperty;

        public SchemaObjectType(ObjectSchema objectSchema, BuildContext context) : base(context)
        {
            ObjectSchema = objectSchema;
            _typeFactory = context.TypeFactory;
            _serializationBuilder = new SerializationBuilder();
            _usage = context.SchemaUsageProvider.GetUsage(ObjectSchema);

            var hasUsage = _usage.HasFlag(SchemaTypeUsage.Model);

            DefaultAccessibility = objectSchema.Extensions?.Accessibility ?? (hasUsage ? "public" : "internal");
            Description = BuilderHelpers.CreateDescription(objectSchema);

            DefaultNamespace = GetDefaultNamespace(objectSchema, context);
            _sourceTypeMapping = context.SourceInputModel?.CreateForModel(ExistingType);

            // Update usage from code attribute
            if (_sourceTypeMapping?.Usage != null)
            {
                foreach (var usage in _sourceTypeMapping.Usage)
                {
                    _usage |= Enum.Parse<SchemaTypeUsage>(usage, true);
                }
            }
        }

        internal ObjectSchema ObjectSchema { get; }

        public override string DefaultName => ObjectSchema.CSharpName();
        protected override string DefaultNamespace { get; }
        protected override TypeKind TypeKind => IsStruct ? TypeKind.Struct : TypeKind.Class;

        public override ObjectTypeProperty? AdditionalPropertiesProperty
        {
            get
            {
                if (_additionalPropertiesProperty != null || ImplementsDictionaryType == null)
                {
                    return _additionalPropertiesProperty;
                }

                SourceMemberMapping? memberMapping = _sourceTypeMapping?.GetForMember("$AdditionalProperties");

                _additionalPropertiesProperty = new ObjectTypeProperty(
                    BuilderHelpers.CreateMemberDeclaration("AdditionalProperties", ImplementsDictionaryType, "internal", memberMapping?.ExistingMember, _typeFactory),
                    string.Empty,
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

            if (Inherits != null && !Inherits.IsFrameworkType && Inherits.Implementation is ObjectType objectType)
            {
                baseSerializationCtor = objectType.Constructors.Last();
                serializationConstructorParameters.AddRange(baseSerializationCtor.Parameters);
            }

            foreach (var property in Properties)
            {
                var type = property.Declaration.Type;

                var deserializationParameter = new Parameter(
                    property.Declaration.Name.ToVariableName(),
                    property.Description,
                    type,
                    null,
                    false
                );

                ownsDiscriminatorProperty |= property == Discriminator?.Property;

                serializationConstructorParameters.Add(deserializationParameter);

                serializationInitializers.Add(new ObjectPropertyInitializer(property, deserializationParameter, GetPropertyDefaultValue(property)));
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
                BuilderHelpers.CreateMemberDeclaration(Type.Name, Type, "internal", null, _typeFactory),
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

        protected override ObjectTypeConstructor BuildInitializationConstructor()
        {
            List<Parameter> defaultCtorParameters = new List<Parameter>();
            List<ObjectPropertyInitializer> defaultCtorInitializers = new List<ObjectPropertyInitializer>();

            ObjectTypeConstructor? baseCtor = GetBaseCtor();
            if (baseCtor is not null)
                defaultCtorParameters.AddRange(baseCtor.Parameters);

            foreach (var property in Properties)
            {
                // Only required properties that are not discriminators go into default ctor
                if (property == Discriminator?.Property)
                {
                    continue;
                }

                ReferenceOrConstant? initializationValue;
                Constant? defaultInitializationValue = null;

                var propertyType = property.Declaration.Type;
                if (property.SchemaProperty?.Schema is ConstantSchema constantSchema)
                {
                    // Turn constants into initializers
                    initializationValue = constantSchema.Value.Value != null ?
                        BuilderHelpers.ParseConstant(constantSchema.Value.Value, propertyType) :
                        Constant.NewInstanceOf(propertyType);
                }
                else if (IsStruct || property.SchemaProperty?.IsRequired == true)
                {
                    // For structs all properties become required
                    Constant? defaultParameterValue = null;
                    if (property.SchemaProperty?.ClientDefaultValue is object defaultValueObject)
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

                    var defaultCtorParameter = new Parameter(
                        property.Declaration.Name.ToVariableName(),
                        property.Description,
                        inputType,
                        defaultParameterValue,
                        property.SchemaProperty?.Nullable != true
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
                BuilderHelpers.CreateMemberDeclaration(
                    Type.Name,
                    Type,
                    // inputs have public ctor by default
                    _usage.HasFlag(SchemaTypeUsage.Input) ? "public" : "internal",
                    null,
                    _typeFactory),
                defaultCtorParameters.ToArray(),
                defaultCtorInitializers.ToArray(),
                baseCtor);
        }

        public override bool IncludeSerializer => _usage.HasFlag(SchemaTypeUsage.Input);
        public override bool IncludeDeserializer => _usage.HasFlag(SchemaTypeUsage.Output);
        public override bool IncludeConverter => _usage.HasFlag(SchemaTypeUsage.Converter);

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

            var property = GetPropertyForSchemaProperty(schemaDiscriminator.Property, includeParents: true);

            if (ObjectSchema.DiscriminatorValue != null)
            {
                value = BuilderHelpers.ParseConstant(ObjectSchema.DiscriminatorValue, property.Declaration.Type);
            }

            return new ObjectTypeDiscriminator(
                property,
                schemaDiscriminator.Property.SerializedName,
                implementations,
                value
            );
        }

        protected override ObjectSerialization[] BuildSerializations()
        {
            var formats = ObjectSchema.SerializationFormats;

            if (ObjectSchema.Extensions != null)
            {
                foreach (var format in ObjectSchema.Extensions.Formats)
                {
                    formats.Add(Enum.Parse<KnownMediaType>(format, true));
                }
            }

            if (_sourceTypeMapping?.Formats is { } formatsDefinedInSource)
            {
                foreach (var format in formatsDefinedInSource)
                {
                    formats.Add(Enum.Parse<KnownMediaType>(format, true));
                }
            }
            return formats.Distinct().Select(type => _serializationBuilder.BuildObject(type, ObjectSchema, this)).ToArray();
        }

        private ObjectTypeDiscriminatorImplementation[] CreateDiscriminatorImplementations(Discriminator schemaDiscriminator)
        {
            return schemaDiscriminator.All.Select(implementation => new ObjectTypeDiscriminatorImplementation(
                implementation.Key,
                _typeFactory.CreateType(implementation.Value, false)
            )).ToArray();
        }

        protected override IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            foreach (var objectSchema in GetCombinedSchemas())
            {
                foreach (Property property in objectSchema.Properties!)
                {
                    var name = BuilderHelpers.DisambiguateName(Type, property.CSharpName());
                    SourceMemberMapping? memberMapping = _sourceTypeMapping?.GetForMember(name);

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

                    bool isReadOnly = IsStruct ||
                                      !_usage.HasFlag(SchemaTypeUsage.Input) ||
                                      property.IsReadOnly;

                    if (isCollection)
                    {
                        isReadOnly |= !property.IsNullable;
                    }
                    else
                    {
                        // In mixed models required properties are not readonly
                        isReadOnly |= property.IsRequired &&
                                      _usage.HasFlag(SchemaTypeUsage.Input) &&
                                     !_usage.HasFlag(SchemaTypeUsage.Output);
                    }

                    if (property.IsDiscriminator == true)
                    {
                        // Discriminator properties should be writeable
                        isReadOnly = false;
                    }

                    yield return new ObjectTypeProperty(
                        memberDeclaration,
                        BuilderHelpers.EscapeXmlDescription(property.Language.Default.Description),
                        isReadOnly,
                        property,
                        valueType,
                        optionalViaNullability);
                }
            }

            if (AdditionalPropertiesProperty is ObjectTypeProperty additionalPropertiesProperty)
            {
                yield return additionalPropertiesProperty;
            }
        }

        private CSharpType GetDefaultPropertyType(Property property)
        {
            var valueType = _typeFactory.CreateType(property.Schema, property.IsNullable);

            if (!_usage.HasFlag(SchemaTypeUsage.Input) ||
                property.IsReadOnly)
            {
                valueType = TypeFactory.GetOutputType(valueType);
            }

            return valueType;
        }

        // Enumerates all schemas that were merged into this one, excludes the inherited schema
        private IEnumerable<ObjectSchema> GetCombinedSchemas()
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

        protected override CSharpType? CreateInheritedDictionaryType()
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
    }
}
