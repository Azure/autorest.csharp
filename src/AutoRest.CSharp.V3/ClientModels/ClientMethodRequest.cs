// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using Azure.Core;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientMethodRequest
    {
        public ClientMethodRequest(RequestMethod method, ConstantOrParameter[] hostSegments, PathSegment[] pathSegments, QueryParameter[] query, RequestHeader[] headers, ConstantOrParameter? body)
        {
            Method = method;
            HostSegments = hostSegments;
            PathSegments = pathSegments;
            Query = query;
            Headers = headers;
            Body = body;
        }

        public RequestMethod Method { get; }
        public ConstantOrParameter[] HostSegments { get; }
        public PathSegment[] PathSegments { get; }
        public QueryParameter[] Query { get; }
        public RequestHeader[] Headers { get; }
        public ConstantOrParameter? Body { get; set; }
    }
}
