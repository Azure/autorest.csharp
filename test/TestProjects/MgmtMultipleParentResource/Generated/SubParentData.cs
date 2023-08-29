// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtMultipleParentResource
{
    /// <summary>
    /// A class representing the SubParent data model.
    /// Describes a Virtual Machine run command.
    /// </summary>
    public partial class SubParentData : TrackedResourceData
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtMultipleParentResource.SubParentData
        ///
        /// </summary>
        /// <param name="location"> The location. </param>
        public SubParentData(AzureLocation location) : base(location)
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtMultipleParentResource.SubParentData
        ///
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="asyncExecution"> Optional. If set to true, provisioning will complete as soon as the script starts and will not wait for script to complete. </param>
        /// <param name="runAsUser"> Specifies the user account on the VM when executing the run command. </param>
        /// <param name="runAsPassword"> Specifies the user account password on the VM when executing the run command. </param>
        /// <param name="timeoutInSeconds"> The timeout in seconds to execute the run command. </param>
        /// <param name="outputBlobUri"> Specifies the Azure storage blob where script output stream will be uploaded. </param>
        /// <param name="errorBlobUri"> Specifies the Azure storage blob where script error stream will be uploaded. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SubParentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, bool? asyncExecution, string runAsUser, string runAsPassword, int? timeoutInSeconds, Uri outputBlobUri, Uri errorBlobUri, string provisioningState, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData, tags, location)
        {
            AsyncExecution = asyncExecution;
            RunAsUser = runAsUser;
            RunAsPassword = runAsPassword;
            TimeoutInSeconds = timeoutInSeconds;
            OutputBlobUri = outputBlobUri;
            ErrorBlobUri = errorBlobUri;
            ProvisioningState = provisioningState;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="SubParentData"/> for deserialization. </summary>
        internal SubParentData()
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
