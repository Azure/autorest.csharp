// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.MirrorSequences
{
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A sample API that uses a petstore as an example to demonstrate features in the swagger-2.0 specification
    /// </summary>
    public partial interface ISequenceRequestResponseTest : System.IDisposable
    {
        /// <summary>
        /// Gets or sets the base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets JSON serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets JSON deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }


        /// <summary>
        /// Creates a new pet in the store.  Duplicates are allowed
        /// </summary>
        /// <param name='pets'>
        /// Pets to add to the store
        /// </param>
        IList<Pet> AddPet(IList<Pet> pets);

        /// <summary>
        /// Creates a new pet in the store.  Duplicates are allowed
        /// </summary>
        /// <param name='pets'>
        /// Pets to add to the store
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<IList<Pet>> AddPetAsync(IList<Pet> pets, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Adds new pet stylesin the store.  Duplicates are allowed
        /// </summary>
        /// <param name='petStyle'>
        /// Pet style to add to the store
        /// </param>
        IList<int?> AddPetStyles(IList<int?> petStyle);

        /// <summary>
        /// Adds new pet stylesin the store.  Duplicates are allowed
        /// </summary>
        /// <param name='petStyle'>
        /// Pet style to add to the store
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<IList<int?>> AddPetStylesAsync(IList<int?> petStyle, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Updates new pet stylesin the store.  Duplicates are allowed
        /// </summary>
        /// <param name='petStyle'>
        /// Pet style to add to the store
        /// </param>
        IList<int?> UpdatePetStyles(IList<int?> petStyle);

        /// <summary>
        /// Updates new pet stylesin the store.  Duplicates are allowed
        /// </summary>
        /// <param name='petStyle'>
        /// Pet style to add to the store
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<IList<int?>> UpdatePetStylesAsync(IList<int?> petStyle, CancellationToken cancellationToken = default(CancellationToken));
    }
}
