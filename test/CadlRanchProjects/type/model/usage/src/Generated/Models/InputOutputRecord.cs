// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Model.Usage.Models
{
    /// <summary> Record used both as operation parameter and return type. </summary>
    public partial class InputOutputRecord
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="InputOutputRecord"/>. </summary>
        /// <param name="requiredProp"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProp"/> is null. </exception>
        public InputOutputRecord(string requiredProp)
        {
            Argument.AssertNotNull(requiredProp, nameof(requiredProp));

            RequiredProp = requiredProp;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="InputOutputRecord"/>. </summary>
        /// <param name="requiredProp"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InputOutputRecord(string requiredProp, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            RequiredProp = requiredProp;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="InputOutputRecord"/> for deserialization. </summary>
        internal InputOutputRecord()
        {
        }

        /// <summary> Gets or sets the required prop. </summary>
        public string RequiredProp { get; set; }
    }
}
