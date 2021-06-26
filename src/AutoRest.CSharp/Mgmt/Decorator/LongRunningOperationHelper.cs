// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Builders;
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
                // need to check result type is [Resource]Data because
                // some PUT operation returns differently and we don't want to wrap that with [Resource]
                var resourceDataType = context.Library.GetResourceData(operationGroup).Type;
                if (resultType.Name.Equals(resourceDataType.Name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
