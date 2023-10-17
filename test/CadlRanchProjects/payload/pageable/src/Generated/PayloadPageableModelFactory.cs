// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Payload.Pageable.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class PayloadPageableModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.User"/>. </summary>
        /// <param name="name"> User name. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <returns> A new <see cref="Models.User"/> instance for mocking. </returns>
        public static User User(string name = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null)
        {
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new User(name, serializedAdditionalRawData);
        }
    }
}
