// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtSupersetInheritance.Models
{
    /// <summary> This model should inherit from SupersetModel4. </summary>
    public partial class SupersetModel5 : TrackedResourceData
    {
        /// <summary> Initializes a new instance of SupersetModel5. </summary>
        /// <param name="location"> The location. </param>
        public SupersetModel5(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of SupersetModel5. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="foo"></param>
        /// <param name="new"></param>
        internal SupersetModel5(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string foo, string @new) : base(id, name, resourceType, systemData, tags, location)
        {
            Foo = foo;
            New = @new;
        }

        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
