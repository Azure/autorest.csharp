// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
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
        public static bool ShouldWrapResultType(this Operation operation, CSharpType? resultType, BuildContext<MgmtOutputLibrary> context, [MaybeNullWhen(false)] out Resource resource)
        {
            resource = null;
            var httpRequest = operation.GetHttpRequest();
            if (resultType != null && httpRequest != null
                && (httpRequest.Method == HttpMethod.Put || httpRequest.Method == HttpMethod.Patch))
            {
                var requestPath = operation.GetRequestPath(context);
                // first we should ensure this request path corresponds to a resource data (which is potentially a resource)
                if (!context.Library.TryGetResourceData(requestPath, out var resourceData))
                    return false;
                // then we ensure the return type is this resource data
                if (!resultType.Name.Equals(resourceData.Type.Name))
                    return false;
                // try to get the resource corresponds to the request path of this operation, and ensure the resource data of this resource is the same one if any
                if (context.Library.TryGetArmResource(requestPath, out resource))
                {
                    return resource.ResourceData == resourceData;
                }
            }
            return false;
        }
    }
}
