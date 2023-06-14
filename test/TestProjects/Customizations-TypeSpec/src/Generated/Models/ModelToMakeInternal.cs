// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CustomizationsInCadl.Models
{
    /// <summary> Public model made internal. </summary>
    internal partial class ModelToMakeInternal
    {
        /// <summary> Initializes a new instance of ModelToMakeInternal. </summary>
        /// <param name="requiredInt"> Required int. </param>
        public ModelToMakeInternal(int requiredInt)
        {
            RequiredInt = requiredInt;
        }

        /// <summary> Required int. </summary>
        public int RequiredInt { get; set; }
    }
}
