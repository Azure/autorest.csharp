// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtOperations
{
    /// <summary> A class representing the AvailabilitySetChild data model. </summary>
    public partial class AvailabilitySetChildData : TrackedResource
    {
        /// <summary> Initializes a new instance of AvailabilitySetChildData. </summary>
        /// <param name="location"> The location. </param>
        public AvailabilitySetChildData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of AvailabilitySetChildData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        internal AvailabilitySetChildData(ResourceIdentifier id, string name, ResourceType type, IDictionary<string, string> tags, AzureLocation location, string bar) : base(id, name, type, tags, location)
        {
            Bar = bar;
        }

        /// <summary> specifies the bar. </summary>
        public string Bar { get; set; }
    }
}
