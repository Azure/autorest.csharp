// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace ModelShapes.Models
{
    /// <summary> The MixedModelWithReadonlyProperty. </summary>
    public partial class MixedModelWithReadonlyProperty
    {
        /// <summary> Initializes a new instance of MixedModelWithReadonlyProperty. </summary>
        public MixedModelWithReadonlyProperty()
        {
            ReadonlyListProperty = new ChangeTrackingList<ReadonlyModel>();
        }

        /// <summary> Initializes a new instance of MixedModelWithReadonlyProperty. </summary>
        /// <param name="readonlyProperty"></param>
        /// <param name="readonlyListProperty"></param>
        internal MixedModelWithReadonlyProperty(ReadonlyModel readonlyProperty, IReadOnlyList<ReadonlyModel> readonlyListProperty)
        {
            ReadonlyProperty = readonlyProperty;
            ReadonlyListProperty = readonlyListProperty;
        }

        /// <summary> Gets the readonly property. </summary>
        public ReadonlyModel ReadonlyProperty { get; }
        /// <summary> Gets the readonly list property. </summary>
        public IReadOnlyList<ReadonlyModel> ReadonlyListProperty { get; }
    }
}
