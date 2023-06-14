// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace SpecialWords.Models
{
    /// <summary> This is a model has property names of special words or characters. </summary>
    public partial class DerivedModel : BaseModel
    {
        /// <summary> Initializes a new instance of DerivedModel. </summary>
        /// <param name="derivedName"></param>
        /// <param name="for"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="derivedName"/> or <paramref name="for"/> is null. </exception>
        public DerivedModel(string derivedName, string @for)
        {
            Argument.AssertNotNull(derivedName, nameof(derivedName));
            Argument.AssertNotNull(@for, nameof(@for));

            ModelKind = "derived";
            DerivedName = derivedName;
            For = @for;
        }

        /// <summary> Initializes a new instance of DerivedModel. </summary>
        /// <param name="modelKind"> Discriminator. </param>
        /// <param name="derivedName"></param>
        /// <param name="for"></param>
        internal DerivedModel(string modelKind, string derivedName, string @for) : base(modelKind)
        {
            DerivedName = derivedName;
            For = @for;
        }

        /// <summary> Gets or sets the derived name. </summary>
        public string DerivedName { get; set; }
        /// <summary> Gets or sets the for. </summary>
        public string For { get; set; }
    }
}
