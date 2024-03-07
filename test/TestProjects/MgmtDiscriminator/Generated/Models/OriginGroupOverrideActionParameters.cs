// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using MgmtDiscriminator;

namespace MgmtDiscriminator.Models
{
    /// <summary> Defines the parameters for the origin group override action. </summary>
    public partial class OriginGroupOverrideActionParameters
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
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
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="OriginGroupOverrideActionParameters"/>. </summary>
        /// <param name="typeName"></param>
        /// <param name="originGroup"> defines the OriginGroup that would override the DefaultOriginGroup. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="originGroup"/> is null. </exception>
        public OriginGroupOverrideActionParameters(OriginGroupOverrideActionParametersTypeName typeName, WritableSubResource originGroup)
        {
            Argument.AssertNotNull(originGroup, nameof(originGroup));

            TypeName = typeName;
            OriginGroup = originGroup;
        }

        /// <summary> Initializes a new instance of <see cref="OriginGroupOverrideActionParameters"/>. </summary>
        /// <param name="typeName"></param>
        /// <param name="originGroup"> defines the OriginGroup that would override the DefaultOriginGroup. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal OriginGroupOverrideActionParameters(OriginGroupOverrideActionParametersTypeName typeName, WritableSubResource originGroup, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TypeName = typeName;
            OriginGroup = originGroup;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="OriginGroupOverrideActionParameters"/> for deserialization. </summary>
        internal OriginGroupOverrideActionParameters()
        {
        }

        /// <summary> Gets or sets the type name. </summary>
        [WirePath("typeName")]
        public OriginGroupOverrideActionParametersTypeName TypeName { get; set; }
        /// <summary> defines the OriginGroup that would override the DefaultOriginGroup. </summary>
        internal WritableSubResource OriginGroup { get; set; }
        /// <summary> Gets or sets Id. </summary>
        [WirePath("originGroup.id")]
        public ResourceIdentifier OriginGroupId
        {
            get => OriginGroup is null ? default : OriginGroup.Id;
            set
            {
                if (OriginGroup is null)
                    OriginGroup = new WritableSubResource();
                OriginGroup.Id = value;
            }
        }
    }
}
