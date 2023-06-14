// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> A list of services that support encryption. </summary>
    public partial class EncryptionServices
    {
        /// <summary> Initializes a new instance of EncryptionServices. </summary>
        public EncryptionServices()
        {
        }

        /// <summary> Initializes a new instance of EncryptionServices. </summary>
        /// <param name="blob"> The encryption function of the blob storage service. </param>
        /// <param name="file"> The encryption function of the file storage service. </param>
        /// <param name="table"> The encryption function of the table storage service. </param>
        /// <param name="queue"> The encryption function of the queue storage service. </param>
        internal EncryptionServices(EncryptionService blob, EncryptionService file, EncryptionService table, EncryptionService queue)
        {
            Blob = blob;
            File = file;
            Table = table;
            Queue = queue;
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
