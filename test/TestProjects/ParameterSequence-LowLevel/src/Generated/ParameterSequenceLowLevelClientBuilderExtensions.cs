// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;
using Azure.Core.Extensions;
using ParameterSequence_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ParameterSequenceClient"/> to client builder. </summary>
    public static partial class ParameterSequenceLowLevelClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ParameterSequenceClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<ParameterSequenceClient, ParameterSequenceClientOptions> AddParameterSequenceClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ParameterSequenceClient, ParameterSequenceClientOptions>((options) => new ParameterSequenceClient(credential, options));
        }

        /// <summary> Registers a <see cref="ParameterSequenceClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ParameterSequenceClient, ParameterSequenceClientOptions> AddParameterSequenceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ParameterSequenceClient, ParameterSequenceClientOptions>(configuration);
        }
    }
}
