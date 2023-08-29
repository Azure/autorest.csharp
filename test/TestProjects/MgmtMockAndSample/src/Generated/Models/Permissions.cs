// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> Permissions the identity has for keys, secrets, certificates and storage. </summary>
    public partial class Permissions
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="Permissions"/>. </summary>
        public Permissions()
        {
            Keys = new ChangeTrackingList<KeyPermission>();
            Secrets = new ChangeTrackingList<SecretPermission>();
            Certificates = new ChangeTrackingList<CertificatePermission>();
            Storage = new ChangeTrackingList<StoragePermission>();
        }

        /// <summary> Initializes a new instance of <see cref="Permissions"/>. </summary>
        /// <param name="keys"> Permissions to keys. </param>
        /// <param name="secrets"> Permissions to secrets. </param>
        /// <param name="certificates"> Permissions to certificates. </param>
        /// <param name="storage"> Permissions to storage accounts. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Permissions(IList<KeyPermission> keys, IList<SecretPermission> secrets, IList<CertificatePermission> certificates, IList<StoragePermission> storage, Dictionary<string, BinaryData> rawData)
        {
            Keys = keys;
            Secrets = secrets;
            Certificates = certificates;
            Storage = storage;
            _rawData = rawData;
        }

        /// <summary> Permissions to keys. </summary>
        public IList<KeyPermission> Keys { get; }
        /// <summary> Permissions to secrets. </summary>
        public IList<SecretPermission> Secrets { get; }
        /// <summary> Permissions to certificates. </summary>
        public IList<CertificatePermission> Certificates { get; }
        /// <summary> Permissions to storage accounts. </summary>
        public IList<StoragePermission> Storage { get; }
    }
}
