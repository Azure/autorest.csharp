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
            InputClient? parent = null;

            InputClient? inputClient = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("summary", ref summary)
                    || reader.TryReadString("doc", ref doc)
                    || reader.TryReadComplexType("operations", options, ref operations)
                    || reader.TryReadComplexType("parameters", options, ref parameters)
                    || reader.TryReadComplexType("parent", options, ref parent);

                if (isKnownProperty)
                {
                    continue;
                }

                if (reader.GetString() == "children")
                {
                    var children = new List<InputClient>();
                    inputClient ??= CreateClientInstance(id, name, summary, doc, operations, parameters, parent, children, resolver);
                    reader.Read();
                    CreateChildren(ref reader, children, options, inputClient.Name);
                    continue;
                }

                reader.SkipProperty();
            }

<<<<<<< HEAD
            return inputClient ??= CreateClientInstance(id, name, summary, doc, operations, parameters, parent, [], resolver);
        }

        private static InputClient CreateClientInstance(string? id, string? name, string? summary, string? doc, IReadOnlyList<InputOperation>? operations, IReadOnlyList<InputParameter>? parameters, InputClient? parent, IReadOnlyList<InputClient> children, ReferenceResolver resolver)
        {
            name = name ?? throw new JsonException("InputClient must have name");
            operations = operations ?? Array.Empty<InputOperation>();
            parameters = parameters ?? Array.Empty<InputParameter>();
            var inputClient = new InputClient(name, summary, doc, operations, parameters, parent, children);

=======
            name= name ?? throw new JsonException("InputClient must have name");
            operations = operations ?? [];
            parameters = parameters ?? [];
            var inputClient = new InputClient(name, summary, doc, operations, parameters, parent);
>>>>>>> origin/main
            if (id != null)
            {
                resolver.AddReference(id, inputClient);
            }

            return inputClient;
        }

        private static void CreateChildren(ref Utf8JsonReader reader, IList<InputClient> children, JsonSerializerOptions options, string clientName)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException($"Invalid JSON format. 'children' property of '{clientName}' should be an array.");
            }
            reader.Read();

            while (reader.TokenType != JsonTokenType.EndArray)
            {
                var child = reader.ReadWithConverter<InputClient>(options);
                if (child == null)
                {
                    throw new JsonException($"child of InputClient '{clientName}' cannot be null.");
                }

                children.Add(child);
            }
            reader.Read();
        }
    }
}
