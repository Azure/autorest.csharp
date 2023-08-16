// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtSupersetInheritance.Models
{
    /// <summary> This model should inherit from SupersetModel4. </summary>
    public partial class SupersetModel5 : TrackedResourceData
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtSupersetInheritance.Models.SupersetModel5
        ///
        /// </summary>
        /// <param name="location"> The location. </param>
        public SupersetModel5(AzureLocation location) : base(location)
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtSupersetInheritance.Models.SupersetModel5
        ///
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="foo"></param>
        /// <param name="new"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SupersetModel5(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string foo, string @new, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData, tags, location)
        {
            Foo = foo;
            New = @new;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
