// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace SupersetInheritance
{
    /// <summary> A class representing the SupersetModel2 data model. </summary>
    public partial class SupersetModel2Data
    {
        /// <summary> Initializes a new instance of SupersetModel2Data. </summary>
        internal SupersetModel2Data()
        {
        }

        /// <summary> Initializes a new instance of SupersetModel2Data. </summary>
        /// <param name="iD"> . </param>
        /// <param name="name"> . </param>
        /// <param name="type"> . </param>
        /// <param name="new"> . </param>
        internal SupersetModel2Data(string iD, string name, string type, string @new)
        {
            ID = iD;
            Name = name;
            Type = type;
            New = @new;
        }

        public string ID { get; }
        public string Name { get; }
        public string Type { get; }
        public string New { get; }
    }
}
