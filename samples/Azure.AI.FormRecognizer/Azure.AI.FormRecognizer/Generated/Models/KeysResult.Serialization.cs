// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class KeysResult
    {
        internal static KeysResult DeserializeKeysResult(JsonElement element)
        {
            KeysResult result;
            IDictionary<string, IList<string>> clusters = new Dictionary<string, IList<string>>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("clusters"))
                {
                    Dictionary<string, IList<string>> array = new Dictionary<string, IList<string>>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        IList<string> value;
                        List<string> array0 = new List<string>();
                        foreach (var item in property0.Value.EnumerateArray())
                        {
                            array0.Add(item.GetString());
                        }
                        value = array0;
                        array.Add(property0.Name, value);
                    }
                    clusters = array;
                    continue;
                }
            }
            result = new KeysResult(clusters);
            return result;
        }
    }
}
