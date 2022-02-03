// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class LongRunningOperationExtensions
    {
        private static readonly HashSet<HttpMethod> _desiredHttpMethods = new()
        {
            HttpMethod.Put,
            HttpMethod.Delete,
            // we do not do fake LROs for PATCH requests
        };

        public static CSharpType? GetReturnTypeAsLongRunningOperation(this Operation operation, Resource? resource, string operationName, BuildContext<MgmtOutputLibrary> context)
        {
            // The resource here can be a ResourceCollection and we only want the Resource to contribute the default name of this LRO
            if (resource != null && resource is ResourceCollection collection)
                resource = collection.Resource;
            var lroName = $"{resource?.Type.Name ?? string.Empty}{operationName}Operation";
            if (operation.IsLongRunning)
            {
                return context.Library.AddLongRunningOperation(operation, resource, lroName).Type;
            }
            else if (ShouldWrapNonLongRunningOperation(operation, resource, context))
            {
                // we only make Fake LROs when it belongs to a resource, and its httpMethod is in our desired list
                return context.Library.AddNonLongRunningOperation(operation, resource, lroName).Type;
            }

            return null;
        }

        private static bool ShouldWrapNonLongRunningOperation(Operation operation, Resource? resource, BuildContext<MgmtOutputLibrary> context)
        {
            if (resource == null)
                return false;
            if (!_desiredHttpMethods.Contains(operation.GetHttpMethod()))
                return false;

            // we only wrap NonLongRunningOperation when it is a CRUD with the desired method of a resource
            var requestPath = operation.GetRequestPath(context, resource.ResourceType);
            return resource.RequestPaths.Contains(requestPath);
        }

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
        public static bool ShouldWrapResultType(this Operation operation, CSharpType? resultType, Resource? resource)
        {
            if (resultType == null || resource == null)
                return false;

            var httpMethod = operation.GetHttpMethod();
            if (httpMethod == HttpMethod.Put || httpMethod == HttpMethod.Patch)
            {
                return resultType.Name.Equals(resource.ResourceData.Type.Name);
            }

            return false;
        }
    }
}
