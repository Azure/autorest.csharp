// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Input.Source
{
    public class SourceMemberMapping
    {
        public SourceMemberMapping(string originalName, ISymbol existingMember)
        {
            OriginalName = originalName;
            ExistingMember = existingMember;
        }

        public string OriginalName { get; }
        public ISymbol ExistingMember { get; }
    }
}