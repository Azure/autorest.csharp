// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputModelPropertyConverter : JsonConverter<IModelProperty>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputModelPropertyConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override IModelProperty Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<IModelProperty>(_referenceHandler.CurrentResolver) ?? ReadInputModelProperty(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, IModelProperty value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private static IModelProperty ReadInputModelProperty(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = true;
            string? serializedName = null;
            string? description = null;
            IType? propertyType = null;
            bool isReadOnly = false;
            bool isRequired = false;
            bool isDiscriminator = false;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(IModelProperty.Name), ref name)
                    || reader.TryReadString(nameof(IModelProperty.SerializedName), ref serializedName)
                    || reader.TryReadString(nameof(IModelProperty.Description), ref description)
                    || reader.TryReadWithConverter(nameof(IModelProperty.Type), options, ref propertyType)
                    || reader.TryReadBoolean(nameof(IModelProperty.IsReadOnly), ref isReadOnly)
                    || reader.TryReadBoolean(nameof(IModelProperty.IsRequired), ref isRequired)
                    || reader.TryReadBoolean(nameof(IModelProperty.IsDiscriminator), ref isDiscriminator);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name = name ?? throw new JsonException($"{nameof(IModelProperty)} must have a name.");
            description = description ?? throw new JsonException($"{nameof(IModelProperty)} must have a description.");
            description = BuilderHelpers.EscapeXmlDocDescription(description);
            propertyType = propertyType ?? throw new JsonException($"{nameof(IModelProperty)} must have a property type.");

            var property = new InputModelProperty(name, serializedName ?? name, description, propertyType, isRequired, isReadOnly, isDiscriminator);
            if (id != null)
            {
                resolver.AddReference(id, property);
            }

            return property;
        }
    }
}
