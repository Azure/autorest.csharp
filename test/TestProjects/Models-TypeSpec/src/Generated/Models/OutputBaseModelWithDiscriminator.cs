// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace ModelsTypeSpec.Models
{
    /// <summary>
    /// Output model with a discriminator
    /// Please note <see cref="OutputBaseModelWithDiscriminator"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="FirstDerivedOutputModel"/> and <see cref="SecondDerivedOutputModel"/>.
    /// </summary>
    public abstract partial class OutputBaseModelWithDiscriminator
    {
        /// <summary> Initializes a new instance of OutputBaseModelWithDiscriminator. </summary>
        protected OutputBaseModelWithDiscriminator()
        {
        }

        /// <summary> Initializes a new instance of OutputBaseModelWithDiscriminator. </summary>
        /// <param name="kind"> Discriminator. </param>
        internal OutputBaseModelWithDiscriminator(string kind)
        {
            Kind = kind;
        }

        /// <summary> Discriminator. </summary>
        internal string Kind { get; set; }
    }
}
