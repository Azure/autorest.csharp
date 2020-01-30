// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
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
        private ObjectSerialization[]? _serializations;

        public ObjectType(ObjectSchema objectSchema, BuildContext context)
        {
            _objectSchema = objectSchema;
            _context = context;
            _typeFactory = _context.TypeFactory;
            _serializationBuilder = new SerializationBuilder(_typeFactory);

            Schema = objectSchema;
            Declaration = BuilderHelpers.CreateTypeAttributes(
                objectSchema.CSharpName(),
                $"{context.DefaultNamespace}.Models",
                Accessibility.Public,
                context.SourceInputModel.FindForSchema(_objectSchema.Name)?.ExistingType);

            Description = BuilderHelpers.CreateDescription(objectSchema);
            Type = new CSharpType(Declaration.Namespace, Declaration.Name, isValueType: false);;
        }

        public TypeDeclarationOptions Declaration { get; }

        public string? Description { get; }

        public Schema Schema { get; }

        public CSharpType? Inherits => _inheritsType ?? CreateInheritedType();

        public ObjectSerialization[] Serializations => _serializations ??= BuildSerializations();

        public ObjectTypeProperty[] Properties => _properties ??= BuildProperties().ToArray();

        public ObjectTypeDiscriminator? Discriminator => _discriminator ??= BuildDiscriminator();

        public CSharpType? ImplementsDictionary => _inheritsType ??= CreateInheritedDictionary();

        public CSharpType Type { get; }

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
            return _context.SupportedMediaTypes.Select(type => _serializationBuilder.BuildObject(type, _objectSchema, isNullable: false)).ToArray();
        }

        private CSharpType CreateDictionaryType(DictionarySchema inheritedDictionarySchema)
        {
            return new CSharpType(typeof(IDictionary<,>),
                isNullable: false,
                new CSharpType(typeof(string)),
                _typeFactory.CreateType(inheritedDictionarySchema.ElementType, false));
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
                yield return CreateProperty(property);
            }
        }

        private ObjectTypeProperty CreateProperty(Property property)
        {
            bool isReadOnly = property.IsDiscriminator == true || property.ReadOnly == true;

            Constant? defaultValue = null;

            CSharpType type;
            CSharpType? initializeType = null;
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
                else if (property.Required == true && (property.Schema is ArraySchema || property.Schema is DictionarySchema))
                {
                    initializeType = type;
                }
            }

            return new ObjectTypeProperty(property.CSharpName(),
                BuilderHelpers.EscapeXmlDescription(property.Language.Default.Description),
                type,
                isReadOnly,
                initializeType,
                property,
                defaultValue);
        }

        private CSharpType? CreateInheritedType()
        {
            foreach (ComplexSchema complexSchema in _objectSchema.Parents!.Immediate)
            {
                if (complexSchema is ObjectSchema parentObjectSchema)
                {
                    return _typeFactory.CreateType(parentObjectSchema, false);
                }
            }

            return null;
        }

        private CSharpType? CreateInheritedDictionary()
        {
            foreach (ComplexSchema complexSchema in _objectSchema.Parents!.Immediate)
            {
                if (complexSchema is DictionarySchema dictionarySchema)
                {
                    return CreateDictionaryType(dictionarySchema);
                };
            }

            return null;
        }
    }
}
