// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The MyDerivedType. </summary>
    public partial class MyDerivedType : MyBaseType
    {
        /// <summary> Initializes a new instance of MyDerivedType. </summary>
        public MyDerivedType()
        {
            Kind = "Kind1";
        }
        public string PropD1 { get; set; }
    }
}
