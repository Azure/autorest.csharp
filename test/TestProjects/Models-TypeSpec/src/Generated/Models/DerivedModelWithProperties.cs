// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Derived model with properties. </summary>
    public partial class DerivedModelWithProperties : BaseModelWithProperties
    {
        /// <summary> Initializes a new instance of DerivedModelWithProperties. </summary>
        /// <param name="requiredCollection"> Required collection. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredCollection"/> is null. </exception>
        public DerivedModelWithProperties(IEnumerable<CollectionItem> requiredCollection)
        {
            Argument.AssertNotNull(requiredCollection, nameof(requiredCollection));

            RequiredCollection = requiredCollection.ToList();
        }

        /// <summary> Initializes a new instance of DerivedModelWithProperties. </summary>
        /// <param name="optionalPropertyOnBase"> Optional properties on base. </param>
        /// <param name="requiredCollection"> Required collection. </param>
        internal DerivedModelWithProperties(string optionalPropertyOnBase, IList<CollectionItem> requiredCollection) : base(optionalPropertyOnBase)
        {
            RequiredCollection = requiredCollection;
        }

        /// <summary> Required collection. </summary>
        public IList<CollectionItem> RequiredCollection { get; }
    }
}
