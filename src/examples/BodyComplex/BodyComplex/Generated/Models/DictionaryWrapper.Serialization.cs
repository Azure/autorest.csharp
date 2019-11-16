// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class DictionaryWrapper
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("dictionary-wrapper");
            }
            else
            {
                writer.WriteStartObject();
            }
            if (_defaultProgram != null)
            {
                writer.WriteStartObject("defaultProgram");
                foreach (var item in _defaultProgram)
                {
                    writer.WriteString(item.Key, item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }
        internal static DictionaryWrapper Deserialize(JsonElement element)
        {
            var result = new DictionaryWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("defaultProgram"))
                {
                    foreach (var item in property.Value.EnumerateObject())
                    {
                        result.DefaultProgram.Add(item.Name, item.Value.GetString());
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
