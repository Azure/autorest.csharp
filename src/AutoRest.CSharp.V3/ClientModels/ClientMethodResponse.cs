// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientMethodResponse
    {
        public ClientMethodResponse(ClientTypeReference? type, int[] successfulStatusCodes, ResponseHeaderModel? headerModel)
        {
            Type = type;
            SuccessfulStatusCodes = successfulStatusCodes;
            HeaderModel = headerModel;
        }

        public ClientTypeReference? Type { get; }
        public int[] SuccessfulStatusCodes { get; }
        public ResponseHeaderModel? HeaderModel { get; }
    }
}
