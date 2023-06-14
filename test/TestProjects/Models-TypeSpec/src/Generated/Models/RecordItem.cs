// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Record item model. </summary>
    public partial class RecordItem : DerivedModel
    {
        /// <summary> Initializes a new instance of RecordItem. </summary>
        /// <param name="requiredCollection"> Required collection. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredCollection"/> is null. </exception>
        public RecordItem(IEnumerable<CollectionItem> requiredCollection) : base(requiredCollection)
        {
            Argument.AssertNotNull(requiredCollection, nameof(requiredCollection));
        }

        /// <summary> Initializes a new instance of RecordItem. </summary>
        /// <param name="requiredCollection"> Required collection. </param>
        internal RecordItem(IList<CollectionItem> requiredCollection) : base(requiredCollection)
        {
        }
    }
}
