// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.Fluent.Lro
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for LRORetrysOperations.
    /// </summary>
    public static partial class LRORetrysOperationsExtensions
    {
            /// <summary>
            /// Long running put request, service returns a 500, then a 201 to the initial
            /// request, with an entity that contains ProvisioningState=’Creating’.  Polls
            /// return this value until the last poll returns a ‘200’ with
            /// ProvisioningState=’Succeeded’
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            public static ProductInner Put201CreatingSucceeded200(this ILRORetrysOperations operations, ProductInner product = default(ProductInner))
            {
                return operations.Put201CreatingSucceeded200Async(product).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running put request, service returns a 500, then a 201 to the initial
            /// request, with an entity that contains ProvisioningState=’Creating’.  Polls
            /// return this value until the last poll returns a ‘200’ with
            /// ProvisioningState=’Succeeded’
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ProductInner> Put201CreatingSucceeded200Async(this ILRORetrysOperations operations, ProductInner product = default(ProductInner), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.Put201CreatingSucceeded200WithHttpMessagesAsync(product, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Long running put request, service returns a 500, then a 200 to the initial
            /// request, with an entity that contains ProvisioningState=’Creating’. Poll
            /// the endpoint indicated in the Azure-AsyncOperation header for operation
            /// status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            public static ProductInner PutAsyncRelativeRetrySucceeded(this ILRORetrysOperations operations, ProductInner product = default(ProductInner))
            {
                return operations.PutAsyncRelativeRetrySucceededAsync(product).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running put request, service returns a 500, then a 200 to the initial
            /// request, with an entity that contains ProvisioningState=’Creating’. Poll
            /// the endpoint indicated in the Azure-AsyncOperation header for operation
            /// status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ProductInner> PutAsyncRelativeRetrySucceededAsync(this ILRORetrysOperations operations, ProductInner product = default(ProductInner), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PutAsyncRelativeRetrySucceededWithHttpMessagesAsync(product, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Long running delete request, service returns a 500, then a  202 to the
            /// initial request, with an entity that contains ProvisioningState=’Accepted’.
            /// Polls return this value until the last poll returns a ‘200’ with
            /// ProvisioningState=’Succeeded’
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static ProductInner DeleteProvisioning202Accepted200Succeeded(this ILRORetrysOperations operations)
            {
                return operations.DeleteProvisioning202Accepted200SucceededAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running delete request, service returns a 500, then a  202 to the
            /// initial request, with an entity that contains ProvisioningState=’Accepted’.
            /// Polls return this value until the last poll returns a ‘200’ with
            /// ProvisioningState=’Succeeded’
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ProductInner> DeleteProvisioning202Accepted200SucceededAsync(this ILRORetrysOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteProvisioning202Accepted200SucceededWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Long running delete request, service returns a 500, then a 202 to the
            /// initial request. Polls return this value until the last poll returns a
            /// ‘200’ with ProvisioningState=’Succeeded’
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static LRORetrysDelete202Retry200HeadersInner Delete202Retry200(this ILRORetrysOperations operations)
            {
                return operations.Delete202Retry200Async().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running delete request, service returns a 500, then a 202 to the
            /// initial request. Polls return this value until the last poll returns a
            /// ‘200’ with ProvisioningState=’Succeeded’
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<LRORetrysDelete202Retry200HeadersInner> Delete202Retry200Async(this ILRORetrysOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.Delete202Retry200WithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <summary>
            /// Long running delete request, service returns a 500, then a 202 to the
            /// initial request. Poll the endpoint indicated in the Azure-AsyncOperation
            /// header for operation status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static LRORetrysDeleteAsyncRelativeRetrySucceededHeadersInner DeleteAsyncRelativeRetrySucceeded(this ILRORetrysOperations operations)
            {
                return operations.DeleteAsyncRelativeRetrySucceededAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running delete request, service returns a 500, then a 202 to the
            /// initial request. Poll the endpoint indicated in the Azure-AsyncOperation
            /// header for operation status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<LRORetrysDeleteAsyncRelativeRetrySucceededHeadersInner> DeleteAsyncRelativeRetrySucceededAsync(this ILRORetrysOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteAsyncRelativeRetrySucceededWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <summary>
            /// Long running post request, service returns a 500, then a 202 to the initial
            /// request, with 'Location' and 'Retry-After' headers, Polls return a 200 with
            /// a response body after success
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            public static LRORetrysPost202Retry200HeadersInner Post202Retry200(this ILRORetrysOperations operations, ProductInner product = default(ProductInner))
            {
                return operations.Post202Retry200Async(product).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running post request, service returns a 500, then a 202 to the initial
            /// request, with 'Location' and 'Retry-After' headers, Polls return a 200 with
            /// a response body after success
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<LRORetrysPost202Retry200HeadersInner> Post202Retry200Async(this ILRORetrysOperations operations, ProductInner product = default(ProductInner), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.Post202Retry200WithHttpMessagesAsync(product, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <summary>
            /// Long running post request, service returns a 500, then a 202 to the initial
            /// request, with an entity that contains ProvisioningState=’Creating’. Poll
            /// the endpoint indicated in the Azure-AsyncOperation header for operation
            /// status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            public static LRORetrysPostAsyncRelativeRetrySucceededHeadersInner PostAsyncRelativeRetrySucceeded(this ILRORetrysOperations operations, ProductInner product = default(ProductInner))
            {
                return operations.PostAsyncRelativeRetrySucceededAsync(product).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running post request, service returns a 500, then a 202 to the initial
            /// request, with an entity that contains ProvisioningState=’Creating’. Poll
            /// the endpoint indicated in the Azure-AsyncOperation header for operation
            /// status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<LRORetrysPostAsyncRelativeRetrySucceededHeadersInner> PostAsyncRelativeRetrySucceededAsync(this ILRORetrysOperations operations, ProductInner product = default(ProductInner), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostAsyncRelativeRetrySucceededWithHttpMessagesAsync(product, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <summary>
            /// Long running put request, service returns a 500, then a 201 to the initial
            /// request, with an entity that contains ProvisioningState=’Creating’.  Polls
            /// return this value until the last poll returns a ‘200’ with
            /// ProvisioningState=’Succeeded’
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            public static ProductInner BeginPut201CreatingSucceeded200(this ILRORetrysOperations operations, ProductInner product = default(ProductInner))
            {
                return operations.BeginPut201CreatingSucceeded200Async(product).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running put request, service returns a 500, then a 201 to the initial
            /// request, with an entity that contains ProvisioningState=’Creating’.  Polls
            /// return this value until the last poll returns a ‘200’ with
            /// ProvisioningState=’Succeeded’
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ProductInner> BeginPut201CreatingSucceeded200Async(this ILRORetrysOperations operations, ProductInner product = default(ProductInner), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginPut201CreatingSucceeded200WithHttpMessagesAsync(product, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Long running put request, service returns a 500, then a 200 to the initial
            /// request, with an entity that contains ProvisioningState=’Creating’. Poll
            /// the endpoint indicated in the Azure-AsyncOperation header for operation
            /// status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            public static ProductInner BeginPutAsyncRelativeRetrySucceeded(this ILRORetrysOperations operations, ProductInner product = default(ProductInner))
            {
                return operations.BeginPutAsyncRelativeRetrySucceededAsync(product).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running put request, service returns a 500, then a 200 to the initial
            /// request, with an entity that contains ProvisioningState=’Creating’. Poll
            /// the endpoint indicated in the Azure-AsyncOperation header for operation
            /// status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ProductInner> BeginPutAsyncRelativeRetrySucceededAsync(this ILRORetrysOperations operations, ProductInner product = default(ProductInner), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginPutAsyncRelativeRetrySucceededWithHttpMessagesAsync(product, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Long running delete request, service returns a 500, then a  202 to the
            /// initial request, with an entity that contains ProvisioningState=’Accepted’.
            /// Polls return this value until the last poll returns a ‘200’ with
            /// ProvisioningState=’Succeeded’
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static ProductInner BeginDeleteProvisioning202Accepted200Succeeded(this ILRORetrysOperations operations)
            {
                return operations.BeginDeleteProvisioning202Accepted200SucceededAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running delete request, service returns a 500, then a  202 to the
            /// initial request, with an entity that contains ProvisioningState=’Accepted’.
            /// Polls return this value until the last poll returns a ‘200’ with
            /// ProvisioningState=’Succeeded’
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ProductInner> BeginDeleteProvisioning202Accepted200SucceededAsync(this ILRORetrysOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginDeleteProvisioning202Accepted200SucceededWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Long running delete request, service returns a 500, then a 202 to the
            /// initial request. Polls return this value until the last poll returns a
            /// ‘200’ with ProvisioningState=’Succeeded’
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static LRORetrysDelete202Retry200HeadersInner BeginDelete202Retry200(this ILRORetrysOperations operations)
            {
                return operations.BeginDelete202Retry200Async().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running delete request, service returns a 500, then a 202 to the
            /// initial request. Polls return this value until the last poll returns a
            /// ‘200’ with ProvisioningState=’Succeeded’
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<LRORetrysDelete202Retry200HeadersInner> BeginDelete202Retry200Async(this ILRORetrysOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginDelete202Retry200WithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <summary>
            /// Long running delete request, service returns a 500, then a 202 to the
            /// initial request. Poll the endpoint indicated in the Azure-AsyncOperation
            /// header for operation status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static LRORetrysDeleteAsyncRelativeRetrySucceededHeadersInner BeginDeleteAsyncRelativeRetrySucceeded(this ILRORetrysOperations operations)
            {
                return operations.BeginDeleteAsyncRelativeRetrySucceededAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running delete request, service returns a 500, then a 202 to the
            /// initial request. Poll the endpoint indicated in the Azure-AsyncOperation
            /// header for operation status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<LRORetrysDeleteAsyncRelativeRetrySucceededHeadersInner> BeginDeleteAsyncRelativeRetrySucceededAsync(this ILRORetrysOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginDeleteAsyncRelativeRetrySucceededWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <summary>
            /// Long running post request, service returns a 500, then a 202 to the initial
            /// request, with 'Location' and 'Retry-After' headers, Polls return a 200 with
            /// a response body after success
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            public static LRORetrysPost202Retry200HeadersInner BeginPost202Retry200(this ILRORetrysOperations operations, ProductInner product = default(ProductInner))
            {
                return operations.BeginPost202Retry200Async(product).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running post request, service returns a 500, then a 202 to the initial
            /// request, with 'Location' and 'Retry-After' headers, Polls return a 200 with
            /// a response body after success
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<LRORetrysPost202Retry200HeadersInner> BeginPost202Retry200Async(this ILRORetrysOperations operations, ProductInner product = default(ProductInner), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginPost202Retry200WithHttpMessagesAsync(product, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

            /// <summary>
            /// Long running post request, service returns a 500, then a 202 to the initial
            /// request, with an entity that contains ProvisioningState=’Creating’. Poll
            /// the endpoint indicated in the Azure-AsyncOperation header for operation
            /// status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            public static LRORetrysPostAsyncRelativeRetrySucceededHeadersInner BeginPostAsyncRelativeRetrySucceeded(this ILRORetrysOperations operations, ProductInner product = default(ProductInner))
            {
                return operations.BeginPostAsyncRelativeRetrySucceededAsync(product).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Long running post request, service returns a 500, then a 202 to the initial
            /// request, with an entity that contains ProvisioningState=’Creating’. Poll
            /// the endpoint indicated in the Azure-AsyncOperation header for operation
            /// status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='product'>
            /// Product to put
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<LRORetrysPostAsyncRelativeRetrySucceededHeadersInner> BeginPostAsyncRelativeRetrySucceededAsync(this ILRORetrysOperations operations, ProductInner product = default(ProductInner), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginPostAsyncRelativeRetrySucceededWithHttpMessagesAsync(product, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Headers;
                }
            }

    }
}
