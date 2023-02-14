// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Extensions;
using Models.Inheritance;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add clients to client builder. </summary>
    public static partial class ModelsInheritanceClientBuilderExtensions
    {
        /// <param name="builder"></param>
        /// <param name="endpoint"> TestServer endpoint. </param>
        public static IAzureClientBuilder<InheritanceClient, InheritanceClientOptions> AddInheritanceClient<TBuilder>(TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<InheritanceClient, InheritanceClientOptions>((options) => new InheritanceClient(endpoint, options));
        }

        /// <param name="builder"></param>
        /// <param name="configuration"></param>
        public static IAzureClientBuilder<InheritanceClient, InheritanceClientOptions> AddInheritanceClient<TBuilder, TConfiguration>(TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<InheritanceClient, InheritanceClientOptions>(configuration);
        }
    }
}
