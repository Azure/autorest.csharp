// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using Pagination;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="PaginationClient"/> to client builder. </summary>
    public static partial class PaginationClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="PaginationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The Uri to use. </param>
        public static IAzureClientBuilder<PaginationClient, PaginationClientOptions> AddPaginationClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<PaginationClient, PaginationClientOptions>((options, cred) => new PaginationClient(endpoint, cred, options));
        }

        /// <summary> Registers a <see cref="PaginationClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<PaginationClient, PaginationClientOptions> AddPaginationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<PaginationClient, PaginationClientOptions>(configuration);
        }
    }
}
