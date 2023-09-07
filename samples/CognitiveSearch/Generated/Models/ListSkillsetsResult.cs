// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a list Skillset request. If successful, it includes the full definitions of all skillsets. </summary>
    public partial class ListSkillsetsResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ListSkillsetsResult"/>. </summary>
        /// <param name="skillsets"> The skillsets defined in the Search service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="skillsets"/> is null. </exception>
        internal ListSkillsetsResult(IEnumerable<Skillset> skillsets)
        {
            Argument.AssertNotNull(skillsets, nameof(skillsets));

            Skillsets = skillsets.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="ListSkillsetsResult"/>. </summary>
        /// <param name="skillsets"> The skillsets defined in the Search service. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ListSkillsetsResult(IReadOnlyList<Skillset> skillsets, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Skillsets = skillsets;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ListSkillsetsResult"/> for deserialization. </summary>
        internal ListSkillsetsResult()
        {
        }

        /// <summary> The skillsets defined in the Search service. </summary>
        public IReadOnlyList<Skillset> Skillsets { get; }
    }
}
