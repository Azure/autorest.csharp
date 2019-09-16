// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System.Collections.Generic;
using System.Linq;
using AutoRest.Core.Utilities;
using Newtonsoft.Json;

namespace AutoRest.Core.Model
{
    /// <summary>
    ///     A type that could fall into multiple categories of specific types (i.e. "type" was not specified in Swagger).
    ///     As of now, we expect languages to choose their typical "catch 'em all" type.
    /// </summary>
    public class MultiType : ModelType
    {
        public MultiType()
        {
        }

        [JsonIgnore]
        public override string Qualifier => "MultiType";

        public override void Disambiguate()
        {
            // not needed, right?
        }
    }
}