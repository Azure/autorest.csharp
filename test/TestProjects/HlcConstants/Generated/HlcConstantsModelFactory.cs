// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace HlcConstants.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class HlcConstantsModelFactory
    {
        /// <summary> Initializes a new instance of ModelWithRequiredConstant. </summary>
        /// <param name="requiredStringConstant"> A constant based on string, the only allowable value is default. </param>
        /// <param name="requiredIntConstant"> A constant based on integer. </param>
        /// <param name="requiredBooleanConstant"> A constant based on boolean. </param>
        /// <param name="requiredFloatConstant"> A constant based on float. </param>
        /// <returns> A new <see cref="Models.ModelWithRequiredConstant"/> instance for mocking. </returns>
        public static ModelWithRequiredConstant ModelWithRequiredConstant(StringConstant requiredStringConstant = default, IntConstant requiredIntConstant = default, bool requiredBooleanConstant = default, FloatConstant requiredFloatConstant = default)
        {
            return new ModelWithRequiredConstant(requiredStringConstant, requiredIntConstant, requiredBooleanConstant, requiredFloatConstant);
        }
    }
}
