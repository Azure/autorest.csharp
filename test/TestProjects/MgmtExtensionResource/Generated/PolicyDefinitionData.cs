// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtExtensionResource.Models;

namespace MgmtExtensionResource
{
    /// <summary>
    /// A class representing the PolicyDefinition data model.
    /// The policy definition.
    /// </summary>
    public partial class PolicyDefinitionData : ResourceData
    {
        /// <summary> Initializes a new instance of PolicyDefinitionData. </summary>
        public PolicyDefinitionData()
        {
            Parameters = new ChangeTrackingDictionary<string, ParameterDefinitionsValue>();
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
        internal PolicyDefinitionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, PolicyType? policyType, string mode, string displayName, string description, BinaryData policyRule, BinaryData metadata, IDictionary<string, ParameterDefinitionsValue> parameters) : base(id, name, resourceType, systemData)
        {
            PolicyType = policyType;
            Mode = mode;
            DisplayName = displayName;
            Description = description;
            PolicyRule = policyRule;
            Metadata = metadata;
            Parameters = parameters;
        }

        /// <summary> The type of policy definition. Possible values are NotSpecified, BuiltIn, Custom, and Static. </summary>
        public PolicyType? PolicyType { get; set; }
        /// <summary> The policy definition mode. Some examples are All, Indexed, Microsoft.KeyVault.Data. </summary>
        public string Mode { get; set; }
        /// <summary> The display name of the policy definition. </summary>
        public string DisplayName { get; set; }
        /// <summary> The policy definition description. </summary>
        public string Description { get; set; }
        /// <summary>
        /// The policy rule.
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BinaryData PolicyRule { get; set; }
        /// <summary>
        /// The policy definition metadata.  Metadata is an open ended object and is typically a collection of key value pairs.
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BinaryData Metadata { get; set; }
        /// <summary> The parameter definitions for parameters used in the policy rule. The keys are the parameter names. </summary>
        public IDictionary<string, ParameterDefinitionsValue> Parameters { get; }
    }
}
