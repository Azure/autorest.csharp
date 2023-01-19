// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace ModelsInCadl.Models
{
    /// <summary> Input model that has property of its own type. </summary>
    public partial class InputRecursiveModel
    {
        /// <summary> Initializes a new instance of InputRecursiveModel. </summary>
        /// <param name="message"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        public InputRecursiveModel(string message)
        {
            Argument.AssertNotNull(message, nameof(message));

            Message = message;
        }

        /// <summary> Gets the message. </summary>
        public string Message { get; }
        /// <summary> Gets or sets the inner. </summary>
        public InputRecursiveModel Inner { get; set; }
    }
}
