// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtDiscriminator;

namespace MgmtDiscriminator.Models
{
    /// <summary> Blueprint artifact that deploys a Resource Manager template. </summary>
    public partial class TemplateArtifact : ArtifactData
    {
        /// <summary> Initializes a new instance of <see cref="TemplateArtifact"/>. </summary>
        /// <param name="template"> The Resource Manager template blueprint artifact body. </param>
        /// <param name="parameters"> Resource Manager template blueprint artifact parameter values. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="template"/> or <paramref name="parameters"/> is null. </exception>
        public TemplateArtifact(BinaryData template, IDictionary<string, BinaryData> parameters)
        {
            Argument.AssertNotNull(template, nameof(template));
            Argument.AssertNotNull(parameters, nameof(parameters));

            Template = template;
            Parameters = parameters;
            Kind = ArtifactKind.Template;
        }

        /// <summary> Initializes a new instance of <see cref="TemplateArtifact"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="kind"> Specifies the kind of blueprint artifact. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="template"> The Resource Manager template blueprint artifact body. </param>
        /// <param name="resourceGroup"> If applicable, the name of the resource group placeholder to which the Resource Manager template blueprint artifact will be deployed. </param>
        /// <param name="parameters"> Resource Manager template blueprint artifact parameter values. </param>
        internal TemplateArtifact(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ArtifactKind kind, IDictionary<string, BinaryData> serializedAdditionalRawData, BinaryData template, string resourceGroup, IDictionary<string, BinaryData> parameters) : base(id, name, resourceType, systemData, kind, serializedAdditionalRawData)
        {
            Template = template;
            ResourceGroup = resourceGroup;
            Parameters = parameters;
            Kind = kind;
        }

        /// <summary> Initializes a new instance of <see cref="TemplateArtifact"/> for deserialization. </summary>
        internal TemplateArtifact()
        {
        }

        /// <summary>
        /// The Resource Manager template blueprint artifact body.
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
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
        [WirePath("properties.template")]
        public BinaryData Template { get; set; }
        /// <summary> If applicable, the name of the resource group placeholder to which the Resource Manager template blueprint artifact will be deployed. </summary>
        [WirePath("properties.resourceGroup")]
        public string ResourceGroup { get; set; }
        /// <summary>
        /// Resource Manager template blueprint artifact parameter values.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
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
        [WirePath("properties.parameters")]
        public IDictionary<string, BinaryData> Parameters { get; }
    }
}
