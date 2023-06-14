// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace body_complex.Models
{
    /// <summary> The DotFishMarket. </summary>
    public partial class DotFishMarket
    {
        /// <summary> Initializes a new instance of DotFishMarket. </summary>
        internal DotFishMarket()
        {
            Salmons = new ChangeTrackingList<DotSalmon>();
            Fishes = new ChangeTrackingList<DotFish>();
        }

        /// <summary> Initializes a new instance of DotFishMarket. </summary>
        /// <param name="sampleSalmon"></param>
        /// <param name="salmons"></param>
        /// <param name="sampleFish">
        /// Please note <see cref="DotFish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="DotSalmon"/>.
        /// </param>
        /// <param name="fishes">
        /// Please note <see cref="DotFish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="DotSalmon"/>.
        /// </param>
        internal DotFishMarket(DotSalmon sampleSalmon, IReadOnlyList<DotSalmon> salmons, DotFish sampleFish, IReadOnlyList<DotFish> fishes)
        {
            SampleSalmon = sampleSalmon;
            Salmons = salmons;
            SampleFish = sampleFish;
            Fishes = fishes;
        }

        /// <summary> Gets the sample salmon. </summary>
        public DotSalmon SampleSalmon { get; }
        /// <summary> Gets the salmons. </summary>
        public IReadOnlyList<DotSalmon> Salmons { get; }
        /// <summary>
        /// Gets the sample fish
        /// Please note <see cref="DotFish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="DotSalmon"/>.
        /// </summary>
        public DotFish SampleFish { get; }
        /// <summary>
        /// Gets the fishes
        /// Please note <see cref="DotFish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="DotSalmon"/>.
        /// </summary>
        public IReadOnlyList<DotFish> Fishes { get; }
    }
}
