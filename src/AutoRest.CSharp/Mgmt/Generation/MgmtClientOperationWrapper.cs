// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.Models;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal record MgmtClientOperationWrapper(MgmtClientOperation ClientOperation, CSharpType ReturnType)
    {
        public static implicit operator MgmtClientOperation(MgmtClientOperationWrapper wrapper) => wrapper.ClientOperation;

        public static implicit operator MgmtClientOperationWrapper(MgmtClientOperation operation) => new MgmtClientOperationWrapper(operation, operation.ReturnType);
    }
}
