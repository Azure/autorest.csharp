// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace body_complex.Models.V20160229
{
    public partial class MyBaseType
    {
        public MyBaseType()
        {
            Kind = null;
        }
        public string Kind { get; internal set; }
        public string? PropB1 { get; set; }
        public MyBaseHelperType? Helper { get; set; }
    }
}
