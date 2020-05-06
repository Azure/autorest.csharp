﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Input.Source;
using AutoRest.CSharp.V3.Output.Builders;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class ObjectType : ITypeProvider
    {
        private readonly ObjectSchema _objectSchema;
        private readonly SerializationBuilder _serializationBuilder;
        private readonly TypeFactory _typeFactory;

        private ObjectTypeProperty[]? _properties;
        private ObjectTypeDiscriminator? _discriminator;
        private CSharpType? _inheritsType;
        private CSharpType? _implementsDictionaryType;
        private ObjectSerialization[]? _serializations;
        private readonly ModelTypeMapping? _sourceTypeMapping;
        private ObjectTypeConstructor[]? _constructors;
        private ObjectTypeProperty? _additionalPropertiesProperty;

        public ObjectType(ObjectSchema objectSchema, BuildContext context): base(context)
        {
            _objectSchema = objectSchema;
            _typeFactory = context.TypeFactory;
            _serializationBuilder = new SerializationBuilder();
            _sourceTypeMapping = context.SourceInputModel.CreateForModel(ExistingType);

            var hasUsage = objectSchema.Usage.Any();

            DefaultAccessibility = hasUsage ? "public" : "internal";
            Description = BuilderHelpers.CreateDescription(objectSchema);
            IsStruct = ExistingType?.IsValueType == true;
            DefaultName = objectSchema.CSharpName();
            DefaultNamespace =  $"{context.DefaultNamespace}.Models";
        }

        public bool IsStruct { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; } = "public";
        protected override string DefaultNamespace { get; }
        protected override TypeKind TypeKind => IsStruct ? TypeKind.Struct : TypeKind.Class;

        public string? Description { get; }

        public CSharpType? Inherits => _inheritsType ??= CreateInheritedType();

        public ObjectSerialization[] Serializations => _serializations ??= BuildSerializations();

        public ObjectTypeProperty[] Properties => _properties ??= BuildProperties().ToArray();

        public ObjectTypeProperty? AdditionalPropertiesProperty {
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
                    null,
                    TypeFactory.GetImplementationType(ImplementsDictionaryType),
                    false
                    );

                return _additionalPropertiesProperty;
            }
        }

        public ObjectTypeConstructor[] Constructors => _constructors ??= BuildConstructors().ToArray();

        private IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            var initializationCtor = BuildInitializationConstructor();
            var serializationCtor = BuildSerializationConstructor();

            yield return initializationCtor;

            // Skip serialization ctor if they are the same
            if (!initializationCtor.Parameters
                .Select(p => p.Type)
                .SequenceEqual(serializationCtor.Parameters.Select(p => p.Type)))
            {
                yield return serializationCtor;
            }
        }

        private ObjectTypeConstructor BuildSerializationConstructor()
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
                var deserializationParameter = new Parameter(
                    property.Declaration.Name.ToVariableName(),
                    property.Description,
                    property.Declaration.Type,
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

                    serializationInitializers.Add(new ObjectPropertyInitializer(Discriminator.Property, discriminatorParameter, BuilderHelpers.StringConstant(Discriminator.Value)));
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
            if (property == Discriminator?.Property)
            {
                if (Discriminator.Value != null)
                {
                    return BuilderHelpers.StringConstant(Discriminator.Value);
                }
            }
            else
            {
                var initializeWithType = property.InitializeWithType;
                return initializeWithType != null ? Constant.NewInstanceOf(initializeWithType) : (ReferenceOrConstant?) null;
            }

            return null;
        }

        private ObjectTypeConstructor BuildInitializationConstructor()
        {
            List<Parameter> defaultCtorParameters = new List<Parameter>();
            List<ObjectPropertyInitializer> defaultCtorInitializers = new List<ObjectPropertyInitializer>();

            ObjectTypeConstructor? baseCtor = null;
            if (Inherits != null && !Inherits.IsFrameworkType && Inherits.Implementation is ObjectType objectType)
            {
                baseCtor = objectType.Constructors.First();
                defaultCtorParameters.AddRange(baseCtor.Parameters);
            }

            foreach (var property in Properties)
            {
                // Only required properties that are not discriminators go into default ctor
                if (property == Discriminator?.Property)
                {
                    continue;
                }

                ReferenceOrConstant? initializationValue;

                if (property.SchemaProperty?.Schema is ConstantSchema constantSchema)
                {
                    // Turn constants into initializers
                    initializationValue = constantSchema.Value.Value != null ?
                        BuilderHelpers.ParseConstant(constantSchema.Value.Value, property.Declaration.Type) :
                        Constant.NewInstanceOf(property.Declaration.Type);
                }
                else if (IsStruct || property.SchemaProperty?.Required == true)
                {
                    // For structs all properties become required
                    Constant? defaultParameterValue = null;
                    if (property.SchemaProperty?.ClientDefaultValue is object defaultValueObject)
                    {
                        defaultParameterValue = BuilderHelpers.ParseConstant(defaultValueObject, property.Declaration.Type);
                    }

                    var defaultCtorParameter = new Parameter(
                        property.Declaration.Name.ToVariableName(),
                        property.Description,
                        TypeFactory.GetInputType(property.Declaration.Type),
                        defaultParameterValue,
                        true
                    );

                    defaultCtorParameters.Add(defaultCtorParameter);
                    initializationValue = defaultCtorParameter;
                }
                else
                {
                    initializationValue = GetPropertyDefaultValue(property);
                }

                if (initializationValue != null)
                {
                    defaultCtorInitializers.Add(new ObjectPropertyInitializer(property, initializationValue.Value));
                }
            }

            if (Discriminator != null)
            {
                defaultCtorInitializers.Add(new ObjectPropertyInitializer(Discriminator.Property, BuilderHelpers.StringConstant(Discriminator.Value)));
            }

            return new ObjectTypeConstructor(
                BuilderHelpers.CreateMemberDeclaration(
                    Type.Name,
                    Type,
                    // inputs have public ctor by default
                    _objectSchema.IsInput ? "public" : "internal",
                    null,
                    _typeFactory),
                defaultCtorParameters.ToArray(),
                defaultCtorInitializers.ToArray(),
                baseCtor);
        }

        public ObjectTypeDiscriminator? Discriminator => _discriminator ??= BuildDiscriminator();

        public CSharpType? ImplementsDictionaryType => _implementsDictionaryType ??= CreateInheritedDictionaryType();


        public bool IncludeSerializer => _objectSchema.IsInput;
        public bool IncludeDeserializer => _objectSchema.IsOutput;

        public ObjectTypeProperty GetPropertyForSchemaProperty(Property property, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.SchemaProperty == property, out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property for schema property {property.SerializedName} in schema {_objectSchema.Name}");
            }

            return objectProperty;
        }

        public ObjectTypeProperty GetPropertyBySerializedName(string serializedName, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.SchemaProperty?.SerializedName == serializedName, out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property with serialized name {serializedName} in schema {_objectSchema.Name}");
            }

            return objectProperty;
        }

        public ObjectTypeProperty GetPropertyForGroupedParameter(RequestParameter groupedParameter, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(
                p => (p.SchemaProperty as GroupProperty)?.OriginalParameter.Contains(groupedParameter) == true,
                out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property for grouped parameter {groupedParameter.Language.Default.Name} in schema {_objectSchema.Name}");
            }

            return objectProperty;
        }

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

        public IEnumerable<ObjectType> EnumerateHierarchy()
        {
            ObjectType? type = this;
            while (type != null)
            {
                yield return type;

                if (type.Inherits?.IsFrameworkType == false && type.Inherits.Implementation is ObjectType o)
                {
                    type = o;
                }
                else
                {
                    type = null;
                }
            }
        }

        private ObjectTypeDiscriminator? BuildDiscriminator()
        {
            ObjectTypeDiscriminator? discriminator = null;
            Discriminator? schemaDiscriminator = _objectSchema.Discriminator;

            if (schemaDiscriminator == null && _objectSchema.DiscriminatorValue != null)
            {
                schemaDiscriminator = _objectSchema.Parents!.All.OfType<ObjectSchema>().First(p => p.Discriminator != null).Discriminator;

                Debug.Assert(schemaDiscriminator != null);

                discriminator = new ObjectTypeDiscriminator(
                    GetPropertyForSchemaProperty(schemaDiscriminator.Property, includeParents: true),
                    schemaDiscriminator.Property.SerializedName,
                    Array.Empty<ObjectTypeDiscriminatorImplementation>(),
                    _objectSchema.DiscriminatorValue
                );
            }
            else if (schemaDiscriminator != null)
            {
                discriminator = new ObjectTypeDiscriminator(
                    GetPropertyForSchemaProperty(schemaDiscriminator.Property, includeParents: true),
                    schemaDiscriminator.Property.SerializedName,
                    CreateDiscriminatorImplementations(schemaDiscriminator),
                    _objectSchema.DiscriminatorValue
                );
            }

            return discriminator;
        }

        private ObjectSerialization[] BuildSerializations()
        {
            return _objectSchema.SerializationFormats.Select(type => _serializationBuilder.BuildObject(type, _objectSchema, this)).ToArray();
        }

        private ObjectTypeDiscriminatorImplementation[] CreateDiscriminatorImplementations(Discriminator schemaDiscriminator)
        {
            return schemaDiscriminator.All.Select(implementation => new ObjectTypeDiscriminatorImplementation(
                implementation.Key,
                _typeFactory.CreateType(implementation.Value, false)
            )).ToArray();
        }

        private IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            // WORKAROUND: https://github.com/Azure/autorest.modelerfour/issues/261
            var existingProperties = EnumerateHierarchy()
                .Skip(1)
                .SelectMany(type => type.Properties)
                .Select(p => p.SchemaProperty?.Language.Default.Name)
                .ToHashSet();

            foreach (var objectSchema in GetCombinedSchemas())
            {
                foreach (Property property in objectSchema.Properties!)
                {
                    if (existingProperties.Contains(property.Language.Default.Name))
                    {
                        // WORKAROUND: https://github.com/Azure/autorest.modelerfour/issues/261
                        continue;
                    }

                    var name = BuilderHelpers.DisambiguateName(Type, property.CSharpName());
                    SourceMemberMapping? memberMapping = _sourceTypeMapping?.GetForMember(name);
                    bool isReadOnly = IsStruct ||
                                      objectSchema.IsOutputOnly ||
                                      property.ReadOnly == true ||
                                      // Required properties of input objects should be readonly
                                      (property.Required == true && objectSchema.IsInputOnly);

                    if (property.IsDiscriminator == true)
                    {
                        // Discriminator properties should be writeable
                        isReadOnly = false;
                    }

                    CSharpType type = _typeFactory.CreateType(
                        property.Schema,
                        property.IsNullable());

                    if (!_objectSchema.IsInput)
                    {
                        type = TypeFactory.GetOutputType(type);
                    }

                    var accessibility = property.IsDiscriminator == true ? "internal" : "public";

                    CSharpType? initializeWithType = memberMapping?.Initialize == true ? TypeFactory.GetImplementationType(type) : null;

                    yield return new ObjectTypeProperty(
                        BuilderHelpers.CreateMemberDeclaration(name, type, accessibility, memberMapping?.ExistingMember, _typeFactory),
                        BuilderHelpers.EscapeXmlDescription(property.Language.Default.Description),
                        isReadOnly,
                        property,
                        initializeWithType,
                        memberMapping?.EmptyAsUndefined ?? false);
                }
            }

            if (AdditionalPropertiesProperty is ObjectTypeProperty additionalPropertiesProperty)
            {
                yield return additionalPropertiesProperty;
            }
        }

        // Enumerates all schemas that were merged into this one, excludes the inherited schema
        private IEnumerable<ObjectSchema> GetCombinedSchemas()
        {
            var inherited = EnumerateHierarchy().Select(type => type._objectSchema).ToHashSet();

            yield return _objectSchema;

            foreach (var parent in _objectSchema.Parents!.All)
            {
                if (parent is ObjectSchema objectParent && !inherited.Contains(objectParent))
                {
                    // WORKAROUND: https://github.com/Azure/autorest.modelerfour/issues/257
                    inherited.Add(objectParent);
                    yield return objectParent;
                }
            }
        }

        private CSharpType? CreateInheritedType()
        {
            var sourceBaseType = ExistingType?.BaseType;
            if (sourceBaseType != null &&
                sourceBaseType.SpecialType != SpecialType.System_ValueType &&
                sourceBaseType.SpecialType != SpecialType.System_Object &&
                _typeFactory.TryCreateType(sourceBaseType, out CSharpType? baseType))
            {
                return baseType;
            }

            var objectSchemas = _objectSchema.Parents!.Immediate.OfType<ObjectSchema>().ToArray();

            ObjectSchema? selectedSchema = null;

            foreach (var objectSchema in objectSchemas)
            {
                bool skip = false;

                // Filter transitive schemas
                // https://github.com/Azure/autorest.modelerfour/issues/258
                foreach (var otherSchema in objectSchemas)
                {
                    if (otherSchema.Parents!.All.Contains(objectSchema))
                    {
                        skip = true;
                        break;
                    }
                }

                if (skip)
                {
                    continue;
                }

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
            foreach (ComplexSchema complexSchema in _objectSchema.Parents!.Immediate)
            {
                if (complexSchema is DictionarySchema dictionarySchema)
                {
                    return new CSharpType(
                        _objectSchema.IsInput ? typeof(IDictionary<,>) : typeof(IReadOnlyDictionary<,>),
                        typeof(string),
                        _typeFactory.CreateType(dictionarySchema.ElementType, false));
                };
            }

            return null;
        }
    }
}
