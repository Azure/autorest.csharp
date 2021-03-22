// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Request = AutoRest.CSharp.Output.Models.Requests.Request;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;

namespace AutoRest.CSharp.Output.Models
{
    internal class LowLevelRestClient : ClientBase
    {
        private RestClientBuilder<LowLevelOutputLibrary> _builder;
        private readonly OperationGroup _operationGroup;
        // Diff
        private readonly BuildContext<LowLevelOutputLibrary> _context;
        private Dictionary<ServiceRequest, RestClientMethod>? _requestMethods;
        private RestClientMethod[]? _allMethods;

        // DIFF
        protected override string DefaultAccessibility { get; } = "public";

        public LowLevelRestClient(OperationGroup operationGroup, BuildContext<LowLevelOutputLibrary> context) : base(context)
        {
            _operationGroup = operationGroup;
            _context = context;
            _builder = new RestClientBuilder<LowLevelOutputLibrary> (operationGroup, context);

            Parameters = _builder.GetOrderedParameters ();
            ClientPrefix = GetClientPrefix(operationGroup.Language.Default.Name, context);
            DefaultName = ClientPrefix + ClientSuffix;
            Description = "";
        }

        public Parameter[] Parameters { get; }
        public string Description { get; }
        public RestClientMethod[] Methods => _allMethods ??= BuildAllMethods().ToArray();
        public string ClientPrefix { get; }
        protected override string DefaultName { get; }

        private IEnumerable<RestClientMethod> BuildAllMethods()
        {
            foreach (var operation in _operationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    RestClientMethod method = GetOperationMethod(serviceRequest);
                    yield return method;
                }
            }
        }

        public RestClientMethod GetOperationMethod(ServiceRequest request)
        {
            return EnsureNormalMethods()[request];
        }

        private Dictionary<ServiceRequest, RestClientMethod> EnsureNormalMethods()
        {
            if (_requestMethods != null)
            {
                return _requestMethods;
            }

            _requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();

            foreach (var operation in _operationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    if (!(serviceRequest.Protocol.Http is HttpRequest httpRequest))
                    {
                        continue;
                    }

                    _requestMethods.Add(serviceRequest, _builder.BuildMethod(operation, httpRequest, serviceRequest.Parameters, null));
                }
            }

            return _requestMethods;
        }

        public IReadOnlyCollection<Parameter> GetConstructorParameters(CSharpType credentialType, bool includeProtocolOptions = false)
        {
            return RestClientHelpers.GetConstructorParameters (Parameters, credentialType, includeProtocolOptions);
        }
    }
}
