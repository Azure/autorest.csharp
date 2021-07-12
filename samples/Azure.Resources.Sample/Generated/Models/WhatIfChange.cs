// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Resources.Sample
{
    /// <summary> Information about a single resource change predicted by What-If operation. </summary>
    public partial class WhatIfChange
    {
        /// <summary> Initializes a new instance of WhatIfChange. </summary>
        /// <param name="resourceId"> Resource ID. </param>
        /// <param name="changeType"> Type of change that will be made to the resource when the deployment is executed. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> is null. </exception>
        internal WhatIfChange(string resourceId, ChangeType changeType)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }

            ResourceId = resourceId;
            ChangeType = changeType;
            Delta = new ChangeTrackingList<WhatIfPropertyChange>();
        }

        /// <summary> Initializes a new instance of WhatIfChange. </summary>
        /// <param name="resourceId"> Resource ID. </param>
        /// <param name="changeType"> Type of change that will be made to the resource when the deployment is executed. </param>
        /// <param name="unsupportedReason"> The explanation about why the resource is unsupported by What-If. </param>
        /// <param name="before"> The snapshot of the resource before the deployment is executed. </param>
        /// <param name="after"> The predicted snapshot of the resource after the deployment is executed. </param>
        /// <param name="delta"> The predicted changes to resource properties. </param>
        internal WhatIfChange(string resourceId, ChangeType changeType, string unsupportedReason, object before, object after, IReadOnlyList<WhatIfPropertyChange> delta)
        {
            ResourceId = resourceId;
            ChangeType = changeType;
            UnsupportedReason = unsupportedReason;
            Before = before;
            After = after;
            Delta = delta;
        }

        /// <summary> Resource ID. </summary>
        public string ResourceId { get; }
        /// <summary> Type of change that will be made to the resource when the deployment is executed. </summary>
        public ChangeType ChangeType { get; }
        /// <summary> The explanation about why the resource is unsupported by What-If. </summary>
        public string UnsupportedReason { get; }
        /// <summary> The snapshot of the resource before the deployment is executed. </summary>
        public object Before { get; }
        /// <summary> The predicted snapshot of the resource after the deployment is executed. </summary>
        public object After { get; }
        /// <summary> The predicted changes to resource properties. </summary>
        public IReadOnlyList<WhatIfPropertyChange> Delta { get; }
    }
}
