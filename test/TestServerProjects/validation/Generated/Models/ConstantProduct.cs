// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace validation.Models
{
    /// <summary> The product documentation. </summary>
    public partial class ConstantProduct
    {
        /// <summary> Initializes a new instance of ConstantProduct. </summary>
        public ConstantProduct()
        {
            ConstProperty = ConstantProductConstProperty.Constant;
            ConstProperty2 = ConstantProductConstProperty2.Constant2;
        }

        /// <summary> Initializes a new instance of ConstantProduct. </summary>
        /// <param name="constProperty"> Constant string. </param>
        /// <param name="constProperty2"> Constant string2. </param>
        internal ConstantProduct(ConstantProductConstProperty constProperty, ConstantProductConstProperty2 constProperty2)
        {
            ConstProperty = constProperty;
            ConstProperty2 = constProperty2;
        }

        /// <summary> Constant string. </summary>
        public ConstantProductConstProperty ConstProperty { get; }
        /// <summary> Constant string2. </summary>
        public ConstantProductConstProperty2 ConstProperty2 { get; }
    }
}
