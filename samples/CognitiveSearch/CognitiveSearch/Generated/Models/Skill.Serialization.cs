// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class Skill : Azure.Core.IUtf8JsonSerializable
    {
        void Azure.Core.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            if (Name != null)
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Description != null)
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            if (Context != null)
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
            foreach (var item0 in Outputs)
            {
                writer.WriteObjectValue(item0);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        internal static CognitiveSearch.Models.Skill DeserializeSkill(System.Text.Json.JsonElement element)
        {
            if (element.TryGetProperty("@odata.type", out System.Text.Json.JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Skills.Custom.WebApiSkill": return CognitiveSearch.Models.WebApiSkill.DeserializeWebApiSkill(element);
                    case "#Microsoft.Skills.Text.EntityRecognitionSkill": return CognitiveSearch.Models.EntityRecognitionSkill.DeserializeEntityRecognitionSkill(element);
                    case "#Microsoft.Skills.Text.KeyPhraseExtractionSkill": return CognitiveSearch.Models.KeyPhraseExtractionSkill.DeserializeKeyPhraseExtractionSkill(element);
                    case "#Microsoft.Skills.Text.LanguageDetectionSkill": return CognitiveSearch.Models.LanguageDetectionSkill.DeserializeLanguageDetectionSkill(element);
                    case "#Microsoft.Skills.Text.MergeSkill": return CognitiveSearch.Models.MergeSkill.DeserializeMergeSkill(element);
                    case "#Microsoft.Skills.Text.SentimentSkill": return CognitiveSearch.Models.SentimentSkill.DeserializeSentimentSkill(element);
                    case "#Microsoft.Skills.Text.SplitSkill": return CognitiveSearch.Models.SplitSkill.DeserializeSplitSkill(element);
                    case "#Microsoft.Skills.Text.TranslationSkill": return CognitiveSearch.Models.TextTranslationSkill.DeserializeTextTranslationSkill(element);
                    case "#Microsoft.Skills.Util.ConditionalSkill": return CognitiveSearch.Models.ConditionalSkill.DeserializeConditionalSkill(element);
                    case "#Microsoft.Skills.Util.ShaperSkill": return CognitiveSearch.Models.ShaperSkill.DeserializeShaperSkill(element);
                    case "#Microsoft.Skills.Vision.ImageAnalysisSkill": return CognitiveSearch.Models.ImageAnalysisSkill.DeserializeImageAnalysisSkill(element);
                    case "#Microsoft.Skills.Vision.OcrSkill": return CognitiveSearch.Models.OcrSkill.DeserializeOcrSkill(element);
                }
            }
            CognitiveSearch.Models.Skill result = new CognitiveSearch.Models.Skill();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@odata.type"))
                {
                    result.OdataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("context"))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Context = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("inputs"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Inputs.Add(CognitiveSearch.Models.InputFieldMappingEntry.DeserializeInputFieldMappingEntry(item));
                    }
                    continue;
                }
                if (property.NameEquals("outputs"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Outputs.Add(CognitiveSearch.Models.OutputFieldMappingEntry.DeserializeOutputFieldMappingEntry(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
