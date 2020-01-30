// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Output.Builders
{
    internal class ModelBuilder
    {
        private readonly BuildContext _context;
        public ModelBuilder(BuildContext context)
        {
            _context = context;
        }

        public ISchemaType BuildModel(Schema schema) => schema switch
        {
            SealedChoiceSchema sealedChoiceSchema => new EnumType(sealedChoiceSchema, _context),
            ChoiceSchema choiceSchema => new EnumType(choiceSchema, _context),
            ObjectSchema objectSchema => new ObjectType(objectSchema, _context),
            _ => throw new NotImplementedException()
        };
    }
}
