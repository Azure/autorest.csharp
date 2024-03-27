// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Input field mapping for a skill. </summary>
    public partial class InputFieldMappingEntry
    {
        /// <summary> Initializes a new instance of <see cref="InputFieldMappingEntry"/>. </summary>
        /// <param name="name"> The name of the input. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public InputFieldMappingEntry(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            Inputs = new ChangeTrackingList<InputFieldMappingEntry>();
        }

        /// <summary> Initializes a new instance of <see cref="InputFieldMappingEntry"/>. </summary>
        /// <param name="name"> The name of the input. </param>
        /// <param name="source"> The source of the input. </param>
        /// <param name="sourceContext"> The source context used for selecting recursive inputs. </param>
        /// <param name="inputs"> The recursive inputs used when creating a complex type. </param>
        internal InputFieldMappingEntry(string name, string source, string sourceContext, IList<InputFieldMappingEntry> inputs)
        {
            Name = name;
            Source = source;
            SourceContext = sourceContext;
            Inputs = inputs;
        }

        /// <summary> The name of the input. </summary>
        public string Name { get; set; }
        /// <summary> The source of the input. </summary>
        public string Source { get; set; }
        /// <summary> The source context used for selecting recursive inputs. </summary>
        public string SourceContext { get; set; }
        /// <summary> The recursive inputs used when creating a complex type. </summary>
        public IList<InputFieldMappingEntry> Inputs { get; }
    }
}
