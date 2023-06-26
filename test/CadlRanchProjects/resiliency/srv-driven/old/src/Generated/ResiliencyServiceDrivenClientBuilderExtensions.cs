// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core.Extensions;
using Resiliency.ServiceDriven.Old;

namespace Microsoft.Extensions.Azure
{
    /// <summary> Extension methods to add <see cref="ResiliencyServiceDrivenClient"/> to client builder. </summary>
    public static partial class ResiliencyServiceDrivenClientBuilderExtensions
    {
        /// <summary> Registers a <see cref="ResiliencyServiceDrivenClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="serviceDeploymentVersion"> Pass in either 'v1' or 'v2'. This represents a version of the service deployment in history. 'v1' is for the deployment when the service had only one api version. 'v2' is for the deployment when the service had api-versions 'v1' and 'v2'. </param>
        public static IAzureClientBuilder<ResiliencyServiceDrivenClient, ResiliencyServiceDrivenClientOptions> AddResiliencyServiceDrivenClient<TBuilder>(this TBuilder builder, string serviceDeploymentVersion)
        where TBuilder : IAzureClientFactoryBuilder
        {
            return builder.RegisterClientFactory<ResiliencyServiceDrivenClient, ResiliencyServiceDrivenClientOptions>((options) => new ResiliencyServiceDrivenClient(serviceDeploymentVersion, options));
        }

        /// <summary> Registers a <see cref="ResiliencyServiceDrivenClient"/> instance. </summary>
        /// <param name="builder"> The builder to register with. </param>
        /// <param name="configuration"> The configuration values. </param>
        public static IAzureClientBuilder<ResiliencyServiceDrivenClient, ResiliencyServiceDrivenClientOptions> AddResiliencyServiceDrivenClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration)
        where TBuilder : IAzureClientFactoryBuilderWithConfiguration<TConfiguration>
        {
            return builder.RegisterClientFactory<ResiliencyServiceDrivenClient, ResiliencyServiceDrivenClientOptions>(configuration);
        }
    }
}
