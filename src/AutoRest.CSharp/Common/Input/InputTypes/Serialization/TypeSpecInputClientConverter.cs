// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Input;

namespace AutoRest.CSharp.Common.Input
{
    internal sealed class TypeSpecInputClientConverter : JsonConverter<InputClient>
    {
        private readonly TypeSpecReferenceHandler _referenceHandler;

        public TypeSpecInputClientConverter(TypeSpecReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputClient? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputClient>(_referenceHandler.CurrentResolver) ?? CreateInputClient(ref reader, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputClient value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private static InputClient? CreateInputClient(ref Utf8JsonReader reader, string? id, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            string? name = null;
            string? description = null;
            IReadOnlyList<InputOperation>? operations = null;
            IReadOnlyList<InputParameter>? parameters = null;
            string? parent = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(InputClient.Name), ref name)
                    || reader.TryReadString(nameof(InputClient.Description), ref description)
                    || reader.TryReadWithConverter(nameof(InputClient.Operations), options, ref operations)
                    || reader.TryReadWithConverter(nameof(InputClient.Parameters), options, ref parameters)
                    || reader.TryReadString(nameof(InputClient.Parent), ref parent);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name= name ?? throw new JsonException("InputClient must have name");
            description = description ?? string.Empty;
            operations = operations ?? Array.Empty<InputOperation>();
            parameters = parameters ?? Array.Empty<InputParameter>();
            var inputClient = new InputClient(name, description, operations, parameters, parent);
            if (id != null)
            {
                resolver.AddReference(id, inputClient);
            }

            return inputClient;
        }
    }
}
