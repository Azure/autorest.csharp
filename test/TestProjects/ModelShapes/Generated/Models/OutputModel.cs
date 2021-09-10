// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
        /// <param name="requiredString"> The RequiredString. </param>
        /// <param name="requiredInt"> The RequiredInt. </param>
        /// <param name="requiredStringList"> The RequiredStringList. </param>
        /// <param name="requiredIntList"> The RequiredIntList. </param>
        /// <param name="requiredNullableString"> The RequiredNullableString. </param>
        /// <param name="requiredNullableInt"> The RequiredNullableInt. </param>
        /// <param name="requiredNullableStringList"> The RequiredNullableStringList. </param>
        /// <param name="requiredNullableIntList"> The RequiredNullableIntList. </param>
        /// <param name="requiredReadonlyInt"> The RequiredReadonlyInt. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredString"/>, <paramref name="requiredStringList"/>, or <paramref name="requiredIntList"/> is null. </exception>
        internal OutputModel(string requiredString, int requiredInt, IEnumerable<string> requiredStringList, IEnumerable<int> requiredIntList, string requiredNullableString, int? requiredNullableInt, IEnumerable<string> requiredNullableStringList, IEnumerable<int> requiredNullableIntList, int requiredReadonlyInt)
        {
            if (requiredString == null)
            {
                throw new ArgumentNullException(nameof(requiredString));
            }
            if (requiredStringList == null)
            {
                throw new ArgumentNullException(nameof(requiredStringList));
            }
            if (requiredIntList == null)
            {
                throw new ArgumentNullException(nameof(requiredIntList));
            }

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
        /// <param name="requiredString"> The RequiredString. </param>
        /// <param name="requiredInt"> The RequiredInt. </param>
        /// <param name="requiredStringList"> The RequiredStringList. </param>
        /// <param name="requiredIntList"> The RequiredIntList. </param>
        /// <param name="nonRequiredString"> The NonRequiredString. </param>
        /// <param name="nonRequiredInt"> The NonRequiredInt. </param>
        /// <param name="nonRequiredStringList"> The NonRequiredStringList. </param>
        /// <param name="nonRequiredIntList"> The NonRequiredIntList. </param>
        /// <param name="requiredNullableString"> The RequiredNullableString. </param>
        /// <param name="requiredNullableInt"> The RequiredNullableInt. </param>
        /// <param name="requiredNullableStringList"> The RequiredNullableStringList. </param>
        /// <param name="requiredNullableIntList"> The RequiredNullableIntList. </param>
        /// <param name="nonRequiredNullableString"> The NonRequiredNullableString. </param>
        /// <param name="nonRequiredNullableInt"> The NonRequiredNullableInt. </param>
        /// <param name="nonRequiredNullableStringList"> The NonRequiredNullableStringList. </param>
        /// <param name="nonRequiredNullableIntList"> The NonRequiredNullableIntList. </param>
        /// <param name="requiredReadonlyInt"> The RequiredReadonlyInt. </param>
        /// <param name="nonRequiredReadonlyInt"> The NonRequiredReadonlyInt. </param>
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

        /// <summary> The RequiredString. </summary>
        public string RequiredString { get; }
        /// <summary> The RequiredInt. </summary>
        public int RequiredInt { get; }
        /// <summary> The RequiredStringList. </summary>
        public IReadOnlyList<string> RequiredStringList { get; }
        /// <summary> The RequiredIntList. </summary>
        public IReadOnlyList<int> RequiredIntList { get; }
        /// <summary> The NonRequiredString. </summary>
        public string NonRequiredString { get; }
        /// <summary> The NonRequiredInt. </summary>
        public int? NonRequiredInt { get; }
        /// <summary> The NonRequiredStringList. </summary>
        public IReadOnlyList<string> NonRequiredStringList { get; }
        /// <summary> The NonRequiredIntList. </summary>
        public IReadOnlyList<int> NonRequiredIntList { get; }
        /// <summary> The RequiredNullableString. </summary>
        public string RequiredNullableString { get; }
        /// <summary> The RequiredNullableInt. </summary>
        public int? RequiredNullableInt { get; }
        /// <summary> The RequiredNullableStringList. </summary>
        public IReadOnlyList<string> RequiredNullableStringList { get; }
        /// <summary> The RequiredNullableIntList. </summary>
        public IReadOnlyList<int> RequiredNullableIntList { get; }
        /// <summary> The NonRequiredNullableString. </summary>
        public string NonRequiredNullableString { get; }
        /// <summary> The NonRequiredNullableInt. </summary>
        public int? NonRequiredNullableInt { get; }
        /// <summary> The NonRequiredNullableStringList. </summary>
        public IReadOnlyList<string> NonRequiredNullableStringList { get; }
        /// <summary> The NonRequiredNullableIntList. </summary>
        public IReadOnlyList<int> NonRequiredNullableIntList { get; }
        /// <summary> The RequiredReadonlyInt. </summary>
        public int RequiredReadonlyInt { get; }
        /// <summary> The NonRequiredReadonlyInt. </summary>
        public int? NonRequiredReadonlyInt { get; }
    }
}
