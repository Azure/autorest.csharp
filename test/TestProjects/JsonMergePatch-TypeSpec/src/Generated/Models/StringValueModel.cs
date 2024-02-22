// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Payload.JsonMergePatch.Models
{
    /// <summary> The StringValueModel. </summary>
    public partial class StringValueModel
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

        /// <summary> Initializes a new instance of <see cref="StringValueModel"/>. </summary>
        /// <param name="requiredStringValue"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredStringValue"/> is null. </exception>
        public StringValueModel(string requiredStringValue)
        {
            if (requiredStringValue == null)
            {
                throw new ArgumentNullException(nameof(requiredStringValue));
            }

            RequiredStringValue = requiredStringValue;
        }

        /// <summary> Initializes a new instance of <see cref="StringValueModel"/>. </summary>
        /// <param name="requiredStringValue"></param>
        /// <param name="optionalStringValue"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal StringValueModel(string requiredStringValue, string optionalStringValue, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            _requiredStringValue = requiredStringValue;
            _optionalStringValue = optionalStringValue;

            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="StringValueModel"/> for deserialization. </summary>
        internal StringValueModel()
        {
        }

        /// <summary> Gets the required string value. </summary>
        private string _requiredStringValue;
        private bool _requiredStringValueChanged = false;
        public string RequiredStringValue
        {
            get => _requiredStringValue;
            set
            {
                _requiredStringValue = value;
                _requiredStringValueChanged = true;
            }
        }

        /// <summary> Gets or sets the optional string value. </summary>
        private string _optionalStringValue;
        private bool _optionalStringValueChanged = false;
        public string OptionalStringValue
        {
            get => _optionalStringValue;
            set
            {
                _optionalStringValue = value;
                _optionalStringValueChanged = true;
            }
        }

    }
}
