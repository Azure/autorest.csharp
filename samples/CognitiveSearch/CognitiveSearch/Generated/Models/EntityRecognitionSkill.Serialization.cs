// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class EntityRecognitionSkill : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Categories))
            {
                writer.WritePropertyName("categories");
                writer.WriteStartArray();
                foreach (var item in Categories)
                {
                    writer.WriteStringValue(item.ToSerialString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(DefaultLanguageCode))
            {
                writer.WritePropertyName("defaultLanguageCode");
                writer.WriteStringValue(DefaultLanguageCode.Value.ToString());
            }
            if (Optional.IsDefined(IncludeTypelessEntities))
            {
                if (IncludeTypelessEntities != null)
                {
                    writer.WritePropertyName("includeTypelessEntities");
                    writer.WriteBooleanValue(IncludeTypelessEntities.Value);
                }
                else
                {
                    writer.WriteNull("includeTypelessEntities");
                }
            }
            if (Optional.IsDefined(MinimumPrecision))
            {
                if (MinimumPrecision != null)
                {
                    writer.WritePropertyName("minimumPrecision");
                    writer.WriteNumberValue(MinimumPrecision.Value);
                }
                else
                {
                    writer.WriteNull("minimumPrecision");
                }
            }
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(Context))
            {
                writer.WritePropertyName("context");
                writer.WriteStringValue(Context);
            }
            writer.WritePropertyName("inputs");
            writer.WriteStartArray();
            foreach (var item in Inputs)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("outputs");
            writer.WriteStartArray();
            foreach (var item in Outputs)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static EntityRecognitionSkill DeserializeEntityRecognitionSkill(JsonElement element)
        {
            Optional<IList<EntityCategory>> categories = default;
            Optional<EntityRecognitionSkillLanguage> defaultLanguageCode = default;
            Optional<bool?> includeTypelessEntities = default;
            Optional<double?> minimumPrecision = default;
            string odataType = default;
            Optional<string> name = default;
            Optional<string> description = default;
            Optional<string> context = default;
            IList<InputFieldMappingEntry> inputs = default;
            IList<OutputFieldMappingEntry> outputs = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("categories"))
                {
                    List<EntityCategory> array = new List<EntityCategory>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString().ToEntityCategory());
                    }
                    categories = array;
                    continue;
                }
                if (property.NameEquals("defaultLanguageCode"))
                {
                    defaultLanguageCode = new EntityRecognitionSkillLanguage(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("includeTypelessEntities"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        includeTypelessEntities = null;
                        continue;
                    }
                    includeTypelessEntities = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("minimumPrecision"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        minimumPrecision = null;
                        continue;
                    }
                    minimumPrecision = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("@odata.type"))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("context"))
                {
                    context = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("inputs"))
                {
                    List<InputFieldMappingEntry> array = new List<InputFieldMappingEntry>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InputFieldMappingEntry.DeserializeInputFieldMappingEntry(item));
                    }
                    inputs = array;
                    continue;
                }
                if (property.NameEquals("outputs"))
                {
                    List<OutputFieldMappingEntry> array = new List<OutputFieldMappingEntry>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(OutputFieldMappingEntry.DeserializeOutputFieldMappingEntry(item));
                    }
                    outputs = array;
                    continue;
                }
            }
            return new EntityRecognitionSkill(odataType, name.Value, description.Value, context.Value, inputs, outputs, Optional.ToList(categories), Optional.ToNullable(defaultLanguageCode), Optional.ToNullable(includeTypelessEntities), Optional.ToNullable(minimumPrecision));
        }
    }
}
