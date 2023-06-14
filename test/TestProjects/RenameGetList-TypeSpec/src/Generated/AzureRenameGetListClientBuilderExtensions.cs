// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using Azure.RenameGetList;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="RenameGetListClient"/> to client builder. </summary>
    public static partial class AzureRenameGetListClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="RenameGetListClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> The Uri to use. </param>
        public static IAzureClientBuilder<RenameGetListClient, RenameGetListClientOptions> AddRenameGetListClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<RenameGetListClient, RenameGetListClientOptions>((options) => new RenameGetListClient(endpoint, options));
        }

        /// <summary> Registers a <see cref="RenameGetListClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<RenameGetListClient, RenameGetListClientOptions> AddRenameGetListClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<RenameGetListClient, RenameGetListClientOptions>(configuration);
        }
    }
}
