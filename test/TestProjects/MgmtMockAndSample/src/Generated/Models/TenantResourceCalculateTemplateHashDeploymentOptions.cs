// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace MgmtMockAndSample.Models
{
    /// <summary> The TenantResourceCalculateTemplateHashDeploymentOptions. </summary>
    public partial class TenantResourceCalculateTemplateHashDeploymentOptions
    {
        /// <summary> Initializes a new instance of <see cref="TenantResourceCalculateTemplateHashDeploymentOptions"/>. </summary>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="template"/> is null. </exception>
        public TenantResourceCalculateTemplateHashDeploymentOptions(BinaryData template)
        {
            Argument.AssertNotNull(template, nameof(template));

            Template = template;
        }

        /// <summary>
        /// The template provided to calculate hash.
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
        public BinaryData Template { get; }
        /// <summary> The first query parameter. </summary>
        public string Q1 { get; set; }
        /// <summary> The second query parameter. </summary>
        public int? Q2 { get; set; }
        /// <summary> The third query parameter. </summary>
        public long? Q3 { get; set; }
        /// <summary> The fourth query parameter. </summary>
        public float? Q4 { get; set; }
        /// <summary> The fifth query parameter. </summary>
        public double? Q5 { get; set; }
        /// <summary> The sixth query parameter. </summary>
        public bool? Q6 { get; set; }
    }
}
