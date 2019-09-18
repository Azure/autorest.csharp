using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace AutoRest.CSharp.V3.Common.Utilities
{
    internal static class JsonElementExtensions
    {
        public static JsonElement? GetPropertyOrNull(this JsonElement jsonElement, string propertyName) =>
            jsonElement.TryGetProperty(propertyName, out var value) ? value : (JsonElement?)null;

        public static TValue ToObject<TValue>(this JsonElement jsonElement, JsonSerializerOptions options = null) =>
            JsonSerializer.Deserialize<TValue>(jsonElement.GetRawText(), options);

        public static JsonElement? Parse(this string jsonText)
        {
            try { return JsonDocument.Parse(jsonText).RootElement; }
            catch { return null; }
        }

        public static JsonElement[] Unwrap(this JsonElement jsonElement) =>
            jsonElement.ValueKind == JsonValueKind.Array ? jsonElement.EnumerateArray().ToArray() : new[] { jsonElement };
    }
}
