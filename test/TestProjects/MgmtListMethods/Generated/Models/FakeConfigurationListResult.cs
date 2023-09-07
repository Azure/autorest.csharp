// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    /// <summary> The List of Fake Configuration operation response. </summary>
    public partial class FakeConfigurationListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="FakeConfigurationListResult"/>. </summary>
        public FakeConfigurationListResult()
        {
            Value = new ChangeTrackingList<FakeConfigurationData>();
        }

        /// <summary> Initializes a new instance of <see cref="FakeConfigurationListResult"/>. </summary>
        /// <param name="value"> The list of Fake Configuration. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal FakeConfigurationListResult(IList<FakeConfigurationData> value, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The list of Fake Configuration. </summary>
        public IList<FakeConfigurationData> Value { get; }
    }
}
