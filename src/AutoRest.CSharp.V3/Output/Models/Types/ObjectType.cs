// Copyright (c) Microsoft Corporation. All rights reserved.
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
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Utilities;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class ObjectType : ISchemaType
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

        public ObjectType(ObjectSchema objectSchema, BuildContext context)
        {
            _objectSchema = objectSchema;
            _typeFactory = context.TypeFactory;
            _serializationBuilder = new SerializationBuilder();

            Schema = objectSchema;
            var name = objectSchema.CSharpName();
            var ns = $"{context.DefaultNamespace}.Models";
            _sourceTypeMapping = context.SourceInputModel.FindForModel(ns, name);
            Declaration = BuilderHelpers.CreateTypeAttributes(
                name,
                ns,
                "public",
                _sourceTypeMapping?.ExistingType);

            Description = BuilderHelpers.CreateDescription(objectSchema);
            IsStruct = _sourceTypeMapping?.ExistingType.IsValueType == true;

            Type = new CSharpType(this, Declaration.Namespace, Declaration.Name, isValueType: IsStruct);
        }

        public bool IsStruct { get; }

        public TypeDeclarationOptions Declaration { get; }

        public string? Description { get; }

        public Schema Schema { get; }

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
                    null);

                return _additionalPropertiesProperty;
            }
        }

        public ObjectTypeConstructor[] Constructors => _constructors ??= BuildConstructors().ToArray();

        private IEnumerable<ObjectTypeConstructor> BuildConstructors()
        {
            List<Parameter> serializationConstructorParameters = new List<Parameter>();
            List<Parameter> defaultCtorParameters = new List<Parameter>();
            List<ObjectPropertyInitializer> initializers = new List<ObjectPropertyInitializer>();
            List<ObjectPropertyInitializer> defaultCtorInitializers = new List<ObjectPropertyInitializer>();

            ObjectTypeConstructor? baseCtor = null;
            ObjectTypeConstructor? baseSerializationCtor = null;
            if (Inherits != null && !Inherits.IsFrameworkType && Inherits.Implementation is ObjectType objectType)
            {
                baseCtor = objectType.Constructors.First();
                baseSerializationCtor = objectType.Constructors.Last();

                defaultCtorParameters.AddRange(baseCtor.Parameters);
                serializationConstructorParameters.AddRange(baseSerializationCtor.Parameters);
            }

            bool ownsDiscriminatorProperty = false;
            foreach (var property in Properties)
            {
                var deserializationParameter = new Parameter(
                    property.Declaration.Name.ToVariableName(),
                    property.Description,
                    property.Declaration.Type,
                    null,
                    false
                );

                serializationConstructorParameters.Add(deserializationParameter);

                initializers.Add(new ObjectPropertyInitializer(property, deserializationParameter));

                // Only required properties that are not discriminators go into default ctor
                if (property == Discriminator?.Property)
                {
                    ownsDiscriminatorProperty = true;
                    continue;
                }
                // For structs all properties become required
                if (!IsStruct && property.SchemaProperty?.Required != true)
                {
                    continue;
                }

                // Turn constants into initializers
                if (property.SchemaProperty?.Schema is ConstantSchema constantSchema)
                {
                    var constantValue = constantSchema.Value.Value != null ?
                        BuilderHelpers.ParseConstant(constantSchema.Value.Value, property.Declaration.Type) :
                        Constant.NewInstanceOf(property.Declaration.Type);

                    defaultCtorInitializers.Add(new ObjectPropertyInitializer(
                        property,
                        constantValue));

                    continue;
                }

                Constant? defaultValue = null;

                if (property.SchemaProperty?.ClientDefaultValue is object defaultValueObject)
                {
                    defaultValue = BuilderHelpers.ParseConstant(defaultValueObject, property.Declaration.Type);
                }

                var defaultCtorParameter = new Parameter(
                    property.Declaration.Name.ToVariableName(),
                    property.Description,
                    TypeFactory.GetInputType(property.Declaration.Type),
                    defaultValue,
                    true
                );

                defaultCtorParameters.Add(defaultCtorParameter);
                defaultCtorInitializers.Add(new ObjectPropertyInitializer(property, defaultCtorParameter));
            }


            if (Discriminator != null)
            {
                // Add discriminator initializer to constructor at every level of hierarchy
                if (!ownsDiscriminatorProperty &&
                    baseSerializationCtor != null
                    )
                {
                    var discriminatorParameter = baseSerializationCtor.FindParameterByInitializedProperty(Discriminator.Property);
                    Debug.Assert(discriminatorParameter != null);

                    initializers.Add(new ObjectPropertyInitializer(Discriminator.Property, discriminatorParameter));
                }
                defaultCtorInitializers.Add(new ObjectPropertyInitializer(Discriminator.Property, BuilderHelpers.StringConstant(Discriminator.Value)));
            }

            // In structs additional properties would become required and get initialized from parameter
            if (AdditionalPropertiesProperty != null && !IsStruct)
            {
                var implType = new CSharpType(typeof(Dictionary<,>), AdditionalPropertiesProperty.Declaration.Type.Arguments);
                defaultCtorInitializers.Add(new ObjectPropertyInitializer(AdditionalPropertiesProperty, Constant.NewInstanceOf(implType)));
            }

            yield return new ObjectTypeConstructor(
                BuilderHelpers.CreateMemberDeclaration(
                    Type.Name,
                    Type,
                    // inputs have public ctor by default
                    _objectSchema.IsInput ? "public" : "internal",
                    _sourceTypeMapping?.DefaultConstructor,
                    _typeFactory),
                defaultCtorParameters.ToArray(),
                defaultCtorInitializers.ToArray(),
                baseCtor);

            // Skip serialization ctor if they are the same
            if (!defaultCtorParameters
                    .Select(p => p.Type)
                    .SequenceEqual(serializationConstructorParameters.Select(p => p.Type)))
            {
                yield return new ObjectTypeConstructor(
                    BuilderHelpers.CreateMemberDeclaration(Type.Name, Type, "internal", null, _typeFactory),
                    serializationConstructorParameters.ToArray(),
                    initializers.ToArray(),
                    baseSerializationCtor
                );
            }
        }

        public ObjectTypeDiscriminator? Discriminator => _discriminator ??= BuildDiscriminator();

        public CSharpType? ImplementsDictionaryType => _implementsDictionaryType ??= CreateInheritedDictionaryType();

        public CSharpType Type { get; }

        public bool IncludeSerializer => _objectSchema.IsInput;
        public bool IncludeDeserializer => _objectSchema.IsOutput;

        public ObjectTypeProperty GetPropertyForSchemaProperty(Property property, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.SchemaProperty == property, out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property for schema property {property.SerializedName} in schema {Schema.Name}");
            }

            return objectProperty;
        }

        public ObjectTypeProperty GetPropertyBySerializedName(string serializedName, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(p => p.SchemaProperty?.SerializedName == serializedName, out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property with serialized name {serializedName} in schema {Schema.Name}");
            }

            return objectProperty;
        }

        public ObjectTypeProperty GetPropertyForGroupedParameter(RequestParameter groupedParameter, bool includeParents = false)
        {
            if (!TryGetPropertyForSchemaProperty(
                p => (p.SchemaProperty as GroupProperty)?.OriginalParameter.Contains(groupedParameter) == true,
                out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property for grouped parameter {groupedParameter.Language.Default.Name} in schema {Schema.Name}");
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
            foreach (var objectSchema in GetCombinedSchemas())
            {
                foreach (Property property in objectSchema.Properties!)
                {
                    var name = BuilderHelpers.DisambiguateName(Type, property.CSharpName());
                               SourceMemberMapping? memberMapping = _sourceTypeMapping?.GetForMember(name);
                    bool isReadOnly =
                        IsStruct ||
                        property.IsDiscriminator != true &&
                        (property.ReadOnly == true ||
                         property.Required == true ||
                         !_objectSchema.IsInput);

                    CSharpType type = _typeFactory.CreateType(
                        property.Schema,
                        property.IsNullable());

                    if (!_objectSchema.IsInput)
                    {
                        type = TypeFactory.GetOutputType(type);
                    }

                    var accessibility = property.IsDiscriminator == true ? "internal" : "public";

                    yield return new ObjectTypeProperty(
                        BuilderHelpers.CreateMemberDeclaration(name, type, accessibility, memberMapping?.ExistingMember, _typeFactory),
                        BuilderHelpers.EscapeXmlDescription(property.Language.Default.Description),
                        isReadOnly,
                        property);
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
            var inherited = EnumerateHierarchy().Select(type => type.Schema).ToHashSet();

            yield return _objectSchema;

            foreach (var parent in _objectSchema.Parents!.All)
            {
                if (parent is ObjectSchema objectParent && !inherited.Contains(objectParent))
                {
                    // WORKAROUND: https://github.com/Azure/autorest.modelerfour/issues/257
                    inherited.Add(parent);
                    yield return objectParent;
                }
            }
        }

        private CSharpType? CreateInheritedType()
        {
            var sourceBaseType = _sourceTypeMapping?.ExistingType?.BaseType;
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
