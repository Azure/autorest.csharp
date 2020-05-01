// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class PagingMethod
    {
        public PagingMethod(RestClientMethod method, RestClientMethod? nextPageMethod, string name, string? nextLinkName, string itemName, CSharpType itemType, Diagnostic diagnostics)
        {
            Method = method;
            NextPageMethod = nextPageMethod;
            Name = name;
            NextLinkName = nextLinkName;
            ItemName = itemName;
            ItemType = itemType;
            Diagnostics = diagnostics;
        }

        public string Name { get; }
        public RestClientMethod Method { get; }
        public RestClientMethod? NextPageMethod { get; }
        public string? NextLinkName { get; }
        public string ItemName { get; }
        public CSharpType ItemType { get; }
        public Diagnostic Diagnostics { get; set; }
    }
}
