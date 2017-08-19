// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsBodyComplex
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Readonlyproperty.
    /// </summary>
    public static partial class ReadonlypropertyExtensions
    {
            /// <summary>
            /// Get complex types that have readonly properties
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static ReadonlyObj GetValid(this IReadonlyproperty operations)
            {
                return operations.GetValidAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get complex types that have readonly properties
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ReadonlyObj> GetValidAsync(this IReadonlyproperty operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetValidWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put complex types that have readonly properties
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='size'>
            /// </param>
            public static void PutValid(this IReadonlyproperty operations, int? size = default(int?))
            {
                operations.PutValidAsync(size).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put complex types that have readonly properties
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='size'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PutValidAsync(this IReadonlyproperty operations, int? size = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PutValidWithHttpMessagesAsync(size, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
