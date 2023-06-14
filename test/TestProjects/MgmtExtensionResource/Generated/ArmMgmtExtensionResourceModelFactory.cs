// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtExtensionResource;

namespace MgmtExtensionResource.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtExtensionResourceModelFactory
    {
        /// <summary> Initializes a new instance of DnsNameAvailabilityResult. </summary>
        /// <param name="available"> Domain availability (True/False). </param>
        /// <returns> A new <see cref="Models.DnsNameAvailabilityResult"/> instance for mocking. </returns>
        public static DnsNameAvailabilityResult DnsNameAvailabilityResult(bool? available = null)
        {
            return new DnsNameAvailabilityResult(available);
        }

        /// <summary> Initializes a new instance of SubSingletonData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="something"> The something. </param>
        /// <returns> A new <see cref="MgmtExtensionResource.SubSingletonData"/> instance for mocking. </returns>
        public static SubSingletonData SubSingletonData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string something = null)
        {
            return new SubSingletonData(id, name, resourceType, systemData, something);
        }

        /// <summary> Initializes a new instance of PolicyDefinitionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="policyType"> The type of policy definition. Possible values are NotSpecified, BuiltIn, Custom, and Static. </param>
        /// <param name="mode"> The policy definition mode. Some examples are All, Indexed, Microsoft.KeyVault.Data. </param>
        /// <param name="displayName"> The display name of the policy definition. </param>
        /// <param name="description"> The policy definition description. </param>
        /// <param name="policyRule"> The policy rule. </param>
        /// <param name="metadata"> The policy definition metadata.  Metadata is an open ended object and is typically a collection of key value pairs. </param>
        /// <param name="parameters"> The parameter definitions for parameters used in the policy rule. The keys are the parameter names. </param>
        /// <returns> A new <see cref="MgmtExtensionResource.PolicyDefinitionData"/> instance for mocking. </returns>
        public static PolicyDefinitionData PolicyDefinitionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, PolicyType? policyType = null, string mode = null, string displayName = null, string description = null, BinaryData policyRule = null, BinaryData metadata = null, IDictionary<string, ParameterDefinitionsValue> parameters = null)
        {
            parameters ??= new Dictionary<string, ParameterDefinitionsValue>();

            return new PolicyDefinitionData(id, name, resourceType, systemData, policyType, mode, displayName, description, policyRule, metadata, parameters);
        }
    }
}
