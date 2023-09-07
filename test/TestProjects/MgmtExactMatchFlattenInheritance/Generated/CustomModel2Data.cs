// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtExactMatchFlattenInheritance
{
    /// <summary>
    /// A class representing the CustomModel2 data model.
    /// Pure custom model, the purpose is to pull in a SubResource model so that it can be generated.
    /// </summary>
    public partial class CustomModel2Data : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="CustomModel2Data"/>. </summary>
        public CustomModel2Data()
        {
        }

        /// <summary> Initializes a new instance of <see cref="CustomModel2Data"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="foo"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CustomModel2Data(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string foo, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Foo = foo;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
    }
}
