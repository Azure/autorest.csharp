// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.Output.Models.Responses
{
    internal class Response
    {
        public Response(ResponseBody? responseBody, StatusCodes[] statusCodes)
        {
            ResponseBody = responseBody;
            StatusCodes = statusCodes;
        }

        public ResponseBody? ResponseBody { get; }
        public StatusCodes[] StatusCodes { get; }
    }

    internal enum Family
    {
        // 1xx HTTP status codes.
        INFORMATIONAL = 1,

        // 2xx HTTP status codes.
        SUCCESSFUL,

        // 3xx HTTP status codes.
        REDIRECTION,

        // 4xx HTTP status codes.
        CLIENT_ERROR,

        // 5xx HTTP status codes.
        SERVER_ERROR,

        // Other, unrecognized HTTP status codes.
        OTHER
    }

    internal struct StatusCodes
    {
        public StatusCodes(int? code, int? family)
        {
            Code = code;
            Family = family;
        }

        public int? Code { get; }
        public int? Family { get; }
    }
}
