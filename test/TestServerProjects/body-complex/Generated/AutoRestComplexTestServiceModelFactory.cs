// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Linq;
using body_complex.Models;

namespace body_complex
{
    /// <summary> Model factory for read-only models. </summary>
    public static partial class AutoRestComplexTestServiceModelFactory
    {
        /// <summary> Initializes new instance of DotFish class. </summary>
        /// <param name="fishType"> . </param>
        /// <param name="species"> . </param>
        /// <returns> A new <see cref="Models.DotFish"/> instance for mocking. </returns>
        public static DotFish DotFish(string fishType = default, string species = default)
        {
            return new DotFish(fishType, species);
        }

        /// <summary> Initializes new instance of DotFishMarket class. </summary>
        /// <param name="sampleSalmon"> . </param>
        /// <param name="salmons"> . </param>
        /// <param name="sampleFish"> . </param>
        /// <param name="fishes"> . </param>
        /// <returns> A new <see cref="Models.DotFishMarket"/> instance for mocking. </returns>
        public static DotFishMarket DotFishMarket(DotSalmon sampleSalmon = default, IEnumerable<DotSalmon> salmons = default, DotFish sampleFish = default, IEnumerable<DotFish> fishes = default)
        {
            var salmonsList = salmons?.ToList() ?? new List<DotSalmon>();
            var fishesList = fishes?.ToList() ?? new List<DotFish>();
            return new DotFishMarket(sampleSalmon, salmonsList, sampleFish, fishesList);
        }

        /// <summary> Initializes new instance of DotSalmon class. </summary>
        /// <param name="fishType"> . </param>
        /// <param name="species"> . </param>
        /// <param name="location"> . </param>
        /// <param name="iswild"> . </param>
        /// <returns> A new <see cref="Models.DotSalmon"/> instance for mocking. </returns>
        public static DotSalmon DotSalmon(string fishType = default, string species = default, string location = default, bool? iswild = default)
        {
            return new DotSalmon(fishType, species, location, iswild);
        }

        /// <summary> Initializes new instance of ReadonlyObj class. </summary>
        /// <param name="id"> . </param>
        /// <param name="size"> . </param>
        /// <returns> A new <see cref="Models.ReadonlyObj"/> instance for mocking. </returns>
        public static ReadonlyObj ReadonlyObj(string id = default, int? size = default)
        {
            return new ReadonlyObj(id, size);
        }

        /// <summary> Initializes new instance of MyBaseType class. </summary>
        /// <param name="kind"> . </param>
        /// <param name="propB1"> . </param>
        /// <param name="propBH1"> . </param>
        /// <returns> A new <see cref="Models.MyBaseType"/> instance for mocking. </returns>
        public static MyBaseType MyBaseType(MyKind kind = default, string propB1 = default, string propBH1 = default)
        {
            return new MyBaseType(kind, propB1, propBH1);
        }

        /// <summary> Initializes new instance of MyDerivedType class. </summary>
        /// <param name="kind"> . </param>
        /// <param name="propB1"> . </param>
        /// <param name="propBH1"> . </param>
        /// <param name="propD1"> . </param>
        /// <returns> A new <see cref="Models.MyDerivedType"/> instance for mocking. </returns>
        public static MyDerivedType MyDerivedType(MyKind kind = default, string propB1 = default, string propBH1 = default, string propD1 = default)
        {
            return new MyDerivedType(kind, propB1, propBH1, propD1);
        }
    }
}
