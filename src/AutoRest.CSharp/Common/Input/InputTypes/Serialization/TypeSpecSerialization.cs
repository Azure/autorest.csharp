// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Input.Examples;
using Azure.Core;

namespace AutoRest.CSharp.Common.Input
{
    internal static class TypeSpecSerialization
    {
        public static InputNamespace? Deserialize(string json)
        {
            var referenceHandler = new TypeSpecReferenceHandler();
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = referenceHandler,
                AllowTrailingCommas = true,
                Converters =
                {
                    new TypeSpecInputNamespaceConverter(referenceHandler),
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                    new RequestMethodConverter(),
                    new TypeSpecInputTypeConverter(referenceHandler),
                    new TypeSpecInputListTypeConverter(referenceHandler),
                    new TypeSpecInputDictionaryTypeConverter(referenceHandler),
                    new TypeSpecInputEnumTypeConverter(referenceHandler),
                    new TypeSpecInputEnumTypeValueConverter(referenceHandler),
                    new TypeSpecInputModelTypeConverter(referenceHandler),
                    new TypeSpecInputModelPropertyConverter(referenceHandler),
                    new TypeSpecInputConstantConverter(),
                    new TypeSpecInputLiteralTypeConverter(referenceHandler),
                    new TypeSpecInputUnionTypeConverter(referenceHandler),
                    new TypeSpecInputParameterConverter(referenceHandler),
                    new TypeSpecInputOperationConverter(referenceHandler),
                    new TypeSpecInputClientConverter(referenceHandler),
                    new TypeSpecInputDateTimeTypeConverter(referenceHandler),
                    new TypeSpecInputDurationTypeConverter(referenceHandler),
                    new TypeSpecInputPrimitiveTypeConverter(referenceHandler),
                    new TypeSpecInputDecoratorInfoConverter(),
                    new TypeSpecInputExampleValueConverter(),
                    new TypeSpecInputOperationExampleConverter(),
                    new TypeSpecInputParameterExampleConverter(),
                    new TypeSpecInputAuthConverter(),
                    new TypeSpecInputApiKeyAuthConverter(),
                    new TypeSpecInputOAuth2AuthConverter(),
                    new TypeSpecInputOperationResponseConverter(),
                    new TypeSpecInputOperationResponseHeaderConverter(referenceHandler),
                    new TypeSpecInputOperationLongRunningConverter(),
                    new TypeSpecInputOperationPagingConverter(),
                    new TypeSpecInputNextLinkConverter(),
                    new TypeSpecInputContinuationTokenConverter(),
                    new TypeSpecInputServiceMethodConverter(referenceHandler),
                    new TypeSpecInputServiceMethodResponseConverter(),
                    new TypeSpecInputBasicServiceMethodConverter(referenceHandler),
                    new TypeSpecInputPagingServiceMethodConverter(referenceHandler),
                    new TypeSpecInputPagingServiceMetadataConverter(),
                    new TypeSpecInputLongRunningServiceMethodConverter(referenceHandler),
                    new TypeSpecInputLongRunningServiceMetadataConverter(),
                    new TypeSpecInputLongRunningPagingServiceMethodConverter(referenceHandler),
                }
            };

            return JsonSerializer.Deserialize<InputNamespace>(json, options);
        }

        private class RequestMethodConverter : JsonConverter<RequestMethod>
        {
            public override RequestMethod Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.String)
                {
                    throw new JsonException();
                }

                var stringValue = reader.GetString();
                return stringValue != null ? RequestMethod.Parse(stringValue) : RequestMethod.Get;
            }

            public override void Write(Utf8JsonWriter writer, RequestMethod value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.Method.AsSpan());
            }
        }
    }
}
