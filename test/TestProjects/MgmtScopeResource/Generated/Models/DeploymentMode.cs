// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtScopeResource.Models
{
    /// <summary> The mode that is used to deploy resources. This value can be either Incremental or Complete. In Incremental mode, resources are deployed without deleting existing resources that are not included in the template. In Complete mode, resources are deployed and existing resources in the resource group that are not included in the template are deleted. Be careful when using Complete mode as you may unintentionally delete resources. </summary>
    public enum DeploymentMode
    {
        /// <summary> Incremental. </summary>
        Incremental,
        /// <summary> Complete. </summary>
        Complete
    }
}
