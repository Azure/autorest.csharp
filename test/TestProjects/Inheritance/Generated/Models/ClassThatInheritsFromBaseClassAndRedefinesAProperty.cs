// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;

namespace Inheritance.Models
{
    /// <summary> The ClassThatInheritsFromBaseClassAndRedefinesAProperty. </summary>
    public partial class ClassThatInheritsFromBaseClassAndRedefinesAProperty : BaseClass
    {
        /// <summary> Initializes a new instance of ClassThatInheritsFromBaseClassAndRedefinesAProperty. </summary>
        public ClassThatInheritsFromBaseClassAndRedefinesAProperty()
        {
        }

        /// <summary> Initializes a new instance of ClassThatInheritsFromBaseClassAndRedefinesAProperty. </summary>
        /// <param name="baseClassProperty"></param>
        /// <param name="dfeString"> Any object. </param>
        /// <param name="dfeDouble"> Any object. </param>
        /// <param name="dfeBool"> Any object. </param>
        /// <param name="dfeInt"> Any object. </param>
        /// <param name="dfeObject"> Any object. </param>
        /// <param name="dfeListOfObject"> Any object. </param>
        /// <param name="dfeListOfT"> Any object. </param>
        /// <param name="dfeListOfString"> Any object. </param>
        /// <param name="dfeKeyValuePairs"> Any object. </param>
        internal ClassThatInheritsFromBaseClassAndRedefinesAProperty(string baseClassProperty, DataFactoryExpression<string> dfeString, DataFactoryExpression<double> dfeDouble, DataFactoryExpression<bool> dfeBool, DataFactoryExpression<int> dfeInt, DataFactoryExpression<BinaryData> dfeObject, DataFactoryExpression<IList<BinaryData>> dfeListOfObject, DataFactoryExpression<IList<SeparateClass>> dfeListOfT, DataFactoryExpression<IList<string>> dfeListOfString, DataFactoryExpression<IDictionary<string, string>> dfeKeyValuePairs) : base(baseClassProperty, dfeString, dfeDouble, dfeBool, dfeInt, dfeObject, dfeListOfObject, dfeListOfT, dfeListOfString, dfeKeyValuePairs)
        {
        }
    }
}
