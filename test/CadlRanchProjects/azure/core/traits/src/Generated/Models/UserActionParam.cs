// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Specs_.Azure.Core.Traits.Models
{
    /// <summary> User action param. </summary>
    public partial class UserActionParam
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of UserActionParam. </summary>
        /// <param name="userActionValue"> User action value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userActionValue"/> is null. </exception>
        public UserActionParam(string userActionValue)
        {
            Argument.AssertNotNull(userActionValue, nameof(userActionValue));

            UserActionValue = userActionValue;
        }

        /// <summary> Initializes a new instance of UserActionParam. </summary>
        /// <param name="userActionValue"> User action value. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UserActionParam(string userActionValue, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            UserActionValue = userActionValue;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="UserActionParam"/> for deserialization. </summary>
        internal UserActionParam()
        {
        }

        /// <summary> User action value. </summary>
        public string UserActionValue { get; }
    }
}
