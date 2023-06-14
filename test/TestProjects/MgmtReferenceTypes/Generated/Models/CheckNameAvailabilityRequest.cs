// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> The check availability request body. </summary>
    [PropertyReferenceType]
    public partial class CheckNameAvailabilityRequest
    {
        /// <summary> Initializes a new instance of CheckNameAvailabilityRequest. </summary>
        [InitializationConstructor]
        public CheckNameAvailabilityRequest()
        {
        }

        /// <summary> Initializes a new instance of CheckNameAvailabilityRequest. </summary>
        /// <param name="name"> The name of the resource for which availability needs to be checked. </param>
        /// <param name="resourceType"> The resource type. </param>
        [SerializationConstructor]
        internal CheckNameAvailabilityRequest(string name, ResourceType resourceType)
        {
            Name = name;
            ResourceType = resourceType;
        }

        /// <summary> The name of the resource for which availability needs to be checked. </summary>
        public string Name { get; set; }
        /// <summary> The resource type. </summary>
        public ResourceType ResourceType { get; set; }
    }
}
