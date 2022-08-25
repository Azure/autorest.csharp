// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace ModelsInCadl
{
    /// <summary> Deriver model with discriminator property. </summary>
    public partial class DerivedModelWithDiscriminatorB
    {
        /// <summary> Initializes a new instance of DerivedModelWithDiscriminatorB. </summary>
        /// <param name="requiredInt"></param>
        public DerivedModelWithDiscriminatorB(int requiredInt)
        {
            RequiredInt = requiredInt;
        }

        public int RequiredInt { get; set; }
    }
}
