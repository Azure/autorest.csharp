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
    internal class LowLevelRestClient : RestClient
    {
        protected override string DefaultAccessibility { get; } = "public";

        public LowLevelRestClient(OperationGroup operationGroup, BuildContext<LowLevelOutputLibrary> context) : base(operationGroup, context, true)
        {
        }

        protected override IEnumerable<RequestParameter> FilterMethodParameters(IEnumerable<RequestParameter> parameters)
        {
            foreach (RequestParameter p in parameters)
            {
                switch (p.In)
                {
                    case ParameterLocation.Header:
                    case ParameterLocation.Query:
                    case ParameterLocation.Path:
                        yield return p;
                        break;
                    default:
                        break;
                }

            }
        }

        protected override IEnumerable<ServiceRequest> FilterServiceRequests(IEnumerable<ServiceRequest> requests)
        {
            if (requests.Any())
            {
                yield return requests.First();
            }
        }
    }
}
