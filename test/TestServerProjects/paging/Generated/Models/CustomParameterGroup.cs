// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace paging.Models
{
    /// <summary> Parameter group. </summary>
    public partial class CustomParameterGroup
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::paging.Models.CustomParameterGroup
        ///
        /// </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> or <paramref name="tenant"/> is null. </exception>
        public CustomParameterGroup(string apiVersion, string tenant)
        {
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));
            Argument.AssertNotNull(tenant, nameof(tenant));

            ApiVersion = apiVersion;
            Tenant = tenant;
        }

        /// <summary>
        /// Initializes a new instance of global::paging.Models.CustomParameterGroup
        ///
        /// </summary>
        /// <param name="apiVersion"> Sets the api version to use. </param>
        /// <param name="tenant"> Sets the tenant to use. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal CustomParameterGroup(string apiVersion, string tenant, Dictionary<string, BinaryData> rawData)
        {
            ApiVersion = apiVersion;
            Tenant = tenant;
            _rawData = rawData;
        }

        /// <summary> Sets the api version to use. </summary>
        public string ApiVersion { get; }
        /// <summary> Sets the tenant to use. </summary>
        public string Tenant { get; }
    }
}
