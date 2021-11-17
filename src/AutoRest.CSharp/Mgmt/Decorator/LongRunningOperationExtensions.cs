// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class LongRunningOperationExtensions
    {
        public static LongRunningOperationInfo FindLongRunningOperationInfo(this Operation operation, BuildContext<MgmtOutputLibrary> context)
        {
            var mgmtRestClient = context.Library.GetRestClient(operation);

            var nextOperationMethod = operation?.Language?.Default?.Paging != null
                ? mgmtRestClient.GetNextOperationMethod(operation.Requests.Single())
                : null;

            return new LongRunningOperationInfo(
                "public",
                mgmtRestClient.ClientPrefix,
                nextOperationMethod);
        }

        /// <summary>
        /// Decides if we want to wrap the LRO result type with a [Resource] type.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="resultType">Result type of the LRO.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool ShouldWrapResultType(this Operation operation, CSharpType? resultType, BuildContext<MgmtOutputLibrary> context)
        {
            var httpRequest = operation.GetHttpRequest();
            if (resultType != null && httpRequest != null
                && (httpRequest.Method == HttpMethod.Put || httpRequest.Method == HttpMethod.Patch))
            {
                // need to check result type is [Resource]Data because:
                // 1. some PUT operation returns differently and we don't want to wrap that with [Resource]
                // 2. some operations belong to non-resource
                if (context.Library.TryGetResourceData(operation.GetHttpPath(), out var resourceData))
                {
                    return resultType.Name.Equals(resourceData.Type.Name);
                }
            }
            return false;
        }
    }
}
