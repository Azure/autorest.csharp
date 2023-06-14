// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Contains information about SSH certificate public key and the path on the Linux VM where the public key is placed.
    /// Serialized Name: SshPublicKey
    /// </summary>
    public partial class SshPublicKeyInfo
    {
        /// <summary> Initializes a new instance of SshPublicKeyInfo. </summary>
        public SshPublicKeyInfo()
        {
        }

        /// <summary> Initializes a new instance of SshPublicKeyInfo. </summary>
        /// <param name="path">
        /// Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys
        /// Serialized Name: SshPublicKey.path
        /// </param>
        /// <param name="keyData">
        /// SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format. &lt;br&gt;&lt;br&gt; For creating ssh keys, see [Create SSH keys on Linux and Mac for Linux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
        /// Serialized Name: SshPublicKey.keyData
        /// </param>
        internal SshPublicKeyInfo(string path, string keyData)
        {
            Path = path;
            KeyData = keyData;
        }

        /// <summary>
        /// Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys
        /// Serialized Name: SshPublicKey.path
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format. &lt;br&gt;&lt;br&gt; For creating ssh keys, see [Create SSH keys on Linux and Mac for Linux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
        /// Serialized Name: SshPublicKey.keyData
        /// </summary>
        public string KeyData { get; set; }
    }
}
