// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtOperations.Models
{
    /// <summary> The Update Resource model definition. </summary>
    public partial class UpdateResource
    {
        /// <summary> Initializes a new instance of UpdateResource. </summary>
        public UpdateResource()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
