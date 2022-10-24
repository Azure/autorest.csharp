// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelsInCadl
{
    public partial class RoundTripModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("requiredString");
            writer.WriteStringValue(RequiredString);
            writer.WritePropertyName("requiredInt");
            writer.WriteNumberValue(RequiredInt);
            writer.WritePropertyName("requiredModel");
            writer.WriteObjectValue(RequiredModel);
            writer.WritePropertyName("requiredFixedStringEnum");
            writer.WriteStringValue(RequiredFixedStringEnum.ToSerialString());
            writer.WritePropertyName("requiredExtensibleEnum");
            writer.WriteStringValue(RequiredExtensibleEnum.ToString());
            writer.WritePropertyName("requiredCollection");
            writer.WriteStartArray();
            foreach (var item in RequiredCollection)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("requiredIntRecord");
            writer.WriteStartObject();
            foreach (var item in RequiredIntRecord)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteNumberValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WritePropertyName("requiredStringRecord");
            writer.WriteStartObject();
            foreach (var item in RequiredStringRecord)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WritePropertyName("requiredModelRecord");
            writer.WriteStartObject();
            foreach (var item in RequiredModelRecord)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static RoundTripModel DeserializeRoundTripModel(JsonElement element)
        {
            string requiredString = default;
            int requiredInt = default;
            BaseModelWithDiscriminator requiredModel = default;
            FixedStringEnum requiredFixedStringEnum = default;
            ExtensibleEnum requiredExtensibleEnum = default;
            IList<CollectionItem> requiredCollection = default;
            IDictionary<string, int> requiredIntRecord = default;
            IDictionary<string, string> requiredStringRecord = default;
            IDictionary<string, RecordItem> requiredModelRecord = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredString"))
                {
                    requiredString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredInt"))
                {
                    requiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("requiredModel"))
                {
                    requiredModel = BaseModelWithDiscriminator.DeserializeBaseModelWithDiscriminator(property.Value);
                    continue;
                }
                if (property.NameEquals("requiredFixedStringEnum"))
                {
                    requiredFixedStringEnum = property.Value.GetString().ToFixedStringEnum();
                    continue;
                }
                if (property.NameEquals("requiredExtensibleEnum"))
                {
                    requiredExtensibleEnum = new ExtensibleEnum(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("requiredCollection"))
                {
                    List<CollectionItem> array = new List<CollectionItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(CollectionItem.DeserializeCollectionItem(item));
                    }
                    requiredCollection = array;
                    continue;
                }
                if (property.NameEquals("requiredIntRecord"))
                {
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetInt32());
                    }
                    requiredIntRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("requiredStringRecord"))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    requiredStringRecord = dictionary;
                    continue;
                }
                if (property.NameEquals("requiredModelRecord"))
                {
                    Dictionary<string, RecordItem> dictionary = new Dictionary<string, RecordItem>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, RecordItem.DeserializeRecordItem(property0.Value));
                    }
                    requiredModelRecord = dictionary;
                    continue;
                }
            }
            return new RoundTripModel(requiredString, requiredInt, requiredModel, requiredFixedStringEnum, requiredExtensibleEnum, requiredCollection, requiredIntRecord, requiredStringRecord, requiredModelRecord);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal new static RoundTripModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRoundTripModel(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
