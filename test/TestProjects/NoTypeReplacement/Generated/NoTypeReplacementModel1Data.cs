// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace NoTypeReplacement
{
    /// <summary> A class representing the NoTypeReplacementModel1 data model. </summary>
    public partial class NoTypeReplacementModel1Data : ResourceData
    {
        /// <summary> Initializes a new instance of NoTypeReplacementModel1Data. </summary>
        public NoTypeReplacementModel1Data()
        {
        }

        /// <summary> Initializes a new instance of NoTypeReplacementModel1Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="foo"></param>
        internal NoTypeReplacementModel1Data(ResourceIdentifier id, string name, ResourceType type, SystemData systemData, SubResource foo) : base(id, name, type, systemData)
        {
            Foo = foo;
        }

        /// <summary> Gets or sets the foo. </summary>
        public SubResource Foo { get; set; }
    }
}
