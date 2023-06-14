// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Spread.Models
{
    /// <summary> The Thing. </summary>
    public partial class Thing
    {
        /// <summary> Initializes a new instance of Thing. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public Thing(string name, int age)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            Age = age;
        }

        /// <summary> name of the Thing. </summary>
        public string Name { get; }
        /// <summary> age of the Thing. </summary>
        public int Age { get; }
    }
}
