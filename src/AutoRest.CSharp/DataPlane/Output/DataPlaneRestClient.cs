// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models
{
    internal class DataPlaneRestClient : RestClient
    {
        private BuildContext<DataPlaneOutputLibrary> _context;

        public DataPlaneRestClient(OperationGroup operationGroup, BuildContext<DataPlaneOutputLibrary> context)
            : base(operationGroup, context, context.Library.FindClient(operationGroup)?.Declaration?.Name)
        {
            _context = context;
        }

        protected override Dictionary<ServiceRequest, RestClientMethod> EnsureNormalMethods()
        {
            var requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();

            foreach (var operation in OperationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    // See also LowLevelRestClient::EnsureNormalMethods if changing
                    if (!(serviceRequest.Protocol.Http is HttpRequest httpRequest))
                    {
                        continue;
                    }
                    var headerModel = _context.Library.FindHeaderModel(operation);
                    var accessibility = operation.Accessibility ?? "public";
                    requestMethods.Add(serviceRequest, Builder.BuildMethod(operation, httpRequest, serviceRequest.Parameters, headerModel, accessibility));
                }
            }

            return requestMethods;
        }
    }
}
