// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace ParametersCadl.Models
{
    /// <summary> The Result. </summary>
    public partial class Result
    {
        /// <summary> Initializes a new instance of Result. </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        internal Result(string id)
        {
            Argument.AssertNotNull(id, nameof(id));

            Id = id;
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
    }
}
