// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_string.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class AutoRestSwaggerBATServiceModelFactory
    {
        /// <summary> Initializes a new instance of RefColorConstant. </summary>
        /// <param name="colorConstant"> Referenced Color Constant Description. </param>
        /// <param name="field1"> Sample string. </param>
        /// <returns> A new <see cref="Models.RefColorConstant"/> instance for mocking. </returns>
        public static RefColorConstant RefColorConstant(ColorConstant colorConstant = default, string field1 = null)
        {
            return new RefColorConstant(colorConstant, field1);
        }
    }
}
