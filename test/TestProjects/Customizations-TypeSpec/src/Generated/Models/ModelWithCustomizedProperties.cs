// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace CustomizationsInCadl.Models
{
    /// <summary> Model with customized properties. </summary>
    public partial class ModelWithCustomizedProperties
    {
        /// <summary> Initializes a new instance of ModelWithCustomizedProperties. </summary>
        /// <param name="propertyToMakeInternal"> Public property made internal. </param>
        /// <param name="renamedProperty"> Renamed property (original name: PropertyToRename). </param>
        /// <param name="propertyToMakeFloat"> Property with type changed to float (original type: int). </param>
        /// <param name="propertyToMakeInt"> Property with type changed to int (original type: float). </param>
        /// <param name="propertyToMakeDuration"> Property with type changed to duration (original type: string). </param>
        /// <param name="propertyToMakeString"> Property with type changed to string (original type: duration). </param>
        /// <param name="propertyToMakeJsonElement"> Property with type changed to JsonElement (original type: string). </param>
        /// <param name="propertyToField"> Field that replaces property (original name: PropertyToField). </param>
        /// <param name="goodListName"> Property renamed that is list. </param>
        /// <param name="goodDictionaryName"> Property renamed that is dictionary. </param>
        /// <param name="goodListOfListName"> Property renamed that is listoflist. </param>
        /// <param name="goodListOfDictionaryName"> Property renamed that is listofdictionary. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="propertyToMakeString"/>, <paramref name="propertyToField"/>, <paramref name="goodListName"/>, <paramref name="goodDictionaryName"/>, <paramref name="goodListOfListName"/> or <paramref name="goodListOfDictionaryName"/> is null. </exception>
        public ModelWithCustomizedProperties(int propertyToMakeInternal, int renamedProperty, float propertyToMakeFloat, int propertyToMakeInt, TimeSpan propertyToMakeDuration, string propertyToMakeString, JsonElement propertyToMakeJsonElement, string propertyToField, IEnumerable<string> goodListName, IDictionary<string, string> goodDictionaryName, IEnumerable<IList<string>> goodListOfListName, IEnumerable<IDictionary<string, string>> goodListOfDictionaryName)
        {
            Argument.AssertNotNull(propertyToMakeString, nameof(propertyToMakeString));
            Argument.AssertNotNull(propertyToField, nameof(propertyToField));
            Argument.AssertNotNull(goodListName, nameof(goodListName));
            Argument.AssertNotNull(goodDictionaryName, nameof(goodDictionaryName));
            Argument.AssertNotNull(goodListOfListName, nameof(goodListOfListName));
            Argument.AssertNotNull(goodListOfDictionaryName, nameof(goodListOfDictionaryName));

            PropertyToMakeInternal = propertyToMakeInternal;
            RenamedProperty = renamedProperty;
            PropertyToMakeFloat = propertyToMakeFloat;
            PropertyToMakeInt = propertyToMakeInt;
            PropertyToMakeDuration = propertyToMakeDuration;
            PropertyToMakeString = propertyToMakeString;
            PropertyToMakeJsonElement = propertyToMakeJsonElement;
            _propertyToField = propertyToField;
            GoodListName = goodListName.ToList();
            GoodDictionaryName = goodDictionaryName;
            GoodListOfListName = goodListOfListName.ToList();
            GoodListOfDictionaryName = goodListOfDictionaryName.ToList();
        }

        /// <summary> Initializes a new instance of ModelWithCustomizedProperties. </summary>
        /// <param name="propertyToMakeInternal"> Public property made internal. </param>
        /// <param name="renamedProperty"> Renamed property (original name: PropertyToRename). </param>
        /// <param name="propertyToMakeFloat"> Property with type changed to float (original type: int). </param>
        /// <param name="propertyToMakeInt"> Property with type changed to int (original type: float). </param>
        /// <param name="propertyToMakeDuration"> Property with type changed to duration (original type: string). </param>
        /// <param name="propertyToMakeString"> Property with type changed to string (original type: duration). </param>
        /// <param name="propertyToMakeJsonElement"> Property with type changed to JsonElement (original type: string). </param>
        /// <param name="propertyToField"> Field that replaces property (original name: PropertyToField). </param>
        /// <param name="goodListName"> Property renamed that is list. </param>
        /// <param name="goodDictionaryName"> Property renamed that is dictionary. </param>
        /// <param name="goodListOfListName"> Property renamed that is listoflist. </param>
        /// <param name="goodListOfDictionaryName"> Property renamed that is listofdictionary. </param>
        internal ModelWithCustomizedProperties(int propertyToMakeInternal, int renamedProperty, float propertyToMakeFloat, int propertyToMakeInt, TimeSpan propertyToMakeDuration, string propertyToMakeString, JsonElement propertyToMakeJsonElement, string propertyToField, IList<string> goodListName, IDictionary<string, string> goodDictionaryName, IList<IList<string>> goodListOfListName, IList<IDictionary<string, string>> goodListOfDictionaryName)
        {
            PropertyToMakeInternal = propertyToMakeInternal;
            RenamedProperty = renamedProperty;
            PropertyToMakeFloat = propertyToMakeFloat;
            PropertyToMakeInt = propertyToMakeInt;
            PropertyToMakeDuration = propertyToMakeDuration;
            PropertyToMakeString = propertyToMakeString;
            PropertyToMakeJsonElement = propertyToMakeJsonElement;
            _propertyToField = propertyToField;
            GoodListName = goodListName;
            GoodDictionaryName = goodDictionaryName;
            GoodListOfListName = goodListOfListName;
            GoodListOfDictionaryName = goodListOfDictionaryName;
        }
    }
}
