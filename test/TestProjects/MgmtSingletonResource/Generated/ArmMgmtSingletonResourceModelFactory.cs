// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtSingletonResource;

namespace MgmtSingletonResource.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtSingletonResourceModelFactory
    {

        /// <summary> Initializes a new instance of CarData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="horsepower"></param>
        /// <returns> A new <see cref="MgmtSingletonResource.CarData"/> instance for mocking. </returns>
        public static CarData CarData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string horsepower = null)
        {
            return new CarData(id, name, resourceType, systemData, horsepower);
        }

        /// <summary> Initializes a new instance of IgnitionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="pushButton"></param>
        /// <returns> A new <see cref="MgmtSingletonResource.IgnitionData"/> instance for mocking. </returns>
        public static IgnitionData IgnitionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, bool? pushButton = null)
        {
            return new IgnitionData(id, name, resourceType, systemData, pushButton);
        }

        /// <summary> Initializes a new instance of BrakeData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="hitBrake"></param>
        /// <returns> A new <see cref="MgmtSingletonResource.BrakeData"/> instance for mocking. </returns>
        public static BrakeData BrakeData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, bool? hitBrake = null)
        {
            return new BrakeData(id, name, resourceType, systemData, hitBrake);
        }

        /// <summary> Initializes a new instance of SingletonResourceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="new"></param>
        /// <returns> A new <see cref="MgmtSingletonResource.SingletonResourceData"/> instance for mocking. </returns>
        public static SingletonResourceData SingletonResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string @new = null)
        {
            return new SingletonResourceData(id, name, resourceType, systemData, @new);
        }

        /// <summary> Initializes a new instance of ParentResourceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="new"></param>
        /// <returns> A new <see cref="MgmtSingletonResource.ParentResourceData"/> instance for mocking. </returns>
        public static ParentResourceData ParentResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string @new = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ParentResourceData(id, name, resourceType, systemData, tags, location, @new);
        }
    }
}
