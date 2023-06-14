// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ModelShapes.Models
{
    /// <summary> The OutputModel. </summary>
    public partial class OutputModel
    {
        /// <summary> Initializes a new instance of OutputModel. </summary>
        /// <param name="requiredString"></param>
        /// <param name="requiredInt"></param>
        /// <param name="requiredStringList"></param>
        /// <param name="requiredIntList"></param>
        /// <param name="requiredNullableString"></param>
        /// <param name="requiredNullableInt"></param>
        /// <param name="requiredNullableStringList"></param>
        /// <param name="requiredNullableIntList"></param>
        /// <param name="requiredReadonlyInt"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/>, <paramref name="requiredStringList"/> or <paramref name="requiredIntList"/> is null. </exception>
        internal OutputModel(string requiredString, int requiredInt, IEnumerable<string> requiredStringList, IEnumerable<int> requiredIntList, string requiredNullableString, int? requiredNullableInt, IEnumerable<string> requiredNullableStringList, IEnumerable<int> requiredNullableIntList, int requiredReadonlyInt)
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
            RequiredReadonlyInt = requiredReadonlyInt;
        }

        /// <summary> Initializes a new instance of OutputModel. </summary>
        /// <param name="requiredString"></param>
        /// <param name="requiredInt"></param>
        /// <param name="requiredStringList"></param>
        /// <param name="requiredIntList"></param>
        /// <param name="nonRequiredString"></param>
        /// <param name="nonRequiredInt"></param>
        /// <param name="nonRequiredStringList"></param>
        /// <param name="nonRequiredIntList"></param>
        /// <param name="requiredNullableString"></param>
        /// <param name="requiredNullableInt"></param>
        /// <param name="requiredNullableStringList"></param>
        /// <param name="requiredNullableIntList"></param>
        /// <param name="nonRequiredNullableString"></param>
        /// <param name="nonRequiredNullableInt"></param>
        /// <param name="nonRequiredNullableStringList"></param>
        /// <param name="nonRequiredNullableIntList"></param>
        /// <param name="requiredReadonlyInt"></param>
        /// <param name="nonRequiredReadonlyInt"></param>
        internal OutputModel(string requiredString, int requiredInt, IReadOnlyList<string> requiredStringList, IReadOnlyList<int> requiredIntList, string nonRequiredString, int? nonRequiredInt, IReadOnlyList<string> nonRequiredStringList, IReadOnlyList<int> nonRequiredIntList, string requiredNullableString, int? requiredNullableInt, IReadOnlyList<string> requiredNullableStringList, IReadOnlyList<int> requiredNullableIntList, string nonRequiredNullableString, int? nonRequiredNullableInt, IReadOnlyList<string> nonRequiredNullableStringList, IReadOnlyList<int> nonRequiredNullableIntList, int requiredReadonlyInt, int? nonRequiredReadonlyInt)
        {
            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredStringList = requiredStringList;
            RequiredIntList = requiredIntList;
            NonRequiredString = nonRequiredString;
            NonRequiredInt = nonRequiredInt;
            NonRequiredStringList = nonRequiredStringList;
            NonRequiredIntList = nonRequiredIntList;
            RequiredNullableString = requiredNullableString;
            RequiredNullableInt = requiredNullableInt;
            RequiredNullableStringList = requiredNullableStringList;
            RequiredNullableIntList = requiredNullableIntList;
            NonRequiredNullableString = nonRequiredNullableString;
            NonRequiredNullableInt = nonRequiredNullableInt;
            NonRequiredNullableStringList = nonRequiredNullableStringList;
            NonRequiredNullableIntList = nonRequiredNullableIntList;
            RequiredReadonlyInt = requiredReadonlyInt;
            NonRequiredReadonlyInt = nonRequiredReadonlyInt;
        }

        /// <summary> Gets the required string. </summary>
        public string RequiredString { get; }
        /// <summary> Gets the required int. </summary>
        public int RequiredInt { get; }
        /// <summary> Gets the required string list. </summary>
        public IReadOnlyList<string> RequiredStringList { get; }
        /// <summary> Gets the required int list. </summary>
        public IReadOnlyList<int> RequiredIntList { get; }
        /// <summary> Gets the non required string. </summary>
        public string NonRequiredString { get; }
        /// <summary> Gets the non required int. </summary>
        public int? NonRequiredInt { get; }
        /// <summary> Gets the non required string list. </summary>
        public IReadOnlyList<string> NonRequiredStringList { get; }
        /// <summary> Gets the non required int list. </summary>
        public IReadOnlyList<int> NonRequiredIntList { get; }
        /// <summary> Gets the required nullable string. </summary>
        public string RequiredNullableString { get; }
        /// <summary> Gets the required nullable int. </summary>
        public int? RequiredNullableInt { get; }
        /// <summary> Gets the required nullable string list. </summary>
        public IReadOnlyList<string> RequiredNullableStringList { get; }
        /// <summary> Gets the required nullable int list. </summary>
        public IReadOnlyList<int> RequiredNullableIntList { get; }
        /// <summary> Gets the non required nullable string. </summary>
        public string NonRequiredNullableString { get; }
        /// <summary> Gets the non required nullable int. </summary>
        public int? NonRequiredNullableInt { get; }
        /// <summary> Gets the non required nullable string list. </summary>
        public IReadOnlyList<string> NonRequiredNullableStringList { get; }
        /// <summary> Gets the non required nullable int list. </summary>
        public IReadOnlyList<int> NonRequiredNullableIntList { get; }
        /// <summary> Gets the required readonly int. </summary>
        public int RequiredReadonlyInt { get; }
        /// <summary> Gets the non required readonly int. </summary>
        public int? NonRequiredReadonlyInt { get; }
    }
}
