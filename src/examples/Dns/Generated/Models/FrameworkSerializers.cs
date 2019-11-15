using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Dns.Models
{
    internal static class FrameworkSerializers
    {
        //public static void Serialize(this string value, string serializedName, Utf8JsonWriter writer)
        //{
        //    writer.WriteString(serializedName, value);
        //}

        //public static void Serialize(this int value, string serializedName, Utf8JsonWriter writer)
        //{
        //    writer.WriteString(serializedName, value.ToString());
        //}

        //public static void Serialize<T>(this IDictionary<string, T> dictionary, string serializedName, Utf8JsonWriter writer)
        //{
        //    writer.WriteStartObject(serializedName);
        //    foreach (var item in dictionary)
        //    {
        //        writer.WriteString(item.Key, item.Value);
        //    }
        //    writer.WriteEndObject();
        //}

        //public static void Serialize<T>(this ICollection<string, T> dictionary, string serializedName, Utf8JsonWriter writer)
        //{
        //    writer.WriteStartObject(serializedName);
        //    foreach (var item in dictionary)
        //    {
        //        writer.WriteString(item.Key, item.Value);
        //    }
        //    writer.WriteEndObject();
        //}
    }
}
