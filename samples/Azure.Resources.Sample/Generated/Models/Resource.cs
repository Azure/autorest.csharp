// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace Azure.Resources.Sample
{
    /// <summary> Specified resource. </summary>
    internal partial class Resource : Resource<TenantResourceIdentifier>
    {
        /// <summary> Initializes a new instance of Resource. </summary>
        internal Resource()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Resource location. </summary>
        public string Location { get; }
        /// <summary> Resource extended location. </summary>
        public ExtendedLocation ExtendedLocation { get; }
        /// <summary> Resource tags. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
    }
}
