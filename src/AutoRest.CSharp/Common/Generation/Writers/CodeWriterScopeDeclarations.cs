// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class CodeWriterScopeDeclarations
    {
        public IReadOnlyList<string> Names { get; }

        public CodeWriterScopeDeclarations(IEnumerable<CodeWriterDeclaration> declarations)
        {
            var names = new List<string>();
            var existingNames = new HashSet<string>();
            foreach (var declaration in declarations)
            {
                declaration.SetActualName(GetUniqueName(declaration.RequestedName, existingNames));
                names.Add(declaration.ActualName);
                existingNames.Add(declaration.ActualName);
            }

            Names = names;
        }

        // for the declarations in the same level of scope, we should ensure the names are unique
        private static string GetUniqueName(string requestedName, IReadOnlyCollection<string> existingNames)
        {
            if (!existingNames.Contains(requestedName))
            {
                return requestedName;
            }

            for (int i = 0; i < 100; i++)
            {
                var name = requestedName + i;
                if (!existingNames.Contains(name))
                {
                    return name;
                }
            }
            throw new InvalidOperationException("Can't find suitable variable name.");
        }
    }
}
