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
    /// <summary> A class representing the NoTypeReplacementModel3 data model. </summary>
    public partial class NoTypeReplacementModel3Data : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="NoTypeReplacementModel3Data"/>. </summary>
        public NoTypeReplacementModel3Data()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NoTypeReplacementModel3Data"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="foo"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal NoTypeReplacementModel3Data(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, MiddleResourceModel foo, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Foo = foo;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the foo. </summary>
        internal MiddleResourceModel Foo { get; set; }
        /// <summary> Gets the foo id. </summary>
        public string FooId
        {
            get => Foo is null ? default : Foo.FooId;
        }
    }
}
