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
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal class ObjectType : ISchemaType
    {
        private readonly ObjectSchema _objectSchema;
        private readonly BuildContext _context;
        private readonly SerializationBuilder _serializationBuilder;
        private readonly TypeFactory _typeFactory;

        private ObjectTypeProperty[]? _properties;
        private ObjectTypeDiscriminator? _discriminator;
        private CSharpType? _inheritsType;
        private CSharpType? _implementsDictionaryType;
        private ObjectSerialization[]? _serializations;
        private readonly ModelTypeMapping? _sourceTypeMapping;

        public ObjectType(ObjectSchema objectSchema, BuildContext context)
        {
            _objectSchema = objectSchema;
            _sourceTypeMapping = context.SourceInputModel.FindForSchema(_objectSchema.Name);
            _context = context;
            _typeFactory = _context.TypeFactory;
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

        public ObjectTypeDiscriminator? Discriminator => _discriminator ??= BuildDiscriminator();

        public CSharpType? ImplementsDictionaryElementType => _implementsDictionaryType ??= CreateInheritedDictionaryElementType();

        public CSharpType Type { get; }

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
            if (!TryGetPropertyForSchemaProperty(p => p.SchemaProperty.SerializedName == serializedName, out ObjectTypeProperty? objectProperty, includeParents))
            {
                throw new InvalidOperationException($"Unable to find object property with serialized name {serializedName} in schema {Schema.Name}");
            }

            return objectProperty;
        }

        private bool TryGetPropertyForSchemaProperty(Func<ObjectTypeProperty, bool> propertySelector, [NotNullWhen(true)] out ObjectTypeProperty? objectProperty, bool includeParents = false)
        {
            objectProperty = null;
            ObjectType? type = this;


            while (type != null && objectProperty == null)
            {
                objectProperty = type.Properties.SingleOrDefault(propertySelector);
                CSharpType? inheritsType = type.Inherits;
                if (includeParents &&
                    inheritsType != null &&
                    !inheritsType.IsFrameworkType)
                {
                    type = inheritsType.Implementation as ObjectType;
                }
                else
                {
                    type = null;
                }
            }
            return objectProperty != null;
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
                    schemaDiscriminator.Property.CSharpName(),
                    schemaDiscriminator.Property.SerializedName,
                    Array.Empty<ObjectTypeDiscriminatorImplementation>(),
                    _objectSchema.DiscriminatorValue
                );
            }
            else if (schemaDiscriminator != null)
            {
                discriminator = new ObjectTypeDiscriminator(
                    schemaDiscriminator.Property.CSharpName(),
                    schemaDiscriminator.Property.SerializedName,
                    CreateDiscriminatorImplementations(schemaDiscriminator),
                    _objectSchema.DiscriminatorValue
                );
            }

            return discriminator;
        }

        private ObjectSerialization[] BuildSerializations()
        {
            //TODO: Remove after https://github.com/Azure/autorest.modelerfour/issues/196 is fixed
            static KnownMediaType Convert(SerializationFormats4 format) => format switch
            {
                SerializationFormats4.Binary => KnownMediaType.Binary,
                SerializationFormats4.Form => KnownMediaType.Form,
                SerializationFormats4.Json => KnownMediaType.Json,
                SerializationFormats4.Multipart => KnownMediaType.Multipart,
                SerializationFormats4.Text => KnownMediaType.Text,
                SerializationFormats4.Unknown => KnownMediaType.Unknown,
                SerializationFormats4.Xml => KnownMediaType.Xml,
                _ => throw new ArgumentOutOfRangeException($"Format {format} is not supported.")
            };

            return _objectSchema.SerializationFormats.Select(type => _serializationBuilder.BuildObject(Convert(type), _objectSchema, this)).ToArray();
        }

        private CSharpType CreateDictionaryElementType(DictionarySchema inheritedDictionarySchema)
        {
            return _typeFactory.CreateType(inheritedDictionarySchema.ElementType, false);
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
                bool isReadOnly = property.IsDiscriminator == true || property.ReadOnly == true;

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

                yield return new ObjectTypeProperty(
                    BuilderHelpers.CreateMemberDeclaration(property.CSharpName(), type, "public", memberMapping?.ExistingMember),
                    BuilderHelpers.EscapeXmlDescription(property.Language.Default.Description),
                    isReadOnly,
                    implementationType,
                    property,
                    defaultValue);
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
                    return CreateDictionaryElementType(dictionarySchema);
                };
            }

            return null;
        }
    }
}
