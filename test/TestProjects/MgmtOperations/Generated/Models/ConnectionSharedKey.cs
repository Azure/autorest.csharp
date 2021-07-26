// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace MgmtOperations.Models
{
    /// <summary> Response for GetConnectionSharedKey API service call. </summary>
    public partial class ConnectionSharedKey : TrackedResource<TenantResourceIdentifier>
    {
        /// <summary> Initializes a new instance of ConnectionSharedKey. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="value"> The virtual network connection shared key value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ConnectionSharedKey(Location location, string value) : base(location)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
        }

        /// <summary> Initializes a new instance of ConnectionSharedKey. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="location"> The location. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="value"> The virtual network connection shared key value. </param>
        internal ConnectionSharedKey(TenantResourceIdentifier id, string name, ResourceType type, Location location, IDictionary<string, string> tags, string value) : base(id, name, type, location, tags)
        {
            Value = value;
        }

        /// <summary> The virtual network connection shared key value. </summary>
        public string Value { get; set; }
    }
}
