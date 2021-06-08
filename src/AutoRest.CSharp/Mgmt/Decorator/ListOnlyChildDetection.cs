// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ListOnlyChildDetection
    {
        private const string ArrayValuePropertyName = "value";

        /// <summary>
        /// Indicates if the given operation group is a ListOnly child resource.
        /// If the operation group is a ListOnly child, will return true indicating
        /// the corresponding container, data... classes should not be generated.
        /// </summary>
        /// <param name="operationGroup">Operation group.</param>
        /// <param name="config">Management plane configuration.</param>
        /// <returns></returns>
        public static bool IsListOnlyChildResource(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            // if operation count is not 1, does not meet the ListOnlyChild criteria. Return false
            if (operationGroup.Operations.Count != 1)
            {
                return false;
            }

            var operation = operationGroup.Operations.First();

            // Check to see if the only operation is GET && return result is array type
            if (!operation.IsLongRunning
                && operation.Requests.FirstOrDefault()?.Protocol.Http is HttpRequest httpRequest
                && httpRequest.Method == HttpMethod.Get)
            {
                // Check 200 return schema
                var successResponse = operation.Responses
                    .FirstOrDefault(r => r.HttpResponse.StatusCodes.Contains(StatusCodes._200));
                ObjectSchema? schema = successResponse?.ResponseSchema as ObjectSchema;

                // TODO -- change p.SerializedName == ArrayValuePropertyName so that we could check the list only operations by x-ms-client-name
                if (schema != null && schema.Properties.Any(p => p.Schema is ArraySchema && p.SerializedName == ArrayValuePropertyName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
