// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.Azure.AcceptanceTestsAzureBodyDurationNoSync
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// DurationOperations operations.
    /// </summary>
    public partial interface IDurationOperations
    {
        /// <summary>
        /// Get null duration value
        /// </summary>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref='ErrorException'>
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref='Microsoft.Rest.SerializationException'>
        /// Thrown when unable to deserialize the response.
        /// </exception>
        Task<AzureOperationResponse<System.TimeSpan?>> GetNullWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Put a positive duration value
        /// </summary>
        /// <param name='durationBody'>
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref='ErrorException'>
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        Task<AzureOperationResponse> PutPositiveDurationWithHttpMessagesAsync(System.TimeSpan durationBody, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get a positive duration value
        /// </summary>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref='ErrorException'>
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref='Microsoft.Rest.SerializationException'>
        /// Thrown when unable to deserialize the response.
        /// </exception>
        Task<AzureOperationResponse<System.TimeSpan?>> GetPositiveDurationWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get an invalid duration value
        /// </summary>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref='ErrorException'>
        /// Thrown when the operation returned an invalid status code.
        /// </exception>
        /// <exception cref='Microsoft.Rest.SerializationException'>
        /// Thrown when unable to deserialize the response.
        /// </exception>
        Task<AzureOperationResponse<System.TimeSpan?>> GetInvalidWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
