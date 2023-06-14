// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtSafeFlatten.Models;

namespace MgmtSafeFlatten
{
    /// <summary>
    /// A class representing the TypeOne data model.
    /// The TypeOne.
    /// </summary>
    public partial class TypeOneData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of TypeOneData. </summary>
        /// <param name="location"> The location. </param>
        public TypeOneData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of TypeOneData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="myType"> The details of the type. </param>
        /// <param name="layerOne"> The single value prop. </param>
        /// <param name="layerOneType">
        /// The single value prop with discriminator.
        /// Please note <see cref="LayerOneBaseType"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="LayerOneBarType"/> and <see cref="LayerOneFooType"/>.
        /// </param>
        /// <param name="layerOneConflict"> The single value prop with conflict. </param>
        internal TypeOneData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string myType, LayerOneSingle layerOne, LayerOneBaseType layerOneType, WritableSubResource layerOneConflict) : base(id, name, resourceType, systemData, tags, location)
        {
            MyType = myType;
            LayerOne = layerOne;
            LayerOneType = layerOneType;
            LayerOneConflict = layerOneConflict;
        }

        /// <summary> The details of the type. </summary>
        public string MyType { get; set; }
        /// <summary> The single value prop. </summary>
        internal LayerOneSingle LayerOne { get; set; }
        /// <summary> MyProp description. </summary>
        public string LayerTwoMyProp
        {
            get => LayerOne is null ? default : LayerOne.LayerTwoMyProp;
            set
            {
                if (LayerOne is null)
                    LayerOne = new LayerOneSingle();
                LayerOne.LayerTwoMyProp = value;
            }
        }

        /// <summary>
        /// The single value prop with discriminator.
        /// Please note <see cref="LayerOneBaseType"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="LayerOneBarType"/> and <see cref="LayerOneFooType"/>.
        /// </summary>
        public LayerOneBaseType LayerOneType { get; set; }
        /// <summary> The single value prop with conflict. </summary>
        internal WritableSubResource LayerOneConflict { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier LayerOneConflictId
        {
            get => LayerOneConflict is null ? default : LayerOneConflict.Id;
            set
            {
                if (LayerOneConflict is null)
                    LayerOneConflict = new WritableSubResource();
                LayerOneConflict.Id = value;
            }
        }
    }
}
