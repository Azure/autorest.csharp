// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies the boot diagnostic settings state. &lt;br&gt;&lt;br&gt;Minimum api-version: 2015-06-15.
    /// Serialized Name: DiagnosticsProfile
    /// </summary>
    internal partial class DiagnosticsProfile
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.DiagnosticsProfile
        ///
        /// </summary>
        public DiagnosticsProfile()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.DiagnosticsProfile
        ///
        /// </summary>
        /// <param name="bootDiagnostics">
        /// Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. &lt;br&gt;&lt;br&gt; You can easily view the output of your console log. &lt;br&gt;&lt;br&gt; Azure also enables you to see a screenshot of the VM from the hypervisor.
        /// Serialized Name: DiagnosticsProfile.bootDiagnostics
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DiagnosticsProfile(BootDiagnostics bootDiagnostics, Dictionary<string, BinaryData> rawData)
        {
            BootDiagnostics = bootDiagnostics;
            _rawData = rawData;
        }

        /// <summary>
        /// Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. &lt;br&gt;&lt;br&gt; You can easily view the output of your console log. &lt;br&gt;&lt;br&gt; Azure also enables you to see a screenshot of the VM from the hypervisor.
        /// Serialized Name: DiagnosticsProfile.bootDiagnostics
        /// </summary>
        public BootDiagnostics BootDiagnostics { get; set; }
    }
}
