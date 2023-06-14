// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtSingletonResource
{
    /// <summary> A class representing the Car data model. </summary>
    public partial class CarData : ResourceData
    {
        /// <summary> Initializes a new instance of CarData. </summary>
        public CarData()
        {
        }

        /// <summary> Initializes a new instance of CarData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="horsepower"></param>
        internal CarData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string horsepower) : base(id, name, resourceType, systemData)
        {
            Horsepower = horsepower;
        }

        /// <summary> Gets or sets the horsepower. </summary>
        public string Horsepower { get; set; }
    }
}
