// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace SpreadTypeSpec.Models
{
    /// <summary> The SpreadAliasWithSpreadAliasRequest. </summary>
    internal partial class SpreadAliasWithSpreadAliasRequest
    {
        /// <summary> Initializes a new instance of SpreadAliasWithSpreadAliasRequest. </summary>
        public SpreadAliasWithSpreadAliasRequest()
        {
        }

        /// <summary> Initializes a new instance of SpreadAliasWithSpreadAliasRequest. </summary>
        /// <param name="age"> age of the Thing. </param>
        /// <param name="name"> name of the Thing. </param>
        internal SpreadAliasWithSpreadAliasRequest(int? age, string name)
        {
            Age = age;
            Name = name;
        }

        /// <summary> age of the Thing. </summary>
        public int? Age { get; set; }
        /// <summary> name of the Thing. </summary>
        public string Name { get; set; }
    }
}
