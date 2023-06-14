// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Derived model. </summary>
    public partial class DerivedModel : BaseModel
    {
        /// <summary> Initializes a new instance of DerivedModel. </summary>
        /// <param name="requiredCollection"> Required collection. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredCollection"/> is null. </exception>
        public DerivedModel(IEnumerable<CollectionItem> requiredCollection)
        {
            Argument.AssertNotNull(requiredCollection, nameof(requiredCollection));

            RequiredCollection = requiredCollection.ToList();
        }

        /// <summary> Initializes a new instance of DerivedModel. </summary>
        /// <param name="requiredCollection"> Required collection. </param>
        internal DerivedModel(IList<CollectionItem> requiredCollection)
        {
            RequiredCollection = requiredCollection;
        }

        /// <summary> Required collection. </summary>
        public IList<CollectionItem> RequiredCollection { get; }
    }
}
