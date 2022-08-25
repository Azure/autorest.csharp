// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CadlFirstTest
{
    /// <summary> The RoundTripModel. </summary>
    public partial class RoundTripModel
    {
        /// <summary> Initializes a new instance of RoundTripModel. </summary>
        /// <param name="requiredString"></param>
        /// <param name="requiredInt"></param>
        /// <param name="requiredCollection"></param>
        /// <param name="requiredDictionary"></param>
        /// <param name="requiredModel"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/>, <paramref name="requiredCollection"/>, <paramref name="requiredDictionary"/> or <paramref name="requiredModel"/> is null. </exception>
        public RoundTripModel(string requiredString, int requiredInt, IEnumerable<SimpleEnum> requiredCollection, IDictionary<string, ExtensibleEnum> requiredDictionary, Thing requiredModel)
        {
            Argument.AssertNotNull(requiredString, nameof(requiredString));
            Argument.AssertNotNull(requiredCollection, nameof(requiredCollection));
            Argument.AssertNotNull(requiredDictionary, nameof(requiredDictionary));
            Argument.AssertNotNull(requiredModel, nameof(requiredModel));

            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredCollection = requiredCollection.ToList();
            RequiredDictionary = requiredDictionary;
            RequiredModel = requiredModel;
        }
        /// <summary> Initializes a new instance of RoundTripModel. </summary>
        /// <param name="requiredString"></param>
        /// <param name="requiredInt"></param>
        /// <param name="requiredCollection"></param>
        /// <param name="requiredDictionary"></param>
        /// <param name="requiredModel"></param>
        internal RoundTripModel(string requiredString, int requiredInt, IList<SimpleEnum> requiredCollection, IDictionary<string, ExtensibleEnum> requiredDictionary, Thing requiredModel)
        {
            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredCollection = requiredCollection;
            RequiredDictionary = requiredDictionary;
            RequiredModel = requiredModel;
        }

        public string RequiredString { get; set; }

        public int RequiredInt { get; set; }

        public IList<SimpleEnum> RequiredCollection { get; }

        public IDictionary<string, ExtensibleEnum> RequiredDictionary { get; }

        public Thing RequiredModel { get; set; }
    }
}
