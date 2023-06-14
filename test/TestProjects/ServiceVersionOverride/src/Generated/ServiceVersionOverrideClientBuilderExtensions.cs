// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using ServiceVersionOverride;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ServiceVersionOverrideClient"/> to client builder. </summary>
    public static partial class ServiceVersionOverrideClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ServiceVersionOverrideClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<ServiceVersionOverrideClient, ServiceVersionOverrideClientOptions> AddServiceVersionOverrideClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ServiceVersionOverrideClient, ServiceVersionOverrideClientOptions>((options) => new ServiceVersionOverrideClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="ServiceVersionOverrideClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ServiceVersionOverrideClient, ServiceVersionOverrideClientOptions> AddServiceVersionOverrideClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ServiceVersionOverrideClient, ServiceVersionOverrideClientOptions>(configuration);
        }
    }
}
