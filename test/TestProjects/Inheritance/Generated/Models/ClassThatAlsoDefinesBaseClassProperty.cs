// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Inheritance.Models
{
    /// <summary> The ClassThatAlsoDefinesBaseClassProperty. </summary>
    internal partial class ClassThatAlsoDefinesBaseClassProperty
    {
        /// <summary> Initializes a new instance of ClassThatAlsoDefinesBaseClassProperty. </summary>
        internal ClassThatAlsoDefinesBaseClassProperty()
        {
        }

        /// <summary> Gets the base class property. </summary>
        public string BaseClassProperty { get; }
    }
}
