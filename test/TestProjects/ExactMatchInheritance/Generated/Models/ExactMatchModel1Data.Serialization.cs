// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using ExactMatchInheritance.Models;

namespace ExactMatchInheritance
{
    public partial class ExactMatchModel1Data : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(New))
            {
                writer.WritePropertyName("new");
                writer.WriteStringValue(New);
            }
            if (Optional.IsCollectionDefined(SupportingUris))
            {
                writer.WritePropertyName("supportingUris");
                writer.WriteStartArray();
                foreach (var item in SupportingUris)
                {
                    writer.WriteStringValue(item.AbsoluteUri);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Type1))
            {
                writer.WritePropertyName("type1");
                writer.WriteStringValue(Type1.Value.ToSerialString());
            }
            if (Optional.IsDefined(Type2))
            {
                writer.WritePropertyName("type2");
                writer.WriteStringValue(Type2.Value.ToSerialString());
            }
            writer.WriteEndObject();
        }

        internal static ExactMatchModel1Data DeserializeExactMatchModel1Data(JsonElement element)
        {
            Optional<string> @new = default;
            Optional<IList<Uri>> supportingUris = default;
            Optional<Type1> type1 = default;
            Optional<Type2> type2 = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            SystemData systemData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("new"))
                {
                    @new = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("supportingUris"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<Uri> array = new List<Uri>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new Uri(item.GetString()));
                    }
                    supportingUris = array;
                    continue;
                }
                if (property.NameEquals("type1"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    type1 = property.Value.GetString().ToType1();
                    continue;
                }
                if (property.NameEquals("type2"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    type2 = property.Value.GetString().ToType2();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.ToString());
                    continue;
                }
            }
            return new ExactMatchModel1Data(id, name, type, systemData, @new.Value, Optional.ToList(supportingUris), Optional.ToNullable(type1), Optional.ToNullable(type2));
        }
    }
}
