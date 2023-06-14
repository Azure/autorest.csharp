// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> An Azure Storage blob. </summary>
    public partial class Blob
    {
        /// <summary> Initializes a new instance of Blob. </summary>
        /// <param name="name"></param>
        /// <param name="deleted"></param>
        /// <param name="snapshot"></param>
        /// <param name="properties"> Properties of a blob. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="snapshot"/> or <paramref name="properties"/> is null. </exception>
        internal Blob(string name, bool deleted, string snapshot, BlobProperties properties)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(snapshot, nameof(snapshot));
            Argument.AssertNotNull(properties, nameof(properties));

            Name = name;
            Deleted = deleted;
            Snapshot = snapshot;
            Properties = properties;
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of Blob. </summary>
        /// <param name="name"></param>
        /// <param name="deleted"></param>
        /// <param name="snapshot"></param>
        /// <param name="properties"> Properties of a blob. </param>
        /// <param name="metadata"> Dictionary of &lt;string&gt;. </param>
        internal Blob(string name, bool deleted, string snapshot, BlobProperties properties, IReadOnlyDictionary<string, string> metadata)
        {
            Name = name;
            Deleted = deleted;
            Snapshot = snapshot;
            Properties = properties;
            Metadata = metadata;
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
        /// <summary> Gets the deleted. </summary>
        public bool Deleted { get; }
        /// <summary> Gets the snapshot. </summary>
        public string Snapshot { get; }
        /// <summary> Properties of a blob. </summary>
        public BlobProperties Properties { get; }
        /// <summary> Dictionary of &lt;string&gt;. </summary>
        public IReadOnlyDictionary<string, string> Metadata { get; }
    }
}
