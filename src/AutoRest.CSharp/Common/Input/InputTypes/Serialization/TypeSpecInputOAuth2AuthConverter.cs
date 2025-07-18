// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal class TypeSpecInputOAuth2AuthConverter : JsonConverter<InputOAuth2Auth>
    {
        public override InputOAuth2Auth? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => CreateInputOAuth2Auth(ref reader, options);

        public override void Write(Utf8JsonWriter writer, InputOAuth2Auth value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        private static InputOAuth2Auth CreateInputOAuth2Auth(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                reader.Read();
            }
            IReadOnlyList<InputOAuth2Flow>? flows = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadComplexType("flows", options, ref flows);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            var result = new InputOAuth2Auth(AggregateScopesFromFlows(flows));
            return result;
        }

        private static IReadOnlyList<string> AggregateScopesFromFlows(IReadOnlyList<InputOAuth2Flow>? flows)
        {
            if (flows == null)
            {
                return [];
            }

            var scopes = new HashSet<string>();
            foreach (var flow in flows)
            {
                if (flow.Scopes != null)
                {
                    foreach (var scope in flow.Scopes)
                    {
                        scopes.Add(scope);
                    }
                }
            }

            return [.. scopes];
        }
    }
}
