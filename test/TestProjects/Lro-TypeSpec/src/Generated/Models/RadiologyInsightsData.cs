// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace lrotsp.Models
{
    /// <summary> The body of the Radiology Insights request. </summary>
    public partial class RadiologyInsightsData
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

        /// <summary> Initializes a new instance of <see cref="RadiologyInsightsData"/>. </summary>
        /// <param name="patients"> The list of patients, including their clinical information and data. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="patients"/> is null. </exception>
        public RadiologyInsightsData(IEnumerable<string> patients)
        {
            Argument.AssertNotNull(patients, nameof(patients));

            Patients = patients.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="RadiologyInsightsData"/>. </summary>
        /// <param name="patients"> The list of patients, including their clinical information and data. </param>
        /// <param name="configuration"> Configuration affecting the Radiology Insights model's inference. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RadiologyInsightsData(IList<string> patients, string configuration, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Patients = patients;
            Configuration = configuration;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="RadiologyInsightsData"/> for deserialization. </summary>
        internal RadiologyInsightsData()
        {
        }

        /// <summary> The list of patients, including their clinical information and data. </summary>
        public IList<string> Patients { get; }
        /// <summary> Configuration affecting the Radiology Insights model's inference. </summary>
        public string Configuration { get; set; }
    }
}
