// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Union.Models
{
    /// <summary> The second one of the unioned model type. </summary>
    internal partial class Model2 : BaseModel
    {
        /// <summary> Initializes a new instance of <see cref="Model2"/>. </summary>
        /// <param name="name"></param>
        /// <param name="prop2"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public Model2(string name, int prop2) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Prop2 = prop2;
        }

        /// <summary> Initializes a new instance of <see cref="Model2"/>. </summary>
        /// <param name="name"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="prop2"></param>
        internal Model2(string name, IDictionary<string, BinaryData> serializedAdditionalRawData, int prop2) : base(name, serializedAdditionalRawData)
        {
            Prop2 = prop2;
        }

        /// <summary> Initializes a new instance of <see cref="Model2"/> for deserialization. </summary>
        internal Model2()
        {
        }

        /// <summary> Gets or sets the prop 2. </summary>
        public int Prop2 { get; set; }
    }
}
