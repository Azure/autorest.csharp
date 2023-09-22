// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace FirstTestTypeSpec.Models
{
    /// <summary> A model with a few properties of literal types. </summary>
    internal partial class Thing
    {
        /// <summary> Initializes a new instance of Thing. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="requiredUnion"> required Union. </param>
        /// <param name="requiredUnionOfLiteralString"> required union of literal string. </param>
        /// <param name="requiredUnionOfLiteralInt"> required union of literal double. </param>
        /// <param name="requiredUnionOfLiteralFloat"> required union of literal float. </param>
        /// <param name="requiredBadDescription"> description with xml &lt;|endoftext|&gt;. </param>
        /// <param name="requiredNullableList"> required nullable collection. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="requiredUnion"/> or <paramref name="requiredBadDescription"/> is null. </exception>
        public Thing(string name, object requiredUnion, ThingRequiredUnionOfLiteralString requiredUnionOfLiteralString, ThingRequiredUnionOfLiteralInt requiredUnionOfLiteralInt, ThingRequiredUnionOfLiteralFloat requiredUnionOfLiteralFloat, string requiredBadDescription, IEnumerable<int> requiredNullableList)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(requiredUnion, nameof(requiredUnion));
            Argument.AssertNotNull(requiredBadDescription, nameof(requiredBadDescription));

            Name = name;
            RequiredUnion = requiredUnion;
            RequiredUnionOfLiteralString = requiredUnionOfLiteralString;
            RequiredUnionOfLiteralInt = requiredUnionOfLiteralInt;
            RequiredUnionOfLiteralFloat = requiredUnionOfLiteralFloat;
            RequiredBadDescription = requiredBadDescription;
            OptionalNullableList = new ChangeTrackingList<int>();
            RequiredNullableList = requiredNullableList?.ToList();
        }

        /// <summary> Initializes a new instance of Thing. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="requiredUnion"> required Union. </param>
        /// <param name="requiredLiteralString"> required literal string. </param>
        /// <param name="requiredUnionOfLiteralString"> required union of literal string. </param>
        /// <param name="requiredLiteralInt"> required literal int. </param>
        /// <param name="requiredUnionOfLiteralInt"> required union of literal double. </param>
        /// <param name="requiredLiteralFloat"> required literal float. </param>
        /// <param name="requiredUnionOfLiteralFloat"> required union of literal float. </param>
        /// <param name="requiredLiteralBool"> required literal bool. </param>
        /// <param name="optionalLiteralString"> optional literal string. </param>
        /// <param name="optionalUnionOfLiteralString"> optional union of literal string. </param>
        /// <param name="optionalLiteralInt"> optional literal int. </param>
        /// <param name="optionalUnionOfLiteralInt"> optional union of literal int. </param>
        /// <param name="optionalLiteralFloat"> optional literal float. </param>
        /// <param name="optionalUnionOfLiteralFloat"> optional union of literal float. </param>
        /// <param name="optionalLiteralBool"> optional literal bool. </param>
        /// <param name="requiredBadDescription"> description with xml &lt;|endoftext|&gt;. </param>
        /// <param name="optionalNullableList"> optional nullable collection. </param>
        /// <param name="requiredNullableList"> required nullable collection. </param>
        internal Thing(string name, object requiredUnion, ThingRequiredLiteralString requiredLiteralString, ThingRequiredUnionOfLiteralString requiredUnionOfLiteralString, ThingRequiredLiteralInt requiredLiteralInt, ThingRequiredUnionOfLiteralInt requiredUnionOfLiteralInt, ThingRequiredLiteralFloat requiredLiteralFloat, ThingRequiredUnionOfLiteralFloat requiredUnionOfLiteralFloat, bool requiredLiteralBool, ThingOptionalLiteralString? optionalLiteralString, ThingOptionalUnionOfLiteralString? optionalUnionOfLiteralString, ThingOptionalLiteralInt? optionalLiteralInt, ThingOptionalUnionOfLiteralInt? optionalUnionOfLiteralInt, ThingOptionalLiteralFloat? optionalLiteralFloat, ThingOptionalUnionOfLiteralFloat? optionalUnionOfLiteralFloat, bool? optionalLiteralBool, string requiredBadDescription, IList<int> optionalNullableList, IList<int> requiredNullableList)
        {
            Name = name;
            RequiredUnion = requiredUnion;
            RequiredLiteralString = requiredLiteralString;
            RequiredUnionOfLiteralString = requiredUnionOfLiteralString;
            RequiredLiteralInt = requiredLiteralInt;
            RequiredUnionOfLiteralInt = requiredUnionOfLiteralInt;
            RequiredLiteralFloat = requiredLiteralFloat;
            RequiredUnionOfLiteralFloat = requiredUnionOfLiteralFloat;
            RequiredLiteralBool = requiredLiteralBool;
            OptionalLiteralString = optionalLiteralString;
            OptionalUnionOfLiteralString = optionalUnionOfLiteralString;
            OptionalLiteralInt = optionalLiteralInt;
            OptionalUnionOfLiteralInt = optionalUnionOfLiteralInt;
            OptionalLiteralFloat = optionalLiteralFloat;
            OptionalUnionOfLiteralFloat = optionalUnionOfLiteralFloat;
            OptionalLiteralBool = optionalLiteralBool;
            RequiredBadDescription = requiredBadDescription;
            OptionalNullableList = optionalNullableList;
            RequiredNullableList = requiredNullableList;
        }

        /// <summary> name of the Thing. </summary>
        public string Name { get; set; }
        /// <summary> required Union. </summary>
        public object RequiredUnion { get; set; }
        /// <summary> required literal string. </summary>
        public ThingRequiredLiteralString RequiredLiteralString { get; } = ThingRequiredLiteralString.Accept;

        /// <summary> required union of literal string. </summary>
        public ThingRequiredUnionOfLiteralString RequiredUnionOfLiteralString { get; set; }
        /// <summary> required literal int. </summary>
        public ThingRequiredLiteralInt RequiredLiteralInt { get; } = ThingRequiredLiteralInt._123;

        /// <summary> required union of literal double. </summary>
        public ThingRequiredUnionOfLiteralInt RequiredUnionOfLiteralInt { get; set; }
        /// <summary> required literal float. </summary>
        public ThingRequiredLiteralFloat RequiredLiteralFloat { get; } = ThingRequiredLiteralFloat._123;

        /// <summary> required union of literal float. </summary>
        public ThingRequiredUnionOfLiteralFloat RequiredUnionOfLiteralFloat { get; set; }
        /// <summary> required literal bool. </summary>
        public bool RequiredLiteralBool { get; } = false;

        /// <summary> optional literal string. </summary>
        public ThingOptionalLiteralString? OptionalLiteralString { get; set; }
        /// <summary> optional union of literal string. </summary>
        public ThingOptionalUnionOfLiteralString? OptionalUnionOfLiteralString { get; set; }
        /// <summary> optional literal int. </summary>
        public ThingOptionalLiteralInt? OptionalLiteralInt { get; set; }
        /// <summary> optional union of literal int. </summary>
        public ThingOptionalUnionOfLiteralInt? OptionalUnionOfLiteralInt { get; set; }
        /// <summary> optional literal float. </summary>
        public ThingOptionalLiteralFloat? OptionalLiteralFloat { get; set; }
        /// <summary> optional union of literal float. </summary>
        public ThingOptionalUnionOfLiteralFloat? OptionalUnionOfLiteralFloat { get; set; }
        /// <summary> optional literal bool. </summary>
        public bool? OptionalLiteralBool { get; set; }
        /// <summary> description with xml &lt;|endoftext|&gt;. </summary>
        public string RequiredBadDescription { get; set; }
        /// <summary> optional nullable collection. </summary>
        public IList<int> OptionalNullableList { get; set; }
        /// <summary> required nullable collection. </summary>
        public IList<int> RequiredNullableList { get; set; }
    }
}
