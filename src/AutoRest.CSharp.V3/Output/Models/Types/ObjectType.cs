// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
            _sourceTypeMapping = context.SourceInputModel.FindForSchema(_objectSchema.Name);
            _typeFactory = context.TypeFactory;
            _serializationBuilder = new SerializationBuilder(_typeFactory);

            Schema = objectSchema;
            Declaration = BuilderHelpers.CreateTypeAttributes(
                objectSchema.CSharpName(),
                $"{context.DefaultNamespace}.Models",
                "public",
                _sourceTypeMapping?.ExistingType);

            Description = BuilderHelpers.CreateDescription(objectSchema);
            Type = new CSharpType(this, Declaration.Namespace, Declaration.Name, isValueType: false);;
        }

        public TypeDeclarationOptions Declaration { get; }

        public string? Description { get; }

        public Schema Schema { get; }

        public CSharpType? Inherits => _inheritsType ??= CreateInheritedType();

        public ObjectSerialization[] Serializations => _serializations ??= BuildSerializations();

        public ObjectTypeProperty[] Properties => _properties ??= BuildProperties().ToArray();

        public ObjectTypeProperty? AdditionalPropertiesProperty {
            get
            {
                if (_additionalPropertiesProperty != null || ImplementsDictionaryElementType == null)
                {
                    return _additionalPropertiesProperty;
                }

                var dictionaryType = new CSharpType(typeof(IDictionary<,>), new CSharpType(typeof(string)), ImplementsDictionaryElementType);
                var implType = new CSharpType(typeof(Dictionary<,>), new CSharpType(typeof(string)), ImplementsDictionaryElementType);

                SourceMemberMapping? memberMapping = _sourceTypeMapping?.GetMemberForSchema("$AdditionalProperties");

                _additionalPropertiesProperty = new ObjectTypeProperty(
                    BuilderHelpers.CreateMemberDeclaration("AdditionalProperties", dictionaryType, "internal", memberMapping?.ExistingMember),
                    string.Empty,
                    !_objectSchema.IsInput,
                    implType,
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

            foreach (var property in Properties)
            {
                var parameter = new Parameter(
                    property.Declaration.Name.ToVariableName(),
                    property.Description,
                    property.Declaration.Type,
                    null,
                    false
                );

                var initializer = new ObjectPropertyInitializer(property, parameter);

                serializationConstructorParameters.Add(parameter);
                initializers.Add(initializer);

                if (property.SchemaProperty?.Required == true &&
                    property != Discriminator?.Property)
                {
                    defaultCtorParameters.Add(parameter);
                    defaultCtorInitializers.Add(initializer);
                }
            }

            if (Discriminator != null)
            {
                defaultCtorInitializers.Add(new ObjectPropertyInitializer(Discriminator.Property, BuilderHelpers.StringConstant(Discriminator.Value)));
            }

            ObjectTypeConstructor? baseCtor = null;
            ObjectTypeConstructor? baseSerializationCtor = null;
            if (Inherits != null && !Inherits.IsFrameworkType && Inherits.Implementation is ObjectType objectType)
            {
                baseCtor = objectType.Constructors.First();
                baseSerializationCtor = objectType.Constructors.Last();

                defaultCtorParameters.AddRange(baseCtor.Parameters);
                serializationConstructorParameters.AddRange(baseSerializationCtor.Parameters);
            }

            yield return new ObjectTypeConstructor(
                BuilderHelpers.CreateMemberDeclaration(
                    Type.Name,
                    Type,
                    // inputs have public ctor by default
                    _objectSchema.IsInput ? "public" : "internal",
                    _sourceTypeMapping?.DefaultConstructor),
                defaultCtorParameters.ToArray(),
                defaultCtorInitializers.ToArray(),
                baseCtor);

            // Skip serialization ctor if they are the same
            if (defaultCtorParameters.Count != serializationConstructorParameters.Count)
            {
                yield return new ObjectTypeConstructor(
                    BuilderHelpers.CreateMemberDeclaration(Type.Name, Type, "internal", null),
                    serializationConstructorParameters.ToArray(),
                    initializers.ToArray(),
                    baseSerializationCtor
                );
            }
        }

        public ObjectTypeDiscriminator? Discriminator => _discriminator ??= BuildDiscriminator();

        public CSharpType? ImplementsDictionaryElementType => _implementsDictionaryType ??= CreateInheritedDictionaryElementType();

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
                _typeFactory.CreateType(implementation.Value, false),
                schemaDiscriminator.Immediate.ContainsKey(implementation.Key)
            )).ToArray();
        }

        private IEnumerable<ObjectTypeProperty> BuildProperties()
        {
            foreach (Property property in _objectSchema.Properties!)
            {
                SourceMemberMapping? memberMapping = _sourceTypeMapping?.GetMemberForSchema(property.SerializedName);
                bool isReadOnly =
                    property.IsDiscriminator != true &&
                    (property.ReadOnly == true ||
                     property.Required == true ||
                     !_objectSchema.IsInput);

                Constant? defaultValue = null;

                CSharpType type;
                CSharpType? implementationType = null;
                if (property.Schema is ConstantSchema constantSchema)
                {
                    type = _typeFactory.CreateType(constantSchema.ValueType, false);
                    defaultValue = BuilderHelpers.ParseConstant(constantSchema.Value.Value, type);
                }
                else
                {
                    type = _typeFactory.CreateType(property.Schema, property.IsNullable());
                    if (property.ClientDefaultValue != null)
                    {
                        defaultValue = BuilderHelpers.ParseConstant(property.ClientDefaultValue, type);
                    }
                    else if (property.Required == true && (property.Schema is ObjectSchema || property.Schema is ArraySchema || property.Schema is DictionarySchema))
                    {
                        implementationType = _typeFactory.CreateImplementationType(property.Schema, property.IsNullable());
                    }
                }

                var accessibility = property.IsDiscriminator == true ? "internal" : "public";

                yield return new ObjectTypeProperty(
                    BuilderHelpers.CreateMemberDeclaration(property.CSharpName(), type, accessibility, memberMapping?.ExistingMember),
                    BuilderHelpers.EscapeXmlDescription(property.Language.Default.Description),
                    isReadOnly,
                    implementationType,
                    property,
                    defaultValue);
            }

            if (AdditionalPropertiesProperty is ObjectTypeProperty additionalPropertiesProperty)
            {
                yield return additionalPropertiesProperty;
            }
        }

        private CSharpType? CreateInheritedType()
        {
            foreach (ComplexSchema complexSchema in _objectSchema.Parents!.Immediate)
            {
                if (complexSchema is ObjectSchema parentObjectSchema)
                {
                    CSharpType type = _typeFactory.CreateType(parentObjectSchema, false);
                    Debug.Assert(!type.IsFrameworkType);
                    return type;
                }
            }

            return null;
        }

        private CSharpType? CreateInheritedDictionaryElementType()
        {
            foreach (ComplexSchema complexSchema in _objectSchema.Parents!.Immediate)
            {
                if (complexSchema is DictionarySchema dictionarySchema)
                {
                    return _typeFactory.CreateType(dictionarySchema.ElementType, false);
                };
            }

            return null;
        }
    }
}
