// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;

namespace Inheritance.Models
{
    /// <summary> The ClassThatInheritsFromBaseClassAndSomeProperties. </summary>
    public partial class ClassThatInheritsFromBaseClassAndSomeProperties : BaseClass
    {
        /// <summary> Initializes a new instance of ClassThatInheritsFromBaseClassAndSomeProperties. </summary>
        public ClassThatInheritsFromBaseClassAndSomeProperties()
        {
        }

        /// <summary> Initializes a new instance of ClassThatInheritsFromBaseClassAndSomeProperties. </summary>
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
        /// <param name="someProperty"></param>
        /// <param name="someOtherProperty"></param>
        internal ClassThatInheritsFromBaseClassAndSomeProperties(string baseClassProperty, DataFactoryElement<string> dfeString, DataFactoryElement<double> dfeDouble, DataFactoryElement<bool> dfeBool, DataFactoryElement<int> dfeInt, DataFactoryElement<BinaryData> dfeObject, DataFactoryElement<IList<SeparateClass>> dfeListOfT, DataFactoryElement<IList<string>> dfeListOfString, DataFactoryElement<IDictionary<string, string>> dfeKeyValuePairs, DataFactoryElement<DateTimeOffset> dfeDateTime, DataFactoryElement<TimeSpan> dfeDuration, DataFactoryElement<Uri> dfeUri, string someProperty, string someOtherProperty) : base(baseClassProperty, dfeString, dfeDouble, dfeBool, dfeInt, dfeObject, dfeListOfT, dfeListOfString, dfeKeyValuePairs, dfeDateTime, dfeDuration, dfeUri)
        {
            SomeProperty = someProperty;
            SomeOtherProperty = someOtherProperty;
        }

        /// <summary> Gets or sets the some property. </summary>
        public string SomeProperty { get; set; }
        /// <summary> Gets or sets the some other property. </summary>
        public string SomeOtherProperty { get; set; }
    }
}
