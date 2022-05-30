// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System.Text.Json;
using Azure;

namespace AmbiguousMethods_LowLevel
{
    public partial class SuccessResponse
    {
        public string Message;

        internal static SuccessResponse FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            // Add your deserialization logic in DeserializeMetricFeedback
            return DeserializeSuccessResponse(document.RootElement);
        }

        internal static SuccessResponse DeserializeSuccessResponse(JsonElement element)
        {
            SuccessResponse response = new SuccessResponse();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("message"))
                {
                    response.Message = property.Value.ToString();
                }
            }
            return response;
        }
    }
}
