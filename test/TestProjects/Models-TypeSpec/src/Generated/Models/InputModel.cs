// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Model used only as input. </summary>
    public partial class InputModel
    {
        /// <summary> Initializes a new instance of InputModel. </summary>
        /// <param name="requiredString"> Required string. </param>
        /// <param name="requiredInt"> Required int. </param>
        /// <param name="requiredModel"> Required model. </param>
        /// <param name="requiredIntCollection"> Required primitive value type collection. </param>
        /// <param name="requiredStringCollection"> Required primitive reference type collection. </param>
        /// <param name="requiredModelCollection"> Required model collection. </param>
        /// <param name="requiredModelRecord"> Required model record. </param>
        /// <param name="requiredCollectionWithNullableFloatElement"> Required collection of which the element is a nullable float. </param>
        /// <param name="requiredCollectionWithNullableBooleanElement"> Required collection of which the element is a nullable boolean. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/>, <paramref name="requiredModel"/>, <paramref name="requiredIntCollection"/>, <paramref name="requiredStringCollection"/>, <paramref name="requiredModelCollection"/>, <paramref name="requiredModelRecord"/>, <paramref name="requiredCollectionWithNullableFloatElement"/> or <paramref name="requiredCollectionWithNullableBooleanElement"/> is null. </exception>
        public InputModel(string requiredString, int requiredInt, BaseModel requiredModel, IEnumerable<int> requiredIntCollection, IEnumerable<string> requiredStringCollection, IEnumerable<CollectionItem> requiredModelCollection, IDictionary<string, RecordItem> requiredModelRecord, IEnumerable<float?> requiredCollectionWithNullableFloatElement, IEnumerable<bool?> requiredCollectionWithNullableBooleanElement)
        {
            Argument.AssertNotNull(requiredString, nameof(requiredString));
            Argument.AssertNotNull(requiredModel, nameof(requiredModel));
            Argument.AssertNotNull(requiredIntCollection, nameof(requiredIntCollection));
            Argument.AssertNotNull(requiredStringCollection, nameof(requiredStringCollection));
            Argument.AssertNotNull(requiredModelCollection, nameof(requiredModelCollection));
            Argument.AssertNotNull(requiredModelRecord, nameof(requiredModelRecord));
            Argument.AssertNotNull(requiredCollectionWithNullableFloatElement, nameof(requiredCollectionWithNullableFloatElement));
            Argument.AssertNotNull(requiredCollectionWithNullableBooleanElement, nameof(requiredCollectionWithNullableBooleanElement));

            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredModel = requiredModel;
            RequiredIntCollection = requiredIntCollection.ToList();
            RequiredStringCollection = requiredStringCollection.ToList();
            RequiredModelCollection = requiredModelCollection.ToList();
            RequiredModelRecord = requiredModelRecord;
            RequiredCollectionWithNullableFloatElement = requiredCollectionWithNullableFloatElement.ToList();
            RequiredCollectionWithNullableBooleanElement = requiredCollectionWithNullableBooleanElement.ToList();
        }

        /// <summary> Initializes a new instance of InputModel. </summary>
        /// <param name="requiredString"> Required string. </param>
        /// <param name="requiredInt"> Required int. </param>
        /// <param name="requiredModel"> Required model. </param>
        /// <param name="requiredIntCollection"> Required primitive value type collection. </param>
        /// <param name="requiredStringCollection"> Required primitive reference type collection. </param>
        /// <param name="requiredModelCollection"> Required model collection. </param>
        /// <param name="requiredModelRecord"> Required model record. </param>
        /// <param name="requiredCollectionWithNullableFloatElement"> Required collection of which the element is a nullable float. </param>
        /// <param name="requiredCollectionWithNullableBooleanElement"> Required collection of which the element is a nullable boolean. </param>
        internal InputModel(string requiredString, int requiredInt, BaseModel requiredModel, IList<int> requiredIntCollection, IList<string> requiredStringCollection, IList<CollectionItem> requiredModelCollection, IDictionary<string, RecordItem> requiredModelRecord, IList<float?> requiredCollectionWithNullableFloatElement, IList<bool?> requiredCollectionWithNullableBooleanElement)
        {
            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredModel = requiredModel;
            RequiredIntCollection = requiredIntCollection;
            RequiredStringCollection = requiredStringCollection;
            RequiredModelCollection = requiredModelCollection;
            RequiredModelRecord = requiredModelRecord;
            RequiredCollectionWithNullableFloatElement = requiredCollectionWithNullableFloatElement;
            RequiredCollectionWithNullableBooleanElement = requiredCollectionWithNullableBooleanElement;
        }

        /// <summary> Required string. </summary>
        public string RequiredString { get; }
        /// <summary> Required int. </summary>
        public int RequiredInt { get; }
        /// <summary> Required model. </summary>
        public BaseModel RequiredModel { get; }
        /// <summary> Required primitive value type collection. </summary>
        public IList<int> RequiredIntCollection { get; }
        /// <summary> Required primitive reference type collection. </summary>
        public IList<string> RequiredStringCollection { get; }
        /// <summary> Required model collection. </summary>
        public IList<CollectionItem> RequiredModelCollection { get; }
        /// <summary> Required model record. </summary>
        public IDictionary<string, RecordItem> RequiredModelRecord { get; }
        /// <summary> Required collection of which the element is a nullable float. </summary>
        public IList<float?> RequiredCollectionWithNullableFloatElement { get; }
        /// <summary> Required collection of which the element is a nullable boolean. </summary>
        public IList<bool?> RequiredCollectionWithNullableBooleanElement { get; }
    }
}
