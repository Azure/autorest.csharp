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
    [JsonConverter(typeof(MgmtReferenceTypesPrivateLinkServiceConnectionStateConverter))]
    public partial class MgmtReferenceTypesPrivateLinkServiceConnectionState : IUtf8JsonSerializable, IJsonModel<MgmtReferenceTypesPrivateLinkServiceConnectionState>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MgmtReferenceTypesPrivateLinkServiceConnectionState>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<MgmtReferenceTypesPrivateLinkServiceConnectionState>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.Value.ToString());
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(ActionsRequired))
            {
                writer.WritePropertyName("actionsRequired"u8);
                writer.WriteStringValue(ActionsRequired);
            }
            writer.WriteEndObject();
        }

        MgmtReferenceTypesPrivateLinkServiceConnectionState IJsonModel<MgmtReferenceTypesPrivateLinkServiceConnectionState>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMgmtReferenceTypesPrivateLinkServiceConnectionState(document.RootElement, options);
        }

        internal static MgmtReferenceTypesPrivateLinkServiceConnectionState DeserializeMgmtReferenceTypesPrivateLinkServiceConnectionState(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<MgmtReferenceTypesPrivateEndpointServiceConnectionStatus> status = default;
            Optional<string> description = default;
            Optional<string> actionsRequired = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = new MgmtReferenceTypesPrivateEndpointServiceConnectionStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("actionsRequired"u8))
                {
                    actionsRequired = property.Value.GetString();
                    continue;
                }
            }
            return new MgmtReferenceTypesPrivateLinkServiceConnectionState(Optional.ToNullable(status), description.Value, actionsRequired.Value);
        }

        BinaryData IModel<MgmtReferenceTypesPrivateLinkServiceConnectionState>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        MgmtReferenceTypesPrivateLinkServiceConnectionState IModel<MgmtReferenceTypesPrivateLinkServiceConnectionState>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == ModelReaderWriterFormat.Json || options.Format == ModelReaderWriterFormat.Wire;
            if (!isValid)
            {
                throw new FormatException($"The model {GetType().Name} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeMgmtReferenceTypesPrivateLinkServiceConnectionState(document.RootElement, options);
        }

        ModelReaderWriterFormat IModel<MgmtReferenceTypesPrivateLinkServiceConnectionState>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;

        internal partial class MgmtReferenceTypesPrivateLinkServiceConnectionStateConverter : JsonConverter<MgmtReferenceTypesPrivateLinkServiceConnectionState>
        {
            public override void Write(Utf8JsonWriter writer, MgmtReferenceTypesPrivateLinkServiceConnectionState model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override MgmtReferenceTypesPrivateLinkServiceConnectionState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeMgmtReferenceTypesPrivateLinkServiceConnectionState(document.RootElement);
            }
        }
    }
}
