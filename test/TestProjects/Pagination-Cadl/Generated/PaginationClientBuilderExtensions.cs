// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using Pagination;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add clients to client builder. </summary>
    public static partial class PaginationClientBuilderExtensions
    {
        /// <param name="builder"></param>
        /// <param name="endpoint"> The Uri to use. </param>
        public static IAzureClientBuilder<PaginationClient, PaginationClientOptions> AddPaginationClient<TBuilder>(TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<PaginationClient, PaginationClientOptions>((options, cred) => new PaginationClient(endpoint, cred, options));
        }

        /// <param name="builder"></param>
        /// <param name="configuration"></param>
        public static IAzureClientBuilder<PaginationClient, PaginationClientOptions> AddPaginationClient<TBuilder, TConfiguration>(TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<PaginationClient, PaginationClientOptions>(configuration);
        }
    }
}
