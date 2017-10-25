// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsPetStoreExtensibleEnums
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ExtensibleEnumsPet.
    /// </summary>
    public static partial class ExtensibleEnumsPetExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static Pet GetByPetId(this IExtensibleEnumsPet operations)
            {
                return operations.GetByPetIdAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Pet> GetByPetIdAsync(this IExtensibleEnumsPet operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByPetIdWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
