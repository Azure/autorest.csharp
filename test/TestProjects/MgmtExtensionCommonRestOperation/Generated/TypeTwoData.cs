// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtExtensionCommonRestOperation
{
    /// <summary>
    /// A class representing the TypeTwo data model.
    /// The TypeTwo.
    /// </summary>
    public partial class TypeTwoData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of TypeTwoData. </summary>
        /// <param name="location"> The location. </param>
        public TypeTwoData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of TypeTwoData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="myType"> The details of the type. </param>
        internal TypeTwoData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string myType) : base(id, name, resourceType, systemData, tags, location)
        {
            MyType = myType;
        }

        /// <summary> The details of the type. </summary>
        public string MyType { get; set; }
    }
}
