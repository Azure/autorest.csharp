// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Accessibility_LowLevel_TokenAuth;
using Azure.Core.Extensions;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="AccessibilityClient"/> to client builder. </summary>
    public static partial class AccessibilityTokenAuthClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="AccessibilityClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<AccessibilityClient, AccessibilityClientOptions> AddAccessibilityClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<AccessibilityClient, AccessibilityClientOptions>((options, cred) => new AccessibilityClient(cred, endpoint, options));
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
