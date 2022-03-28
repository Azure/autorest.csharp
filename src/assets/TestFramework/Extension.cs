// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.TestFramework
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    public static partial class ResourceGroupExtensions
    {
        public static DeploymentCollection GetDeployments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroup)
        {
            return new DeploymentCollection();
        }
    }
}
