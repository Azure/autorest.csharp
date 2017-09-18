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
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Dictionary.
    /// </summary>
    public static partial class DictionaryExtensions
    {
            /// <summary>
            /// Get complex types with dictionary property
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static DictionaryWrapper GetValid(this IDictionary operations)
            {
                return operations.GetValidAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get complex types with dictionary property
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DictionaryWrapper> GetValidAsync(this IDictionary operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetValidWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put complex types with dictionary property
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='defaultProgram'>
            /// </param>
            public static void PutValid(this IDictionary operations, IDictionary<string, string> defaultProgram = default(IDictionary<string, string>))
            {
                operations.PutValidAsync(defaultProgram).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put complex types with dictionary property
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='defaultProgram'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PutValidAsync(this IDictionary operations, IDictionary<string, string> defaultProgram = default(IDictionary<string, string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PutValidWithHttpMessagesAsync(defaultProgram, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get complex types with dictionary property which is empty
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static DictionaryWrapper GetEmpty(this IDictionary operations)
            {
                return operations.GetEmptyAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get complex types with dictionary property which is empty
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DictionaryWrapper> GetEmptyAsync(this IDictionary operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetEmptyWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put complex types with dictionary property which is empty
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='defaultProgram'>
            /// </param>
            public static void PutEmpty(this IDictionary operations, IDictionary<string, string> defaultProgram = default(IDictionary<string, string>))
            {
                operations.PutEmptyAsync(defaultProgram).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put complex types with dictionary property which is empty
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='defaultProgram'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PutEmptyAsync(this IDictionary operations, IDictionary<string, string> defaultProgram = default(IDictionary<string, string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PutEmptyWithHttpMessagesAsync(defaultProgram, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Get complex types with dictionary property which is null
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static DictionaryWrapper GetNull(this IDictionary operations)
            {
                return operations.GetNullAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get complex types with dictionary property which is null
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DictionaryWrapper> GetNullAsync(this IDictionary operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetNullWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get complex types with dictionary property while server doesn't provide a
            /// response payload
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static DictionaryWrapper GetNotProvided(this IDictionary operations)
            {
                return operations.GetNotProvidedAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get complex types with dictionary property while server doesn't provide a
            /// response payload
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DictionaryWrapper> GetNotProvidedAsync(this IDictionary operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetNotProvidedWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
