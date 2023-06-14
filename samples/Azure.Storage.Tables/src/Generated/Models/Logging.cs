// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    /// <summary> Azure Analytics Logging settings. </summary>
    public partial class Logging
    {
        /// <summary> Initializes a new instance of Logging. </summary>
        /// <param name="version"> The version of Storage Analytics to configure. </param>
        /// <param name="delete"> Indicates whether all delete requests should be logged. </param>
        /// <param name="read"> Indicates whether all read requests should be logged. </param>
        /// <param name="write"> Indicates whether all write requests should be logged. </param>
        /// <param name="retentionPolicy"> the retention policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="version"/> or <paramref name="retentionPolicy"/> is null. </exception>
        public Logging(string version, bool delete, bool read, bool write, RetentionPolicy retentionPolicy)
        {
            Argument.AssertNotNull(version, nameof(version));
            Argument.AssertNotNull(retentionPolicy, nameof(retentionPolicy));

            Version = version;
            Delete = delete;
            Read = read;
            Write = write;
            RetentionPolicy = retentionPolicy;
        }

        /// <summary> The version of Storage Analytics to configure. </summary>
        public string Version { get; set; }
        /// <summary> Indicates whether all delete requests should be logged. </summary>
        public bool Delete { get; set; }
        /// <summary> Indicates whether all read requests should be logged. </summary>
        public bool Read { get; set; }
        /// <summary> Indicates whether all write requests should be logged. </summary>
        public bool Write { get; set; }
        /// <summary> the retention policy. </summary>
        public RetentionPolicy RetentionPolicy { get; set; }
    }
}
