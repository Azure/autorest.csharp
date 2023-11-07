// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;
using Azure.Core.Extensions;
using body_array_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ArrayClient"/> to client builder. </summary>
    public static partial class BodyArrayLowLevelClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ArrayClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<ArrayClient, ArrayClientOptions> AddArrayClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ArrayClient, ArrayClientOptions>((options) => new ArrayClient(credential, options));
        }

        /// <summary> Registers a <see cref="ArrayClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ArrayClient, ArrayClientOptions> AddArrayClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ArrayClient, ArrayClientOptions>(configuration);
        }
    }
}
