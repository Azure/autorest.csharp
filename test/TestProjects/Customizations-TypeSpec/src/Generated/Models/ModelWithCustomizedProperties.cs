// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using CustomizationsInTsp;

namespace CustomizationsInTsp.Models
{
    /// <summary> Model with customized properties. </summary>
    public partial class ModelWithCustomizedProperties
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ModelWithCustomizedProperties"/>. </summary>
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
        /// <param name="vector"> Property type changed to ReadOnlyMemory&lt;float&gt;. </param>
        /// <param name="vectorNullable"> Property type changed to ReadOnlyMemory&lt;float&gt;?. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="propertyToMakeString"/>, <paramref name="propertyToField"/>, <paramref name="goodListName"/>, <paramref name="goodDictionaryName"/>, <paramref name="goodListOfListName"/> or <paramref name="goodListOfDictionaryName"/> is null. </exception>
        public ModelWithCustomizedProperties(int propertyToMakeInternal, int renamedProperty, float propertyToMakeFloat, int propertyToMakeInt, TimeSpan propertyToMakeDuration, string propertyToMakeString, JsonElement propertyToMakeJsonElement, string propertyToField, IEnumerable<string> goodListName, IDictionary<string, string> goodDictionaryName, IEnumerable<IList<string>> goodListOfListName, IEnumerable<IDictionary<string, string>> goodListOfDictionaryName, ReadOnlyMemory<float> vector, ReadOnlyMemory<float>? vectorNullable)
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
            Vector = vector;
            VectorNullable = vectorNullable;
            VectorReadOnly = ReadOnlyMemory<float>.Empty;
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithCustomizedProperties"/>. </summary>
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
        /// <param name="vector"> Property type changed to ReadOnlyMemory&lt;float&gt;. </param>
        /// <param name="vectorOptional"> Property type changed to ReadOnlyMemory&lt;float&gt;?. </param>
        /// <param name="vectorNullable"> Property type changed to ReadOnlyMemory&lt;float&gt;?. </param>
        /// <param name="vectorOptionalNullable"> Property type changed to ReadOnlyMemory&lt;float&gt;?. </param>
        /// <param name="vectorReadOnly"> Property type changed to ReadOnlyMemory&lt;float&gt;. </param>
        /// <param name="vectorOptionalReadOnly"> Property type changed to ReadOnlyMemory&lt;float&gt;?. </param>
        /// <param name="vectorNullableReadOnly"> Property type changed to ReadOnlyMemory&lt;float&gt;?. </param>
        /// <param name="vectorOptionalNullableReadOnly"> Property type changed to ReadOnlyMemory&lt;float&gt;?. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelWithCustomizedProperties(int propertyToMakeInternal, int renamedProperty, float propertyToMakeFloat, int propertyToMakeInt, TimeSpan propertyToMakeDuration, string propertyToMakeString, JsonElement propertyToMakeJsonElement, string propertyToField, IList<string> goodListName, IDictionary<string, string> goodDictionaryName, IList<IList<string>> goodListOfListName, IList<IDictionary<string, string>> goodListOfDictionaryName, ReadOnlyMemory<float> vector, ReadOnlyMemory<float>? vectorOptional, ReadOnlyMemory<float>? vectorNullable, ReadOnlyMemory<float>? vectorOptionalNullable, ReadOnlyMemory<float> vectorReadOnly, ReadOnlyMemory<float>? vectorOptionalReadOnly, ReadOnlyMemory<float>? vectorNullableReadOnly, ReadOnlyMemory<float>? vectorOptionalNullableReadOnly, IDictionary<string, BinaryData> serializedAdditionalRawData)
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
            Vector = vector;
            VectorOptional = vectorOptional;
            VectorNullable = vectorNullable;
            VectorOptionalNullable = vectorOptionalNullable;
            VectorReadOnly = vectorReadOnly;
            VectorOptionalReadOnly = vectorOptionalReadOnly;
            VectorNullableReadOnly = vectorNullableReadOnly;
            VectorOptionalNullableReadOnly = vectorOptionalNullableReadOnly;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithCustomizedProperties"/> for deserialization. </summary>
        internal ModelWithCustomizedProperties()
        {
        }
    }
}
