// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtExactMatchFlattenInheritance
{
    /// <summary>
    /// A class representing the AzureResourceFlattenModel1 data model.
    /// This model is x-ms-azure-resource, has flatten properties, and it contains all reference type properties.
    /// </summary>
    public partial class AzureResourceFlattenModel1Data : TrackedResourceData
    {
        /// <summary> Initializes a new instance of AzureResourceFlattenModel1Data. </summary>
        /// <param name="location"> The location. </param>
        public AzureResourceFlattenModel1Data(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of AzureResourceFlattenModel1Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="foo"> New property. </param>
        /// <param name="fooPropertiesFoo"></param>
        /// <param name="idPropertiesId"> ID in CustomModel1. </param>
        internal AzureResourceFlattenModel1Data(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, int? foo, string fooPropertiesFoo, string idPropertiesId) : base(id, name, resourceType, systemData, tags, location)
        {
            Foo = foo;
            FooPropertiesFoo = fooPropertiesFoo;
            IdPropertiesId = idPropertiesId;
        }

        /// <summary> New property. </summary>
        public int? Foo { get; set; }
        /// <summary> Gets or sets the foo properties foo. </summary>
        public string FooPropertiesFoo { get; set; }
        /// <summary> ID in CustomModel1. </summary>
        public string IdPropertiesId { get; set; }
    }
}
