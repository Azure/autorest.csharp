// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            string? summary = null;
            string? doc = null;
            IReadOnlyList<InputOperation>? operations = null;
            IReadOnlyList<InputParameter>? parameters = null;
            string? parent = null;
            IReadOnlyList<InputDecoratorInfo>? decorators = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("summary", ref summary)
                    || reader.TryReadString("doc", ref doc)
                    || reader.TryReadComplexType("operations", options, ref operations)
                    || reader.TryReadComplexType("parameters", options, ref parameters)
                    || reader.TryReadString("parent", ref parent)
                    || reader.TryReadComplexType("decorators", options, ref decorators);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            name= name ?? throw new JsonException("InputClient must have name");
            operations = operations ?? [];
            parameters = parameters ?? [];
            var inputClient = new InputClient(name, summary, doc, operations, parameters, parent);
            if (id != null)
            {
                resolver.AddReference(id, inputClient);
            }
            inputClient.Decorators = decorators ?? Array.Empty<InputDecoratorInfo>();
            return inputClient;
        }
    }
}
