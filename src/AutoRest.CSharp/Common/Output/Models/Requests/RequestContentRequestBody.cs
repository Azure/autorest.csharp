// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class RequestContentRequestBody : RequestBody
    {
        public string ParameterName { get; }

        public RequestContentRequestBody(string parameterName)
        {
            ParameterName = parameterName;
        }
    }
}
