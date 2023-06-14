// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.Extensions;
using CustomizationsInCadl;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="CustomizationsInCadlClient"/> to client builder. </summary>
    public static partial class CustomizationsInCadlClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="CustomizationsInCadlClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        public static IAzureClientBuilder<CustomizationsInCadlClient, CustomizationsInCadlClientOptions> AddCustomizationsInCadlClient<TBuilder>(this TBuilder builder)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<CustomizationsInCadlClient, CustomizationsInCadlClientOptions>((options) => new CustomizationsInCadlClient(options));
        }

        /// <summary> Registers a <see cref="CustomizationsInCadlClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<CustomizationsInCadlClient, CustomizationsInCadlClientOptions> AddCustomizationsInCadlClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<CustomizationsInCadlClient, CustomizationsInCadlClientOptions>(configuration);
        }
    }
}
