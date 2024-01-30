// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    public partial class UrlRedirectActionParameters : IUtf8JsonSerializable, IJsonModel<UrlRedirectActionParameters>, IPersistableModel<UrlRedirectActionParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<UrlRedirectActionParameters>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<UrlRedirectActionParameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UrlRedirectActionParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(UrlRedirectActionParameters)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("redirectType"u8);
            writer.WriteStringValue(RedirectType.ToString());
            if (Optional.IsDefined(DestinationProtocol))
            {
                writer.WritePropertyName("destinationProtocol"u8);
                writer.WriteStringValue(DestinationProtocol.Value.ToString());
            }
            if (Optional.IsDefined(CustomPath))
            {
                writer.WritePropertyName("customPath"u8);
                writer.WriteStringValue(CustomPath);
            }
            if (Optional.IsDefined(CustomHostname))
            {
                writer.WritePropertyName("customHostname"u8);
                writer.WriteStringValue(CustomHostname);
            }
            if (Optional.IsDefined(CustomQueryString))
            {
                writer.WritePropertyName("customQueryString"u8);
                writer.WriteStringValue(CustomQueryString);
            }
            if (Optional.IsDefined(CustomFragment))
            {
                writer.WritePropertyName("customFragment"u8);
                writer.WriteStringValue(CustomFragment);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        UrlRedirectActionParameters IJsonModel<UrlRedirectActionParameters>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UrlRedirectActionParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(UrlRedirectActionParameters)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeUrlRedirectActionParameters(document.RootElement, options);
        }

        internal static UrlRedirectActionParameters DeserializeUrlRedirectActionParameters(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            UrlRedirectActionParametersTypeName typeName = default;
            RedirectType redirectType = default;
            Optional<DestinationProtocol> destinationProtocol = default;
            Optional<string> customPath = default;
            Optional<string> customHostname = default;
            Optional<string> customQueryString = default;
            Optional<string> customFragment = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new UrlRedirectActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("redirectType"u8))
                {
                    redirectType = new RedirectType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("destinationProtocol"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    destinationProtocol = new DestinationProtocol(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("customPath"u8))
                {
                    customPath = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customHostname"u8))
                {
                    customHostname = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customQueryString"u8))
                {
                    customQueryString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("customFragment"u8))
                {
                    customFragment = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new UrlRedirectActionParameters(typeName, redirectType, Optional.ToNullable(destinationProtocol), customPath.Value, customHostname.Value, customQueryString.Value, customFragment.Value, serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{");

            builder.Append("  typeName:");
            builder.AppendLine($" '{TypeName.ToString()}'");

            builder.Append("  redirectType:");
            builder.AppendLine($" '{RedirectType.ToString()}'");

            if (Optional.IsDefined(DestinationProtocol))
            {
                builder.Append("  destinationProtocol:");
                builder.AppendLine($" '{DestinationProtocol.ToString()}'");
            }

            if (Optional.IsDefined(CustomPath))
            {
                builder.Append("  customPath:");
                builder.AppendLine($" '{CustomPath.ToString()}'");
            }

            if (Optional.IsDefined(CustomHostname))
            {
                builder.Append("  customHostname:");
                builder.AppendLine($" '{CustomHostname.ToString()}'");
            }

            if (Optional.IsDefined(CustomQueryString))
            {
                builder.Append("  customQueryString:");
                builder.AppendLine($" '{CustomQueryString.ToString()}'");
            }

            if (Optional.IsDefined(CustomFragment))
            {
                builder.Append("  customFragment:");
                builder.AppendLine($" '{CustomFragment.ToString()}'");
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        private void AppendChildObject(StringBuilder stringBuilder, object childObject, ModelReaderWriterOptions options, int spaces)
        {
            string indent = new string(' ', spaces);
            BinaryData data = ModelReaderWriter.Write(childObject, options);
            string[] lines = data.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                stringBuilder.AppendLine($"{indent}{line}");
            }
        }

        BinaryData IPersistableModel<UrlRedirectActionParameters>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UrlRedirectActionParameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "B":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(UrlRedirectActionParameters)} does not support '{options.Format}' format.");
            }
        }

        UrlRedirectActionParameters IPersistableModel<UrlRedirectActionParameters>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<UrlRedirectActionParameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeUrlRedirectActionParameters(document.RootElement, options);
                    }
                case "B":
                    throw new InvalidOperationException("Bicep deserialization is not supported for this type.");
                default:
                    throw new FormatException($"The model {nameof(UrlRedirectActionParameters)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<UrlRedirectActionParameters>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
