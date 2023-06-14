// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core.Extensions;
using security_aad_LowLevel;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="AutorestSecurityAadClient"/> to client builder. </summary>
    public static partial class AutorestSecurityAadClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="AutorestSecurityAadClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="endpoint"> server parameter. </param>
        public static IAzureClientBuilder<AutorestSecurityAadClient, AutorestSecurityAadClientOptions> AddAutorestSecurityAadClient<TBuilder>(this TBuilder builder, Uri endpoint)
        where TBuilder : IAzureClientFactoryBuilderWithCredential
        {
            return builder.RegisterClientFactory<AutorestSecurityAadClient, AutorestSecurityAadClientOptions>((options, cred) => new AutorestSecurityAadClient(cred, endpoint, options));
        }

        /// <summary> Registers a <see cref="AutorestSecurityAadClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<AutorestSecurityAadClient, AutorestSecurityAadClientOptions> AddAutorestSecurityAadClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<AutorestSecurityAadClient, AutorestSecurityAadClientOptions>(configuration);
        }
    }
}
