// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Inheritance.Models
{
    /// <summary> The ClassThatInheritsFromSomePropertiesAndBaseClassAndRedefinesAProperty. </summary>
    public partial class ClassThatInheritsFromSomePropertiesAndBaseClassAndRedefinesAProperty : ClassThatInheritsFromSomePropertiesAndBaseClass
    {
        /// <summary> Initializes a new instance of ClassThatInheritsFromSomePropertiesAndBaseClassAndRedefinesAProperty. </summary>
        public ClassThatInheritsFromSomePropertiesAndBaseClassAndRedefinesAProperty()
        {
        }

        /// <summary> Initializes a new instance of ClassThatInheritsFromSomePropertiesAndBaseClassAndRedefinesAProperty. </summary>
        /// <param name="someProperty"></param>
        /// <param name="someOtherProperty"></param>
        /// <param name="baseClassProperty"></param>
        internal ClassThatInheritsFromSomePropertiesAndBaseClassAndRedefinesAProperty(string someProperty, string someOtherProperty, string baseClassProperty) : base(someProperty, someOtherProperty, baseClassProperty)
        {
        }
    }
}
