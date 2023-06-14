// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtExtensionCommonRestOperation;

namespace MgmtExtensionCommonRestOperation.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtExtensionCommonRestOperationModelFactory
    {

        /// <summary> Initializes a new instance of TypeOneData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="myType"> The details of the type. </param>
        /// <returns> A new <see cref="MgmtExtensionCommonRestOperation.TypeOneData"/> instance for mocking. </returns>
        public static TypeOneData TypeOneData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string myType = null)
        {
            tags ??= new Dictionary<string, string>();

            return new TypeOneData(id, name, resourceType, systemData, tags, location, myType);
        }

        /// <summary> Initializes a new instance of TypeTwoData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="myType"> The details of the type. </param>
        /// <returns> A new <see cref="MgmtExtensionCommonRestOperation.TypeTwoData"/> instance for mocking. </returns>
        public static TypeTwoData TypeTwoData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string myType = null)
        {
            tags ??= new Dictionary<string, string>();

            return new TypeTwoData(id, name, resourceType, systemData, tags, location, myType);
        }
    }
}
