// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Dns.Models.V20180501
{
    public partial class SubResource
    {
        public string? Id { get; set; }
    }

    public partial class SubResource
    {
        internal static SubResource Deserialize(JsonElement element)
        {
            var result = new SubResource();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    result.Id = property.Value.GetString();
                    continue;
                }
                //property.Value.GetDateTime()
            }
            return result;
        }

        public void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("subResource");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Id != null)
            {
                writer.WriteString("id", Id);
            }
            writer.WriteEndObject();
        }
    }
}
