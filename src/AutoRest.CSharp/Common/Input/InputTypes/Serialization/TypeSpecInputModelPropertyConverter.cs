﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputModelPropertyConverter : JsonConverter<InputModelProperty>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputModelPropertyConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputModelProperty Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputModelProperty>(_referenceHandler.CurrentResolver) ?? ReadInputModelProperty(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        private static InputModelProperty ReadInputModelProperty(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = true;
            string? serializedName = null;
            string? summary = null;
            string? doc = null;
            InputType? propertyType = null;
            InputConstant? defaultValue = null;
            bool isReadOnly = false;
            bool isOptional = false;
            bool isDiscriminator = false;
            IReadOnlyList<InputDecoratorInfo>? decorators = null;
            bool isFlattened = false;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("serializedName", ref serializedName)
                    || reader.TryReadString("summary", ref summary)
                    || reader.TryReadString("doc", ref doc)
                    || reader.TryReadComplexType("type", options, ref propertyType)
                    || reader.TryReadBoolean("readOnly", ref isReadOnly)
                    || reader.TryReadBoolean("optional", ref isOptional)
                    || reader.TryReadBoolean("discriminator", ref isDiscriminator)
                    || reader.TryReadComplexType("decorators", options, ref decorators)
                    || reader.TryReadBoolean("flatten", ref isFlattened);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException($"{nameof(InputModelProperty)} must have a name.");
            propertyType = propertyType ?? throw new JsonException($"{nameof(InputModelProperty)} must have a property type.");

            if (propertyType is InputLiteralType lt)
            {
                defaultValue = new InputConstant(lt.Value, lt.ValueType);
                propertyType = lt.ValueType;
            }

            var property = new InputModelProperty(name, serializedName ?? name, summary, doc, propertyType, defaultValue, !isOptional, isReadOnly, isDiscriminator)
            {
                Decorators = decorators ?? [],
                IsFlattened = isFlattened
            };
            if (id != null)
            {
                resolver.AddReference(id, property);
            }

            return property;
        }

        public override void Write(Utf8JsonWriter writer, InputModelProperty value, JsonSerializerOptions options)
        {
            var id = _referenceHandler.CurrentResolver.GetReference(value, out var alreadyExists);
            if (alreadyExists)
            {
                writer.WriteObjectReference(id);
                return;
            }

            // if not exist
            writer.WriteStartObject();

            // the first property should always be the id
            writer.WriteReferenceId(id);
            // kind
            writer.WriteString("kind", "property");
            // name
            writer.WriteString("name", value.Name);
            // serializedName
            writer.WriteString("serializedName", value.SerializedName);
            // summary
            writer.WriteString("summary", value.Summary);
            // doc
            writer.WriteString("doc", value.Doc);
            // type
            writer.WriteObject("type", value.Type, options);
            // optional
            writer.WriteBoolean("optional", !value.IsRequired);
            // isReadOnly
            writer.WriteBoolean("isReadOnly", value.IsReadOnly);
            // discriminator
            writer.WriteBoolean("discriminator", value.IsDiscriminator);
            // flatten
            writer.WriteBoolean("flatten", value.IsFlattened); // need to figure out how flatten works here.
            // decorators
            writer.WriteArray("decorators", value.Decorators, options);
            // crossLanguageDefinitionId
            writer.WriteString("crossLanguageDefinitionId", string.Empty);
            // serializationOptions
            //writer.WriteObject("serializationOptions", value.SerializationOptions); // we did not adopt this yet

            writer.WriteEndObject();
        }
    }
}
