// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Dns.Models.V20180501
{
    public partial class Zone
    {
        public string? Etag { get; set; }
        public ZoneProperties? Properties { get; set; }
    }

    public partial class Zone
    {
        internal static Zone Deserialize(JsonElement element)
        {
            var result = new Zone();
            foreach (var property in element.EnumerateObject())
            {
                //var value = property.Name switch
                //{
                //    "etag" => property.Value,
                //    "zone" => property.Value,
                //    _ => (JsonElement?)null
                //};
                if (property.NameEquals("etag"))
                {
                    result.Etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("zone"))
                {
                    result.Properties = ZoneProperties.Deserialize(property.Value);
                    continue;
                }
            }
            return result;
        }

        internal void Serialize(Utf8JsonWriter writer, bool includeName = true)
        {
            //var buffer = new ArrayBufferWriter<byte>();
            //using var writer = new Utf8JsonWriter(buffer);
            //writer.WriteStartObject();
            //WriteRequestBody(json, setting);

            //Etag?.Serialize("etag", writer);
            if (includeName)
            {
                writer.WriteStartObject("zone");
            }
            else
            {
                writer.WriteStartObject();
            }

            if (Etag != null)
            {
                writer.WriteString("etag", Etag);

                //writer.WriteBoolean("thing", true);
                //writer.WriteBooleanValue(true);
                //writer.Write
                //writer.
                //var thing = new DateTime();
                //writer.WriteStringValue(thing.);
            }
            //Properties?.Serialize(writer);
            if (Properties != null)
            {
                Properties.Serialize(writer);
            }

            //if (Properties != null)
            //{
            //    Properties.Serialize(writer);
            //    //writer.WriteString("properties", Properties.ToSerialized());
            //    //writer.WriteStartObject("properties");
            //    //foreach (var item in Properties)
            //    //{
            //    //    writer.WriteString(item.Key, item.Value);
            //    //}
            //    //writer.WriteEndObject();
            //}


            //writer.WriteString("value", setting.Value);
            //writer.WriteString("content_type", setting.ContentType);
            //if (setting.Tags != null)
            //{
            //    writer.WriteStartObject("tags");
            //    foreach (System.Collections.Generic.KeyValuePair<string, string> tag in setting.Tags)
            //    {
            //        writer.WriteString(tag.Key, tag.Value);
            //    }

            //    writer.WriteEndObject();
            //}

            //if (setting.ETag != default)
            //{
            //    writer.WriteString("etag", setting.ETag.ToString());
            //}



            writer.WriteEndObject();
            //writer.Flush();
            ////return writer.WrittenMemory;
            //return "";
        }
    }
}
