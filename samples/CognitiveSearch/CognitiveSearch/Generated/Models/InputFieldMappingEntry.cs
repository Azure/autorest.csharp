// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Input field mapping for a skill. </summary>
    public partial class InputFieldMappingEntry
    {
        /// <summary> The name of the input. </summary>
        public string Name { get; set; }
        /// <summary> The source of the input. </summary>
        public string Source { get; set; }
        /// <summary> The source context used for selecting recursive inputs. </summary>
        public string SourceContext { get; set; }
        /// <summary> The recursive inputs used when creating a complex type. </summary>
        public ICollection<InputFieldMappingEntry> Inputs { get; set; }
    }
}
