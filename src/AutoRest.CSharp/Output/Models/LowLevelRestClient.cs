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
        public LowLevelRestClient(OperationGroup operationGroup, BuildContext context) : base(operationGroup, context)
        {
        }

        protected override void FilterMethodParameters (List<RequestParameter> parameters)
        {
            base.FilterMethodParameters(parameters);

            parameters.RemoveAll(requestParameter =>
                requestParameter.In != ParameterLocation.Header &&
                requestParameter.In != ParameterLocation.Query &&
                requestParameter.In !=ParameterLocation.Path);
        }
    }
}
