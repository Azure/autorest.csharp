// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Fixtures.AcceptanceTestsBodyDate
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Date.
    /// </summary>
    public static partial class DateExtensions
    {
            /// <summary>
            /// Get null date value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetNull(this IDate operations)
            {
                return operations.GetNullAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get null date value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.DateTime?> GetNullAsync(this IDate operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetNullWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get invalid date value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetInvalidDate(this IDate operations)
            {
                return operations.GetInvalidDateAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get invalid date value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.DateTime?> GetInvalidDateAsync(this IDate operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetInvalidDateWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get overflow date value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetOverflowDate(this IDate operations)
            {
                return operations.GetOverflowDateAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get overflow date value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.DateTime?> GetOverflowDateAsync(this IDate operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetOverflowDateWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get underflow date value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetUnderflowDate(this IDate operations)
            {
                return operations.GetUnderflowDateAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get underflow date value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.DateTime?> GetUnderflowDateAsync(this IDate operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetUnderflowDateWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put max date value 9999-12-31
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='dateBody'>
            /// </param>
            public static void PutMaxDate(this IDate operations, System.DateTime dateBody)
            {
                operations.PutMaxDateAsync(dateBody).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put max date value 9999-12-31
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='dateBody'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PutMaxDateAsync(this IDate operations, System.DateTime dateBody, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PutMaxDateWithHttpMessagesAsync(dateBody, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get max date value 9999-12-31
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetMaxDate(this IDate operations)
            {
                return operations.GetMaxDateAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get max date value 9999-12-31
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.DateTime?> GetMaxDateAsync(this IDate operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetMaxDateWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put min date value 0000-01-01
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='dateBody'>
            /// </param>
            public static void PutMinDate(this IDate operations, System.DateTime dateBody)
            {
                operations.PutMinDateAsync(dateBody).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put min date value 0000-01-01
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='dateBody'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PutMinDateAsync(this IDate operations, System.DateTime dateBody, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PutMinDateWithHttpMessagesAsync(dateBody, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get min date value 0000-01-01
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetMinDate(this IDate operations)
            {
                return operations.GetMinDateAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get min date value 0000-01-01
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.DateTime?> GetMinDateAsync(this IDate operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetMinDateWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
