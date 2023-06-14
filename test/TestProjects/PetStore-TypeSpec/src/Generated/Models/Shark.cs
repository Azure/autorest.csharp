// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace PetStore.Models
{
    /// <summary> Shark is a fish. </summary>
    public partial class Shark : Fish
    {
        /// <summary> Initializes a new instance of Shark. </summary>
        /// <param name="size"> The size of the fish. </param>
        /// <param name="bite"> The bite of the shark. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="bite"/> is null. </exception>
        internal Shark(int size, string bite) : base(size)
        {
            Argument.AssertNotNull(bite, nameof(bite));

            Kind = "shark";
            Bite = bite;
        }

        /// <summary> Initializes a new instance of Shark. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="size"> The size of the fish. </param>
        /// <param name="bite"> The bite of the shark. </param>
        internal Shark(string kind, int size, string bite) : base(kind, size)
        {
            Bite = bite;
        }

        /// <summary> The bite of the shark. </summary>
        public string Bite { get; }
    }
}
