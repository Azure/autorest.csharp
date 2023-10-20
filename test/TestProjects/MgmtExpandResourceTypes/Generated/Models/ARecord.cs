// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> An A record. </summary>
    public partial class ARecord
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ARecord"/>. </summary>
        public ARecord()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ARecord"/>. </summary>
        /// <param name="ipv4Address"> The IPv4 address of this A record. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ARecord(string ipv4Address, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Ipv4Address = ipv4Address;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The IPv4 address of this A record. </summary>
        public string Ipv4Address { get; set; }
    }
}
