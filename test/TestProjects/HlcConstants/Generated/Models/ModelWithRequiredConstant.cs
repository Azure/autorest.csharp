// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace HlcConstants.Models
{
    /// <summary> Describes Protocol and thumbprint of Windows Remote Management listener. </summary>
    public partial class ModelWithRequiredConstant
    {
        /// <summary> Initializes a new instance of ModelWithRequiredConstant. </summary>
        public ModelWithRequiredConstant()
        {
            RequiredStringConstant = StringConstant.Default;
            RequiredIntConstant = IntConstant._0;
            RequiredBooleanConstant = true;
            RequiredFloatConstant = FloatConstant._314;
        }

        /// <summary> Initializes a new instance of ModelWithRequiredConstant. </summary>
        /// <param name="requiredStringConstant"> A constant based on string, the only allowable value is default. </param>
        /// <param name="requiredIntConstant"> A constant based on integer. </param>
        /// <param name="requiredBooleanConstant"> A constant based on boolean. </param>
        /// <param name="requiredFloatConstant"> A constant based on float. </param>
        internal ModelWithRequiredConstant(StringConstant requiredStringConstant, IntConstant requiredIntConstant, bool requiredBooleanConstant, FloatConstant requiredFloatConstant)
        {
            RequiredStringConstant = requiredStringConstant;
            RequiredIntConstant = requiredIntConstant;
            RequiredBooleanConstant = requiredBooleanConstant;
            RequiredFloatConstant = requiredFloatConstant;
        }

        /// <summary> A constant based on string, the only allowable value is default. </summary>
        public StringConstant RequiredStringConstant { get; }
        /// <summary> A constant based on integer. </summary>
        public IntConstant RequiredIntConstant { get; }
        /// <summary> A constant based on boolean. </summary>
        public bool RequiredBooleanConstant { get; }
        /// <summary> A constant based on float. </summary>
        public FloatConstant RequiredFloatConstant { get; }
    }
}
