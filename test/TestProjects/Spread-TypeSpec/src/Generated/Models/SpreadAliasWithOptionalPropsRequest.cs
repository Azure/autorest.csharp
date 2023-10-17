// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace SpreadTypeSpec.Models
{
    /// <summary> The SpreadAliasWithOptionalPropsRequest. </summary>
    internal partial class SpreadAliasWithOptionalPropsRequest
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="SpreadAliasWithOptionalPropsRequest"/>. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="items"> required array. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="items"/> is null. </exception>
        public SpreadAliasWithOptionalPropsRequest(string name, IEnumerable<int> items)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(items, nameof(items));

            Name = name;
            Items = items.ToList();
            Elements = new ChangeTrackingList<string>();
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="SpreadAliasWithOptionalPropsRequest"/>. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="color"> optional property of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <param name="items"> required array. </param>
        /// <param name="elements"> optional array. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SpreadAliasWithOptionalPropsRequest(string name, string color, int? age, IList<int> items, IList<string> elements, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Color = color;
            Age = age;
            Items = items;
            Elements = elements;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="SpreadAliasWithOptionalPropsRequest"/> for deserialization. </summary>
        internal SpreadAliasWithOptionalPropsRequest()
        {
        }

        /// <summary> name of the Thing. </summary>
        public string Name { get; }
        /// <summary> optional property of the Thing. </summary>
        public string Color { get; set; }
        /// <summary> age of the Thing. </summary>
        public int? Age { get; set; }
        /// <summary> required array. </summary>
        public IList<int> Items { get; }
        /// <summary> optional array. </summary>
        public IList<string> Elements { get; }
    }
}
