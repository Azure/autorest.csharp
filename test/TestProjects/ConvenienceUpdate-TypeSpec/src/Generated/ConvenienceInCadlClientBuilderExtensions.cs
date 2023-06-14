// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.Extensions;
using ConvenienceInCadl;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ConvenienceInCadlClient"/> to client builder. </summary>
    public static partial class ConvenienceInCadlClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ConvenienceInCadlClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        public static IAzureClientBuilder<ConvenienceInCadlClient, ConvenienceInCadlClientOptions> AddConvenienceInCadlClient<TBuilder>(this TBuilder builder)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ConvenienceInCadlClient, ConvenienceInCadlClientOptions>((options) => new ConvenienceInCadlClient(options));
        }

        /// <summary> Registers a <see cref="ConvenienceInCadlClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ConvenienceInCadlClient, ConvenienceInCadlClientOptions> AddConvenienceInCadlClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ConvenienceInCadlClient, ConvenienceInCadlClientOptions>(configuration);
        }
    }
}
