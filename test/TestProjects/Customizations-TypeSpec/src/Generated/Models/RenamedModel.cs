// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CustomizationsInTsp.Models
{
    /// <summary> Renamed model (original name: ModelToRename). </summary>
    public partial class RenamedModel
    {
        /// <summary> Initializes a new instance of RenamedModel. </summary>
        /// <param name="requiredInt"> Required int. </param>
        public RenamedModel(int requiredInt)
        {
            RequiredInt = requiredInt;
        }

        /// <summary> Initializes a new instance of RenamedModel. </summary>
        /// <param name="requiredInt"> Required int. </param>
        /// <param name="optionalInt"> Optional int. </param>
        internal RenamedModel(int requiredInt, int? optionalInt)
        {
            RequiredInt = requiredInt;
            OptionalInt = optionalInt;
        }

        /// <summary> Required int. </summary>
        public int RequiredInt { get; set; }
    }
}
