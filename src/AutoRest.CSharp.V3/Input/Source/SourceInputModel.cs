// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoRest.CSharp.V3.Input.Source
{
    public class SourceInputModel
    {
        public SourceInputModel(
            SourceTypeMapping[] definedSchemaTypes)
        {
            DefinedSchemaTypes = definedSchemaTypes;
        }

        public SourceTypeMapping[] DefinedSchemaTypes { get; }

        public SourceTypeMapping? FindForSchema(string name) => FindByName(DefinedSchemaTypes, name);

        private static SourceTypeMapping FindByName(IEnumerable<SourceTypeMapping> sourceTypes, string name)
        {
            return sourceTypes.SingleOrDefault(s => string.Compare(s.SchemaName, name, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
    }
}
