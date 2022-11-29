// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using TenantOnly;

namespace TenantOnly.Models
{
    /// <summary> Model factory for read-only models. </summary>
    public static partial class TenantOnlyModelFactory
    {

        /// <summary> Initializes a new instance of AgreementData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="foo"></param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <returns> A new <see cref="TenantOnly.AgreementData"/> instance for mocking. </returns>
        public static AgreementData AgreementData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string foo = null, string location = null, IReadOnlyDictionary<string, string> tags = null)
        {
            tags ??= new Dictionary<string, string>();

            return new AgreementData(id, name, resourceType, systemData, foo, location, tags);
        }
    }
}
