// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.Dns.Models.V20180501
{
    public partial class Resource
    {
        private Dictionary<string, string>? _tags;

        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string Location { get; set; }
        public IDictionary<string, string> Tags => LazyInitializer.EnsureInitialized(ref _tags);

        public Resource(string location)
        {
            Location = location;
        }
    }
}
