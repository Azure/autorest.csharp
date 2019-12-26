// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class DotFish : Azure.Core.IUtf8JsonSerializable
    {
        void Azure.Core.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("fish.type");
            writer.WriteStringValue(FishType);
            if (Species != null)
            {
                writer.WritePropertyName("species");
                writer.WriteStringValue(Species);
            }
            writer.WriteEndObject();
        }
        internal static body_complex.Models.V20160229.DotFish DeserializeDotFish(System.Text.Json.JsonElement element)
        {
            if (element.TryGetProperty("fish.type", out System.Text.Json.JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "DotSalmon": return body_complex.Models.V20160229.DotSalmon.DeserializeDotSalmon(element);
                }
            }
            body_complex.Models.V20160229.DotFish result = new body_complex.Models.V20160229.DotFish();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("fish.type"))
                {
                    result.FishType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Species = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
