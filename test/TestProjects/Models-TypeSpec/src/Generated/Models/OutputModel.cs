// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Model used only as output. </summary>
    public partial class OutputModel
    {
        /// <summary> Initializes a new instance of OutputModel. </summary>
        /// <param name="requiredString"> Required string. </param>
        /// <param name="requiredInt"> Required int. </param>
        /// <param name="requiredModel"> Required model. </param>
        /// <param name="requiredCollection"> Required collection. </param>
        /// <param name="requiredModelRecord"> Required model record. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/>, <paramref name="requiredModel"/>, <paramref name="requiredCollection"/> or <paramref name="requiredModelRecord"/> is null. </exception>
        internal OutputModel(string requiredString, int requiredInt, DerivedModel requiredModel, IEnumerable<CollectionItem> requiredCollection, IReadOnlyDictionary<string, RecordItem> requiredModelRecord)
        {
            Argument.AssertNotNull(requiredString, nameof(requiredString));
            Argument.AssertNotNull(requiredModel, nameof(requiredModel));
            Argument.AssertNotNull(requiredCollection, nameof(requiredCollection));
            Argument.AssertNotNull(requiredModelRecord, nameof(requiredModelRecord));

            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredModel = requiredModel;
            RequiredCollection = requiredCollection.ToList();
            RequiredModelRecord = requiredModelRecord;
        }

        /// <summary> Initializes a new instance of OutputModel. </summary>
        /// <param name="requiredString"> Required string. </param>
        /// <param name="requiredInt"> Required int. </param>
        /// <param name="requiredModel"> Required model. </param>
        /// <param name="requiredCollection"> Required collection. </param>
        /// <param name="requiredModelRecord"> Required model record. </param>
        internal OutputModel(string requiredString, int requiredInt, DerivedModel requiredModel, IReadOnlyList<CollectionItem> requiredCollection, IReadOnlyDictionary<string, RecordItem> requiredModelRecord)
        {
            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredModel = requiredModel;
            RequiredCollection = requiredCollection;
            RequiredModelRecord = requiredModelRecord;
        }

        /// <summary> Required string. </summary>
        public string RequiredString { get; }
        /// <summary> Required int. </summary>
        public int RequiredInt { get; }
        /// <summary> Required model. </summary>
        public DerivedModel RequiredModel { get; }
        /// <summary> Required collection. </summary>
        public IReadOnlyList<CollectionItem> RequiredCollection { get; }
        /// <summary> Required model record. </summary>
        public IReadOnlyDictionary<string, RecordItem> RequiredModelRecord { get; }
    }
}
