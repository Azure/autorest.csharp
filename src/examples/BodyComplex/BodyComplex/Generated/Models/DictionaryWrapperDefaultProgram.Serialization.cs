// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace BodyComplex.Models.V20160229
{
    public partial class DictionaryWrapperDefaultProgram
    {
        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            if (includeName)
            {
                writer.WriteStartObject("dictionary-wrapper-defaultProgram");
            }
            else
            {
                writer.WriteStartObject();
            }
            writer.WriteEndObject();
        }
        internal static DictionaryWrapperDefaultProgram Deserialize(JsonElement element)
        {
            var result = new DictionaryWrapperDefaultProgram();
            foreach (var property in element.EnumerateObject())
            {
            }
            return result;
        }
    }
}
