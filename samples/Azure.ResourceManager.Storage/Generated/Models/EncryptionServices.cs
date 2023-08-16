// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> A list of services that support encryption. </summary>
    public partial class EncryptionServices
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.EncryptionServices
        ///
        /// </summary>
        public EncryptionServices()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Storage.Models.EncryptionServices
        ///
        /// </summary>
        /// <param name="blob"> The encryption function of the blob storage service. </param>
        /// <param name="file"> The encryption function of the file storage service. </param>
        /// <param name="table"> The encryption function of the table storage service. </param>
        /// <param name="queue"> The encryption function of the queue storage service. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal EncryptionServices(EncryptionService blob, EncryptionService file, EncryptionService table, EncryptionService queue, Dictionary<string, BinaryData> rawData)
        {
            Blob = blob;
            File = file;
            Table = table;
            Queue = queue;
            _rawData = rawData;
        }

        /// <summary> The encryption function of the blob storage service. </summary>
        public EncryptionService Blob { get; set; }
        /// <summary> The encryption function of the file storage service. </summary>
        public EncryptionService File { get; set; }
        /// <summary> The encryption function of the table storage service. </summary>
        public EncryptionService Table { get; set; }
        /// <summary> The encryption function of the queue storage service. </summary>
        public EncryptionService Queue { get; set; }
    }
}
