// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Specs_.Azure.ClientGenerator.Core.Internal.Models
{
    /// <summary> This is a model only used by internal operation. It should be generated but not exported. </summary>
    internal partial class InternalModel
    {
        /// <summary> Initializes a new instance of InternalModel. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal InternalModel(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
