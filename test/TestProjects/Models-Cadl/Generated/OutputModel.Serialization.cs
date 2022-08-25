// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelsInCadl
{
    public partial class OutputModel : IUtf8JsonSerializable
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
            writer.WriteEndObject();
        }

        internal static OutputModel DeserializeOutputModel(JsonElement element)
        {
            string requiredString = default;
            int requiredInt = default;
            DerivedModel requiredModel = default;
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
                    requiredModel = DerivedModel.DeserializeDerivedModel(property.Value);
                    continue;
                }
            }
            return new OutputModel(requiredString, requiredInt, requiredModel);
        }

        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal static OutputModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeOutputModel(document.RootElement);
        }
    }
}
