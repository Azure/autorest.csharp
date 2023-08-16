// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace SpreadTypeSpec.Models
{
    /// <summary> The SpreadMultiTargetAliasRequest. </summary>
    internal partial class SpreadMultiTargetAliasRequest
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of SpreadMultiTargetAliasRequest. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public SpreadMultiTargetAliasRequest(string name, int age)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            Age = age;
        }

        /// <summary> Initializes a new instance of SpreadMultiTargetAliasRequest. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SpreadMultiTargetAliasRequest(string name, int age, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            Age = age;
            _rawData = rawData;
        }

        /// <summary> name of the Thing. </summary>
        public string Name { get; }
        /// <summary> age of the Thing. </summary>
        public int Age { get; }
    }
}
