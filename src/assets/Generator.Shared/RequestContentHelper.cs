// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;

namespace Azure.Core
{
    internal static class RequestContentHelper
    {
        public static RequestContent FromDictionary<T>(IDictionary<string, T> dictionary) where T : notnull
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartObject();
            foreach (var item in dictionary)
            {
                content.JsonWriter.WritePropertyName(item.Key);
                content.JsonWriter.WriteObjectValue(item.Value);
            }
            content.JsonWriter.WriteEndObject();

            return content;
        }
    }
}
