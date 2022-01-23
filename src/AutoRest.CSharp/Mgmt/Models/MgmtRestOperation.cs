// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
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
        public string OperationId => Operation.OperationId(OperationGroup);
        /// <summary>
        /// The name of this operation
        /// </summary>
        public string Name { get; }
        public string? Description => Method.Description;
        public IEnumerable<Parameter> Parameters => Method.Parameters;
        public CSharpType? ReturnType { get; }
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

        public Resource? Resource { get; }

        public MgmtRestOperation(RestClientMethod method, MgmtRestClient restClient, RequestPath requestPath, RequestPath contextualPath, string methodName, CSharpType? returnType)
        {
            Method = method;
            RestClient = restClient;
            RequestPath = requestPath;
            ContextualPath = contextualPath;
            Name = methodName;
            Resource = GetResourceMatch(restClient, method, requestPath);
            ReturnType = returnType ?? method.ReturnType;
        }

        private static Resource? GetResourceMatch(MgmtRestClient restClient, RestClientMethod method, RequestPath requestPath)
        {
            if (restClient.Resources.Count == 1)
                return restClient.Resources[0];

            foreach (var resource in restClient.Resources)
            {
                if (resource.RequestPaths.Any(path => { return DoesPathMatch(method, path, requestPath); }))
                    return resource;
            }
            return null;
        }

        private static bool DoesPathMatch(RestClientMethod method, RequestPath path, RequestPath requestPath)
        {
            //check exact match
            if (path == requestPath)
                return true;

            var httpMethod = method.Operation.GetHttpMethod();

            //check for a list by an ancestor, for path we need to check - 2 for normal and - 4 for tuple
            var requestLastSegment = requestPath[requestPath.Count - 1];
            if (path.Count >= 2 && requestPath.Count < path.Count && requestLastSegment.IsConstant)
            {
                if (path[path.Count - 2] == requestLastSegment || (httpMethod == HttpMethod.Get && path[path.Count - 4] == requestLastSegment))
                    return true;
            }

            if (requestPath.Count < 2)
                return false;

            var secondToLastSegment = requestPath[requestPath.Count - 2];
            var pathLastSegement = path[path.Count - 1];
            //check for single value methods after the GET path which are typically POST methods
            if (path.Count == requestPath.Count - 1 && requestLastSegment.IsConstant && pathLastSegement == secondToLastSegment)
                return true;

            //sometimes for singletons the POST methods show up at the same level
            if (path.Count == requestPath.Count && requestLastSegment.IsConstant && pathLastSegement.IsConstant && secondToLastSegment == path[path.Count - 2])
                return true;

            //catch check name availability where the provider ending matches
            if (path.Count >= 4 && secondToLastSegment.IsConstant && secondToLastSegment == path[path.Count - 3] && path[path.Count - 4].ToString() == "providers")
                return true;

            return false;
        }
    }
}
