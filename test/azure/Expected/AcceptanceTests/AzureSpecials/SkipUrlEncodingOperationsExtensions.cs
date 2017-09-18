// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.AcceptanceTestsAzureSpecials
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for SkipUrlEncodingOperations.
    /// </summary>
    public static partial class SkipUrlEncodingOperationsExtensions
    {
            /// <summary>
            /// Get method with unencoded path parameter with value 'path1/path2/path3'
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='unencodedPathParam'>
            /// Unencoded path parameter with value 'path1/path2/path3'
            /// </param>
            public static void GetMethodPathValid(this ISkipUrlEncodingOperations operations, string unencodedPathParam)
            {
                operations.GetMethodPathValidAsync(unencodedPathParam).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get method with unencoded path parameter with value 'path1/path2/path3'
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='unencodedPathParam'>
            /// Unencoded path parameter with value 'path1/path2/path3'
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task GetMethodPathValidAsync(this ISkipUrlEncodingOperations operations, string unencodedPathParam, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.GetMethodPathValidWithHttpMessagesAsync(unencodedPathParam, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get method with unencoded path parameter with value 'path1/path2/path3'
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='unencodedPathParam'>
            /// Unencoded path parameter with value 'path1/path2/path3'
            /// </param>
            public static void GetPathPathValid(this ISkipUrlEncodingOperations operations, string unencodedPathParam)
            {
                operations.GetPathPathValidAsync(unencodedPathParam).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get method with unencoded path parameter with value 'path1/path2/path3'
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='unencodedPathParam'>
            /// Unencoded path parameter with value 'path1/path2/path3'
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task GetPathPathValidAsync(this ISkipUrlEncodingOperations operations, string unencodedPathParam, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.GetPathPathValidWithHttpMessagesAsync(unencodedPathParam, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get method with unencoded path parameter with value 'path1/path2/path3'
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static void GetSwaggerPathValid(this ISkipUrlEncodingOperations operations)
            {
                operations.GetSwaggerPathValidAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get method with unencoded path parameter with value 'path1/path2/path3'
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task GetSwaggerPathValidAsync(this ISkipUrlEncodingOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.GetSwaggerPathValidWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get method with unencoded query parameter with value
            /// 'value1&amp;q2=value2&amp;q3=value3'
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='q1'>
            /// Unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'
            /// </param>
            public static void GetMethodQueryValid(this ISkipUrlEncodingOperations operations, string q1)
            {
                operations.GetMethodQueryValidAsync(q1).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get method with unencoded query parameter with value
            /// 'value1&amp;q2=value2&amp;q3=value3'
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='q1'>
            /// Unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task GetMethodQueryValidAsync(this ISkipUrlEncodingOperations operations, string q1, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.GetMethodQueryValidWithHttpMessagesAsync(q1, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get method with unencoded query parameter with value null
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='q1'>
            /// Unencoded query parameter with value null
            /// </param>
            public static void GetMethodQueryNull(this ISkipUrlEncodingOperations operations, string q1 = default(string))
            {
                operations.GetMethodQueryNullAsync(q1).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get method with unencoded query parameter with value null
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='q1'>
            /// Unencoded query parameter with value null
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task GetMethodQueryNullAsync(this ISkipUrlEncodingOperations operations, string q1 = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.GetMethodQueryNullWithHttpMessagesAsync(q1, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get method with unencoded query parameter with value
            /// 'value1&amp;q2=value2&amp;q3=value3'
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='q1'>
            /// Unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'
            /// </param>
            public static void GetPathQueryValid(this ISkipUrlEncodingOperations operations, string q1)
            {
                operations.GetPathQueryValidAsync(q1).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get method with unencoded query parameter with value
            /// 'value1&amp;q2=value2&amp;q3=value3'
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='q1'>
            /// Unencoded query parameter with value 'value1&amp;q2=value2&amp;q3=value3'
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task GetPathQueryValidAsync(this ISkipUrlEncodingOperations operations, string q1, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.GetPathQueryValidWithHttpMessagesAsync(q1, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get method with unencoded query parameter with value
            /// 'value1&amp;q2=value2&amp;q3=value3'
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static void GetSwaggerQueryValid(this ISkipUrlEncodingOperations operations)
            {
                operations.GetSwaggerQueryValidAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get method with unencoded query parameter with value
            /// 'value1&amp;q2=value2&amp;q3=value3'
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task GetSwaggerQueryValidAsync(this ISkipUrlEncodingOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.GetSwaggerQueryValidWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
