// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsExtensibleEnums
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for PetOperations.
    /// </summary>
    public static partial class PetOperationsExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='petId'>
            /// Pet id
            /// </param>
            public static Pet GetByPetId(this IPetOperations operations, string petId)
            {
                return operations.GetByPetIdAsync(petId).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='petId'>
            /// Pet id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Pet> GetByPetIdAsync(this IPetOperations operations, string petId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByPetIdWithHttpMessagesAsync(petId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
