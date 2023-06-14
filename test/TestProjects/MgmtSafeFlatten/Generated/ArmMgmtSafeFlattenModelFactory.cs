// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtSafeFlatten;

namespace MgmtSafeFlatten.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtSafeFlattenModelFactory
    {

        /// <summary> Initializes a new instance of TypeOneData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="myType"> The details of the type. </param>
        /// <param name="layerTwoMyProp"> The single value prop. </param>
        /// <param name="layerOneType">
        /// The single value prop with discriminator.
        /// Please note <see cref="LayerOneBaseType"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="LayerOneBarType"/> and <see cref="LayerOneFooType"/>.
        /// </param>
        /// <param name="layerOneConflictId"> The single value prop with conflict. </param>
        /// <returns> A new <see cref="MgmtSafeFlatten.TypeOneData"/> instance for mocking. </returns>
        public static TypeOneData TypeOneData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string myType = null, string layerTwoMyProp = null, LayerOneBaseType layerOneType = null, ResourceIdentifier layerOneConflictId = null)
        {
            tags ??= new Dictionary<string, string>();

            return new TypeOneData(id, name, resourceType, systemData, tags, location, myType, layerTwoMyProp != null ? new LayerOneSingle(new LayerTwoSingle(layerTwoMyProp)) : null, layerOneType, layerOneConflictId != null ? ResourceManagerModelFactory.WritableSubResource(layerOneConflictId) : null);
        }

        /// <summary> Initializes a new instance of TypeTwoData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="myType"> The details of the type. </param>
        /// <param name="layerTwoMyProp"> The single value prop. </param>
        /// <returns> A new <see cref="MgmtSafeFlatten.TypeTwoData"/> instance for mocking. </returns>
        public static TypeTwoData TypeTwoData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string myType = null, string layerTwoMyProp = null)
        {
            tags ??= new Dictionary<string, string>();

            return new TypeTwoData(id, name, resourceType, systemData, tags, location, myType, layerTwoMyProp != null ? new LayerOneSingle(new LayerTwoSingle(layerTwoMyProp)) : null);
        }
    }
}
