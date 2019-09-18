using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace AutoRest.CSharp.V3.Common.Utilities
{
    internal static class JsonElementExtensions
    {
        public static JsonElement? GetPropertyOrNull(this JsonElement element, string propertyName) =>
            element.TryGetProperty(propertyName, out var value) ? value : (JsonElement?)null;

        public static JsonProperty? GetPropertyOrNull(this IEnumerable<JsonProperty?> properties, string propertyName) =>
            properties.FirstOrDefault(p => p?.Name == propertyName);

        public static TValue ToObject<TValue>(this JsonElement element, JsonSerializerOptions options = null) =>
            JsonSerializer.Deserialize<TValue>(element.GetRawText(), options);

        public static JsonElement? Parse(this string jsonText)
        {
            try { return JsonDocument.Parse(jsonText).RootElement; }
            catch { return null; }
        }

        public static JsonElement[] Unwrap(this JsonElement element) =>
            element.ValueKind == JsonValueKind.Array ? element.EnumerateArray().ToArray() : new[] { element };
    }
}
