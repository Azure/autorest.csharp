// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;
using Azure.Core.Extensions;
using dpg_customization_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="DPGClient"/> to client builder. </summary>
    public static partial class DpgCustomizationLowLevelClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="DPGClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<DPGClient, DPGClientOptions> AddDPGClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<DPGClient, DPGClientOptions>((options) => new DPGClient(credential, options));
        }

        /// <summary> Registers a <see cref="DPGClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<DPGClient, DPGClientOptions> AddDPGClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<DPGClient, DPGClientOptions>(configuration);
        }
    }
}
