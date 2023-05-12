// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using TypeSpec.HeadClient;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="HeadClientClient"/> to client builder. </summary>
    public static partial class TypeSpecHeadClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="HeadClientClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<HeadClientClient, HeadClientClientOptions> AddHeadClientClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<HeadClientClient, HeadClientClientOptions>((options) => new HeadClientClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="HeadClientClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<HeadClientClient, HeadClientClientOptions> AddHeadClientClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<HeadClientClient, HeadClientClientOptions>(configuration);
        }
    }
}
