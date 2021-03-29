// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class DataPlaneLongRunningOperationMethod
    {
        public DataPlaneLongRunningOperationMethod(string name, DataPlaneLongRunningOperation operation, RestClientMethod startMethod, Diagnostic diagnostics)
        {
            Operation = operation;
            StartMethod = startMethod;
            Diagnostics = diagnostics;
            Name = name;
        }


        public string Name { get; }
        public DataPlaneLongRunningOperation Operation { get; }

        public RestClientMethod StartMethod { get; }

        public Diagnostic Diagnostics { get; }
    }
}
