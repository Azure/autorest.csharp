// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ModelShapes.Models
{
    /// <summary> The InputModel. </summary>
    public partial class InputModel
    {
        /// <summary> Initializes a new instance of InputModel. </summary>
        /// <param name="requiredString"></param>
        /// <param name="requiredInt"></param>
        /// <param name="requiredStringList"></param>
        /// <param name="requiredIntList"></param>
        /// <param name="requiredNullableString"></param>
        /// <param name="requiredNullableInt"></param>
        /// <param name="requiredNullableStringList"></param>
        /// <param name="requiredNullableIntList"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/>, <paramref name="requiredStringList"/> or <paramref name="requiredIntList"/> is null. </exception>
        public InputModel(string requiredString, int requiredInt, IEnumerable<string> requiredStringList, IEnumerable<int> requiredIntList, string requiredNullableString, int? requiredNullableInt, IEnumerable<string> requiredNullableStringList, IEnumerable<int> requiredNullableIntList)
        {
            Argument.AssertNotNull(requiredString, nameof(requiredString));
            Argument.AssertNotNull(requiredStringList, nameof(requiredStringList));
            Argument.AssertNotNull(requiredIntList, nameof(requiredIntList));

            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredStringList = requiredStringList.ToList();
            RequiredIntList = requiredIntList.ToList();
            NonRequiredStringList = new ChangeTrackingList<string>();
            NonRequiredIntList = new ChangeTrackingList<int>();
            RequiredNullableString = requiredNullableString;
            RequiredNullableInt = requiredNullableInt;
            RequiredNullableStringList = requiredNullableStringList?.ToList();
            RequiredNullableIntList = requiredNullableIntList?.ToList();
            NonRequiredNullableStringList = new ChangeTrackingList<string>();
            NonRequiredNullableIntList = new ChangeTrackingList<int>();
        }

        /// <summary> Gets the required string. </summary>
        public string RequiredString { get; }
        /// <summary> Gets the required int. </summary>
        public int RequiredInt { get; }
        /// <summary> Gets the required string list. </summary>
        public IList<string> RequiredStringList { get; }
        /// <summary> Gets the required int list. </summary>
        public IList<int> RequiredIntList { get; }
        /// <summary> Gets or sets the non required string. </summary>
        public string NonRequiredString { get; set; }
        /// <summary> Gets or sets the non required int. </summary>
        public int? NonRequiredInt { get; set; }
        /// <summary> Gets the non required string list. </summary>
        public IList<string> NonRequiredStringList { get; }
        /// <summary> Gets the non required int list. </summary>
        public IList<int> NonRequiredIntList { get; }
        /// <summary> Gets the required nullable string. </summary>
        public string RequiredNullableString { get; }
        /// <summary> Gets the required nullable int. </summary>
        public int? RequiredNullableInt { get; }
        /// <summary> Gets or sets the required nullable string list. </summary>
        public IList<string> RequiredNullableStringList { get; set; }
        /// <summary> Gets or sets the required nullable int list. </summary>
        public IList<int> RequiredNullableIntList { get; set; }
        /// <summary> Gets or sets the non required nullable string. </summary>
        public string NonRequiredNullableString { get; set; }
        /// <summary> Gets or sets the non required nullable int. </summary>
        public int? NonRequiredNullableInt { get; set; }
        /// <summary> Gets or sets the non required nullable string list. </summary>
        public IList<string> NonRequiredNullableStringList { get; set; }
        /// <summary> Gets or sets the non required nullable int list. </summary>
        public IList<int> NonRequiredNullableIntList { get; set; }
    }
}
