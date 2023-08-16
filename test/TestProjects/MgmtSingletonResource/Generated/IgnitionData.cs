// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtSingletonResource
{
    /// <summary> A class representing the Ignition data model. </summary>
    public partial class IgnitionData : ResourceData
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtSingletonResource.IgnitionData
        ///
        /// </summary>
        internal IgnitionData()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtSingletonResource.IgnitionData
        ///
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="pushButton"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal IgnitionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, bool? pushButton, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData)
        {
            PushButton = pushButton;
            _rawData = rawData;
        }

        /// <summary> Gets the push button. </summary>
        public bool? PushButton { get; }
    }
}
