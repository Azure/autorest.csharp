// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> An MX record. </summary>
    public partial class MxRecord
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="MxRecord"/>. </summary>
        public MxRecord()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MxRecord"/>. </summary>
        /// <param name="preference"> The preference value for this MX record. </param>
        /// <param name="exchange"> The domain name of the mail host for this MX record. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MxRecord(int? preference, string exchange, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Preference = preference;
            Exchange = exchange;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The preference value for this MX record. </summary>
        public int? Preference { get; set; }
        /// <summary> The domain name of the mail host for this MX record. </summary>
        public string Exchange { get; set; }
    }
}
