// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtExactMatchFlattenInheritance.Models
{
    /// <summary> This model is x-ms-azure-resource, but only extends a Resource type and inherits Resource properties from flatten source. </summary>
    public partial class AzureResourceFlattenModel5 : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="AzureResourceFlattenModel5"/>. </summary>
        public AzureResourceFlattenModel5()
        {
        }

        /// <summary> Initializes a new instance of <see cref="AzureResourceFlattenModel5"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="foo"> New property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AzureResourceFlattenModel5(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, int? foo, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Foo = foo;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> New property. </summary>
        public int? Foo { get; set; }
    }
}
