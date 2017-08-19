// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsBodyDateTimeRfc1123
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Datetimerfc1123.
    /// </summary>
    public static partial class Datetimerfc1123Extensions
    {
            /// <summary>
            /// Get null datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetNull(this IDatetimerfc1123 operations)
            {
                return operations.GetNullAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get null datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.DateTime?> GetNullAsync(this IDatetimerfc1123 operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetNullWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get invalid datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetInvalid(this IDatetimerfc1123 operations)
            {
                return operations.GetInvalidAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get invalid datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.DateTime?> GetInvalidAsync(this IDatetimerfc1123 operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetInvalidWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get overflow datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetOverflow(this IDatetimerfc1123 operations)
            {
                return operations.GetOverflowAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get overflow datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.DateTime?> GetOverflowAsync(this IDatetimerfc1123 operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetOverflowWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get underflow datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetUnderflow(this IDatetimerfc1123 operations)
            {
                return operations.GetUnderflowAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get underflow datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.DateTime?> GetUnderflowAsync(this IDatetimerfc1123 operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetUnderflowWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put max datetime value Fri, 31 Dec 9999 23:59:59 GMT
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            public static void PutUtcMaxDateTime(this IDatetimerfc1123 operations, System.DateTime datetimeBody)
            {
                operations.PutUtcMaxDateTimeAsync(datetimeBody).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put max datetime value Fri, 31 Dec 9999 23:59:59 GMT
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PutUtcMaxDateTimeAsync(this IDatetimerfc1123 operations, System.DateTime datetimeBody, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PutUtcMaxDateTimeWithHttpMessagesAsync(datetimeBody, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get max datetime value fri, 31 dec 9999 23:59:59 gmt
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetUtcLowercaseMaxDateTime(this IDatetimerfc1123 operations)
            {
                return operations.GetUtcLowercaseMaxDateTimeAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get max datetime value fri, 31 dec 9999 23:59:59 gmt
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.DateTime?> GetUtcLowercaseMaxDateTimeAsync(this IDatetimerfc1123 operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetUtcLowercaseMaxDateTimeWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get max datetime value FRI, 31 DEC 9999 23:59:59 GMT
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetUtcUppercaseMaxDateTime(this IDatetimerfc1123 operations)
            {
                return operations.GetUtcUppercaseMaxDateTimeAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get max datetime value FRI, 31 DEC 9999 23:59:59 GMT
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.DateTime?> GetUtcUppercaseMaxDateTimeAsync(this IDatetimerfc1123 operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetUtcUppercaseMaxDateTimeWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put min datetime value Mon, 1 Jan 0001 00:00:00 GMT
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            public static void PutUtcMinDateTime(this IDatetimerfc1123 operations, System.DateTime datetimeBody)
            {
                operations.PutUtcMinDateTimeAsync(datetimeBody).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put min datetime value Mon, 1 Jan 0001 00:00:00 GMT
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PutUtcMinDateTimeAsync(this IDatetimerfc1123 operations, System.DateTime datetimeBody, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PutUtcMinDateTimeWithHttpMessagesAsync(datetimeBody, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get min datetime value Mon, 1 Jan 0001 00:00:00 GMT
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetUtcMinDateTime(this IDatetimerfc1123 operations)
            {
                return operations.GetUtcMinDateTimeAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get min datetime value Mon, 1 Jan 0001 00:00:00 GMT
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.DateTime?> GetUtcMinDateTimeAsync(this IDatetimerfc1123 operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetUtcMinDateTimeWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
