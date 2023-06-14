// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.ResourceManager.Models;
using MgmtExactMatchInheritance.Models;

namespace MgmtExactMatchInheritance
{
    public partial class ExactMatchModel1Data : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(New))
            {
                writer.WritePropertyName("new"u8);
                writer.WriteStringValue(New);
            }
            if (Optional.IsCollectionDefined(SupportingUris))
            {
                writer.WritePropertyName("supportingUris"u8);
                writer.WriteStartArray();
                foreach (var item in SupportingUris)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStringValue(item.AbsoluteUri);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Type1))
            {
                writer.WritePropertyName("type1"u8);
                writer.WriteStringValue(Type1.Value.ToString());
            }
            if (Optional.IsDefined(Type2))
            {
                writer.WritePropertyName("type2"u8);
                writer.WriteStringValue(Type2.Value.ToString());
            }
            if (Optional.IsDefined(Type3))
            {
                writer.WritePropertyName("type3"u8);
                writer.WriteStringValue(Type3.ToString());
            }
            if (Optional.IsDefined(Type4))
            {
                writer.WritePropertyName("type4"u8);
                writer.WriteObjectValue(Type4);
            }
            if (Optional.IsDefined(Type5))
            {
                writer.WritePropertyName("type5"u8);
                JsonSerializer.Serialize(writer, Type5);
            }
            if (Optional.IsDefined(Type6))
            {
                writer.WritePropertyName("type6"u8);
                JsonSerializer.Serialize(writer, Type6);
            }
            if (Optional.IsDefined(Type7))
            {
                writer.WritePropertyName("type7"u8);
                JsonSerializer.Serialize(writer, Type7);
            }
            if (Optional.IsDefined(Type8))
            {
                writer.WritePropertyName("type8"u8);
                JsonSerializer.Serialize(writer, Type8);
            }
            if (Optional.IsDefined(Type9))
            {
                writer.WritePropertyName("type9"u8);
                JsonSerializer.Serialize(writer, Type9);
            }
            if (Optional.IsDefined(Type10))
            {
                writer.WritePropertyName("type10"u8);
                JsonSerializer.Serialize(writer, Type10);
            }
            if (Optional.IsDefined(Type11))
            {
                writer.WritePropertyName("type11"u8);
                JsonSerializer.Serialize(writer, Type11);
            }
            if (Optional.IsDefined(Type12))
            {
                writer.WritePropertyName("type12"u8);
                JsonSerializer.Serialize(writer, Type12);
            }
            if (Optional.IsDefined(Type13))
            {
                writer.WritePropertyName("type13"u8);
                JsonSerializer.Serialize(writer, Type13);
            }
            if (Optional.IsDefined(Type14))
            {
                writer.WritePropertyName("type14"u8);
                JsonSerializer.Serialize(writer, Type14);
            }
            if (Optional.IsDefined(Type15))
            {
                writer.WritePropertyName("type15"u8);
                JsonSerializer.Serialize(writer, Type15);
            }
            if (Optional.IsDefined(Type16))
            {
                writer.WritePropertyName("type16"u8);
                JsonSerializer.Serialize(writer, Type16);
            }
            writer.WriteEndObject();
        }

        internal static ExactMatchModel1Data DeserializeExactMatchModel1Data(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> @new = default;
            Optional<IList<Uri>> supportingUris = default;
            Optional<Type1> type1 = default;
            Optional<Type2> type2 = default;
            Optional<IPAddress> type3 = default;
            Optional<object> type4 = default;
            Optional<DataFactoryElement<string>> type5 = default;
            Optional<DataFactoryElement<double>> type6 = default;
            Optional<DataFactoryElement<bool>> type7 = default;
            Optional<DataFactoryElement<int>> type8 = default;
            Optional<DataFactoryElement<BinaryData>> type9 = default;
            Optional<DataFactoryElement<IList<SeparateClass>>> type10 = default;
            Optional<DataFactoryElement<IList<string>>> type11 = default;
            Optional<DataFactoryElement<IDictionary<string, string>>> type12 = default;
            Optional<DataFactoryElement<IList<SeparateClass>>> type13 = default;
            Optional<DataFactoryElement<DateTimeOffset>> type14 = default;
            Optional<DataFactoryElement<TimeSpan>> type15 = default;
            Optional<DataFactoryElement<Uri>> type16 = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("new"u8))
                {
                    @new = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("supportingUris"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Uri> array = new List<Uri>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(new Uri(item.GetString()));
                        }
                    }
                    supportingUris = array;
                    continue;
                }
                if (property.NameEquals("type1"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type1 = new Type1(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("type2"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type2 = new Type2(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("type3"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || property.Value.ValueKind == JsonValueKind.String && property.Value.GetString().Length == 0)
                    {
                        continue;
                    }
                    type3 = IPAddress.Parse(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("type4"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type4 = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("type5"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type5 = JsonSerializer.Deserialize<DataFactoryElement<string>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("type6"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type6 = JsonSerializer.Deserialize<DataFactoryElement<double>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("type7"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type7 = JsonSerializer.Deserialize<DataFactoryElement<bool>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("type8"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type8 = JsonSerializer.Deserialize<DataFactoryElement<int>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("type9"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type9 = JsonSerializer.Deserialize<DataFactoryElement<BinaryData>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("type10"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type10 = JsonSerializer.Deserialize<DataFactoryElement<IList<SeparateClass>>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("type11"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type11 = JsonSerializer.Deserialize<DataFactoryElement<IList<string>>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("type12"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type12 = JsonSerializer.Deserialize<DataFactoryElement<IDictionary<string, string>>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("type13"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type13 = JsonSerializer.Deserialize<DataFactoryElement<IList<SeparateClass>>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("type14"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type14 = JsonSerializer.Deserialize<DataFactoryElement<DateTimeOffset>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("type15"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type15 = JsonSerializer.Deserialize<DataFactoryElement<TimeSpan>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("type16"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type16 = JsonSerializer.Deserialize<DataFactoryElement<Uri>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
            }
            return new ExactMatchModel1Data(id, name, type, systemData.Value, @new.Value, Optional.ToList(supportingUris), Optional.ToNullable(type1), Optional.ToNullable(type2), type3.Value, type4.Value, type5.Value, type6.Value, type7.Value, type8.Value, type9.Value, type10.Value, type11.Value, type12.Value, type13.Value, type14.Value, type15.Value, type16.Value);
        }
    }
}
