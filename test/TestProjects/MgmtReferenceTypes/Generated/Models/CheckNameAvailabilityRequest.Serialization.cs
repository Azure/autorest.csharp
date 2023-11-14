// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(CheckNameAvailabilityRequestConverter))]
    public partial class CheckNameAvailabilityRequest : IUtf8JsonSerializable, IJsonModel<CheckNameAvailabilityRequest>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<CheckNameAvailabilityRequest>)this).Write(writer, ModelReaderWriterOptions.Wire);

        void IJsonModel<CheckNameAvailabilityRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<CheckNameAvailabilityRequest>)this).GetWireFormat(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<CheckNameAvailabilityRequest>)} interface");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(ResourceType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ResourceType);
            }
            writer.WriteEndObject();
        }

        CheckNameAvailabilityRequest IJsonModel<CheckNameAvailabilityRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CheckNameAvailabilityRequest)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCheckNameAvailabilityRequest(document.RootElement, options);
        }

        internal static CheckNameAvailabilityRequest DeserializeCheckNameAvailabilityRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.Wire;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> name = default;
            Optional<ResourceType> type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
            }
            return new CheckNameAvailabilityRequest(name.Value, type);
        }

        BinaryData IPersistableModel<CheckNameAvailabilityRequest>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CheckNameAvailabilityRequest)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        CheckNameAvailabilityRequest IPersistableModel<CheckNameAvailabilityRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CheckNameAvailabilityRequest)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeCheckNameAvailabilityRequest(document.RootElement, options);
        }

        string IPersistableModel<CheckNameAvailabilityRequest>.GetWireFormat(ModelReaderWriterOptions options) => "J";

        internal partial class CheckNameAvailabilityRequestConverter : JsonConverter<CheckNameAvailabilityRequest>
        {
            public override void Write(Utf8JsonWriter writer, CheckNameAvailabilityRequest model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override CheckNameAvailabilityRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeCheckNameAvailabilityRequest(document.RootElement);
            }
        }
    }
}
