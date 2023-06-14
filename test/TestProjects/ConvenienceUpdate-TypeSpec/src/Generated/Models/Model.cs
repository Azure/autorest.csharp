// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace ConvenienceInCadl.Models
{
    /// <summary> A model. </summary>
    public partial class Model
    {
        /// <summary> Initializes a new instance of Model. </summary>
        /// <param name="id"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        public Model(string id)
        {
            Argument.AssertNotNull(id, nameof(id));

            Id = id;
        }

        /// <summary> Gets or sets the id. </summary>
        public string Id { get; set; }
    }
}
