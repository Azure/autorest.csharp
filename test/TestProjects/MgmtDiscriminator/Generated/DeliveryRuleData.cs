// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtDiscriminator.Models;

namespace MgmtDiscriminator
{
    /// <summary>
    /// A class representing the DeliveryRule data model.
    /// A rule that specifies a set of actions and conditions
    /// </summary>
    public partial class DeliveryRuleData : ResourceData
    {
        /// <summary> Initializes a new instance of DeliveryRuleData. </summary>
        public DeliveryRuleData()
        {
        }

        /// <summary> Initializes a new instance of DeliveryRuleData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> The properties. </param>
        internal DeliveryRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DeliveryRuleProperties properties) : base(id, name, resourceType, systemData)
        {
            Properties = properties;
        }

        /// <summary> The properties. </summary>
        public DeliveryRuleProperties Properties { get; set; }
    }
}
