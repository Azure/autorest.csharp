// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;
using Azure.Core.Extensions;
using dpg_update1_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ParamsClient"/> to client builder. </summary>
    public static partial class DpgUpdate1LowLevelClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ParamsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<ParamsClient, ParamsClientOptions> AddParamsClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ParamsClient, ParamsClientOptions>((options) => new ParamsClient(credential, options));
        }

        /// <summary> Registers a <see cref="ParamsClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ParamsClient, ParamsClientOptions> AddParamsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ParamsClient, ParamsClientOptions>(configuration);
        }
    }
}
