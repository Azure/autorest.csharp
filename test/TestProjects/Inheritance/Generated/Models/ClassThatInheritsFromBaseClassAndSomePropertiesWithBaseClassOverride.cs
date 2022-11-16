// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core.Expressions.DataFactory;

namespace Inheritance.Models
{
    /// <summary> The ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride. </summary>
    internal partial class ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride : SomeProperties
    {
        /// <summary> Initializes a new instance of ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride. </summary>
        public ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride()
        {
        }

        /// <summary> Initializes a new instance of ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride. </summary>
        /// <param name="someProperty"></param>
        /// <param name="someOtherProperty"></param>
        /// <param name="baseClassProperty"></param>
        /// <param name="dfeString"> Any object. </param>
        /// <param name="dfeDouble"> Any object. </param>
        /// <param name="dfeBool"> Any object. </param>
        /// <param name="dfeInt"> Any object. </param>
        /// <param name="dfeArray"> Any object. </param>
        internal ClassThatInheritsFromBaseClassAndSomePropertiesWithBaseClassOverride(string someProperty, string someOtherProperty, string baseClassProperty, DataFactoryExpression<string> dfeString, DataFactoryExpression<double> dfeDouble, DataFactoryExpression<bool> dfeBool, DataFactoryExpression<int> dfeInt, DataFactoryExpression<Array> dfeArray) : base(someProperty, someOtherProperty)
        {
            BaseClassProperty = baseClassProperty;
            DfeString = dfeString;
            DfeDouble = dfeDouble;
            DfeBool = dfeBool;
            DfeInt = dfeInt;
            DfeArray = dfeArray;
        }

        /// <summary> Gets or sets the base class property. </summary>
        public string BaseClassProperty { get; set; }
        /// <summary> Any object. </summary>
        public DataFactoryExpression<string> DfeString { get; set; }
        /// <summary> Any object. </summary>
        public DataFactoryExpression<double> DfeDouble { get; set; }
        /// <summary> Any object. </summary>
        public DataFactoryExpression<bool> DfeBool { get; set; }
        /// <summary> Any object. </summary>
        public DataFactoryExpression<int> DfeInt { get; set; }
        /// <summary> Any object. </summary>
        public DataFactoryExpression<Array> DfeArray { get; set; }
    }
}
