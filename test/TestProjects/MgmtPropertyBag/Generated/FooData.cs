// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtPropertyBag
{
    /// <summary>
    /// A class representing the Foo data model.
    /// Foo instance details.
    /// </summary>
    public partial class FooData : ResourceData
    {
        /// <summary> Initializes a new instance of FooData. </summary>
        public FooData()
        {
        }

        /// <summary> Initializes a new instance of FooData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="details"> The details of the resource. </param>
        internal FooData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string details) : base(id, name, resourceType, systemData)
        {
            Details = details;
        }

        /// <summary> The details of the resource. </summary>
        public string Details { get; set; }
    }
}
