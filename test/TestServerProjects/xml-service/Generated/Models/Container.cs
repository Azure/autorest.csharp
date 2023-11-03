// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> An Azure Storage container. </summary>
    public partial class Container
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="Container"/>. </summary>
        /// <param name="name"></param>
        /// <param name="properties"> Properties of a container. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="properties"/> is null. </exception>
        internal Container(string name, ContainerProperties properties)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(properties, nameof(properties));

            Name = name;
            Properties = properties;
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="Container"/>. </summary>
        /// <param name="name"></param>
        /// <param name="properties"> Properties of a container. </param>
        /// <param name="metadata"> Dictionary of &lt;string&gt;. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Container(string name, ContainerProperties properties, IReadOnlyDictionary<string, string> metadata, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Properties = properties;
            Metadata = metadata;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="Container"/> for deserialization. </summary>
        internal Container()
        {
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
        /// <summary> Properties of a container. </summary>
        public ContainerProperties Properties { get; }
        /// <summary> Dictionary of &lt;string&gt;. </summary>
        public IReadOnlyDictionary<string, string> Metadata { get; }
    }
}
