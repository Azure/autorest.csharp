// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Utilities;

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
            IReadOnlyList<InputServiceMethod>? methods = null;
            IReadOnlyList<InputParameter>? parameters = null;
            InputClient? parent = null;
            IReadOnlyList<InputDecoratorInfo>? decorators = null;

            InputClient? inputClient = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString("name", ref name)
                    || reader.TryReadString("summary", ref summary)
                    || reader.TryReadString("doc", ref doc)
                    || reader.TryReadComplexType("methods", options, ref methods)
                    || reader.TryReadComplexType("parameters", options, ref parameters)
                    || reader.TryReadComplexType("parent", options, ref parent)
                    || reader.TryReadComplexType("decorators", options, ref decorators);

                if (isKnownProperty)
                {
                    continue;
                }

                if (reader.GetString() == "children")
                {
                    var children = new List<InputClient>();
                    inputClient ??= CreateClientInstance(id, name, summary, doc, methods, parameters, parent, decorators, children, resolver);
                    reader.Read();
                    CreateChildren(ref reader, children, options, inputClient.Name);
                    continue;
                }

                reader.SkipProperty();
            }

            return inputClient ??= CreateClientInstance(id, name, summary, doc, methods, parameters, parent, decorators, [], resolver);
        }

        private static InputClient CreateClientInstance(string? id, string? name, string? summary, string? doc, IReadOnlyList<InputServiceMethod>? methods, IReadOnlyList<InputParameter>? parameters, InputClient? parent, IReadOnlyList<InputDecoratorInfo>? decorators,  IReadOnlyList<InputClient> children, ReferenceResolver resolver)
        {
            name = name ?? throw new JsonException("InputClient must have name");

            // here we need to prepend all the name of its parents in front of this name
            // previously this is done in the emitter, now the emitter no longer does it therefore we have to do it here.
            // we should not be doing it here, but doing it correctly requires so much changes in our generator.
            name = BuildClientName(name, parent);

            methods = methods ?? Array.Empty<InputServiceMethod>();
            parameters = parameters ?? Array.Empty<InputParameter>();
            var operations = AggregateOperationsFromMethods(methods);
            var inputClient = new InputClient(name, summary, doc, operations, parameters, parent, children);

            if (id != null)
            {
                resolver.AddReference(id, inputClient);
            }
            inputClient.Decorators = decorators ?? Array.Empty<InputDecoratorInfo>();
            return inputClient;

            static string BuildClientName(string name, InputClient? parent)
            {
                name = name.ToCleanName();
                if (parent == null || parent.Parent == null)
                {
                    // toplevel client, and first level sub-client will keep its original name.
                    return name;
                }

                // more deeper level client will prepend all their parents' name (except for the root) as the prefix of the client name to avoid client name conflict
                // such as we have client A.B.C and A.D.C, now the two subclient C will be named to BC and DC.
                return $"{parent.Name}{name}";
            }
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

        private static List<InputOperation> AggregateOperationsFromMethods(IReadOnlyList<InputServiceMethod> methods)
        {
            var operations = new List<InputOperation>();
            foreach (var method in methods)
            {
                operations.Add(method.Operation);
            }
            return operations;
        }
    }
}
