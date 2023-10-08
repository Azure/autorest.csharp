// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class ResourceItem
    {
        public ResourceItem(string name)
        {
            Name = name;
        }

        [YamlIgnore]
        public string Name { get; set; }
        public List<string> ContextPaths { get; set; } = new List<string>();
        public bool IsNonResource { get; set; } = false;
        public Dictionary<string, List<string>> Operations { get; set; } = new Dictionary<string, List<string>>();
    }
}
