// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtMultipleParentResource;

namespace MgmtMultipleParentResource.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtMultipleParentResourceModelFactory
    {
        /// <summary>
        /// Initializes a new instance of global::MgmtMultipleParentResource.AnotherParentData
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
        /// <returns> A new <see cref="MgmtMultipleParentResource.AnotherParentData"/> instance for mocking. </returns>
        public static AnotherParentData AnotherParentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, bool? asyncExecution = null, string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = null, Uri outputBlobUri = null, Uri errorBlobUri = null, string provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();

            return new AnotherParentData(id, name, resourceType, systemData, tags, location, asyncExecution, runAsUser, runAsPassword, timeoutInSeconds, outputBlobUri, errorBlobUri, provisioningState, default);
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtMultipleParentResource.Models.AnotherParentPatch
        ///
        /// </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="asyncExecution"> Optional. If set to true, provisioning will complete as soon as the script starts and will not wait for script to complete. </param>
        /// <param name="runAsUser"> Specifies the user account on the VM when executing the run command. </param>
        /// <param name="runAsPassword"> Specifies the user account password on the VM when executing the run command. </param>
        /// <param name="timeoutInSeconds"> The timeout in seconds to execute the run command. </param>
        /// <param name="outputBlobUri"> Specifies the Azure storage blob where script output stream will be uploaded. </param>
        /// <param name="errorBlobUri"> Specifies the Azure storage blob where script error stream will be uploaded. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <returns> A new <see cref="Models.AnotherParentPatch"/> instance for mocking. </returns>
        public static AnotherParentPatch AnotherParentPatch(IDictionary<string, string> tags = null, bool? asyncExecution = null, string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = null, Uri outputBlobUri = null, Uri errorBlobUri = null, string provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();

            return new AnotherParentPatch(tags, asyncExecution, runAsUser, runAsPassword, timeoutInSeconds, outputBlobUri, errorBlobUri, provisioningState, default);
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtMultipleParentResource.ChildBodyData
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
        /// <returns> A new <see cref="MgmtMultipleParentResource.ChildBodyData"/> instance for mocking. </returns>
        public static ChildBodyData ChildBodyData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, bool? asyncExecution = null, string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = null, Uri outputBlobUri = null, Uri errorBlobUri = null, string provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ChildBodyData(id, name, resourceType, systemData, tags, location, asyncExecution, runAsUser, runAsPassword, timeoutInSeconds, outputBlobUri, errorBlobUri, provisioningState, default);
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtMultipleParentResource.Models.ChildBodyUpdate
        ///
        /// </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="asyncExecution"> Optional. If set to true, provisioning will complete as soon as the script starts and will not wait for script to complete. </param>
        /// <param name="runAsUser"> Specifies the user account on the VM when executing the run command. </param>
        /// <param name="runAsPassword"> Specifies the user account password on the VM when executing the run command. </param>
        /// <param name="timeoutInSeconds"> The timeout in seconds to execute the run command. </param>
        /// <param name="outputBlobUri"> Specifies the Azure storage blob where script output stream will be uploaded. </param>
        /// <param name="errorBlobUri"> Specifies the Azure storage blob where script error stream will be uploaded. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <returns> A new <see cref="Models.ChildBodyUpdate"/> instance for mocking. </returns>
        public static ChildBodyUpdate ChildBodyUpdate(IDictionary<string, string> tags = null, bool? asyncExecution = null, string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = null, Uri outputBlobUri = null, Uri errorBlobUri = null, string provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ChildBodyUpdate(tags, asyncExecution, runAsUser, runAsPassword, timeoutInSeconds, outputBlobUri, errorBlobUri, provisioningState, default);
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtMultipleParentResource.TheParentData
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
        /// <returns> A new <see cref="MgmtMultipleParentResource.TheParentData"/> instance for mocking. </returns>
        public static TheParentData TheParentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, bool? asyncExecution = null, string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = null, Uri outputBlobUri = null, Uri errorBlobUri = null, string provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();

            return new TheParentData(id, name, resourceType, systemData, tags, location, asyncExecution, runAsUser, runAsPassword, timeoutInSeconds, outputBlobUri, errorBlobUri, provisioningState, default);
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtMultipleParentResource.Models.TheParentPatch
        ///
        /// </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="asyncExecution"> Optional. If set to true, provisioning will complete as soon as the script starts and will not wait for script to complete. </param>
        /// <param name="runAsUser"> Specifies the user account on the VM when executing the run command. </param>
        /// <param name="runAsPassword"> Specifies the user account password on the VM when executing the run command. </param>
        /// <param name="timeoutInSeconds"> The timeout in seconds to execute the run command. </param>
        /// <param name="outputBlobUri"> Specifies the Azure storage blob where script output stream will be uploaded. </param>
        /// <param name="errorBlobUri"> Specifies the Azure storage blob where script error stream will be uploaded. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <returns> A new <see cref="Models.TheParentPatch"/> instance for mocking. </returns>
        public static TheParentPatch TheParentPatch(IDictionary<string, string> tags = null, bool? asyncExecution = null, string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = null, Uri outputBlobUri = null, Uri errorBlobUri = null, string provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();

            return new TheParentPatch(tags, asyncExecution, runAsUser, runAsPassword, timeoutInSeconds, outputBlobUri, errorBlobUri, provisioningState, default);
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
        /// <returns> A new <see cref="MgmtMultipleParentResource.SubParentData"/> instance for mocking. </returns>
        public static SubParentData SubParentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, bool? asyncExecution = null, string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = null, Uri outputBlobUri = null, Uri errorBlobUri = null, string provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();

            return new SubParentData(id, name, resourceType, systemData, tags, location, asyncExecution, runAsUser, runAsPassword, timeoutInSeconds, outputBlobUri, errorBlobUri, provisioningState, default);
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtMultipleParentResource.Models.SubParentPatch
        ///
        /// </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="asyncExecution"> Optional. If set to true, provisioning will complete as soon as the script starts and will not wait for script to complete. </param>
        /// <param name="runAsUser"> Specifies the user account on the VM when executing the run command. </param>
        /// <param name="runAsPassword"> Specifies the user account password on the VM when executing the run command. </param>
        /// <param name="timeoutInSeconds"> The timeout in seconds to execute the run command. </param>
        /// <param name="outputBlobUri"> Specifies the Azure storage blob where script output stream will be uploaded. </param>
        /// <param name="errorBlobUri"> Specifies the Azure storage blob where script error stream will be uploaded. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <returns> A new <see cref="Models.SubParentPatch"/> instance for mocking. </returns>
        public static SubParentPatch SubParentPatch(IDictionary<string, string> tags = null, bool? asyncExecution = null, string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = null, Uri outputBlobUri = null, Uri errorBlobUri = null, string provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();

            return new SubParentPatch(tags, asyncExecution, runAsUser, runAsPassword, timeoutInSeconds, outputBlobUri, errorBlobUri, provisioningState, default);
        }
    }
}
