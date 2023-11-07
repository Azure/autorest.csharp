// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Accessibility_LowLevel;
using Azure;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="AccessibilityClient"/> to client builder. </summary>
    public static partial class AccessibilityLowLevelClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="AccessibilityClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        public static IAzureClientBuilder<AccessibilityClient, AccessibilityClientOptions> AddAccessibilityClient<TBuilder>(this TBuilder builder, AzureKeyCredential credential)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<AccessibilityClient, AccessibilityClientOptions>((options) => new AccessibilityClient(credential, options));
        }

        /// <summary> Registers a <see cref="AccessibilityClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<AccessibilityClient, AccessibilityClientOptions> AddAccessibilityClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<AccessibilityClient, AccessibilityClientOptions>(configuration);
        }
    }
}
