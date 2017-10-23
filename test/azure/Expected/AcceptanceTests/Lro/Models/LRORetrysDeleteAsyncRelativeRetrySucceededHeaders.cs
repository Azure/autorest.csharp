// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.AcceptanceTestsLro.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines headers for deleteAsyncRelativeRetrySucceeded operation.
    /// </summary>
    public partial class LRORetrysDeleteAsyncRelativeRetrySucceededHeaders
    {
        /// <summary>
        /// Initializes a new instance of the
        /// LRORetrysDeleteAsyncRelativeRetrySucceededHeaders class.
        /// </summary>
        public LRORetrysDeleteAsyncRelativeRetrySucceededHeaders()
        {
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets location to poll for result status: will be set to
        /// /lro/retryerror/deleteasync/retry/succeeded/operationResults/200
        /// </summary>
        [JsonProperty(PropertyName = "Azure-AsyncOperation")]
        public string AzureAsyncOperation { get; set; }

        /// <summary>
        /// Gets or sets location to poll for result status: will be set to
        /// /lro/retryerror/deleteasync/retry/succeeded/operationResults/200
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
