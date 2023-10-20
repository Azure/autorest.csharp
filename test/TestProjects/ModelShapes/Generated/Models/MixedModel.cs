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
    /// <summary> The MixedModel. </summary>
    public partial class MixedModel
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of MixedModel. </summary>
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
        public MixedModel(string requiredString, int requiredInt, IEnumerable<string> requiredStringList, IEnumerable<int> requiredIntList, string requiredNullableString, int? requiredNullableInt, IEnumerable<string> requiredNullableStringList, IEnumerable<int> requiredNullableIntList, int requiredReadonlyInt)
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

        /// <summary> Initializes a new instance of MixedModel. </summary>
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
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MixedModel(string requiredString, int requiredInt, IList<string> requiredStringList, IList<int> requiredIntList, string nonRequiredString, int? nonRequiredInt, IList<string> nonRequiredStringList, IList<int> nonRequiredIntList, string requiredNullableString, int? requiredNullableInt, IList<string> requiredNullableStringList, IList<int> requiredNullableIntList, string nonRequiredNullableString, int? nonRequiredNullableInt, IList<string> nonRequiredNullableStringList, IList<int> nonRequiredNullableIntList, int requiredReadonlyInt, int? nonRequiredReadonlyInt, IDictionary<string, BinaryData> serializedAdditionalRawData)
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
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the required string. </summary>
        public string RequiredString { get; set; }
        /// <summary> Gets or sets the required int. </summary>
        public int RequiredInt { get; set; }
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
        /// <summary> Gets or sets the required nullable string. </summary>
        public string RequiredNullableString { get; set; }
        /// <summary> Gets or sets the required nullable int. </summary>
        public int? RequiredNullableInt { get; set; }
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
        /// <summary> Gets the required readonly int. </summary>
        public int RequiredReadonlyInt { get; }
        /// <summary> Gets the non required readonly int. </summary>
        public int? NonRequiredReadonlyInt { get; }
    }
}
