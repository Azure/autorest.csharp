// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary>
    /// The MyBaseType.
    /// Please note <see cref="MyBaseType"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="MyDerivedType"/>.
    /// </summary>
    public abstract partial class MyBaseType
    {
        /// <summary> Initializes a new instance of MyBaseType. </summary>
        protected MyBaseType()
        {
        }

        /// <summary> Initializes a new instance of MyBaseType. </summary>
        /// <param name="kind"></param>
        /// <param name="propB1"></param>
        /// <param name="propBH1"></param>
        internal MyBaseType(MyKind kind, string propB1, string propBH1)
        {
            Kind = kind;
            PropB1 = propB1;
            PropBH1 = propBH1;
        }

        /// <summary> Gets or sets the kind. </summary>
        internal MyKind Kind { get; set; }
        /// <summary> Gets the prop b 1. </summary>
        public string PropB1 { get; }
        /// <summary> Gets the prop bh 1. </summary>
        public string PropBH1 { get; }
    }
}
