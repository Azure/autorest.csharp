// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    /// <summary> The DerivedModel. </summary>
    public partial class DerivedModel : BaseModel
    {
        /// <summary> Initializes a new instance of DerivedModel. </summary>
        /// <param name="requiredCollection"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredCollection"/> is null. </exception>
        public DerivedModel(IEnumerable<string> requiredCollection)
        {
            Argument.AssertNotNull(requiredCollection, nameof(requiredCollection));

            RequiredCollection = requiredCollection.ToList();
        }

        /// <summary> Initializes a new instance of DerivedModel. </summary>
        /// <param name="optionalString"></param>
        /// <param name="requiredCollection"></param>
        internal DerivedModel(string optionalString, IList<string> requiredCollection) : base(optionalString)
        {
            RequiredCollection = requiredCollection;
        }

        /// <summary> Gets the required collection. </summary>
        public IList<string> RequiredCollection { get; }
    }
}
