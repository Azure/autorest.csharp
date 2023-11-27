// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace MgmtAcronymMapping.Models
{
    /// <summary>
    /// Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. &lt;br&gt;&lt;br&gt; You can easily view the output of your console log. &lt;br&gt;&lt;br&gt; Azure also enables you to see a screenshot of the VM from the hypervisor.
    /// Serialized Name: BootDiagnostics
    /// </summary>
    public partial class BootDiagnostics
    {
        /// <summary> Initializes a new instance of <see cref="BootDiagnostics"/>. </summary>
        public BootDiagnostics()
        {
        }

        /// <summary> Initializes a new instance of <see cref="BootDiagnostics"/>. </summary>
        /// <param name="enabled">
        /// Whether boot diagnostics should be enabled on the Virtual Machine.
        /// Serialized Name: BootDiagnostics.enabled
        /// </param>
        /// <param name="storageUri">
        /// Uri of the storage account to use for placing the console output and screenshot. &lt;br&gt;&lt;br&gt;If storageUri is not specified while enabling boot diagnostics, managed storage will be used.
        /// Serialized Name: BootDiagnostics.storageUri
        /// </param>
        internal BootDiagnostics(bool? enabled, Uri storageUri)
        {
            Enabled = enabled;
            StorageUri = storageUri;
        }

        /// <summary>
        /// Whether boot diagnostics should be enabled on the Virtual Machine.
        /// Serialized Name: BootDiagnostics.enabled
        /// </summary>
        public bool? Enabled { get; set; }
        /// <summary>
        /// Uri of the storage account to use for placing the console output and screenshot. &lt;br&gt;&lt;br&gt;If storageUri is not specified while enabling boot diagnostics, managed storage will be used.
        /// Serialized Name: BootDiagnostics.storageUri
        /// </summary>
        public Uri StorageUri { get; set; }
    }
}
