// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class MgmtLongRunningOperationMethod
    {
        public MgmtLongRunningOperationMethod(string name, MgmtLongRunningOperation operation, RestClientMethod startMethod, Diagnostic diagnostics)
        {
            Operation = operation;
            StartMethod = startMethod;
            Diagnostics = diagnostics;
            Name = name;
        }


        public string Name { get; }
        public MgmtLongRunningOperation Operation { get; }

        public RestClientMethod StartMethod { get; }

        public Diagnostic Diagnostics { get; }
    }
}
