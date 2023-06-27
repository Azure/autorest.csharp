// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtNoTypeReplacement.Models;

namespace MgmtNoTypeReplacement
{
    /// <summary> A class representing the NoTypeReplacementModel2 data model. </summary>
    public partial class NoTypeReplacementModel2Data : ResourceData
    {
        /// <summary> Initializes a new instance of NoTypeReplacementModel2Data. </summary>
        public NoTypeReplacementModel2Data()
        {
        }

        /// <summary> Initializes a new instance of NoTypeReplacementModel2Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="foo"></param>
        internal NoTypeReplacementModel2Data(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, NoSubResourceModel foo) : base(id, name, resourceType, systemData)
        {
            Foo = foo;
        }

        /// <summary> Gets or sets the foo. </summary>
        internal NoSubResourceModel Foo { get; set; }
        /// <summary> Gets the foo id. </summary>
        public string FooId
        {
            get => Foo is null ? default : Foo.Id;
        }
    }
}
