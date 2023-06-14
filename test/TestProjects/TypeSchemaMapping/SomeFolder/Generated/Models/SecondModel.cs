// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using NamespaceForEnums;

namespace TypeSchemaMapping.Models
{
    /// <summary> The SecondModel. </summary>
    internal partial class SecondModel
    {
        /// <summary> Initializes a new instance of SecondModel. </summary>
        public SecondModel()
        {
            DictionaryProperty = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of SecondModel. </summary>
        /// <param name="intProperty"> . </param>
        /// <param name="dictionaryProperty"> . </param>
        /// <param name="daysOfWeek"> Day of week. </param>
        internal SecondModel(int intProperty, IReadOnlyDictionary<string, string> dictionaryProperty, CustomDaysOfWeek? daysOfWeek)
        {
            IntProperty = intProperty;
            DictionaryProperty = dictionaryProperty;
            DaysOfWeek = daysOfWeek;
        }
    }
}
