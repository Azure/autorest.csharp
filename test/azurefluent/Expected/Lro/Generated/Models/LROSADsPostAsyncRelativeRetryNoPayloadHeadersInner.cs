// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.Fluent.Lro.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines headers for postAsyncRelativeRetryNoPayload operation.
    /// </summary>
    public partial class LROSADsPostAsyncRelativeRetryNoPayloadHeadersInner
    {
        /// <summary>
        /// Initializes a new instance of the
        /// LROSADsPostAsyncRelativeRetryNoPayloadHeadersInner class.
        /// </summary>
        public LROSADsPostAsyncRelativeRetryNoPayloadHeadersInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// LROSADsPostAsyncRelativeRetryNoPayloadHeadersInner class.
        /// </summary>
        /// <param name="azureAsyncOperation">Location to poll for result
        /// status: will be set to
        /// /lro/error/putasync/retry/failed/operationResults/nopayload</param>
        /// <param name="location">Location to poll for result status: will be
        /// set to
        /// /lro/error/putasync/retry/failed/operationResults/nopayload</param>
        /// <param name="retryAfter">Number of milliseconds until the next poll
        /// should be sent, will be set to zero</param>
        public LROSADsPostAsyncRelativeRetryNoPayloadHeadersInner(string azureAsyncOperation = default(string), string location = default(string), int? retryAfter = default(int?))
        {
            AzureAsyncOperation = azureAsyncOperation;
            Location = location;
            RetryAfter = retryAfter;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets location to poll for result status: will be set to
        /// /lro/error/putasync/retry/failed/operationResults/nopayload
        /// </summary>
        [JsonProperty(PropertyName = "Azure-AsyncOperation")]
        public string AzureAsyncOperation { get; set; }

        /// <summary>
        /// Gets or sets location to poll for result status: will be set to
        /// /lro/error/putasync/retry/failed/operationResults/nopayload
        /// </summary>
        [JsonProperty(PropertyName = "Location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets number of milliseconds until the next poll should be
        /// sent, will be set to zero
        /// </summary>
        [JsonProperty(PropertyName = "Retry-After")]
        public int? RetryAfter { get; set; }

    }
}
