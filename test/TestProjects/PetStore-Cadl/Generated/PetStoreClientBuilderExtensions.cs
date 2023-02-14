// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using PetStore;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add clients to client builder. </summary>
    public static partial class PetStoreClientBuilderExtensions
    {
        /// <param name="builder"></param>
        /// <param name="endpoint"> The Uri to use. </param>
        public static IAzureClientBuilder<PetStoreClient, PetStoreClientOptions> AddPetStoreClient<TBuilder>(TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<PetStoreClient, PetStoreClientOptions>((options) => new PetStoreClient(endpoint, options));
        }
    }
}
