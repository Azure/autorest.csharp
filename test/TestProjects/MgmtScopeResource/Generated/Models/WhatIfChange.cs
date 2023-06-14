// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    /// <summary> Information about a single resource change predicted by What-If operation. </summary>
    public partial class WhatIfChange
    {
        /// <summary> Initializes a new instance of WhatIfChange. </summary>
        /// <param name="resourceId"> Resource ID. </param>
        /// <param name="changeType"> Type of change that will be made to the resource when the deployment is executed. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> is null. </exception>
        internal WhatIfChange(string resourceId, ChangeType changeType)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));

            ResourceId = resourceId;
            ChangeType = changeType;
        }

        /// <summary> Initializes a new instance of WhatIfChange. </summary>
        /// <param name="resourceId"> Resource ID. </param>
        /// <param name="changeType"> Type of change that will be made to the resource when the deployment is executed. </param>
        /// <param name="unsupportedReason"> The explanation about why the resource is unsupported by What-If. </param>
        /// <param name="before"> The snapshot of the resource before the deployment is executed. </param>
        /// <param name="after"> The predicted snapshot of the resource after the deployment is executed. </param>
        internal WhatIfChange(string resourceId, ChangeType changeType, string unsupportedReason, BinaryData before, BinaryData after)
        {
            ResourceId = resourceId;
            ChangeType = changeType;
            UnsupportedReason = unsupportedReason;
            Before = before;
            After = after;
        }

        /// <summary> Resource ID. </summary>
        public string ResourceId { get; }
        /// <summary> Type of change that will be made to the resource when the deployment is executed. </summary>
        public ChangeType ChangeType { get; }
        /// <summary> The explanation about why the resource is unsupported by What-If. </summary>
        public string UnsupportedReason { get; }
        /// <summary>
        /// The snapshot of the resource before the deployment is executed.
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
        public BinaryData Before { get; }
        /// <summary>
        /// The predicted snapshot of the resource after the deployment is executed.
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
        public BinaryData After { get; }
    }
}
