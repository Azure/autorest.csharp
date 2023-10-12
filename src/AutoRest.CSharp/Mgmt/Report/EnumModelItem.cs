// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class EnumModelItem : TransformableItem
    {
        public EnumModelItem(string @namespace, string name, string serializedName, TransformSection transformSection)
            :base(serializedName, transformSection)
        {
            FullName = string.IsNullOrEmpty(@namespace) ? name : $"{@namespace}.{name}";
        }

        [YamlIgnore]
        public string FullName { get; set; }

        public Dictionary<string, EnumValueItem> Values { get; set; } = new Dictionary<string, EnumValueItem>();
    }
}
