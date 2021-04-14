// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class PagingMethod
    {
        public PagingMethod(RestClientMethod method, RestClientMethod? nextPageMethod, string name, Diagnostic diagnostics, PagingResponseInfo pagingResponse)
        {
            Method = method;
            NextPageMethod = nextPageMethod;
            Name = name;
            Diagnostics = diagnostics;
            PagingResponse = pagingResponse;
        }

        public string Name { get; }
        public RestClientMethod Method { get; }
        public RestClientMethod? NextPageMethod { get; }
        public PagingResponseInfo PagingResponse { get; }
        public Diagnostic Diagnostics { get; }
        public string Accessibility => "public";
    }
}
