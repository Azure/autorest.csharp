// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputDiscriminatorConverter : JsonConverter<InputDiscriminator>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputDiscriminatorConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputDiscriminator? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputDiscriminator>(_referenceHandler.CurrentResolver) ?? CreateInputDiscriminator(ref reader, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputDiscriminator value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private static InputDiscriminator CreateInputDiscriminator(ref Utf8JsonReader reader, string? id, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;

            InputModelProperty? property = null;
            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadWithConverter<InputModelProperty>(nameof(InputDiscriminator.Property), options, ref property);

                if (isKnownProperty)
                    continue;
            }

            return CreateInputDiscriminatorInstance(id, property, resolver);
        }

        private static InputDiscriminator CreateInputDiscriminatorInstance(string? id, InputModelProperty? property, ReferenceResolver resolver)
        {
            property = property ?? throw new JsonException("Property in InputDiscriminator must not be null");
            var discriminator = new InputDiscriminator(property);
            if (id != null)
            {
                resolver.AddReference(id, discriminator);
            }
            return discriminator;
        }
    }
}
