// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Specs_.Azure.Core.Basic.Models
{
    /// <summary> UserOrder for testing list with expand. </summary>
    public partial class UserOrder
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of UserOrder. </summary>
        /// <param name="userId"> The user's id. </param>
        /// <param name="detail"> The user's order detail. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="detail"/> is null. </exception>
        public UserOrder(int userId, string detail)
        {
            Argument.AssertNotNull(detail, nameof(detail));

            UserId = userId;
            Detail = detail;
        }

        /// <summary> Initializes a new instance of UserOrder. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="userId"> The user's id. </param>
        /// <param name="detail"> The user's order detail. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UserOrder(int id, int userId, string detail, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            UserId = userId;
            Detail = detail;
            _rawData = rawData;
        }

        /// <summary> The user's id. </summary>
        public int Id { get; }
        /// <summary> The user's id. </summary>
        public int UserId { get; set; }
        /// <summary> The user's order detail. </summary>
        public string Detail { get; set; }
    }
}
