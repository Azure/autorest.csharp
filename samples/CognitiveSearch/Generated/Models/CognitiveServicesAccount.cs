// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary>
    /// Base type for describing any cognitive service resource attached to a skillset.
    /// Please note <see cref="CognitiveServicesAccount"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="CognitiveServicesAccountKey"/> and <see cref="DefaultCognitiveServicesAccount"/>.
    /// </summary>
    public partial class CognitiveServicesAccount
    {
        /// <summary> Initializes a new instance of CognitiveServicesAccount. </summary>
        public CognitiveServicesAccount()
        {
        }

        /// <summary> Initializes a new instance of CognitiveServicesAccount. </summary>
        /// <param name="odataType"> Identifies the concrete type of the cognitive service resource attached to a skillset. </param>
        /// <param name="description"> Description of the cognitive service resource attached to a skillset. </param>
        internal CognitiveServicesAccount(string odataType, string description)
        {
            OdataType = odataType;
            Description = description;
        }

        /// <summary> Identifies the concrete type of the cognitive service resource attached to a skillset. </summary>
        internal string OdataType { get; set; }
        /// <summary> Description of the cognitive service resource attached to a skillset. </summary>
        public string Description { get; set; }
    }
}
