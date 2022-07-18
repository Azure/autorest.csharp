// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class InputOperationExtensions
    {
        public static string GetHttpPath(this InputOperation operation)
        {
            var path = operation.Path;
            // Do not trim the tenant resource path '/'.
            return path.Length == 1 ? path : path.TrimEnd('/');
        }

        public static bool IsGetResourceOperation(this InputOperation operation, string? responseBodyType, ResourceData resourceData)
        {
            // first we need to be a GET operation
            if (operation.HttpMethod != RequestMethod.Get)
                return false;
            // then we get the corresponding OperationSet and see if this OperationSet corresponds to a resource
            var operationSet = MgmtContext.Library.GetOperationSet(operation.GetHttpPath());
            if (!operationSet.IsResource())
                return false;
            return responseBodyType == resourceData.Type.Name;
        }
    }
}
