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
        /// <summary> Initializes a new instance of DotFish. </summary>
        /// <param name="fishType"> . </param>
        /// <param name="species"> . </param>
        /// <returns> A new <see cref="Models.DotFish"/> instance for mocking. </returns>
        public static DotFish DotFish(string fishType = null, string species = null)
        {
            return new DotFish(fishType, species);
        }

        /// <summary> Initializes a new instance of DotFishMarket. </summary>
        /// <param name="sampleSalmon"> . </param>
        /// <param name="salmons"> . </param>
        /// <param name="sampleFish"> . </param>
        /// <param name="fishes"> . </param>
        /// <returns> A new <see cref="Models.DotFishMarket"/> instance for mocking. </returns>
        public static DotFishMarket DotFishMarket(DotSalmon sampleSalmon = null, IEnumerable<DotSalmon> salmons = null, DotFish sampleFish = null, IEnumerable<DotFish> fishes = null)
        {
            salmons ??= new List<DotSalmon>();
            fishes ??= new List<DotFish>();

            return new DotFishMarket(sampleSalmon, salmons?.ToList(), sampleFish, fishes?.ToList());
        }

        /// <summary> Initializes a new instance of DotSalmon. </summary>
        /// <param name="fishType"> . </param>
        /// <param name="species"> . </param>
        /// <param name="location"> . </param>
        /// <param name="iswild"> . </param>
        /// <returns> A new <see cref="Models.DotSalmon"/> instance for mocking. </returns>
        public static DotSalmon DotSalmon(string fishType = null, string species = null, string location = null, bool? iswild = null)
        {
            return new DotSalmon(fishType, species, location, iswild);
        }

        /// <summary> Initializes a new instance of ReadonlyObj. </summary>
        /// <param name="id"> . </param>
        /// <param name="size"> . </param>
        /// <returns> A new <see cref="Models.ReadonlyObj"/> instance for mocking. </returns>
        public static ReadonlyObj ReadonlyObj(string id = null, int? size = null)
        {
            return new ReadonlyObj(id, size);
        }

        /// <summary> Initializes a new instance of MyBaseType. </summary>
        /// <param name="kind"> . </param>
        /// <param name="propB1"> . </param>
        /// <param name="propBH1"> . </param>
        /// <returns> A new <see cref="Models.MyBaseType"/> instance for mocking. </returns>
        public static MyBaseType MyBaseType(MyKind kind = default, string propB1 = null, string propBH1 = null)
        {
            return new MyBaseType(kind, propB1, propBH1);
        }

        /// <summary> Initializes a new instance of MyDerivedType. </summary>
        /// <param name="kind"> . </param>
        /// <param name="propB1"> . </param>
        /// <param name="propBH1"> . </param>
        /// <param name="propD1"> . </param>
        /// <returns> A new <see cref="Models.MyDerivedType"/> instance for mocking. </returns>
        public static MyDerivedType MyDerivedType(MyKind kind = default, string propB1 = null, string propBH1 = null, string propD1 = null)
        {
            return new MyDerivedType(kind, propB1, propBH1, propD1);
        }
    }
}
