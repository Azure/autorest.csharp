// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using _Type.Model.Inheritance;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="InheritanceClient"/> to client builder. </summary>
    public static partial class TypeModelInheritanceClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="InheritanceClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<InheritanceClient, InheritanceClientOptions> AddInheritanceClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<InheritanceClient, InheritanceClientOptions>((options) => new InheritanceClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="InheritanceClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<InheritanceClient, InheritanceClientOptions> AddInheritanceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<InheritanceClient, InheritanceClientOptions>(configuration);
        }
    }
}
