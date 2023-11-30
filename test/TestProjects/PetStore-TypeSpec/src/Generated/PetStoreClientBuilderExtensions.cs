// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using PetStore;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="PetStoreClient"/> to client builder. </summary>
    public static partial class PetStoreClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="PetStoreClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        public static IAzureClientBuilder<PetStoreClient, PetStoreClientOptions> AddPetStoreClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<PetStoreClient, PetStoreClientOptions>((options) => new PetStoreClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="PetStoreClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<PetStoreClient, PetStoreClientOptions> AddPetStoreClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<PetStoreClient, PetStoreClientOptions>(configuration);
        }
    }
}
