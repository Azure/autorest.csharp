// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace ReferenceTypes.Models
{
    /// <summary> The resource model definition for an Azure Resource Manager tracked top level resource which has &apos;tags&apos; and a &apos;location&apos;. </summary>
    internal partial class TrackedResource : Azure.ResourceManager.Resources.Models.Resource
    {
        /// <summary> Initializes a new instance of TrackedResource. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        internal TrackedResource(string location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            Tags = new ChangeTrackingDictionary<string, string>();
            Location = location;
        }

        /// <summary> Resource tags. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
        /// <summary> The geo-location where the resource lives. </summary>
        public string Location { get; }
    }
}
