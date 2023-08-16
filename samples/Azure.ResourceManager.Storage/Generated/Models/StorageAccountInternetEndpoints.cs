// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The URIs that are used to perform a retrieval of a public blob, file, web or dfs object via a internet routing endpoint. </summary>
    public partial class StorageAccountInternetEndpoints
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints
        ///
        /// </summary>
        internal StorageAccountInternetEndpoints()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.StorageAccountInternetEndpoints
        ///
        /// </summary>
        /// <param name="blob"> Gets the blob endpoint. </param>
        /// <param name="file"> Gets the file endpoint. </param>
        /// <param name="web"> Gets the web endpoint. </param>
        /// <param name="dfs"> Gets the dfs endpoint. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal StorageAccountInternetEndpoints(string blob, string file, string web, string dfs, Dictionary<string, BinaryData> rawData)
        {
            Blob = blob;
            File = file;
            Web = web;
            Dfs = dfs;
            _rawData = rawData;
        }

        /// <summary> Gets the blob endpoint. </summary>
        public string Blob { get; }
        /// <summary> Gets the file endpoint. </summary>
        public string File { get; }
        /// <summary> Gets the web endpoint. </summary>
        public string Web { get; }
        /// <summary> Gets the dfs endpoint. </summary>
        public string Dfs { get; }
    }
}
