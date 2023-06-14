// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MultipleMediaTypes.Models
{
    /// <summary> The Body. </summary>
    public partial class Body
    {
        /// <summary> Initializes a new instance of Body. </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        public Body(string id)
        {
            Argument.AssertNotNull(id, nameof(id));

            Id = id;
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
    }
}
