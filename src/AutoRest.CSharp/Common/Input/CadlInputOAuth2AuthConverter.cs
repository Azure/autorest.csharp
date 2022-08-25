// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal class CadlInputOAuth2AuthConverter: JsonConverter<InputOAuth2Auth>
    {
        private readonly CadlReferenceHandler _referenceHandler;

        public CadlInputOAuth2AuthConverter(CadlReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputOAuth2Auth Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputOAuth2Auth>(_referenceHandler.CurrentResolver) ?? CreateInputOAuth2Auth(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputOAuth2Auth value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static InputOAuth2Auth CreateInputOAuth2Auth(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            IReadOnlyList<string>? scopes = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadWithConverter(nameof(InputOAuth2Auth.Scopes), options, ref scopes);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            if (scopes == null || scopes.Count == 0)
            {
                throw new JsonException("OAuth2 authentication must have at least one scope");
            }

            var oAuth2 = new InputOAuth2Auth(scopes);
            if (id != null)
            {
                resolver.AddReference(id, oAuth2);
            }
            return oAuth2;
        }
    }
}
