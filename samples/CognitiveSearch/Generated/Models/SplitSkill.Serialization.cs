// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class SplitSkill : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(DefaultLanguageCode))
            {
                writer.WritePropertyName("defaultLanguageCode"u8);
                writer.WriteStringValue(DefaultLanguageCode.Value.ToString());
            }
            if (Optional.IsDefined(TextSplitMode))
            {
                writer.WritePropertyName("textSplitMode"u8);
                writer.WriteStringValue(TextSplitMode.Value.ToSerialString());
            }
            if (Optional.IsDefined(MaximumPageLength))
            {
                if (MaximumPageLength != null)
                {
                    writer.WritePropertyName("maximumPageLength"u8);
                    writer.WriteNumberValue(MaximumPageLength.Value);
                }
                else
                {
                    writer.WriteNull("maximumPageLength");
                }
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            if (Optional.IsDefined(Context))
            {
                writer.WritePropertyName("context"u8);
                writer.WriteStringValue(Context);
            }
            writer.WritePropertyName("inputs"u8);
            writer.WriteStartArray();
            foreach (var item in Inputs)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("outputs"u8);
            writer.WriteStartArray();
            foreach (var item in Outputs)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static SplitSkill DeserializeSplitSkill(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            SplitSkillLanguage? defaultLanguageCode = default;
            TextSplitMode? textSplitMode = default;
            int? maximumPageLength = default;
            string odataType = default;
            string name = default;
            string description = default;
            string context = default;
            IList<InputFieldMappingEntry> inputs = default;
            IList<OutputFieldMappingEntry> outputs = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("defaultLanguageCode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    defaultLanguageCode = new SplitSkillLanguage(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("textSplitMode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    textSplitMode = property.Value.GetString().ToTextSplitMode();
                    continue;
                }
                if (property.NameEquals("maximumPageLength"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maximumPageLength = null;
                        continue;
                    }
                    maximumPageLength = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("context"u8))
                {
                    context = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("inputs"u8))
                {
                    List<InputFieldMappingEntry> array = new List<InputFieldMappingEntry>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InputFieldMappingEntry.DeserializeInputFieldMappingEntry(item));
                    }
                    inputs = array;
                    continue;
                }
                if (property.NameEquals("outputs"u8))
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
            return new SplitSkill(
                odataType,
                name,
                description,
                context,
                inputs,
                outputs,
                defaultLanguageCode,
                textSplitMode,
                maximumPageLength);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new SplitSkill FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeSplitSkill(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal override RequestContent ToRequestContent()
        {
            BinaryData binaryData = ModelReaderWriter.Write(this, new ModelReaderWriterOptions("W"));
            return RequestContent.Create(binaryData);
        }
    }
}
