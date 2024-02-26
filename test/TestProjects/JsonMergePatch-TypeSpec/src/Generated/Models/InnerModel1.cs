// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Payload.JsonMergePatch.Models
{
    /// <summary> It is the model used by Resource model. </summary>
    public partial class InnerModel1
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

        /// <summary> Initializes a new instance of <see cref="InnerModel1"/>. </summary>
        public InnerModel1()
        {
        }

        /// <summary> Initializes a new instance of <see cref="InnerModel1"/>. </summary>
        /// <param name="innerModel2"></param>
        /// <param name="property"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InnerModel1(InnerModel2 innerModel2, string property, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            InnerModel2 = innerModel2;
            Property = property;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        private void HandlePropertyChangeEvent(object sender, PropertyChangedEventArgs args)
        {
            _changed = true;
        }

        private InnerModel2 _innerModel2;
        private bool _innerModel2Changed = false;
        public InnerModel2 InnerModel2
        {
            get => _innerModel2;
            set
            {
                _innerModel2 = value;
                _innerModel2Changed = true;
                _innerModel2.PropertyChanged += HandlePropertyChangeEvent;
                _changed = true;
            }
        }

        private string _property;
        private bool _propertyChanged = false;
        public string Property
        {
            get => _property;
            set
            {
                _property = value;
                _propertyChanged = true;
                _changed = true;
            }
        }

        internal bool _changed = false;
    }
}