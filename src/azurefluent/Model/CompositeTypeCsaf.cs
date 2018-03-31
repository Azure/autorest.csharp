// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.Core.Utilities;
using AutoRest.CSharp.Azure.Model;
using AutoRest.Extensions.Azure;
using Newtonsoft.Json;
using System.Linq;

namespace AutoRest.CSharp.Azure.Fluent.Model
{
    public class CompositeTypeCsaf : CompositeTypeCsa
    {
        public CompositeTypeCsaf()
        {
            Name.OnGet += nam => nam.IsNullOrEmpty() || !IsInnerModel ? nam : nam + "Inner";
        }

        public CompositeTypeCsaf(string name ) : base(name)
        {
            Name.OnGet += nam => nam.IsNullOrEmpty() || !IsInnerModel ? nam : nam + "Inner";
        }

        [JsonIgnore]
        public bool IsResource =>
            ModelResourceType != ResourceType.None;

        public bool IsInnerModel { get; set; } = false;

        [JsonIgnore]
        public ResourceType ModelResourceType
        {
            get
            {
                if (!Extensions.ContainsKey(AzureExtensions.AzureResourceExtension) || !(bool)Extensions[AzureExtensions.AzureResourceExtension])
                {
                    return ResourceType.None;
                }
                else
                {
                    var rawName = Name.RawValue.Split('.', System.StringSplitOptions.RemoveEmptyEntries).Last();
                    if (rawName == "SubResource")
                    {
                        return ResourceType.SubResource;
                    }
                    else if (rawName == "TrackedResource")
                    {
                        return ResourceType.Resource;
                    }
                    else if (rawName == "ProxyResource")
                    {
                        return ResourceType.ProxyResource;
                    }
                    else if (rawName == "Resource")
                    {
                        var locationProperty = Properties.Where(p => p.SerializedName == "location").FirstOrDefault();
                        var tagsProperty = Properties.Where(p => p.SerializedName == "tags").FirstOrDefault();
                        // Otherwise location will be validated
                        if (locationProperty == null || !locationProperty.IsRequired || tagsProperty == null)
                        {
                            var idProperty = Properties.Where(p => p.SerializedName == "id").FirstOrDefault();
                            var nameProperty = Properties.Where(p => p.SerializedName == "name").FirstOrDefault();
                            var typeProperty = Properties.Where(p => p.SerializedName == "type").FirstOrDefault();
                            if (idProperty == null || !idProperty.IsReadOnly ||
                                nameProperty == null || !nameProperty.IsReadOnly ||
                                typeProperty == null || !typeProperty.IsReadOnly)
                            {
                                return ResourceType.SubResource;
                            }
                            return ResourceType.ProxyResource;
                        }
                        return ResourceType.Resource;
                    }
                    else
                    {
                        return ResourceType.None;
                    }
                }
            }
        }
    }

    public enum ResourceType
    {
        Resource,
        ProxyResource,
        SubResource,
        None
    }
}
