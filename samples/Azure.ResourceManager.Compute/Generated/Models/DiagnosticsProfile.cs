// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Compute
{
    /// <summary> Specifies the boot diagnostic settings state. &lt;br&gt;&lt;br&gt;Minimum api-version: 2015-06-15. </summary>
    public partial class DiagnosticsProfile
    {
        /// <summary> Initializes a new instance of DiagnosticsProfile. </summary>
        public DiagnosticsProfile()
        {
        }

        /// <summary> Initializes a new instance of DiagnosticsProfile. </summary>
        /// <param name="bootDiagnostics"> Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. &lt;br&gt;&lt;br&gt; You can easily view the output of your console log. &lt;br&gt;&lt;br&gt; Azure also enables you to see a screenshot of the VM from the hypervisor. </param>
        internal DiagnosticsProfile(BootDiagnostics bootDiagnostics)
        {
            BootDiagnostics = bootDiagnostics;
        }

        /// <summary> Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. &lt;br&gt;&lt;br&gt; You can easily view the output of your console log. &lt;br&gt;&lt;br&gt; Azure also enables you to see a screenshot of the VM from the hypervisor. </summary>
        public BootDiagnostics BootDiagnostics { get; set; }
    }
}
