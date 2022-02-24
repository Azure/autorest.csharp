// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

[assembly:CodeGenSuppressType("ModelToBeSkipped")]
[assembly:CodeGenSuppressType("EnumToBeSkipped")]
[assembly:CodeGenSuppressType("EnumToBeSkippedExtensions")]

namespace MgmtScopeResource
{
    [CodeGenSuppress("GetPolicyAssignments")]
    internal partial class ArmResourceExtensionClient
    {
    }
}
