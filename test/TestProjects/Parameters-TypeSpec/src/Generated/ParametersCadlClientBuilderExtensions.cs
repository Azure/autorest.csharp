// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.Extensions;
using ParametersCadl;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ParametersCadlClient"/> to client builder. </summary>
    public static partial class ParametersCadlClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ParametersCadlClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        public static IAzureClientBuilder<ParametersCadlClient, ParametersCadlClientOptions> AddParametersCadlClient<TBuilder>(this TBuilder builder)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ParametersCadlClient, ParametersCadlClientOptions>((options) => new ParametersCadlClient(options));
        }

        /// <summary> Registers a <see cref="ParametersCadlClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ParametersCadlClient, ParametersCadlClientOptions> AddParametersCadlClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ParametersCadlClient, ParametersCadlClientOptions>(configuration);
        }
    }
}
