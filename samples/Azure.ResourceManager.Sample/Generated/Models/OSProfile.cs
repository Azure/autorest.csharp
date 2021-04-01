// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> Specifies the operating system settings for the virtual machine. Some of the settings cannot be changed once VM is provisioned. </summary>
    public partial class OSProfile
    {
        /// <summary> Initializes a new instance of OSProfile. </summary>
        public OSProfile()
        {
            Secrets = new ChangeTrackingList<VaultSecretGroup>();
        }

        /// <summary> Initializes a new instance of OSProfile. </summary>
        /// <param name="computerName"> Specifies the host OS name of the virtual machine. &lt;br&gt;&lt;br&gt; This name cannot be updated after the VM is created. &lt;br&gt;&lt;br&gt; **Max-length (Windows):** 15 characters &lt;br&gt;&lt;br&gt; **Max-length (Linux):** 64 characters. &lt;br&gt;&lt;br&gt; For naming conventions and restrictions see [Azure infrastructure services implementation guidelines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-infrastructure-subscription-accounts-guidelines?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json#1-naming-conventions). </param>
        /// <param name="adminUsername"> Specifies the name of the administrator account. &lt;br&gt;&lt;br&gt; This property cannot be updated after the VM is created. &lt;br&gt;&lt;br&gt; **Windows-only restriction:** Cannot end in &quot;.&quot; &lt;br&gt;&lt;br&gt; **Disallowed values:** &quot;administrator&quot;, &quot;admin&quot;, &quot;user&quot;, &quot;user1&quot;, &quot;test&quot;, &quot;user2&quot;, &quot;test1&quot;, &quot;user3&quot;, &quot;admin1&quot;, &quot;1&quot;, &quot;123&quot;, &quot;a&quot;, &quot;actuser&quot;, &quot;adm&quot;, &quot;admin2&quot;, &quot;aspnet&quot;, &quot;backup&quot;, &quot;console&quot;, &quot;david&quot;, &quot;guest&quot;, &quot;john&quot;, &quot;owner&quot;, &quot;root&quot;, &quot;server&quot;, &quot;sql&quot;, &quot;support&quot;, &quot;support_388945a0&quot;, &quot;sys&quot;, &quot;test2&quot;, &quot;test3&quot;, &quot;user4&quot;, &quot;user5&quot;. &lt;br&gt;&lt;br&gt; **Minimum-length (Linux):** 1  character &lt;br&gt;&lt;br&gt; **Max-length (Linux):** 64 characters &lt;br&gt;&lt;br&gt; **Max-length (Windows):** 20 characters  &lt;br&gt;&lt;br&gt;&lt;li&gt; For root access to the Linux VM, see [Using root privileges on Linux virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-use-root-privileges?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)&lt;br&gt;&lt;li&gt; For a list of built-in system users on Linux that should not be used in this field, see [Selecting User Names for Linux on Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-usernames?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json). </param>
        /// <param name="adminPassword"> Specifies the password of the administrator account. &lt;br&gt;&lt;br&gt; **Minimum-length (Windows):** 8 characters &lt;br&gt;&lt;br&gt; **Minimum-length (Linux):** 6 characters &lt;br&gt;&lt;br&gt; **Max-length (Windows):** 123 characters &lt;br&gt;&lt;br&gt; **Max-length (Linux):** 72 characters &lt;br&gt;&lt;br&gt; **Complexity requirements:** 3 out of 4 conditions below need to be fulfilled &lt;br&gt; Has lower characters &lt;br&gt;Has upper characters &lt;br&gt; Has a digit &lt;br&gt; Has a special character (Regex match [\W_]) &lt;br&gt;&lt;br&gt; **Disallowed values:** &quot;abc@123&quot;, &quot;P@$$w0rd&quot;, &quot;P@ssw0rd&quot;, &quot;P@ssword123&quot;, &quot;Pa$$word&quot;, &quot;pass@word1&quot;, &quot;Password!&quot;, &quot;Password1&quot;, &quot;Password22&quot;, &quot;iloveyou!&quot; &lt;br&gt;&lt;br&gt; For resetting the password, see [How to reset the Remote Desktop service or its login password in a Windows VM](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-reset-rdp?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; For resetting root password, see [Manage users, SSH, and check or repair disks on Azure Linux VMs using the VMAccess Extension](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-vmaccess-extension?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json#reset-root-password). </param>
        /// <param name="customData"> Specifies a base-64 encoded string of custom data. The base-64 encoded string is decoded to a binary array that is saved as a file on the Virtual Machine. The maximum length of the binary array is 65535 bytes. &lt;br&gt;&lt;br&gt; **Note: Do not pass any secrets or passwords in customData property** &lt;br&gt;&lt;br&gt; This property cannot be updated after the VM is created. &lt;br&gt;&lt;br&gt; customData is passed to the VM to be saved as a file, for more information see [Custom Data on Azure VMs](https://azure.microsoft.com/en-us/blog/custom-data-and-cloud-init-on-windows-azure/) &lt;br&gt;&lt;br&gt; For using cloud-init for your Linux VM, see [Using cloud-init to customize a Linux VM during creation](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-cloud-init?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json). </param>
        /// <param name="windowsConfiguration"> Specifies Windows operating system settings on the virtual machine. </param>
        /// <param name="linuxConfiguration"> Specifies the Linux operating system settings on the virtual machine. &lt;br&gt;&lt;br&gt;For a list of supported Linux distributions, see [Linux on Azure-Endorsed Distributions](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-endorsed-distros?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json) &lt;br&gt;&lt;br&gt; For running non-endorsed distributions, see [Information for Non-Endorsed Distributions](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-create-upload-generic?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json). </param>
        /// <param name="secrets"> Specifies set of certificates that should be installed onto the virtual machine. </param>
        /// <param name="allowExtensionOperations"> Specifies whether extension operations should be allowed on the virtual machine. &lt;br&gt;&lt;br&gt;This may only be set to False when no extensions are present on the virtual machine. </param>
        /// <param name="requireGuestProvisionSignal"> Specifies whether the guest provision signal is required to infer provision success of the virtual machine.  **Note: This property is for private testing only, and all customers must not set the property to false.**. </param>
        internal OSProfile(string computerName, string adminUsername, string adminPassword, string customData, WindowsConfiguration windowsConfiguration, LinuxConfiguration linuxConfiguration, IList<VaultSecretGroup> secrets, bool? allowExtensionOperations, bool? requireGuestProvisionSignal)
        {
            ComputerName = computerName;
            AdminUsername = adminUsername;
            AdminPassword = adminPassword;
            CustomData = customData;
            WindowsConfiguration = windowsConfiguration;
            LinuxConfiguration = linuxConfiguration;
            Secrets = secrets;
            AllowExtensionOperations = allowExtensionOperations;
            RequireGuestProvisionSignal = requireGuestProvisionSignal;
        }

        /// <summary> Specifies the host OS name of the virtual machine. &lt;br&gt;&lt;br&gt; This name cannot be updated after the VM is created. &lt;br&gt;&lt;br&gt; **Max-length (Windows):** 15 characters &lt;br&gt;&lt;br&gt; **Max-length (Linux):** 64 characters. &lt;br&gt;&lt;br&gt; For naming conventions and restrictions see [Azure infrastructure services implementation guidelines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-infrastructure-subscription-accounts-guidelines?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json#1-naming-conventions). </summary>
        public string ComputerName { get; set; }
        /// <summary> Specifies the name of the administrator account. &lt;br&gt;&lt;br&gt; This property cannot be updated after the VM is created. &lt;br&gt;&lt;br&gt; **Windows-only restriction:** Cannot end in &quot;.&quot; &lt;br&gt;&lt;br&gt; **Disallowed values:** &quot;administrator&quot;, &quot;admin&quot;, &quot;user&quot;, &quot;user1&quot;, &quot;test&quot;, &quot;user2&quot;, &quot;test1&quot;, &quot;user3&quot;, &quot;admin1&quot;, &quot;1&quot;, &quot;123&quot;, &quot;a&quot;, &quot;actuser&quot;, &quot;adm&quot;, &quot;admin2&quot;, &quot;aspnet&quot;, &quot;backup&quot;, &quot;console&quot;, &quot;david&quot;, &quot;guest&quot;, &quot;john&quot;, &quot;owner&quot;, &quot;root&quot;, &quot;server&quot;, &quot;sql&quot;, &quot;support&quot;, &quot;support_388945a0&quot;, &quot;sys&quot;, &quot;test2&quot;, &quot;test3&quot;, &quot;user4&quot;, &quot;user5&quot;. &lt;br&gt;&lt;br&gt; **Minimum-length (Linux):** 1  character &lt;br&gt;&lt;br&gt; **Max-length (Linux):** 64 characters &lt;br&gt;&lt;br&gt; **Max-length (Windows):** 20 characters  &lt;br&gt;&lt;br&gt;&lt;li&gt; For root access to the Linux VM, see [Using root privileges on Linux virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-use-root-privileges?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json)&lt;br&gt;&lt;li&gt; For a list of built-in system users on Linux that should not be used in this field, see [Selecting User Names for Linux on Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-usernames?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json). </summary>
        public string AdminUsername { get; set; }
        /// <summary> Specifies the password of the administrator account. &lt;br&gt;&lt;br&gt; **Minimum-length (Windows):** 8 characters &lt;br&gt;&lt;br&gt; **Minimum-length (Linux):** 6 characters &lt;br&gt;&lt;br&gt; **Max-length (Windows):** 123 characters &lt;br&gt;&lt;br&gt; **Max-length (Linux):** 72 characters &lt;br&gt;&lt;br&gt; **Complexity requirements:** 3 out of 4 conditions below need to be fulfilled &lt;br&gt; Has lower characters &lt;br&gt;Has upper characters &lt;br&gt; Has a digit &lt;br&gt; Has a special character (Regex match [\W_]) &lt;br&gt;&lt;br&gt; **Disallowed values:** &quot;abc@123&quot;, &quot;P@$$w0rd&quot;, &quot;P@ssw0rd&quot;, &quot;P@ssword123&quot;, &quot;Pa$$word&quot;, &quot;pass@word1&quot;, &quot;Password!&quot;, &quot;Password1&quot;, &quot;Password22&quot;, &quot;iloveyou!&quot; &lt;br&gt;&lt;br&gt; For resetting the password, see [How to reset the Remote Desktop service or its login password in a Windows VM](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-reset-rdp?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; For resetting root password, see [Manage users, SSH, and check or repair disks on Azure Linux VMs using the VMAccess Extension](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-vmaccess-extension?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json#reset-root-password). </summary>
        public string AdminPassword { get; set; }
        /// <summary> Specifies a base-64 encoded string of custom data. The base-64 encoded string is decoded to a binary array that is saved as a file on the Virtual Machine. The maximum length of the binary array is 65535 bytes. &lt;br&gt;&lt;br&gt; **Note: Do not pass any secrets or passwords in customData property** &lt;br&gt;&lt;br&gt; This property cannot be updated after the VM is created. &lt;br&gt;&lt;br&gt; customData is passed to the VM to be saved as a file, for more information see [Custom Data on Azure VMs](https://azure.microsoft.com/en-us/blog/custom-data-and-cloud-init-on-windows-azure/) &lt;br&gt;&lt;br&gt; For using cloud-init for your Linux VM, see [Using cloud-init to customize a Linux VM during creation](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-using-cloud-init?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json). </summary>
        public string CustomData { get; set; }
        /// <summary> Specifies Windows operating system settings on the virtual machine. </summary>
        public WindowsConfiguration WindowsConfiguration { get; set; }
        /// <summary> Specifies the Linux operating system settings on the virtual machine. &lt;br&gt;&lt;br&gt;For a list of supported Linux distributions, see [Linux on Azure-Endorsed Distributions](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-endorsed-distros?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json) &lt;br&gt;&lt;br&gt; For running non-endorsed distributions, see [Information for Non-Endorsed Distributions](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-create-upload-generic?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json). </summary>
        public LinuxConfiguration LinuxConfiguration { get; set; }
        /// <summary> Specifies set of certificates that should be installed onto the virtual machine. </summary>
        public IList<VaultSecretGroup> Secrets { get; }
        /// <summary> Specifies whether extension operations should be allowed on the virtual machine. &lt;br&gt;&lt;br&gt;This may only be set to False when no extensions are present on the virtual machine. </summary>
        public bool? AllowExtensionOperations { get; set; }
        /// <summary> Specifies whether the guest provision signal is required to infer provision success of the virtual machine.  **Note: This property is for private testing only, and all customers must not set the property to false.**. </summary>
        public bool? RequireGuestProvisionSignal { get; set; }
    }
}
