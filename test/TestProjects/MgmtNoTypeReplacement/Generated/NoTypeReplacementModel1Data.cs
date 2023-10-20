// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace MgmtNoTypeReplacement
{
    /// <summary> A class representing the NoTypeReplacementModel1 data model. </summary>
    public partial class NoTypeReplacementModel1Data : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="NoTypeReplacementModel1Data"/>. </summary>
        public NoTypeReplacementModel1Data()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NoTypeReplacementModel1Data"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="foo"> Gets or sets the foo. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal NoTypeReplacementModel1Data(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, SubResource foo, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Foo = foo;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the foo. </summary>
        internal SubResource Foo { get; set; }
        /// <summary> Gets Id. </summary>
        public ResourceIdentifier FooId
        {
            get => Foo is null ? default : Foo.Id;
        }
    }
}
