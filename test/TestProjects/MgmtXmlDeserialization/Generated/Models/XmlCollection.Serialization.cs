// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Linq;
using Azure.Core;
using MgmtXmlDeserialization;

namespace MgmtXmlDeserialization.Models
{
    internal partial class XmlCollection
    {
        internal static XmlCollection DeserializeXmlCollection(XElement element)
        {
            long? count = default;
            string nextLink = default;
            IReadOnlyList<XmlInstanceData> value = default;
            if (element.Element("count") is XElement countElement)
            {
                count = (long?)countElement;
            }
            if (element.Element("nextLink") is XElement nextLinkElement)
            {
                nextLink = (string)nextLinkElement;
            }
            var array = new List<XmlInstanceData>();
            foreach (var e in element.Elements("XmlInstance"))
            {
                array.Add(XmlInstanceData.DeserializeXmlInstanceData(e));
            }
            value = array;
            return new XmlCollection(value, count, nextLink);
        }

        internal static XmlCollection DeserializeXmlCollection(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<XmlInstanceData>> value = default;
            Optional<long> count = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<XmlInstanceData> array = new List<XmlInstanceData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(XmlInstanceData.DeserializeXmlInstanceData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("count"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    count = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new XmlCollection(Optional.ToList(value), Optional.ToNullable(count), nextLink.Value);
        }
    }
}
