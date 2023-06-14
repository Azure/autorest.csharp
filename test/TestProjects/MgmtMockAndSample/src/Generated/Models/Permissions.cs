// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> Permissions the identity has for keys, secrets, certificates and storage. </summary>
    public partial class Permissions
    {
        /// <summary> Initializes a new instance of Permissions. </summary>
        public Permissions()
        {
            Keys = new ChangeTrackingList<KeyPermission>();
            Secrets = new ChangeTrackingList<SecretPermission>();
            Certificates = new ChangeTrackingList<CertificatePermission>();
            Storage = new ChangeTrackingList<StoragePermission>();
        }

        /// <summary> Initializes a new instance of Permissions. </summary>
        /// <param name="keys"> Permissions to keys. </param>
        /// <param name="secrets"> Permissions to secrets. </param>
        /// <param name="certificates"> Permissions to certificates. </param>
        /// <param name="storage"> Permissions to storage accounts. </param>
        internal Permissions(IList<KeyPermission> keys, IList<SecretPermission> secrets, IList<CertificatePermission> certificates, IList<StoragePermission> storage)
        {
            Keys = keys;
            Secrets = secrets;
            Certificates = certificates;
            Storage = storage;
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
