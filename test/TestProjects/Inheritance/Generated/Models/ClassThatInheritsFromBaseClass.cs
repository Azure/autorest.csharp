// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;

namespace Inheritance.Models
{
    /// <summary> The ClassThatInheritsFromBaseClass. </summary>
    public partial class ClassThatInheritsFromBaseClass : BaseClass
    {
        /// <summary> Initializes a new instance of ClassThatInheritsFromBaseClass. </summary>
        public ClassThatInheritsFromBaseClass()
        {
        }

        /// <summary> Initializes a new instance of ClassThatInheritsFromBaseClass. </summary>
        /// <param name="baseClassProperty"></param>
        /// <param name="dfeString"> Any object. </param>
        /// <param name="dfeDouble"> Any object. </param>
        /// <param name="dfeBool"> Any object. </param>
        /// <param name="dfeInt"> Any object. </param>
        /// <param name="dfeObject"> Any object. </param>
        /// <param name="dfeListOfT"> Any object. </param>
        /// <param name="dfeListOfString"> Any object. </param>
        /// <param name="dfeKeyValuePairs"> Any object. </param>
        /// <param name="dfeDateTime"> Any object. </param>
        /// <param name="dfeDuration"> Any object. </param>
        /// <param name="dfeUri"> Any object. </param>
        internal ClassThatInheritsFromBaseClass(string baseClassProperty, DataFactoryElement<string> dfeString, DataFactoryElement<double> dfeDouble, DataFactoryElement<bool> dfeBool, DataFactoryElement<int> dfeInt, DataFactoryElement<BinaryData> dfeObject, DataFactoryElement<IList<SeparateClass>> dfeListOfT, DataFactoryElement<IList<string>> dfeListOfString, DataFactoryElement<IDictionary<string, string>> dfeKeyValuePairs, DataFactoryElement<DateTimeOffset> dfeDateTime, DataFactoryElement<TimeSpan> dfeDuration, DataFactoryElement<Uri> dfeUri) : base(baseClassProperty, dfeString, dfeDouble, dfeBool, dfeInt, dfeObject, dfeListOfT, dfeListOfString, dfeKeyValuePairs, dfeDateTime, dfeDuration, dfeUri)
        {
        }
    }
}
