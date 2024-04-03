// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using MgmtReferenceTypes;

namespace Azure.ResourceManager.Fake.Models
{
    [JsonConverter(typeof(PrivateEndpointConnectionListConverter))]
    public partial class PrivateEndpointConnectionList : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static PrivateEndpointConnectionList DeserializePrivateEndpointConnectionList(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<PrivateEndpointConnectionData> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PrivateEndpointConnectionData> array = new List<PrivateEndpointConnectionData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PrivateEndpointConnectionData.DeserializePrivateEndpointConnectionData(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new PrivateEndpointConnectionList(value ?? new ChangeTrackingList<PrivateEndpointConnectionData>());
        }

        internal partial class PrivateEndpointConnectionListConverter : JsonConverter<PrivateEndpointConnectionList>
        {
            public override void Write(Utf8JsonWriter writer, PrivateEndpointConnectionList model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue<PrivateEndpointConnectionList>(model);
            }

            public override PrivateEndpointConnectionList Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializePrivateEndpointConnectionList(document.RootElement);
            }
        }
    }
}
