// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtScopeResource.Models
{
    /// <summary> Type of change that will be made to the resource when the deployment is executed. </summary>
    public enum ChangeType
    {
        /// <summary> The resource does not exist in the current state but is present in the desired state. The resource will be created when the deployment is executed. </summary>
        Create,
        /// <summary> The resource exists in the current state and is missing from the desired state. The resource will be deleted when the deployment is executed. </summary>
        Delete,
        /// <summary> The resource exists in the current state and is missing from the desired state. The resource will not be deployed or modified when the deployment is executed. </summary>
        Ignore,
        /// <summary> The resource exists in the current state and the desired state and will be redeployed when the deployment is executed. The properties of the resource may or may not change. </summary>
        Deploy,
        /// <summary> The resource exists in the current state and the desired state and will be redeployed when the deployment is executed. The properties of the resource will not change. </summary>
        NoChange,
        /// <summary> The resource exists in the current state and the desired state and will be redeployed when the deployment is executed. The properties of the resource will change. </summary>
        Modify,
        /// <summary> The resource is not supported by What-If. </summary>
        Unsupported
    }
}
