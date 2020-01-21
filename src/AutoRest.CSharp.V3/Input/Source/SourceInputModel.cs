// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.Input.Source
{
    public class SourceInputModel
    {
        public SourceInputModel(SourceSchemaType[] definedSchemaTypes)
        {
            DefinedSchemaTypes = definedSchemaTypes;
        }

        public SourceSchemaType[] DefinedSchemaTypes { get; }
    }
}
