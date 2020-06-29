// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    /// <summary> One property of operation, include metric specifications. </summary>
    public partial class ServiceSpecification
    {
        /// <summary> Initializes a new instance of ServiceSpecification. </summary>
        internal ServiceSpecification()
        {
            MetricSpecifications = new ChangeTrackingList<MetricSpecification>();
        }

        /// <summary> Initializes a new instance of ServiceSpecification. </summary>
        /// <param name="metricSpecifications"> Metric specifications of operation. </param>
        internal ServiceSpecification(IReadOnlyList<MetricSpecification> metricSpecifications)
        {
            MetricSpecifications = metricSpecifications;
        }

        /// <summary> Metric specifications of operation. </summary>
        public IReadOnlyList<MetricSpecification> MetricSpecifications { get; }
    }
}
