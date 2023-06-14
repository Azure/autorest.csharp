// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Roundtrip model that has property of its own type. </summary>
    public partial class RoundTripRecursiveModel
    {
        /// <summary> Initializes a new instance of RoundTripRecursiveModel. </summary>
        /// <param name="message"> Message. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="message"/> is null. </exception>
        public RoundTripRecursiveModel(string message)
        {
            Argument.AssertNotNull(message, nameof(message));

            Message = message;
        }

        /// <summary> Initializes a new instance of RoundTripRecursiveModel. </summary>
        /// <param name="message"> Message. </param>
        /// <param name="inner"> Required Record. </param>
        internal RoundTripRecursiveModel(string message, RoundTripRecursiveModel inner)
        {
            Message = message;
            Inner = inner;
        }

        /// <summary> Message. </summary>
        public string Message { get; set; }
        /// <summary> Required Record. </summary>
        public RoundTripRecursiveModel Inner { get; set; }
    }
}
