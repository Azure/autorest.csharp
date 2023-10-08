// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class ObjectModelItem
    {
        public ObjectModelItem(string @namespace, string name, string serializedName)
        {
            FullName = string.IsNullOrEmpty(@namespace) ? name : $"{@namespace}.{name}";
            SerializedName = serializedName;
        }

        [YamlIgnore]
        public string FullName { get; set; }
        public string SerializedName { get; set; }

        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
}
