// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal record MgmtRestOperation
    {
        public Operation Operation => Method.Operation;
        public string Name => Operation.CSharpName();
        /// <summary>
        /// The actual operation
        /// </summary>
        public RestClientMethod Method { get; }
        /// <summary>
        /// Which version of resource this operation belongs?
        /// </summary>
        public OperationSet ResourceOperationSet { get; }
        /// <summary>
        /// From which RestClient is this operation invoked
        /// </summary>
        public MgmtRestClient RestClient { get; }

        public MgmtRestOperation(RestClientMethod method, OperationSet resourceOperationSet, MgmtRestClient restClient)
        {
            Method = method;
            ResourceOperationSet = resourceOperationSet;
            RestClient = restClient;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Deconstruct(out RestClientMethod method, out OperationSet operationSet, out MgmtRestClient restClient)
        {
            method = Method;
            operationSet = ResourceOperationSet;
            restClient = RestClient;
        }
    }
}
