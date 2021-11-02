// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Models
{
    /// <summary>
    /// A <see cref="MgmtRestOperation"/> includes some invocation information of a <see cref="RestClientMethod"/>
    /// We have the <see cref="RestClientMethod"/> that will be invoked, also we have the "Contextual Path" of this method,
    /// which records the context of this method invocation,
    /// providing you the information that which part of the `Id` we should pass to the parameter of <see cref="RestClientMethod"/>
    /// </summary>
    internal record MgmtRestOperation
    {
        /// <summary>
        /// The underlying <see cref="Operation"/> object.
        /// </summary>
        public Operation Operation => Method.Operation;
        /// <summary>
        /// We use the <see cref="OperationGroup"/> to get a fully quanlified name for this operation
        /// </summary>
        public OperationGroup OperationGroup => RestClient.OperationGroup;
        public string OperationId => BuildOperationId(OperationGroup, Operation);
        /// <summary>
        /// The name of this operation
        /// </summary>
        public string Name { get; }
        public string? Description => Method.Description;
        public IEnumerable<Parameter> Parameters => Method.Parameters;
        public CSharpType? ReturnType => Method.ReturnType;
        public string Accessibility => Method.Accessibility;
        /// <summary>
        /// The actual operation
        /// </summary>
        public RestClientMethod Method { get; }
        /// <summary>
        /// The request path of this operation
        /// </summary>
        public RequestPath RequestPath { get; }
        /// <summary>
        /// The contextual path of this operation
        /// </summary>
        public RequestPath ContextualPath { get; }
        /// <summary>
        /// From which RestClient is this operation invoked
        /// </summary>
        public MgmtRestClient RestClient { get; }

        public MgmtRestOperation(RestClientMethod method, MgmtRestClient restClient, RequestPath requestPath, RequestPath contextualPath, string methodName)
        {
            Method = method;
            RestClient = restClient;
            RequestPath = requestPath;
            ContextualPath = contextualPath;
            Name = methodName;
        }

        /// <summary>
        /// Build "operation_id" property from OperationGroup and Operation
        /// </summary>
        /// <param name="operationGroup"></param>
        /// <param name="operation"></param>
        /// <returns>Original "operation_id" property</returns>
        public static string BuildOperationId(OperationGroup operationGroup, Operation operation)
        {
            return operationGroup.Key.IsNullOrEmpty() ? operation.Language.Default.Name : $"{operationGroup.Key}_{operation.Language.Default.Name}";
        }
    }
}
