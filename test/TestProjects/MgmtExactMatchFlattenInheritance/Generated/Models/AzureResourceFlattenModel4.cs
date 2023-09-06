// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtExactMatchFlattenInheritance.Models
{
    /// <summary> This model is x-ms-azure-resource, has flatten properties, and WITHOUT enough reference type properties. </summary>
    public partial class AzureResourceFlattenModel4
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="AzureResourceFlattenModel4"/>. </summary>
        public AzureResourceFlattenModel4()
        {
        }

        /// <summary> Initializes a new instance of <see cref="AzureResourceFlattenModel4"/>. </summary>
        /// <param name="foo"> New property. </param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="resourceType"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal AzureResourceFlattenModel4(int? foo, string id, string name, string resourceType, Dictionary<string, BinaryData> rawData)
        {
            Foo = foo;
            Id = id;
            Name = name;
            ResourceType = resourceType;
            _rawData = rawData;
        }

        /// <summary> New property. </summary>
        public int? Foo { get; set; }
        /// <summary> Gets or sets the id. </summary>
        public string Id { get; set; }
        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
        /// <summary> Gets or sets the resource type. </summary>
        public string ResourceType { get; set; }
    }
}
