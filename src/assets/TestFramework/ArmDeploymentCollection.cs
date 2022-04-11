// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
namespace Azure.ResourceManager.TestFramework
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    public class ArmDeploymentCollection
    {
        public async Task<ArmOperation<ArmDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitForCompletion, string ArmDeploymentName, object parameters, object? cancellationToken = default)
        {
            await Task.Yield();
            return new FakeResourcesArmOperation<ArmDeploymentResource>();
        }

    }
}
