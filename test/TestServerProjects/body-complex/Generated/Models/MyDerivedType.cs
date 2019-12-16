// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace body_complex.Models.V20160229
{
    public partial class MyDerivedType : MyBaseType
    {
        public MyDerivedType()
        {
            Kind = "Kind1";
        }
        public string? PropD1 { get; set; }
    }
}
