// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtSupersetInheritance
{
    /// <summary>
    /// A class representing the SupersetModel6 data model.
    /// This model has a common type systemData and should inherit from Resource.
    /// </summary>
    public partial class SupersetModel6Data : ResourceData
    {
        /// <summary> Initializes a new instance of SupersetModel6Data. </summary>
        public SupersetModel6Data()
        {
        }

        /// <summary> Initializes a new instance of SupersetModel6Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="new"></param>
        internal SupersetModel6Data(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string @new) : base(id, name, resourceType, systemData)
        {
            New = @new;
        }

        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
