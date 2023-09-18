// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using _Type.Model.Inheritance.NotDiscriminated;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="NotDiscriminatedClient"/> to client builder. </summary>
    public static partial class TypeModelInheritanceNotDiscriminatedClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="NotDiscriminatedClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<NotDiscriminatedClient, NotDiscriminatedClientOptions> AddNotDiscriminatedClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<NotDiscriminatedClient, NotDiscriminatedClientOptions>((options) => new NotDiscriminatedClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="NotDiscriminatedClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<NotDiscriminatedClient, NotDiscriminatedClientOptions> AddNotDiscriminatedClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<NotDiscriminatedClient, NotDiscriminatedClientOptions>(configuration);
        }
    }
}
