// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ServiceModel.Rest.Experimental;

namespace UnbrandedTypeSpec.Models
{
    /// <summary> this is not a friendly model but with a friendly name. </summary>
    public partial class Friend
    {
        /// <summary> Initializes a new instance of Friend. </summary>
        /// <param name="name"> name of the NotFriend. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public Friend(string name)
        {
            ClientUtilities.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> name of the NotFriend. </summary>
        public string Name { get; set; }
    }
}
