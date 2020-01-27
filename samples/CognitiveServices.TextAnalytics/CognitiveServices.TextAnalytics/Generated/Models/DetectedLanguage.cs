// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class DetectedLanguage
    {
        /// <summary> Long name of a detected language (e.g. English, French). </summary>
        public string Name { get; set; }
        /// <summary> A two letter representation of the detected language according to the ISO 639-1 standard (e.g. en, fr). </summary>
        public string Iso6391Name { get; set; }
        /// <summary> A confidence score between 0 and 1. Scores close to 1 indicate 100% certainty that the identified language is true. </summary>
        public double Score { get; set; }
    }
}
