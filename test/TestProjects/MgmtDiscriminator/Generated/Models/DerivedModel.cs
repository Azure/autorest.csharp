// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
        /// <summary> Initializes a new instance of <see cref="DerivedModel"/>. </summary>
        /// <param name="requiredCollection"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredCollection"/> is null. </exception>
        public DerivedModel(IEnumerable<string> requiredCollection)
        {
            Argument.AssertNotNull(requiredCollection, nameof(requiredCollection));

            RequiredCollection = requiredCollection.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="DerivedModel"/>. </summary>
        /// <param name="optionalString"></param>
        /// <param name="requiredCollection"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DerivedModel(string optionalString, IList<string> requiredCollection, Dictionary<string, BinaryData> rawData) : base(optionalString, rawData)
        {
            RequiredCollection = requiredCollection;
        }

        /// <summary> Initializes a new instance of <see cref="DerivedModel"/> for deserialization. </summary>
        internal DerivedModel()
        {
        }

        /// <summary> Gets the required collection. </summary>
        public IList<string> RequiredCollection { get; }
    }
}
