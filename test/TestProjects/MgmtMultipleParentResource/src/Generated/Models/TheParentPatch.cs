// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtMultipleParentResource.Models
{
    /// <summary> Describes a Virtual Machine run command. </summary>
    public partial class TheParentPatch : UpdateResource
    {
        /// <summary> Initializes a new instance of <see cref="TheParentPatch"/>. </summary>
        public TheParentPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="TheParentPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="asyncExecution"> Optional. If set to true, provisioning will complete as soon as the script starts and will not wait for script to complete. </param>
        /// <param name="runAsUser"> Specifies the user account on the VM when executing the run command. </param>
        /// <param name="runAsPassword"> Specifies the user account password on the VM when executing the run command. </param>
        /// <param name="timeoutInSeconds"> The timeout in seconds to execute the run command. </param>
        /// <param name="outputBlobUri"> Specifies the Azure storage blob where script output stream will be uploaded. </param>
        /// <param name="errorBlobUri"> Specifies the Azure storage blob where script error stream will be uploaded. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        internal TheParentPatch(IDictionary<string, string> tags, bool? asyncExecution, string runAsUser, string runAsPassword, int? timeoutInSeconds, Uri outputBlobUri, Uri errorBlobUri, string provisioningState) : base(tags)
        {
            AsyncExecution = asyncExecution;
            RunAsUser = runAsUser;
            RunAsPassword = runAsPassword;
            TimeoutInSeconds = timeoutInSeconds;
            OutputBlobUri = outputBlobUri;
            ErrorBlobUri = errorBlobUri;
            ProvisioningState = provisioningState;
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
