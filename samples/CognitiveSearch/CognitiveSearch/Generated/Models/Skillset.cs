// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> A list of skills. </summary>
    public partial class Skillset
    {
        /// <summary> Initializes a new instance of Skillset. </summary>
        /// <param name="name"> The name of the skillset. </param>
        /// <param name="description"> The description of the skillset. </param>
        /// <param name="skills"> A list of skills in the skillset. </param>
        public Skillset(string name, string description, IList<Skill> skills)
        {
            Name = name;
            Description = description;
            Skills = skills;
        }

        /// <summary> Initializes a new instance of Skillset. </summary>
        /// <param name="name"> The name of the skillset. </param>
        /// <param name="description"> The description of the skillset. </param>
        /// <param name="skills"> A list of skills in the skillset. </param>
        /// <param name="cognitiveServicesAccount"> Details about cognitive services to be used when running skills. </param>
        /// <param name="eTag"> The ETag of the skillset. </param>
        internal Skillset(string name, string description, IList<Skill> skills, CognitiveServicesAccount cognitiveServicesAccount, string eTag)
        {
            Name = name;
            Description = description;
            Skills = skills;
            CognitiveServicesAccount = cognitiveServicesAccount;
            ETag = eTag;
        }

        /// <summary> The name of the skillset. </summary>
        public string Name { get; }
        /// <summary> The description of the skillset. </summary>
        public string Description { get; }
        /// <summary> A list of skills in the skillset. </summary>
        public IList<Skill> Skills { get; } = new List<Skill>();
        /// <summary> Details about cognitive services to be used when running skills. </summary>
        public CognitiveServicesAccount CognitiveServicesAccount { get; set; }
        /// <summary> The ETag of the skillset. </summary>
        public string ETag { get; set; }
    }
}
