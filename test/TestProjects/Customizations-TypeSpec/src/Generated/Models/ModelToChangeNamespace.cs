// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CustomizationsInCadl.Models
{
    /// <summary> Model moved into custom namespace. </summary>
    public partial class ModelToChangeNamespace
    {
        /// <summary> Initializes a new instance of ModelToChangeNamespace. </summary>
        /// <param name="requiredInt"> Required int. </param>
        public ModelToChangeNamespace(int requiredInt)
        {
            RequiredInt = requiredInt;
        }

        /// <summary> Required int. </summary>
        public int RequiredInt { get; set; }
    }
}
