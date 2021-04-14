// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A Class representing a LogAnalytics along with the instance operations that can be performed on it. </summary>
    public class LogAnalytics : LogAnalyticsOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "LogAnalytics"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal LogAnalytics(ResourceOperationsBase options, LogAnalyticsData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets or sets the global::Azure.ResourceManager.Sample.LogAnalyticsData
        /// 
        /// .
        /// </summary>
        public LogAnalyticsData

         Data
        { get; private set; }

        /// <inheritdoc />
        protected override LogAnalytics GetResource()
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<LogAnalytics> GetResourceAsync(CancellationToken cancellation = default)
        {
            return Task.FromResult(this);
        }
    }
}
