// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal abstract class OutputLibrary
    {
        private readonly CodeModel _codeModel;
        private readonly BuildContext _context;

        protected OutputLibrary(CodeModel codeModel, BuildContext context)
        {
            _codeModel = codeModel;
            _context = context;
        }

        public abstract CSharpType FindTypeForSchema(Schema schema);
        public abstract CSharpType? FindTypeByName(string name);
    }
}
