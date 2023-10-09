// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Tables
{
    /// <summary>
    /// Options for a TableClient.
    /// </summary>
    public class TableClientOptions : ClientOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableClientOptions"/> class.
        /// </summary>
        /// <param name="version">The version to use.</param>
        public TableClientOptions(ServiceVersion version = ServiceVersion.V2019_05_09)
        {
            Version = version;
        }

        /// <summary>
        /// Gets the service version of the service API used when making requests.
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// The service versions.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V2019_02_02 service version described at.
            /// </summary>
            V2019_05_09 = 1,
        }
    }
}
