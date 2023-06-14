// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace ModelWithConverterUsage.Models
{
    /// <summary> . </summary>
    public partial class ModelClass
    {
        /// <summary> Initializes a new instance of ModelClass. </summary>
        /// <param name="enumProperty"> More Letters. </param>
        public ModelClass(EnumProperty enumProperty)
        {
            EnumProperty = enumProperty;
        }

        /// <summary> Initializes a new instance of ModelClass. </summary>
        /// <param name="stringProperty"></param>
        /// <param name="enumProperty"> More Letters. </param>
        /// <param name="objProperty"> The product documentation. </param>
        internal ModelClass(string stringProperty, EnumProperty enumProperty, Product objProperty)
        {
            StringProperty = stringProperty;
            EnumProperty = enumProperty;
            ObjProperty = objProperty;
        }

        /// <summary> Gets or sets the string property. </summary>
        public string StringProperty { get; set; }
        /// <summary> More Letters. </summary>
        public EnumProperty EnumProperty { get; set; }
        /// <summary> The product documentation. </summary>
        public Product ObjProperty { get; set; }
    }
}
