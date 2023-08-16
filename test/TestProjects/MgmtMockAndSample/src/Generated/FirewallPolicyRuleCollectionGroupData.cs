// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    /// <summary>
    /// A class representing the FirewallPolicyRuleCollectionGroup data model.
    /// Rule Collection Group resource.
    /// </summary>
    public partial class FirewallPolicyRuleCollectionGroupData : SubResource
    {
        /// <summary>
        /// Initializes a new instance of global::MgmtMockAndSample.FirewallPolicyRuleCollectionGroupData
        ///
        /// </summary>
        public FirewallPolicyRuleCollectionGroupData()
        {
            RuleCollections = new ChangeTrackingList<FirewallPolicyRuleCollection>();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtMockAndSample.FirewallPolicyRuleCollectionGroupData
        ///
        /// </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="resourceType"> Rule Group type. </param>
        /// <param name="priority"> Priority of the Firewall Policy Rule Collection Group resource. </param>
        /// <param name="ruleCollections">
        /// Group of Firewall Policy rule collections.
        /// Please note <see cref="FirewallPolicyRuleCollection"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="FirewallPolicyFilterRuleCollection"/> and <see cref="FirewallPolicyNatRuleCollection"/>.
        /// </param>
        /// <param name="provisioningState"> The provisioning state of the firewall policy rule collection group resource. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal FirewallPolicyRuleCollectionGroupData(string id, string name, string etag, ResourceType? resourceType, int? priority, IList<FirewallPolicyRuleCollection> ruleCollections, ProvisioningState? provisioningState, Dictionary<string, BinaryData> rawData) : base(id, rawData)
        {
            Name = name;
            Etag = etag;
            ResourceType = resourceType;
            Priority = priority;
            RuleCollections = ruleCollections;
            ProvisioningState = provisioningState;
        }

        /// <summary> The name of the resource that is unique within a resource group. This name can be used to access the resource. </summary>
        public string Name { get; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> Rule Group type. </summary>
        public ResourceType? ResourceType { get; }
        /// <summary> Priority of the Firewall Policy Rule Collection Group resource. </summary>
        public int? Priority { get; set; }
        /// <summary>
        /// Group of Firewall Policy rule collections.
        /// Please note <see cref="FirewallPolicyRuleCollection"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="FirewallPolicyFilterRuleCollection"/> and <see cref="FirewallPolicyNatRuleCollection"/>.
        /// </summary>
        public IList<FirewallPolicyRuleCollection> RuleCollections { get; }
        /// <summary> The provisioning state of the firewall policy rule collection group resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
    }
}
