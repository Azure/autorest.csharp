// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Spread.Models
{
    /// <summary> The SpreadAliasWithOptionalPropsRequest. </summary>
    internal partial class SpreadAliasWithOptionalPropsRequest
    {
        /// <summary> Initializes a new instance of SpreadAliasWithOptionalPropsRequest. </summary>
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
        }

        /// <summary> Initializes a new instance of SpreadAliasWithOptionalPropsRequest. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="color"> optional property of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <param name="items"> required array. </param>
        /// <param name="elements"> optional array. </param>
        internal SpreadAliasWithOptionalPropsRequest(string name, string color, int? age, IList<int> items, IList<string> elements)
        {
            Name = name;
            Color = color;
            Age = age;
            Items = items;
            Elements = elements;
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
