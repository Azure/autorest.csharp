// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(PrivateLinkResourceListConverter))]
    public partial class PrivateLinkResourceList : IUtf8JsonSerializable, IJsonModel<PrivateLinkResourceList>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PrivateLinkResourceList>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<PrivateLinkResourceList>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<PrivateLinkResourceList>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<PrivateLinkResourceList>)} interface");
            }

            writer.WriteStartObject();
            if (options.Format == "J")
            {
                if (Optional.IsCollectionDefined(Value))
                {
                    writer.WritePropertyName("value"u8);
                    writer.WriteStartArray();
                    foreach (var item in Value)
                    {
                        writer.WriteObjectValue(item);
                    }
                    writer.WriteEndArray();
                }
            }
            writer.WriteEndObject();
        }

        PrivateLinkResourceList IJsonModel<PrivateLinkResourceList>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(PrivateLinkResourceList)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePrivateLinkResourceList(document.RootElement, options);
        }

        internal static PrivateLinkResourceList DeserializePrivateLinkResourceList(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<PrivateLinkResourceData>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PrivateLinkResourceData> array = new List<PrivateLinkResourceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PrivateLinkResourceData.DeserializePrivateLinkResourceData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new PrivateLinkResourceList(Optional.ToList(value));
        }

        BinaryData IPersistableModel<PrivateLinkResourceList>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(PrivateLinkResourceList)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        PrivateLinkResourceList IPersistableModel<PrivateLinkResourceList>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(PrivateLinkResourceList)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializePrivateLinkResourceList(document.RootElement, options);
        }

        string IPersistableModel<PrivateLinkResourceList>.GetWireFormat(ModelReaderWriterOptions options) => "J";

        internal partial class PrivateLinkResourceListConverter : JsonConverter<PrivateLinkResourceList>
        {
            public override void Write(Utf8JsonWriter writer, PrivateLinkResourceList model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override PrivateLinkResourceList Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializePrivateLinkResourceList(document.RootElement);
            }
        }
    }
}
