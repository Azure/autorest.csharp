// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.V3.Input.Source
{
    public class ClientTypeMapping
    {
        public ClientTypeMapping(string operationGroupName, INamedTypeSymbol existingType)
        {
            OperationGroupName = operationGroupName;
            ExistingType = existingType;
        }

        public string OperationGroupName { get; }
        public INamedTypeSymbol ExistingType { get; }
    }
}