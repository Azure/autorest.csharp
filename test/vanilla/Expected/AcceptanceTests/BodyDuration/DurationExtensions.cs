// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Fixtures.AcceptanceTestsBodyDuration
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Duration.
    /// </summary>
    public static partial class DurationExtensions
    {
            /// <summary>
            /// Get null duration value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.TimeSpan? GetNull(this IDuration operations)
            {
                return operations.GetNullAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get null duration value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.TimeSpan?> GetNullAsync(this IDuration operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetNullWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put a positive duration value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='durationBody'>
            /// </param>
            public static void PutPositiveDuration(this IDuration operations, System.TimeSpan durationBody)
            {
                operations.PutPositiveDurationAsync(durationBody).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put a positive duration value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='durationBody'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PutPositiveDurationAsync(this IDuration operations, System.TimeSpan durationBody, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PutPositiveDurationWithHttpMessagesAsync(durationBody, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get a positive duration value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.TimeSpan? GetPositiveDuration(this IDuration operations)
            {
                return operations.GetPositiveDurationAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get a positive duration value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.TimeSpan?> GetPositiveDurationAsync(this IDuration operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetPositiveDurationWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get an invalid duration value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.TimeSpan? GetInvalid(this IDuration operations)
            {
                return operations.GetInvalidAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get an invalid duration value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<System.TimeSpan?> GetInvalidAsync(this IDuration operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetInvalidWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
