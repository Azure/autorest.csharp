// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace xml_service.Models.V100
{
    public partial class Container
    {
        public string Name { get; set; }
        public ContainerProperties Properties { get; set; } = new ContainerProperties();
        public IDictionary<string, string>? Metadata { get; set; }
    }
}
