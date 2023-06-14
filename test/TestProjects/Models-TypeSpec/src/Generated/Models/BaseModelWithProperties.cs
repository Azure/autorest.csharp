// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace ModelsTypeSpec.Models
{
    /// <summary> Base model with properties. </summary>
    public partial class BaseModelWithProperties
    {
        /// <summary> Initializes a new instance of BaseModelWithProperties. </summary>
        internal BaseModelWithProperties()
        {
        }

        /// <summary> Initializes a new instance of BaseModelWithProperties. </summary>
        /// <param name="optionalPropertyOnBase"> Optional properties on base. </param>
        internal BaseModelWithProperties(string optionalPropertyOnBase)
        {
            OptionalPropertyOnBase = optionalPropertyOnBase;
        }

        /// <summary> Optional properties on base. </summary>
        public string OptionalPropertyOnBase { get; set; }
    }
}
