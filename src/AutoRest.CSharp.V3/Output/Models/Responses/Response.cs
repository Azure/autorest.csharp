// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.Output.Models.Responses
{
    internal class Response
    {
        public Response(ResponseBody? responseBody, int[] successfulStatusCodes, ResponseHeaderGroupType? headerModel)
        {
            ResponseBody = responseBody;
            SuccessfulStatusCodes = successfulStatusCodes;
            HeaderModel = headerModel;
        }

        public ResponseBody? ResponseBody { get; }
        public int[] SuccessfulStatusCodes { get; }
        public ResponseHeaderGroupType? HeaderModel { get; }
    }
}
