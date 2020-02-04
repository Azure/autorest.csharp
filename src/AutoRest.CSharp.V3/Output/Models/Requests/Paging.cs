// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class Paging
    {
        public Paging(Method method, Method nextPageMethod, string name, string? nextLinkName, string itemName, CSharpType itemType)
        {
            Method = method;
            NextPageMethod = nextPageMethod;
            Name = name;
            NextLinkName = nextLinkName;
            ItemName = itemName;
            ItemType = itemType;
        }

        public string Name { get; }
        public Method Method { get; }
        public Method NextPageMethod { get; }
        public string? NextLinkName { get; }
        public string ItemName { get; }
        public CSharpType ItemType { get; }
    }
}
