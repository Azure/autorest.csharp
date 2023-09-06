// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtNoTypeReplacement.Models;

namespace MgmtNoTypeReplacement
{
    /// <summary> A class representing the NoTypeReplacementModel2 data model. </summary>
    public partial class NoTypeReplacementModel2Data : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="NoTypeReplacementModel2Data"/>. </summary>
        public NoTypeReplacementModel2Data()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NoTypeReplacementModel2Data"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="foo"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal NoTypeReplacementModel2Data(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, NoSubResourceModel foo, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData)
        {
            Foo = foo;
            _rawData = rawData;
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
