// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Model.Usage.Models
{
    /// <summary> Record used in operation parameters. </summary>
    public partial class InputRecord
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="InputRecord"/>. </summary>
        /// <param name="requiredProp"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProp"/> is null. </exception>
        public InputRecord(string requiredProp)
        {
            Argument.AssertNotNull(requiredProp, nameof(requiredProp));

            RequiredProp = requiredProp;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="InputRecord"/>. </summary>
        /// <param name="requiredProp"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InputRecord(string requiredProp, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            RequiredProp = requiredProp;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="InputRecord"/> for deserialization. </summary>
        internal InputRecord()
        {
        }

        /// <summary> Gets the required prop. </summary>
        public string RequiredProp { get; }
    }
}
