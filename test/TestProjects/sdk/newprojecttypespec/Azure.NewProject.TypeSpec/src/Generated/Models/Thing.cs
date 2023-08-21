// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.NewProject.TypeSpec.Models
{
    /// <summary> A model with a few properties of literal types. </summary>
    internal partial class Thing
    {
        /// <summary> Initializes a new instance of Thing. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="requiredUnion"> required Union. </param>
        /// <param name="requiredBadDescription"> description with xml &lt;|endoftext|&gt;. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="requiredUnion"/> or <paramref name="requiredBadDescription"/> is null. </exception>
        public Thing(string name, object requiredUnion, string requiredBadDescription)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(requiredUnion, nameof(requiredUnion));
            Argument.AssertNotNull(requiredBadDescription, nameof(requiredBadDescription));

            Name = name;
            RequiredUnion = requiredUnion;
            RequiredBadDescription = requiredBadDescription;
        }

        /// <summary> Initializes a new instance of Thing. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="requiredUnion"> required Union. </param>
        /// <param name="requiredLiteralString"> required literal string. </param>
        /// <param name="requiredLiteralInt"> required literal int. </param>
        /// <param name="requiredLiteralFloat"> required literal float. </param>
        /// <param name="requiredLiteralBool"> required literal bool. </param>
        /// <param name="optionalLiteralString"> optional literal string. </param>
        /// <param name="optionalLiteralInt"> optional literal int. </param>
        /// <param name="optionalLiteralFloat"> optional literal float. </param>
        /// <param name="optionalLiteralBool"> optional literal bool. </param>
        /// <param name="requiredBadDescription"> description with xml &lt;|endoftext|&gt;. </param>
        internal Thing(string name, object requiredUnion, ThingRequiredLiteralString requiredLiteralString, ThingRequiredLiteralInt requiredLiteralInt, ThingRequiredLiteralFloat requiredLiteralFloat, bool requiredLiteralBool, ThingOptionalLiteralString? optionalLiteralString, ThingOptionalLiteralInt? optionalLiteralInt, ThingOptionalLiteralFloat? optionalLiteralFloat, bool? optionalLiteralBool, string requiredBadDescription)
        {
            Name = name;
            RequiredUnion = requiredUnion;
            RequiredLiteralString = requiredLiteralString;
            RequiredLiteralInt = requiredLiteralInt;
            RequiredLiteralFloat = requiredLiteralFloat;
            RequiredLiteralBool = requiredLiteralBool;
            OptionalLiteralString = optionalLiteralString;
            OptionalLiteralInt = optionalLiteralInt;
            OptionalLiteralFloat = optionalLiteralFloat;
            OptionalLiteralBool = optionalLiteralBool;
            RequiredBadDescription = requiredBadDescription;
        }

        /// <summary> name of the Thing. </summary>
        public string Name { get; set; }
        /// <summary> required Union. </summary>
        public object RequiredUnion { get; set; }
        /// <summary> required literal string. </summary>
        public ThingRequiredLiteralString RequiredLiteralString { get; } = ThingRequiredLiteralString.Accept;

        /// <summary> required literal int. </summary>
        public ThingRequiredLiteralInt RequiredLiteralInt { get; } = ThingRequiredLiteralInt._123;

        /// <summary> required literal float. </summary>
        public ThingRequiredLiteralFloat RequiredLiteralFloat { get; } = ThingRequiredLiteralFloat._123;

        /// <summary> required literal bool. </summary>
        public bool RequiredLiteralBool { get; } = false;

        /// <summary> optional literal string. </summary>
        public ThingOptionalLiteralString? OptionalLiteralString { get; set; }
        /// <summary> optional literal int. </summary>
        public ThingOptionalLiteralInt? OptionalLiteralInt { get; set; }
        /// <summary> optional literal float. </summary>
        public ThingOptionalLiteralFloat? OptionalLiteralFloat { get; set; }
        /// <summary> optional literal bool. </summary>
        public bool? OptionalLiteralBool { get; set; }
        /// <summary> description with xml &lt;|endoftext|&gt;. </summary>
        public string RequiredBadDescription { get; set; }
    }
}
