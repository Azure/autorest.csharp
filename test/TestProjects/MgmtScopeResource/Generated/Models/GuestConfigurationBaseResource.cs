// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtScopeResource.Models
{
    /// <summary> The core properties of ARM resources. </summary>
    public partial class GuestConfigurationBaseResource
    {
        /// <summary> Initializes a new instance of GuestConfigurationBaseResource. </summary>
        public GuestConfigurationBaseResource()
        {
        }

        /// <summary> Initializes a new instance of GuestConfigurationBaseResource. </summary>
        /// <param name="id"> ARM resource id of the guest configuration assignment. </param>
        /// <param name="name"> Name of the guest configuration assignment. </param>
        /// <param name="location"> Region where the VM is located. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        internal GuestConfigurationBaseResource(string id, string name, string location, string resourceType)
        {
            Id = id;
            Name = name;
            Location = location;
            ResourceType = resourceType;
        }

        /// <summary> ARM resource id of the guest configuration assignment. </summary>
        public string Id { get; }
        /// <summary> Name of the guest configuration assignment. </summary>
        public string Name { get; set; }
        /// <summary> Region where the VM is located. </summary>
        public string Location { get; set; }
        /// <summary> The type of the resource. </summary>
        public string ResourceType { get; }
    }
}
