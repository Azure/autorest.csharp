// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary> The instance view of a virtual machine boot diagnostics. </summary>
    public partial class BootDiagnosticsInstanceView
    {
        /// <summary> Initializes a new instance of BootDiagnosticsInstanceView. </summary>
        internal BootDiagnosticsInstanceView()
        {
        }

        /// <summary> Initializes a new instance of BootDiagnosticsInstanceView. </summary>
        /// <param name="consoleScreenshotBlobUri"> The console screenshot blob URI. &lt;br&gt;&lt;br&gt;NOTE: This will **not** be set if boot diagnostics is currently enabled with managed storage. </param>
        /// <param name="serialConsoleLogBlobUri"> The serial console log blob Uri. &lt;br&gt;&lt;br&gt;NOTE: This will **not** be set if boot diagnostics is currently enabled with managed storage. </param>
        /// <param name="status"> The boot diagnostics status information for the VM. &lt;br&gt;&lt;br&gt; NOTE: It will be set only if there are errors encountered in enabling boot diagnostics. </param>
        internal BootDiagnosticsInstanceView(string consoleScreenshotBlobUri, string serialConsoleLogBlobUri, InstanceViewStatus status)
        {
            ConsoleScreenshotBlobUri = consoleScreenshotBlobUri;
            SerialConsoleLogBlobUri = serialConsoleLogBlobUri;
            Status = status;
        }

        /// <summary> The console screenshot blob URI. &lt;br&gt;&lt;br&gt;NOTE: This will **not** be set if boot diagnostics is currently enabled with managed storage. </summary>
        public string ConsoleScreenshotBlobUri { get; }
        /// <summary> The serial console log blob Uri. &lt;br&gt;&lt;br&gt;NOTE: This will **not** be set if boot diagnostics is currently enabled with managed storage. </summary>
        public string SerialConsoleLogBlobUri { get; }
        /// <summary> The boot diagnostics status information for the VM. &lt;br&gt;&lt;br&gt; NOTE: It will be set only if there are errors encountered in enabling boot diagnostics. </summary>
        public InstanceViewStatus Status { get; }
    }
}
