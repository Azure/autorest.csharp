// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace System.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
    /// <summary> Unknown version of BaseModel. </summary>
    internal partial class UnknownBaseModel : BaseModel
    {
        /// <summary> Initializes a new instance of <see cref="UnknownBaseModel"/>. </summary>
        /// <param name="name"> The name property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal UnknownBaseModel(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
        }

        /// <summary> Initializes a new instance of <see cref="UnknownBaseModel"/>. </summary>
        /// <param name="kind"> The kind. </param>
        /// <param name="name"> The name property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownBaseModel(string kind, string name, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(kind, name, serializedAdditionalRawData)
        {
        }

        /// <summary> Initializes a new instance of <see cref="UnknownBaseModel"/> for deserialization. </summary>
        internal UnknownBaseModel()
        {
        }
    }
}
