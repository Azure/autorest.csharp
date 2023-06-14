// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtExactMatchFlattenInheritance.Models
{
    /// <summary> This model is x-ms-azure-resource, and is exactly a WritableSubResource type. </summary>
    public partial class AzureResourceFlattenModel7
    {
        /// <summary> Initializes a new instance of AzureResourceFlattenModel7. </summary>
        public AzureResourceFlattenModel7()
        {
        }

        /// <summary> Initializes a new instance of AzureResourceFlattenModel7. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="resourceType"></param>
        internal AzureResourceFlattenModel7(string id, string name, string resourceType)
        {
            Id = id;
            Name = name;
            ResourceType = resourceType;
        }

        /// <summary> Gets or sets the id. </summary>
        public string Id { get; set; }
        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
        /// <summary> Gets or sets the resource type. </summary>
        public string ResourceType { get; set; }
    }
}
