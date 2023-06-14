// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The URIs that are used to perform a retrieval of a public blob, queue, table, web or dfs object. </summary>
    public partial class Endpoints
    {
        /// <summary> Initializes a new instance of Endpoints. </summary>
        internal Endpoints()
        {
        }

        /// <summary> Initializes a new instance of Endpoints. </summary>
        /// <param name="blob"> Gets the blob endpoint. </param>
        /// <param name="queue"> Gets the queue endpoint. </param>
        /// <param name="table"> Gets the table endpoint. </param>
        /// <param name="file"> Gets the file endpoint. </param>
        /// <param name="web"> Gets the web endpoint. </param>
        /// <param name="dfs"> Gets the dfs endpoint. </param>
        /// <param name="microsoftEndpoints"> Gets the microsoft routing storage endpoints. </param>
        /// <param name="internetEndpoints"> Gets the internet routing storage endpoints. </param>
        internal Endpoints(string blob, string queue, string table, string file, string web, string dfs, StorageAccountMicrosoftEndpoints microsoftEndpoints, StorageAccountInternetEndpoints internetEndpoints)
        {
            Blob = blob;
            Queue = queue;
            Table = table;
            File = file;
            Web = web;
            Dfs = dfs;
            MicrosoftEndpoints = microsoftEndpoints;
            InternetEndpoints = internetEndpoints;
        }

        /// <summary> Gets the blob endpoint. </summary>
        public string Blob { get; }
        /// <summary> Gets the queue endpoint. </summary>
        public string Queue { get; }
        /// <summary> Gets the table endpoint. </summary>
        public string Table { get; }
        /// <summary> Gets the file endpoint. </summary>
        public string File { get; }
        /// <summary> Gets the web endpoint. </summary>
        public string Web { get; }
        /// <summary> Gets the dfs endpoint. </summary>
        public string Dfs { get; }
        /// <summary> Gets the microsoft routing storage endpoints. </summary>
        public StorageAccountMicrosoftEndpoints MicrosoftEndpoints { get; }
        /// <summary> Gets the internet routing storage endpoints. </summary>
        public StorageAccountInternetEndpoints InternetEndpoints { get; }
    }
}
