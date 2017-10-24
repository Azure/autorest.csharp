// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.Azure.Fluent.AcceptanceTestsAzureSpecials
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for HeaderOperations.
    /// </summary>
    public static partial class HeaderOperationsExtensions
    {
        /// <summary>
        /// Send foo-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='fooClientRequestId'>
        /// The fooRequestId
        /// </param>
        public static HeaderCustomNamedRequestIdHeadersInner CustomNamedRequestId(this IHeaderOperations operations, string fooClientRequestId)
        {
            return operations.CustomNamedRequestIdAsync(fooClientRequestId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Send foo-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='fooClientRequestId'>
        /// The fooRequestId
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<HeaderCustomNamedRequestIdHeadersInner> CustomNamedRequestIdAsync(this IHeaderOperations operations, string fooClientRequestId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CustomNamedRequestIdWithHttpMessagesAsync(fooClientRequestId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Headers;
            }
        }

        /// <summary>
        /// Send foo-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request, via a parameter
        /// group
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='headerCustomNamedRequestIdParamGroupingParameters'>
        /// Additional parameters for the operation
        /// </param>
        public static HeaderCustomNamedRequestIdParamGroupingHeadersInner CustomNamedRequestIdParamGrouping(this IHeaderOperations operations, HeaderCustomNamedRequestIdParamGroupingParametersInner headerCustomNamedRequestIdParamGroupingParameters)
        {
            return operations.CustomNamedRequestIdParamGroupingAsync(headerCustomNamedRequestIdParamGroupingParameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Send foo-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request, via a parameter
        /// group
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='headerCustomNamedRequestIdParamGroupingParameters'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<HeaderCustomNamedRequestIdParamGroupingHeadersInner> CustomNamedRequestIdParamGroupingAsync(this IHeaderOperations operations, HeaderCustomNamedRequestIdParamGroupingParametersInner headerCustomNamedRequestIdParamGroupingParameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CustomNamedRequestIdParamGroupingWithHttpMessagesAsync(headerCustomNamedRequestIdParamGroupingParameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Headers;
            }
        }

        /// <summary>
        /// Send foo-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='fooClientRequestId'>
        /// The fooRequestId
        /// </param>
        public static bool CustomNamedRequestIdHead(this IHeaderOperations operations, string fooClientRequestId)
        {
            return operations.CustomNamedRequestIdHeadAsync(fooClientRequestId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Send foo-client-request-id = 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0 in the header of the request
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='fooClientRequestId'>
        /// The fooRequestId
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<bool> CustomNamedRequestIdHeadAsync(this IHeaderOperations operations, string fooClientRequestId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CustomNamedRequestIdHeadWithHttpMessagesAsync(fooClientRequestId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

    }
}
