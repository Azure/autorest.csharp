// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Specs_.Azure.Core.Basic.Models
{
    /// <summary> Details about a user. </summary>
    public partial class User
    {
        /// <summary> Initializes a new instance of User. </summary>
        /// <param name="name"> The user's name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public User(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            Orders = new ChangeTrackingList<UserOrder>();
        }

        /// <summary> Initializes a new instance of User. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="name"> The user's name. </param>
        /// <param name="orders"> The user's order list. </param>
        /// <param name="etag"> The entity tag for this resource. </param>
        internal User(int id, string name, IList<UserOrder> orders, string etag)
        {
            Id = id;
            Name = name;
            Orders = orders;
            Etag = etag;
        }

        /// <summary> The user's id. </summary>
        public int Id { get; }
        /// <summary> The user's name. </summary>
        public string Name { get; set; }
        /// <summary> The user's order list. </summary>
        public IList<UserOrder> Orders { get; }
        /// <summary> The entity tag for this resource. </summary>
        public string Etag { get; }
    }
}
