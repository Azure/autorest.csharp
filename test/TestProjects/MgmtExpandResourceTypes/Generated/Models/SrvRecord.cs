// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> An SRV record. </summary>
    public partial class SrvRecord
    {
        /// <summary> Initializes a new instance of SrvRecord. </summary>
        public SrvRecord()
        {
        }

        /// <summary> Initializes a new instance of SrvRecord. </summary>
        /// <param name="priority"> The priority value for this SRV record. </param>
        /// <param name="weight"> The weight value for this SRV record. </param>
        /// <param name="port"> The port value for this SRV record. </param>
        /// <param name="target"> The target domain name for this SRV record. </param>
        internal SrvRecord(int? priority, int? weight, int? port, string target)
        {
            Priority = priority;
            Weight = weight;
            Port = port;
            Target = target;
        }

        /// <summary> The priority value for this SRV record. </summary>
        public int? Priority { get; set; }
        /// <summary> The weight value for this SRV record. </summary>
        public int? Weight { get; set; }
        /// <summary> The port value for this SRV record. </summary>
        public int? Port { get; set; }
        /// <summary> The target domain name for this SRV record. </summary>
        public string Target { get; set; }
    }
}
