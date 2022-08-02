// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace CadlPetStore
{
    public partial class ToyListResults
    {
        public object Items { get; }

        public string NextLink { get; }

        /// <summary> Initializes a new instance of ToyListResults. </summary>
        /// <param name="items"></param>
        /// <param name="nextLink"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="items"/> or <paramref name="nextLink"/> is null. </exception>
        public ToyListResults(object items, string nextLink)
        {
            Argument.AssertNotNull(items, nameof(items));
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            Items = items;
            NextLink = nextLink;
        }
    }
}
