// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> An A record. </summary>
    public partial class ARecord
    {
        /// <summary> Initializes a new instance of ARecord. </summary>
        public ARecord()
        {
        }

        /// <summary> Initializes a new instance of ARecord. </summary>
        /// <param name="ipv4Address"> The IPv4 address of this A record. </param>
        internal ARecord(string ipv4Address)
        {
            Ipv4Address = ipv4Address;
        }

        /// <summary> The IPv4 address of this A record. </summary>
        public string Ipv4Address { get; set; }
    }
}
