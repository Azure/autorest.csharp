// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Input.InputTypes;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputModelTypeConverter : JsonConverter<InputModelType>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputModelTypeConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputModelType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => ReadModelType(ref reader, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputModelType value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private static InputModelType? ReadModelType(ref Utf8JsonReader reader, JsonSerializerOptions options, ReferenceResolver resolver)
            => reader.ReadReferenceAndResolve<InputModelType>(resolver) ?? CreateModelType(ref reader, null, null, options, resolver);

        public static InputModelType CreateModelType(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null && name == null;
            var properties = new List<InputModelProperty>();
            var discriminatedSubtypes = new Dictionary<string, InputModelType>();
            string? crossLanguageDefinitionId = null;
            string? access = null;
            string? deprecation = null;
            string? description = null;
            string? usageString = null;
            InputModelProperty? discriminatorProperty = null;
            string? discriminatorValue = null;
            InputType? additionalProperties = null;
            InputModelType? baseModel = null;
            InputModelType? model = null;
            IReadOnlyList<InputDecoratorInfo>? decorators = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("crossLanguageDefinitionId", ref crossLanguageDefinitionId)
                    || reader.TryReadString("access", ref access)
                    || reader.TryReadString("deprecation", ref deprecation)
                    || reader.TryReadString("description", ref description)
                    || reader.TryReadString("usage", ref usageString)
                    || reader.TryReadWithConverter("discriminatorProperty", options, ref discriminatorProperty)
                    || reader.TryReadString("discriminatorValue", ref discriminatorValue)
                    || reader.TryReadWithConverter("additionalProperties", options, ref additionalProperties)
                    || reader.TryReadWithConverter("decorators", options, ref decorators);

                if (isKnownProperty)
                {
                    continue;
                }
                /**
                 * If the model has base model, `BaseModel` and `Properties` should be the last two items in tspCodeModel.
                 * and `BaseModel` should be last but one, and `Properties` should be the last one.
                 */
                if (reader.GetString() == "baseModel")
                {
                    model = CreateInputModelTypeInstance(id, name, crossLanguageDefinitionId, access, deprecation, description, usageString, discriminatorValue, discriminatorProperty, baseModel, properties, discriminatedSubtypes, additionalProperties, decorators, resolver);
                    reader.TryReadWithConverter("baseModel", options, ref baseModel);
                    if (baseModel != null)
                    {
                        model.SetBaseModel(baseModel);
                        var baseModelDerived = (List<InputModelType>)resolver.ResolveReference($"{baseModel.Name}.{nameof(InputModelType.DerivedModels)}");
                        baseModelDerived.Add(model);
                    }
                    continue;
                }
                if (reader.GetString() == "properties")
                {
                    model = model ?? CreateInputModelTypeInstance(id, name, crossLanguageDefinitionId, access, deprecation, description, usageString, discriminatorValue, discriminatorProperty, baseModel, properties, discriminatedSubtypes, additionalProperties, decorators, resolver);
                    reader.Read();
                    CreateProperties(ref reader, properties, options, model.Usage.HasFlag(InputModelTypeUsage.MultipartFormData));
                    continue;
                }
                if (reader.GetString() == "discriminatedSubtypes")
                {
                    model = model ?? CreateInputModelTypeInstance(id, name, crossLanguageDefinitionId, access, deprecation, description, usageString, discriminatorValue, discriminatorProperty, baseModel, properties, discriminatedSubtypes, additionalProperties, decorators, resolver);
                    reader.Read();
                    CreateDiscriminatedSubtypes(ref reader, discriminatedSubtypes, options);
                    if (reader.TokenType != JsonTokenType.EndObject)
                    {
                        throw new JsonException($"{nameof(InputModelType)}.{nameof(InputModelType.Properties)} must be the last defined property for id '{id}', name '{name}'");
                    }
                    continue;
                }

                reader.SkipProperty();
            }

            var result = model ?? CreateInputModelTypeInstance(id, name, crossLanguageDefinitionId, access, deprecation, description, usageString, discriminatorValue, discriminatorProperty, baseModel, properties, discriminatedSubtypes, additionalProperties, decorators, resolver);
            result.Decorators = decorators ?? Array.Empty<InputDecoratorInfo>();
            return result;
        }

        private static InputModelType CreateInputModelTypeInstance(string? id, string? name, string? crossLanguageDefinitionId, string? accessibility, string? deprecated, string? description, string? usageString, string? discriminatorValue, InputModelProperty? discriminatorProperty, InputModelType? baseModel, IReadOnlyList<InputModelProperty> properties, IReadOnlyDictionary<string, InputModelType> discriminatedSubtypes, InputType? additionalProperties, IReadOnlyList<InputDecoratorInfo>? decorators, ReferenceResolver resolver)
        {
            name = name ?? throw new JsonException("Model must have name");
            if (!Enum.TryParse<InputModelTypeUsage>(usageString, out var usage))
            {
                throw new JsonException($"Cannot parse usage {usageString}");
            }

            var derivedModels = new List<InputModelType>();
            decorators = decorators ?? Array.Empty<InputDecoratorInfo>();
            var model = new InputModelType(name, crossLanguageDefinitionId ?? string.Empty, accessibility, deprecated, description, usage, properties, baseModel, derivedModels, discriminatorValue, discriminatorProperty, discriminatedSubtypes, additionalProperties)
            {
                Decorators = decorators
            };

            if (id is not null)
            {
                resolver.AddReference(id, model);
                resolver.AddReference($"{model.Name}.{nameof(InputModelType.DerivedModels)}", derivedModels);
            }

            if (baseModel is not null)
            {
                var baseModelDerived = (List<InputModelType>)resolver.ResolveReference($"{baseModel.Name}.{nameof(InputModelType.DerivedModels)}");
                baseModelDerived.Add(model);
            }

            return model;
        }

        private static void CreateProperties(ref Utf8JsonReader reader, ICollection<InputModelProperty> properties, JsonSerializerOptions options, bool isMultipartType)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }
            reader.Read();

            while (reader.TokenType != JsonTokenType.EndArray)
            {
                var property = reader.ReadWithConverter<InputModelProperty>(options);
                /* TODO: in Multipart body model, if the property is of type Bytes, it should be converted to Stream
                 * In future, we will convert this in emitter when we adopt tcgc.
                 */
                if (property != null && isMultipartType)
                {
                    static InputType ConvertPropertyType(InputType propertyType)
                    {
                        return propertyType switch
                        {
                            InputPrimitiveType { Kind: InputPrimitiveTypeKind.Bytes } => InputPrimitiveType.Stream,
                            InputListType listType => new InputListType(listType.Name, listType.CrossLanguageDefinitionId, ConvertPropertyType(listType.ValueType))
                            {
                                Decorators = listType.Decorators
                            },
                            InputDictionaryType dictionaryType => new InputDictionaryType(dictionaryType.Name, dictionaryType.KeyType, ConvertPropertyType(dictionaryType.ValueType))
                            {
                                Decorators = dictionaryType.Decorators
                            },
                            InputNullableType nullableType => new InputNullableType(ConvertPropertyType(nullableType.Type))
                            {
                                Decorators = nullableType.Decorators
                            },
                            _ => propertyType
                        };
                    }

                    property = new InputModelProperty(property.Name,
                                                    property.SerializedName,
                                                    property.Description,
                                                    ConvertPropertyType(property.Type),
                                                    property.ConstantValue,
                                                    property.IsRequired,
                                                    property.IsReadOnly,
                                                    property.IsDiscriminator,
                                                    property.FlattenedNames);
                }
                properties.Add(property ?? throw new JsonException($"null {nameof(InputModelProperty)} is not allowed"));
            }
            reader.Read();
        }

        private static void CreateDiscriminatedSubtypes(ref Utf8JsonReader reader, IDictionary<string, InputModelType> discriminatedSubtypes, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }
            reader.Read();

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var discriminatorValue = reader.GetString() ?? throw new JsonException("Discriminator value cannot be null");
                reader.Read();
                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    var subtype = reader.ReadWithConverter<InputModelType>(options) ?? throw new JsonException("Discriminated Subtype cannot be null");
                    discriminatedSubtypes.Add(discriminatorValue, subtype);
                }
                else
                {
                    reader.Read();
                }
            }

            reader.Read();
        }
    }
}
