// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Resources.Sample
{
    /// <summary> The predicted change to the resource property. </summary>
    public partial class WhatIfPropertyChange
    {
        /// <summary> Initializes a new instance of WhatIfPropertyChange. </summary>
        /// <param name="path"> The path of the property. </param>
        /// <param name="propertyChangeType"> The type of property change. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="path"/> is null. </exception>
        internal WhatIfPropertyChange(string path, PropertyChangeType propertyChangeType)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            Path = path;
            PropertyChangeType = propertyChangeType;
            Children = new ChangeTrackingList<WhatIfPropertyChange>();
        }

        /// <summary> Initializes a new instance of WhatIfPropertyChange. </summary>
        /// <param name="path"> The path of the property. </param>
        /// <param name="propertyChangeType"> The type of property change. </param>
        /// <param name="before"> The value of the property before the deployment is executed. </param>
        /// <param name="after"> The value of the property after the deployment is executed. </param>
        /// <param name="children"> Nested property changes. </param>
        internal WhatIfPropertyChange(string path, PropertyChangeType propertyChangeType, object before, object after, IReadOnlyList<WhatIfPropertyChange> children)
        {
            Path = path;
            PropertyChangeType = propertyChangeType;
            Before = before;
            After = after;
            Children = children;
        }

        /// <summary> The path of the property. </summary>
        public string Path { get; }
        /// <summary> The type of property change. </summary>
        public PropertyChangeType PropertyChangeType { get; }
        /// <summary> The value of the property before the deployment is executed. </summary>
        public object Before { get; }
        /// <summary> The value of the property after the deployment is executed. </summary>
        public object After { get; }
        /// <summary> Nested property changes. </summary>
        public IReadOnlyList<WhatIfPropertyChange> Children { get; }
    }
}
