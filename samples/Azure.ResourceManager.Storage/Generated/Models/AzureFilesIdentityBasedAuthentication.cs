// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Settings for Azure Files identity based authentication. </summary>
    public partial class AzureFilesIdentityBasedAuthentication
    {
        /// <summary> Initializes a new instance of AzureFilesIdentityBasedAuthentication. </summary>
        /// <param name="directoryServiceOptions"> Indicates the directory service used. </param>
        public AzureFilesIdentityBasedAuthentication(DirectoryServiceOption directoryServiceOptions)
        {
            DirectoryServiceOptions = directoryServiceOptions;
        }

        /// <summary> Initializes a new instance of AzureFilesIdentityBasedAuthentication. </summary>
        /// <param name="directoryServiceOptions"> Indicates the directory service used. </param>
        /// <param name="activeDirectoryProperties"> Required if choose AD. </param>
        /// <param name="defaultSharePermission"> Default share permission for users using Kerberos authentication if RBAC role is not assigned. </param>
        internal AzureFilesIdentityBasedAuthentication(DirectoryServiceOption directoryServiceOptions, ActiveDirectoryProperties activeDirectoryProperties, DefaultSharePermission? defaultSharePermission)
        {
            DirectoryServiceOptions = directoryServiceOptions;
            ActiveDirectoryProperties = activeDirectoryProperties;
            DefaultSharePermission = defaultSharePermission;
        }

        /// <summary> Indicates the directory service used. </summary>
        public DirectoryServiceOption DirectoryServiceOptions { get; set; }
        /// <summary> Required if choose AD. </summary>
        public ActiveDirectoryProperties ActiveDirectoryProperties { get; set; }
        /// <summary> Default share permission for users using Kerberos authentication if RBAC role is not assigned. </summary>
        public DefaultSharePermission? DefaultSharePermission { get; set; }
    }
}
