// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
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

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleData"/>. </summary>
        public DeliveryRuleData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DeliveryRuleData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="boolProperty"> A bool property to verify bicep generation. </param>
        /// <param name="location"> A location property to verify bicep generation. </param>
        /// <param name="locationWithCustomSerialization"> A location property to verify bicep generation. </param>
        /// <param name="dateTimeProperty"> A datetime property to verify bicep generation. </param>
        /// <param name="duration"> A duration property to verify bicep generation. </param>
        /// <param name="number"> A number property to verify bicep generation. </param>
        /// <param name="uri"> A number property to verify bicep generation. </param>
        /// <param name="properties"> The properties. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DeliveryRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, bool? boolProperty, AzureLocation? location, AzureLocation? locationWithCustomSerialization, DateTimeOffset? dateTimeProperty, TimeSpan? duration, int? number, Uri uri, DeliveryRuleProperties properties, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            BoolProperty = boolProperty;
            Location = location;
            LocationWithCustomSerialization = locationWithCustomSerialization;
            DateTimeProperty = dateTimeProperty;
            Duration = duration;
            Number = number;
            Uri = uri;
            Properties = properties;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> A bool property to verify bicep generation. </summary>
        public bool? BoolProperty { get; set; }
        /// <summary> A location property to verify bicep generation. </summary>
        public AzureLocation? Location { get; set; }
        /// <summary> A location property to verify bicep generation. </summary>
        public AzureLocation? LocationWithCustomSerialization { get; set; }
        /// <summary> A datetime property to verify bicep generation. </summary>
        public DateTimeOffset? DateTimeProperty { get; set; }
        /// <summary> A duration property to verify bicep generation. </summary>
        public TimeSpan? Duration { get; set; }
        /// <summary> A number property to verify bicep generation. </summary>
        public int? Number { get; set; }
        /// <summary> A number property to verify bicep generation. </summary>
        public Uri Uri { get; set; }
        /// <summary> The properties. </summary>
        public DeliveryRuleProperties Properties { get; set; }
    }
}
