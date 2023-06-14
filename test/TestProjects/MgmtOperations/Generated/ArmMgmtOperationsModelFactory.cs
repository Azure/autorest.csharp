// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtOperations;

namespace MgmtOperations.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtOperationsModelFactory
    {
        /// <summary> Initializes a new instance of AvailabilitySetData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtOperations.AvailabilitySetData"/> instance for mocking. </returns>
        public static AvailabilitySetData AvailabilitySetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new AvailabilitySetData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of ConnectionSharedKey. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="value"> The virtual network connection shared key value. </param>
        /// <returns> A new <see cref="Models.ConnectionSharedKey"/> instance for mocking. </returns>
        public static ConnectionSharedKey ConnectionSharedKey(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string value = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ConnectionSharedKey(id, name, resourceType, systemData, tags, location, value);
        }

        /// <summary> Initializes a new instance of AvailabilitySetChildData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtOperations.AvailabilitySetChildData"/> instance for mocking. </returns>
        public static AvailabilitySetChildData AvailabilitySetChildData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new AvailabilitySetChildData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of AvailabilitySetGrandChildData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="MgmtOperations.AvailabilitySetGrandChildData"/> instance for mocking. </returns>
        public static AvailabilitySetGrandChildData AvailabilitySetGrandChildData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string bar = null)
        {
            tags ??= new Dictionary<string, string>();

            return new AvailabilitySetGrandChildData(id, name, resourceType, systemData, tags, location, bar);
        }

        /// <summary> Initializes a new instance of TestAvailabilitySet. </summary>
        /// <param name="bar"> specifies the bar. </param>
        /// <returns> A new <see cref="Models.TestAvailabilitySet"/> instance for mocking. </returns>
        public static TestAvailabilitySet TestAvailabilitySet(string bar = null)
        {
            return new TestAvailabilitySet(bar);
        }

        /// <summary> Initializes a new instance of UnpatchableResourceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="foo"> specifies the foo. </param>
        /// <returns> A new <see cref="MgmtOperations.UnpatchableResourceData"/> instance for mocking. </returns>
        public static UnpatchableResourceData UnpatchableResourceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string foo = null)
        {
            tags ??= new Dictionary<string, string>();

            return new UnpatchableResourceData(id, name, resourceType, systemData, tags, location, foo);
        }
    }
}
