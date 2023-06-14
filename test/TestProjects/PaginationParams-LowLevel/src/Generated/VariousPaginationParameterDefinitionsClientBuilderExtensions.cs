// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using PaginationParams_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="PaginationParamsClient"/> to client builder. </summary>
    public static partial class VariousPaginationParameterDefinitionsClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="PaginationParamsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<PaginationParamsClient, PaginationParamsClientOptions> AddPaginationParamsClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<PaginationParamsClient, PaginationParamsClientOptions>((options, cred) => new PaginationParamsClient(cred, endpoint, options));
        }

        /// <summary> Registers a <see cref="PaginationParamsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<PaginationParamsClient, PaginationParamsClientOptions> AddPaginationParamsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<PaginationParamsClient, PaginationParamsClientOptions>(configuration);
        }
    }
}
