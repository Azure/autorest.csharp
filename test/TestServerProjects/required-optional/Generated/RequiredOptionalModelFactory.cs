// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace required_optional.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class RequiredOptionalModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Product"/>. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns> A new <see cref="Models.Product"/> instance for mocking. </returns>
        public static Product Product(int id = default, string name = null)
        {
            return new Product(id, name, default);
        }
    }
}
