// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xml_service.Models
{
    /// <summary> I am a complex type with XML node. </summary>
    public partial class ComplexTypeWithMeta
    {
        /// <summary> Initializes a new instance of ComplexTypeWithMeta. </summary>
        public ComplexTypeWithMeta()
        {
        }

        /// <summary> Initializes a new instance of ComplexTypeWithMeta. </summary>
        /// <param name="id"> The id of the res. </param>
        internal ComplexTypeWithMeta(string id)
        {
            ID = id;
        }

        /// <summary> The id of the res. </summary>
        public string ID { get; set; }
    }
}
