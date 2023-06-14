// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtExactMatchInheritance.Models
{
    /// <summary> The SeparateClass. </summary>
    public partial class SeparateClass
    {
        /// <summary> Initializes a new instance of SeparateClass. </summary>
        public SeparateClass()
        {
        }

        /// <summary> Initializes a new instance of SeparateClass. </summary>
        /// <param name="stringProperty"></param>
        /// <param name="modelProperty"></param>
        internal SeparateClass(string stringProperty, ExactMatchModel10 modelProperty)
        {
            StringProperty = stringProperty;
            ModelProperty = modelProperty;
        }

        /// <summary> Gets or sets the string property. </summary>
        public string StringProperty { get; set; }
        /// <summary> Gets or sets the model property. </summary>
        public ExactMatchModel10 ModelProperty { get; set; }
    }
}
