// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using Parameters.QueryOptionality;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="QueryOptionalityClient"/> to client builder. </summary>
    public static partial class ParametersQueryOptionalityClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="QueryOptionalityClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        public static IAzureClientBuilder<QueryOptionalityClient, QueryOptionalityClientOptions> AddQueryOptionalityClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<QueryOptionalityClient, QueryOptionalityClientOptions>((options) => new QueryOptionalityClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="QueryOptionalityClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<QueryOptionalityClient, QueryOptionalityClientOptions> AddQueryOptionalityClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<QueryOptionalityClient, QueryOptionalityClientOptions>(configuration);
        }
    }
}
