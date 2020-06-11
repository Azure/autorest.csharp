// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelShapes.Models
{
    /// <summary> The OutputModel. </summary>
    public partial class OutputModel
    {
        /// <summary> Initializes a new instance of OutputModel. </summary>
        /// <param name="requiredString"> . </param>
        /// <param name="requiredInt"> . </param>
        /// <param name="requiredStringList"> . </param>
        /// <param name="requiredIntList"> . </param>
        /// <param name="requiredNullableString"> . </param>
        /// <param name="requiredNullableInt"> . </param>
        /// <param name="requiredNullableStringList"> . </param>
        /// <param name="requiredNullableIntList"> . </param>
        internal OutputModel(string requiredString, int requiredInt, IEnumerable<string> requiredStringList, IEnumerable<int> requiredIntList, string requiredNullableString, int? requiredNullableInt, IEnumerable<string> requiredNullableStringList, IEnumerable<int> requiredNullableIntList)
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
            RequiredStringList = requiredStringList.ToArray();
            RequiredIntList = requiredIntList.ToArray();
            RequiredNullableString = requiredNullableString;
            RequiredNullableInt = requiredNullableInt;
            RequiredNullableStringList = requiredNullableStringList?.ToArray();
            RequiredNullableIntList = requiredNullableIntList?.ToArray();
        }

        /// <summary> Initializes a new instance of OutputModel. </summary>
        /// <param name="requiredString"> . </param>
        /// <param name="requiredInt"> . </param>
        /// <param name="requiredStringList"> . </param>
        /// <param name="requiredIntList"> . </param>
        /// <param name="nonRequiredString"> . </param>
        /// <param name="nonRequiredInt"> . </param>
        /// <param name="nonRequiredStringList"> . </param>
        /// <param name="nonRequiredIntList"> . </param>
        /// <param name="requiredNullableString"> . </param>
        /// <param name="requiredNullableInt"> . </param>
        /// <param name="requiredNullableStringList"> . </param>
        /// <param name="requiredNullableIntList"> . </param>
        internal OutputModel(string requiredString, int requiredInt, IReadOnlyList<string> requiredStringList, IReadOnlyList<int> requiredIntList, string nonRequiredString, int? nonRequiredInt, IReadOnlyList<string> nonRequiredStringList, IReadOnlyList<int> nonRequiredIntList, string requiredNullableString, int? requiredNullableInt, IReadOnlyList<string> requiredNullableStringList, IReadOnlyList<int> requiredNullableIntList)
        {
            RequiredString = requiredString;
            RequiredInt = requiredInt;
            RequiredStringList = requiredStringList ?? new List<string>();
            RequiredIntList = requiredIntList ?? new List<int>();
            NonRequiredString = nonRequiredString;
            NonRequiredInt = nonRequiredInt;
            NonRequiredStringList = nonRequiredStringList;
            NonRequiredIntList = nonRequiredIntList;
            RequiredNullableString = requiredNullableString;
            RequiredNullableInt = requiredNullableInt;
            RequiredNullableStringList = requiredNullableStringList;
            RequiredNullableIntList = requiredNullableIntList;
        }

        public string RequiredString { get; }
        public int RequiredInt { get; }
        public IReadOnlyList<string> RequiredStringList { get; }
        public IReadOnlyList<int> RequiredIntList { get; }
        public string NonRequiredString { get; }
        public int? NonRequiredInt { get; }
        public IReadOnlyList<string> NonRequiredStringList { get; }
        public IReadOnlyList<int> NonRequiredIntList { get; }
        public string RequiredNullableString { get; }
        public int? RequiredNullableInt { get; }
        public IReadOnlyList<string> RequiredNullableStringList { get; }
        public IReadOnlyList<int> RequiredNullableIntList { get; }
    }
}
