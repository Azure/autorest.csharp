// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtMultipleParentResource.Models
{
    /// <summary> Describes a Virtual Machine run command. </summary>
    public partial class ChildBodyUpdate : UpdateResource
    {
        /// <summary> Initializes a new instance of ChildBodyUpdate. </summary>
        public ChildBodyUpdate()
        {
        }

        /// <summary> Optional. If set to true, provisioning will complete as soon as the script starts and will not wait for script to complete. </summary>
        public bool? AsyncExecution { get; set; }
        /// <summary> Specifies the user account on the VM when executing the run command. </summary>
        public string RunAsUser { get; set; }
        /// <summary> Specifies the user account password on the VM when executing the run command. </summary>
        public string RunAsPassword { get; set; }
        /// <summary> The timeout in seconds to execute the run command. </summary>
        public int? TimeoutInSeconds { get; set; }
        /// <summary> Specifies the Azure storage blob where script output stream will be uploaded. </summary>
        public Uri OutputBlobUri { get; set; }
        /// <summary> Specifies the Azure storage blob where script error stream will be uploaded. </summary>
        public Uri ErrorBlobUri { get; set; }
        /// <summary> The provisioning state, which only appears in the response. </summary>
        public string ProvisioningState { get; }
    }
}
