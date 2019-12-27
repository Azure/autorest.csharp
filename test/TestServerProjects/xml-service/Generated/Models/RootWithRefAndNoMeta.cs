// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace xml_service.Models.V100
{
    public partial class RootWithRefAndNoMeta
    {
        public ComplexTypeNoMeta? RefToModel { get; set; }
        public string? Something { get; set; }
    }
}
