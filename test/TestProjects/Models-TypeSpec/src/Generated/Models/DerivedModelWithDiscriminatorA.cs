// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Deriver model with discriminator property. </summary>
    public partial class DerivedModelWithDiscriminatorA : BaseModelWithDiscriminator
    {
        /// <summary> Initializes a new instance of DerivedModelWithDiscriminatorA. </summary>
        /// <param name="requiredPropertyOnBase"> Required property on base. </param>
        /// <param name="requiredString"> Required string. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/> is null. </exception>
        public DerivedModelWithDiscriminatorA(int requiredPropertyOnBase, string requiredString) : base(requiredPropertyOnBase)
        {
            Argument.AssertNotNull(requiredString, nameof(requiredString));

            DiscriminatorProperty = "A";
            RequiredString = requiredString;
        }

        /// <summary> Initializes a new instance of DerivedModelWithDiscriminatorA. </summary>
        /// <param name="discriminatorProperty"> Discriminator. </param>
        /// <param name="optionalPropertyOnBase"> Optional property on base. </param>
        /// <param name="requiredPropertyOnBase"> Required property on base. </param>
        /// <param name="requiredString"> Required string. </param>
        internal DerivedModelWithDiscriminatorA(string discriminatorProperty, string optionalPropertyOnBase, int requiredPropertyOnBase, string requiredString) : base(discriminatorProperty, optionalPropertyOnBase, requiredPropertyOnBase)
        {
            RequiredString = requiredString;
        }

        /// <summary> Required string. </summary>
        public string RequiredString { get; set; }
    }
}
