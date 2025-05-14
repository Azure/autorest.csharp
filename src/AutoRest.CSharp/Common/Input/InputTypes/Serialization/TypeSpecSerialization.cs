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
        public static string Serialize(InputNamespace inputNamespace)
        {
            var options = CreateOptions();
            options.WriteIndented = true;
            return JsonSerializer.Serialize(inputNamespace, options);
        }

        public static InputNamespace? Deserialize(string json)
        {
            var options = CreateOptions();
            return JsonSerializer.Deserialize<InputNamespace>(json, options);
        }

        private static JsonSerializerOptions CreateOptions()
        {
            var referenceHandler = new TypeSpecReferenceHandler();
            return new JsonSerializerOptions
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
                    new TypeSpecInputConstantConverter(referenceHandler),
                    new TypeSpecInputLiteralTypeConverter(referenceHandler),
                    new TypeSpecInputUnionTypeConverter(referenceHandler),
                    new TypeSpecInputParameterConverter(referenceHandler),
                    new TypeSpecInputOperationConverter(referenceHandler),
                    new TypeSpecInputClientConverter(referenceHandler),
                    new TypeSpecInputDateTimeTypeConverter(referenceHandler),
                    new TypeSpecInputDurationTypeConverter(referenceHandler),
                    new TypeSpecInputPrimitiveTypeConverter(referenceHandler),
                    new TypeSpecInputDecoratorInfoConverter(referenceHandler),
                    new TypeSpecInputExampleValueConverter(referenceHandler),
                    new TypeSpecInputOperationExampleConverter(referenceHandler),
                    new TypeSpecInputParameterExampleConverter(referenceHandler),
                    new TypeSpecInputAuthConverter(referenceHandler),
                    new TypeSpecInputApiKeyAuthConverter(referenceHandler),
                    new TypeSpecInputOAuth2AuthConverter(referenceHandler),
                    new TypeSpecInputOperationResponseConverter(referenceHandler),
                    new TypeSpecInputOperationResponseHeaderConverter(referenceHandler),
                    new TypeSpecInputOperationLongRunningConverter(referenceHandler),
                    new TypeSpecInputOperationPagingConverter(referenceHandler),
                    new TypeSpecInputNextLinkConverter(referenceHandler),
                    new TypeSpecInputContinuationTokenConverter(referenceHandler),
                    new TypeSpecInputServiceMethodConverter(referenceHandler),
                    new TypeSpecInputServiceMethodResponseConverter(referenceHandler),
                    new TypeSpecInputBasicServiceMethodConverter(referenceHandler),
                    new TypeSpecInputPagingServiceMethodConverter(referenceHandler),
                    new TypeSpecInputPagingServiceMetadataConverter(referenceHandler),
                    new TypeSpecInputLongRunningServiceMethodConverter(referenceHandler),
                    new TypeSpecInputLongRunningServiceMetadataConverter(referenceHandler),
                    new TypeSpecInputLongRunningPagingServiceMethodConverter(referenceHandler),
                }
            };
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
