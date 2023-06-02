// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace CustomizationsInCadl.Models
{
    /// <summary> The first layer model in the inheritance tree. </summary>
    public partial class FirstLayer
    {
        /// <summary> Initializes a new instance of FirstLayer. </summary>
        /// <param name="stringToBeChanged"> Property to change serialization and deserialization in this class and all derived classes. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="stringToBeChanged"/> is null. </exception>
        public FirstLayer(string stringToBeChanged)
        {
            Argument.AssertNotNull(stringToBeChanged, nameof(stringToBeChanged));

            StringToBeChanged = stringToBeChanged;
        }
    }
}
