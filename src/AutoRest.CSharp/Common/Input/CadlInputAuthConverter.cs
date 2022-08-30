// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input
{
    internal class CadlInputAuthConverter: JsonConverter<InputAuth>
    {
        private readonly CadlReferenceHandler _referenceHandler;

        public CadlInputAuthConverter(CadlReferenceHandler referenceHandler)
        {
            _referenceHandler = referenceHandler;
        }

        public override InputAuth Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.ReadReferenceAndResolve<InputAuth>(_referenceHandler.CurrentResolver) ?? CreateInputAuth(ref reader, null, null, options, _referenceHandler.CurrentResolver);

        public override void Write(Utf8JsonWriter writer, InputAuth value, JsonSerializerOptions options)
            => throw new NotSupportedException("Writing not supported");

        public static InputAuth CreateInputAuth(ref Utf8JsonReader reader, string? id, string? name, JsonSerializerOptions options, ReferenceResolver resolver)
        {
            var isFirstProperty = id == null;
            string? apiKey = null;
            InputOAuth2Auth? oAuth = null;

            while (reader.TokenType != JsonTokenType.EndObject)
            {
                var isKnownProperty = reader.TryReadReferenceId(ref isFirstProperty, ref id)
                    || reader.TryReadString(nameof(InputAuth.ApiKey), ref apiKey)
                    || reader.TryReadWithConverter(nameof(InputAuth.OAuth2), options, ref oAuth);

                if (!isKnownProperty)
                {
                    reader.SkipProperty();
                }
            }

            InputApiKeyAuth? apiKeyAuth = null;
            if (apiKey != null && !apiKey.IsNullOrEmpty())
            {
                apiKeyAuth = new InputApiKeyAuth(apiKey);
            }

            var auth = new InputAuth(apiKeyAuth, oAuth);
            if (id != null)
            {
                resolver.AddReference(id, auth);
            }
            return auth;
        }
    }
}
