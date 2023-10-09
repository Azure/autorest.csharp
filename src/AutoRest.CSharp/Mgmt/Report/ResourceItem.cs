// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using YamlDotNet.Serialization;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class ResourceItem
    {
        public ResourceItem(string name)
        {
            Name = name;
        }

        public ResourceItem(Resource resource)
            :this(resource.ResourceName)
        {
            this.ContextPaths =
                resource.AllOperations.SelectMany(cop => cop.Select(rop => rop.ContextualPath.ToString())).Distinct().ToList();
            this.RequestPath = resource.RequestPath.ToString();
            this.IsNonResource = !resource.OperationSet.IsResource();
            this.Operations = resource.AllOperations
                .GroupBy(op => op.MethodSignature.Name)
                .ToDictionary(
                    g => g.Key,
                    g => g.SelectMany(op => op.Select(mrop => mrop.OperationId)).Distinct().ToList());
            // assume there is no circle in resource hirachy. TODO: handle it if it's not true
            this.ChildResources = resource.ChildResources.ToDictionary(r => r.ResourceName, r => new ResourceItem(r));
        }

        [YamlIgnore]
        public string Name { get; set; }
        public List<string> ContextPaths { get; set; } = new List<string>();
        public string RequestPath { get; set; } = string.Empty;
        public bool IsNonResource { get; set; } = false;
        public Dictionary<string, List<string>> Operations { get; set; } = new Dictionary<string, List<string>>();
        public Dictionary<string, ResourceItem> ChildResources { get; set; } = new Dictionary<string, ResourceItem>();
    }
}
