// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Storage.Tables.Models
{
    /// <summary> the retention policy. </summary>
    public partial class RetentionPolicy
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="RetentionPolicy"/>. </summary>
        /// <param name="enabled"> Indicates whether a retention policy is enabled for the storage service. </param>
        public RetentionPolicy(bool enabled)
        {
            Enabled = enabled;
        }

        /// <summary> Initializes a new instance of <see cref="RetentionPolicy"/>. </summary>
        /// <param name="enabled"> Indicates whether a retention policy is enabled for the storage service. </param>
        /// <param name="days"> Indicates the number of days that metrics or logging or soft-deleted data should be retained. All data older than this value will be deleted. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal RetentionPolicy(bool enabled, int? days, Dictionary<string, BinaryData> rawData)
        {
            Enabled = enabled;
            Days = days;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="RetentionPolicy"/> for deserialization. </summary>
        internal RetentionPolicy()
        {
        }

        /// <summary> Indicates whether a retention policy is enabled for the storage service. </summary>
        public bool Enabled { get; set; }
        /// <summary> Indicates the number of days that metrics or logging or soft-deleted data should be retained. All data older than this value will be deleted. </summary>
        public int? Days { get; set; }
    }
}
