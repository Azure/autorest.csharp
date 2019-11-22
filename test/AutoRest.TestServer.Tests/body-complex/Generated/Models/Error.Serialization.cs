// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace body_complex.Models.V20160229
{
    public partial class Error
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("Error");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (Status != null)
            {
                writer.WriteNumber("status", Status.Value);
            }
            if (Message != null)
            {
                writer.WriteString("message", Message);
            }
            writer.WriteEndObject();
        }
        internal static Error Deserialize(JsonElement element)
        {
            var result = new Error();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"))
                {
                    result.Status = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    result.Message = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
