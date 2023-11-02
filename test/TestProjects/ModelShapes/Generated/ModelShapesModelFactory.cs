// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelShapes.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ModelShapesModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.InputModel"/>. </summary>
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
        /// <param name="vector"> The vector representation of a search query. </param>
        /// <param name="vectorReadOnly"> The vector representation of a search query. </param>
        /// <param name="vectorReadOnlyRequired"> The vector representation of a search query. </param>
        /// <param name="vectorRequired"> The vector representation of a search query. </param>
        /// <param name="vectorNullable"> The vector representation of a search query. </param>
        /// <param name="vectorReadOnlyNullable"> The vector representation of a search query. </param>
        /// <param name="vectorReadOnlyRequiredNullable"> The vector representation of a search query. </param>
        /// <param name="vectorRequiredNullable"> The vector representation of a search query. </param>
        /// <returns> A new <see cref="Models.InputModel"/> instance for mocking. </returns>
        public static InputModel InputModel(string requiredString = null, int requiredInt = default, IEnumerable<string> requiredStringList = null, IEnumerable<int> requiredIntList = null, string nonRequiredString = null, int? nonRequiredInt = null, IEnumerable<string> nonRequiredStringList = null, IEnumerable<int> nonRequiredIntList = null, string requiredNullableString = null, int? requiredNullableInt = null, IEnumerable<string> requiredNullableStringList = null, IEnumerable<int> requiredNullableIntList = null, string nonRequiredNullableString = null, int? nonRequiredNullableInt = null, IEnumerable<string> nonRequiredNullableStringList = null, IEnumerable<int> nonRequiredNullableIntList = null, ReadOnlyMemory<float> vector = default, ReadOnlyMemory<float> vectorReadOnly = default, ReadOnlyMemory<float> vectorReadOnlyRequired = default, ReadOnlyMemory<float> vectorRequired = default, ReadOnlyMemory<float>? vectorNullable = null, ReadOnlyMemory<float>? vectorReadOnlyNullable = null, ReadOnlyMemory<float>? vectorReadOnlyRequiredNullable = null, ReadOnlyMemory<float>? vectorRequiredNullable = null)
        {
            requiredStringList ??= new List<string>();
            requiredIntList ??= new List<int>();
            nonRequiredStringList ??= new List<string>();
            nonRequiredIntList ??= new List<int>();
            requiredNullableStringList ??= new List<string>();
            requiredNullableIntList ??= new List<int>();
            nonRequiredNullableStringList ??= new List<string>();
            nonRequiredNullableIntList ??= new List<int>();

            return new InputModel(requiredString, requiredInt, requiredStringList?.ToList(), requiredIntList?.ToList(), nonRequiredString, nonRequiredInt, nonRequiredStringList?.ToList(), nonRequiredIntList?.ToList(), requiredNullableString, requiredNullableInt, requiredNullableStringList?.ToList(), requiredNullableIntList?.ToList(), nonRequiredNullableString, nonRequiredNullableInt, nonRequiredNullableStringList?.ToList(), nonRequiredNullableIntList?.ToList(), vector, vectorReadOnly, vectorReadOnlyRequired, vectorRequired, vectorNullable, vectorReadOnlyNullable, vectorReadOnlyRequiredNullable, vectorRequiredNullable, new Dictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.MixedModel"/>. </summary>
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
        /// <param name="vector"> The vector representation of a search query. </param>
        /// <param name="vectorReadOnly"> The vector representation of a search query. </param>
        /// <param name="vectorReadOnlyRequired"> The vector representation of a search query. </param>
        /// <param name="vectorRequired"> The vector representation of a search query. </param>
        /// <param name="vectorNullable"> The vector representation of a search query. </param>
        /// <param name="vectorReadOnlyNullable"> The vector representation of a search query. </param>
        /// <param name="vectorReadOnlyRequiredNullable"> The vector representation of a search query. </param>
        /// <param name="vectorRequiredNullable"> The vector representation of a search query. </param>
        /// <returns> A new <see cref="Models.MixedModel"/> instance for mocking. </returns>
        public static MixedModel MixedModel(string requiredString = null, int requiredInt = default, IEnumerable<string> requiredStringList = null, IEnumerable<int> requiredIntList = null, string nonRequiredString = null, int? nonRequiredInt = null, IEnumerable<string> nonRequiredStringList = null, IEnumerable<int> nonRequiredIntList = null, string requiredNullableString = null, int? requiredNullableInt = null, IEnumerable<string> requiredNullableStringList = null, IEnumerable<int> requiredNullableIntList = null, string nonRequiredNullableString = null, int? nonRequiredNullableInt = null, IEnumerable<string> nonRequiredNullableStringList = null, IEnumerable<int> nonRequiredNullableIntList = null, int requiredReadonlyInt = default, int? nonRequiredReadonlyInt = null, ReadOnlyMemory<float> vector = default, ReadOnlyMemory<float> vectorReadOnly = default, ReadOnlyMemory<float> vectorReadOnlyRequired = default, ReadOnlyMemory<float> vectorRequired = default, ReadOnlyMemory<float>? vectorNullable = null, ReadOnlyMemory<float>? vectorReadOnlyNullable = null, ReadOnlyMemory<float>? vectorReadOnlyRequiredNullable = null, ReadOnlyMemory<float>? vectorRequiredNullable = null)
        {
            requiredStringList ??= new List<string>();
            requiredIntList ??= new List<int>();
            nonRequiredStringList ??= new List<string>();
            nonRequiredIntList ??= new List<int>();
            requiredNullableStringList ??= new List<string>();
            requiredNullableIntList ??= new List<int>();
            nonRequiredNullableStringList ??= new List<string>();
            nonRequiredNullableIntList ??= new List<int>();

            return new MixedModel(requiredString, requiredInt, requiredStringList?.ToList(), requiredIntList?.ToList(), nonRequiredString, nonRequiredInt, nonRequiredStringList?.ToList(), nonRequiredIntList?.ToList(), requiredNullableString, requiredNullableInt, requiredNullableStringList?.ToList(), requiredNullableIntList?.ToList(), nonRequiredNullableString, nonRequiredNullableInt, nonRequiredNullableStringList?.ToList(), nonRequiredNullableIntList?.ToList(), requiredReadonlyInt, nonRequiredReadonlyInt, vector, vectorReadOnly, vectorReadOnlyRequired, vectorRequired, vectorNullable, vectorReadOnlyNullable, vectorReadOnlyRequiredNullable, vectorRequiredNullable, new Dictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.OutputModel"/>. </summary>
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
        /// <param name="vector"> The vector representation of a search query. </param>
        /// <param name="vectorReadOnly"> The vector representation of a search query. </param>
        /// <param name="vectorReadOnlyRequired"> The vector representation of a search query. </param>
        /// <param name="vectorRequired"> The vector representation of a search query. </param>
        /// <param name="vectorNullable"> The vector representation of a search query. </param>
        /// <param name="vectorReadOnlyNullable"> The vector representation of a search query. </param>
        /// <param name="vectorReadOnlyRequiredNullable"> The vector representation of a search query. </param>
        /// <param name="vectorRequiredNullable"> The vector representation of a search query. </param>
        /// <returns> A new <see cref="Models.OutputModel"/> instance for mocking. </returns>
        public static OutputModel OutputModel(string requiredString = null, int requiredInt = default, IEnumerable<string> requiredStringList = null, IEnumerable<int> requiredIntList = null, string nonRequiredString = null, int? nonRequiredInt = null, IEnumerable<string> nonRequiredStringList = null, IEnumerable<int> nonRequiredIntList = null, string requiredNullableString = null, int? requiredNullableInt = null, IEnumerable<string> requiredNullableStringList = null, IEnumerable<int> requiredNullableIntList = null, string nonRequiredNullableString = null, int? nonRequiredNullableInt = null, IEnumerable<string> nonRequiredNullableStringList = null, IEnumerable<int> nonRequiredNullableIntList = null, int requiredReadonlyInt = default, int? nonRequiredReadonlyInt = null, ReadOnlyMemory<float> vector = default, ReadOnlyMemory<float> vectorReadOnly = default, ReadOnlyMemory<float> vectorReadOnlyRequired = default, ReadOnlyMemory<float> vectorRequired = default, ReadOnlyMemory<float>? vectorNullable = null, ReadOnlyMemory<float>? vectorReadOnlyNullable = null, ReadOnlyMemory<float>? vectorReadOnlyRequiredNullable = null, ReadOnlyMemory<float>? vectorRequiredNullable = null)
        {
            requiredStringList ??= new List<string>();
            requiredIntList ??= new List<int>();
            nonRequiredStringList ??= new List<string>();
            nonRequiredIntList ??= new List<int>();
            requiredNullableStringList ??= new List<string>();
            requiredNullableIntList ??= new List<int>();
            nonRequiredNullableStringList ??= new List<string>();
            nonRequiredNullableIntList ??= new List<int>();

            return new OutputModel(requiredString, requiredInt, requiredStringList?.ToList(), requiredIntList?.ToList(), nonRequiredString, nonRequiredInt, nonRequiredStringList?.ToList(), nonRequiredIntList?.ToList(), requiredNullableString, requiredNullableInt, requiredNullableStringList?.ToList(), requiredNullableIntList?.ToList(), nonRequiredNullableString, nonRequiredNullableInt, nonRequiredNullableStringList?.ToList(), nonRequiredNullableIntList?.ToList(), requiredReadonlyInt, nonRequiredReadonlyInt, vector, vectorReadOnly, vectorReadOnlyRequired, vectorRequired, vectorNullable, vectorReadOnlyNullable, vectorReadOnlyRequiredNullable, vectorRequiredNullable, new Dictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.MixedModelWithReadonlyProperty"/>. </summary>
        /// <param name="readonlyProperty"></param>
        /// <param name="readonlyListProperty"></param>
        /// <returns> A new <see cref="Models.MixedModelWithReadonlyProperty"/> instance for mocking. </returns>
        public static MixedModelWithReadonlyProperty MixedModelWithReadonlyProperty(ReadonlyModel readonlyProperty = null, IEnumerable<ReadonlyModel> readonlyListProperty = null)
        {
            readonlyListProperty ??= new List<ReadonlyModel>();

            return new MixedModelWithReadonlyProperty(readonlyProperty, readonlyListProperty?.ToList(), new Dictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.ReadonlyModel"/>. </summary>
        /// <param name="name"></param>
        /// <returns> A new <see cref="Models.ReadonlyModel"/> instance for mocking. </returns>
        public static ReadonlyModel ReadonlyModel(string name = null)
        {
            return new ReadonlyModel(name, new Dictionary<string, BinaryData>());
        }
    }
}
