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
            ModelTypeMapping[] definedSchemaTypes,
            ClientTypeMapping[] definedClientTypes)
        {
            DefinedSchemaTypes = definedSchemaTypes;
            DefinedClientTypes = definedClientTypes;
        }

        public ModelTypeMapping[] DefinedSchemaTypes { get; }
        public ClientTypeMapping[] DefinedClientTypes { get; }

        public ModelTypeMapping? FindForSchema(string name)
        {
            return DefinedSchemaTypes.SingleOrDefault(s => string.Compare(s.SchemaName, name, StringComparison.InvariantCultureIgnoreCase) == 0);
        }

        public ClientTypeMapping? FindForOperationGroup(string name)
        {
            return DefinedClientTypes.SingleOrDefault(s => string.Compare(s.OperationGroupName, name, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
    }
}
