// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Input.Source;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.TypeReferences;
using AutoRest.CSharp.V3.Output.Models.Types;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.V3.Output.Builders
{
    internal class ModelBuilder
    {
        private readonly KnownMediaType[] _mediaTypes;
        private readonly SourceInputModel _sourceInputModel;
        private readonly string _defaultModelsNamespace;
        private Accessibility _defaultAccessibility;

        public ModelBuilder(string @namespace, KnownMediaType[] mediaTypes, SourceInputModel sourceInputModel)
        {
            _mediaTypes = mediaTypes;
            _sourceInputModel = sourceInputModel;
            _defaultModelsNamespace = $"{@namespace}.Models";
        }

        private ISchemaType BuildClientEnum(SealedChoiceSchema sealedChoiceSchema)
        {
            var codeInput = _sourceInputModel.FindForSchema(sealedChoiceSchema.Name);

            _defaultAccessibility = Accessibility.Public;
            return new EnumType(
                sealedChoiceSchema,
                BuilderHelpers.CreateTypeAttributes(sealedChoiceSchema.CSharpName(), _defaultModelsNamespace, _defaultAccessibility, codeInput?.ExistingType),
                CreateDescription(sealedChoiceSchema),
                sealedChoiceSchema.Choices.Select(c => new EnumTypeValue(
                    c.CSharpName(),
                    CreateDescription(c),
                    BuilderHelpers.StringConstant(c.Value))));
        }

        private ISchemaType BuildClientEnum(ChoiceSchema choiceSchema)
        {
            var codeInput = _sourceInputModel.FindForSchema(choiceSchema.Name);

            return new EnumType(
                choiceSchema,
                BuilderHelpers.CreateTypeAttributes(choiceSchema.CSharpName(), _defaultModelsNamespace, _defaultAccessibility, codeInput?.ExistingType),
                CreateDescription(choiceSchema),
                choiceSchema.Choices.Select(c => new EnumTypeValue(
                    c.CSharpName(),
                    CreateDescription(c),
                    BuilderHelpers.StringConstant(c.Value))),
                true);
        }

        private ISchemaType BuildClientObject(ObjectSchema objectSchema)
        {
            var codeInput = _sourceInputModel.FindForSchema(objectSchema.Name);

            TypeReference? inheritsFromTypeReference = null;
            DictionarySchema? inheritedDictionarySchema = null;

            foreach (ComplexSchema complexSchema in objectSchema.Parents!.Immediate)
            {
                switch (complexSchema)
                {
                    case ObjectSchema parentObjectSchema:
                        inheritsFromTypeReference = BuilderHelpers.CreateType(parentObjectSchema, false);
                        break;
                    case DictionarySchema dictionarySchema:
                        inheritedDictionarySchema = dictionarySchema;
                        break;
                }
            }

            List<ObjectTypeProperty> properties = new List<ObjectTypeProperty>();

            foreach (Property property in objectSchema.Properties!)
            {
                ObjectTypeProperty objectTypeProperty = CreateProperty(property);
                properties.Add(objectTypeProperty);
            }

            Discriminator? schemaDiscriminator = objectSchema.Discriminator;
            ObjectTypeDiscriminator? discriminator = null;

            if (schemaDiscriminator == null && objectSchema.DiscriminatorValue != null)
            {
                schemaDiscriminator = objectSchema.Parents!.All.OfType<ObjectSchema>().First(p => p.Discriminator != null).Discriminator;

                Debug.Assert(schemaDiscriminator != null);

                discriminator = new ObjectTypeDiscriminator(
                    schemaDiscriminator.Property.CSharpName(),
                    schemaDiscriminator.Property.SerializedName,
                    Array.Empty<ObjectTypeDiscriminatorImplementation>(),
                    objectSchema.DiscriminatorValue
                );
            }
            else if (schemaDiscriminator != null)
            {
                discriminator = new ObjectTypeDiscriminator(
                    schemaDiscriminator.Property.CSharpName(),
                    schemaDiscriminator.Property.SerializedName,
                    CreateDiscriminatorImplementations(schemaDiscriminator),
                    objectSchema.DiscriminatorValue
                    );
            }

            return new ObjectType(
                objectSchema,
                BuilderHelpers.CreateTypeAttributes(objectSchema.CSharpName(), _defaultModelsNamespace, _defaultAccessibility, codeInput?.ExistingType),
                CreateDescription(objectSchema),
                (SchemaTypeReference?) inheritsFromTypeReference,
                properties.ToArray(),
                discriminator,
                inheritedDictionarySchema == null ? null : CreateDictionaryType(inheritedDictionarySchema),
                BuildSerializations(objectSchema)
                );
        }

        private ObjectSerialization[] BuildSerializations(ObjectSchema objectSchema)
        {
            return _mediaTypes.Select(type => SerializationBuilder.BuildObject(type, objectSchema, isNullable: false)).ToArray();
        }

        private static DictionaryTypeReference CreateDictionaryType(DictionarySchema inheritedDictionarySchema)
        {
            return new DictionaryTypeReference(
                new FrameworkTypeReference(typeof(string)),
                BuilderHelpers.CreateType(inheritedDictionarySchema.ElementType, false),
                false);
        }

        private static ObjectTypeDiscriminatorImplementation[] CreateDiscriminatorImplementations(Discriminator schemaDiscriminator)
        {
            return schemaDiscriminator.All.Select(implementation => new ObjectTypeDiscriminatorImplementation(
                implementation.Key,
                (SchemaTypeReference)BuilderHelpers.CreateType(implementation.Value, false),
                schemaDiscriminator.Immediate.ContainsKey(implementation.Key)
            )).ToArray();
        }

        public ISchemaType BuildModel(Schema schema) => schema switch
        {
            SealedChoiceSchema sealedChoiceSchema => BuildClientEnum(sealedChoiceSchema),
            ChoiceSchema choiceSchema => BuildClientEnum(choiceSchema),
            ObjectSchema objectSchema => BuildClientObject(objectSchema),
            _ => throw new NotImplementedException()
        };

        private static ObjectTypeProperty CreateProperty(Property property)
        {
            bool isReadOnly = property.IsDiscriminator == true || property.ReadOnly == true;

            Constant? defaultValue = null;

            TypeReference type;
            if (property.Schema is ConstantSchema constantSchema)
            {
                type = BuilderHelpers.CreateType(constantSchema.ValueType, false);
                defaultValue = BuilderHelpers.ParseConstant(constantSchema.Value.Value, type);
            }
            else
            {
                type = BuilderHelpers.CreateType(property.Schema, property.IsNullable());
                if (property.ClientDefaultValue != null)
                {
                    defaultValue = BuilderHelpers.ParseConstant(property.ClientDefaultValue, type);
                }
            }

            return new ObjectTypeProperty(property.CSharpName(),
                BuilderHelpers.EscapeXmlDescription(property.Language.Default.Description),
                type,
                isReadOnly,
                defaultValue);
        }

        private static string CreateDescription(ChoiceValue choiceValue)
        {
            return string.IsNullOrWhiteSpace(choiceValue.Language.Default.Description) ?
                choiceValue.Value :
                BuilderHelpers.EscapeXmlDescription(choiceValue.Language.Default.Description);
        }

        private static string CreateDescription(Schema objectSchema)
        {
            return string.IsNullOrWhiteSpace(objectSchema.Language.Default.Description) ?
                $"The {objectSchema.Name}." :
                BuilderHelpers.EscapeXmlDescription(objectSchema.Language.Default.Description);
        }
    }
}
