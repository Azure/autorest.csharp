// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.AI.FormRecognizer
{
    internal partial class AzureAIFormRecognizerTrainCustomModelAsyncHeaders
    {
        private readonly Response _response;
        public AzureAIFormRecognizerTrainCustomModelAsyncHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> Location and ID of the model being trained. The status of model training is specified in the status property at the model location. </summary>
        public string Location => _response.Headers.TryGetValue("Location", out string value) ? value : null;
    }
}
