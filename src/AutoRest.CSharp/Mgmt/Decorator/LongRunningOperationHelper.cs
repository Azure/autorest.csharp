// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class LongRunningOperationHelper
    {
        /// <summary>
        /// Decides if we want to wrap the LRO result type with a [Resource] type.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="operationGroup"></param>
        /// <param name="operation"></param>
        /// <param name="resultType">Result type of the LRO.</param>
        /// <returns></returns>
        public static bool ShouldWrapResultType(BuildContext<MgmtOutputLibrary> context, OperationGroup operationGroup, Input.Operation operation, CSharpType? resultType)
        {
            if (resultType != null
                && operation.Requests.FirstOrDefault().Protocol.Http is HttpRequest httpRequest
                && (httpRequest.Method == HttpMethod.Put || httpRequest.Method == HttpMethod.Patch))
            {
                // need to check result type is [Resource]Data because:
                // 1. some PUT operation returns differently and we don't want to wrap that with [Resource]
                // 2. some operations belong to non-resource
                if (context.Library.TryGetResourceData(operationGroup, out var resourceData))
                {
                    var resourceDataType = resourceData.Type;
                    if (resultType.Name.Equals(resourceDataType.Name))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
