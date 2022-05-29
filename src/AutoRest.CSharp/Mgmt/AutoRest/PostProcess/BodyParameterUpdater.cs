// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Rename;
using static Microsoft.CodeAnalysis.Rename.Renamer;

namespace AutoRest.CSharp.Mgmt.AutoRest.PostProcess
{
    internal static class BodyParameterUpdater
    {
        public static async Task<Project> Update(Project project)
        {
            var compilation = await project.GetCompilationAsync();
            if (compilation == null)
                return project;
            // TODO: prepare the symbols
            // TODO: count the usages of the parameters
            // TODO: rename the parameters that needed to be renamed
            return project;
        }

        private static async Task<Project> RenameSymbol(Project project, ISymbol symbolToRename, string newName)
        {
            var solution = project.Solution;
            var projectId = project.Id;
            // rename the containing document's name, which will automatically rename the containing symbol that matches the name of the document
            var actions = new List<RenameDocumentActionSet>();
            foreach (var definition in symbolToRename.DeclaringSyntaxReferences)
            {
                var document = project.GetDocument(definition.SyntaxTree);
                Debug.Assert(document != null);
                // TODO -- need to see if the replace could cause some unexpected result
                var newDocumentName = document.Name.ReplaceLast(symbolToRename.Name, newName);
                actions.Add(await Renamer.RenameDocumentAsync(document, newDocumentName));
            }

            // apply the changes
            foreach (var action in actions)
            {
                solution = await action.UpdateSolutionAsync(solution, default);
            }

            return solution.GetProject(projectId)!;
        }
    }
}
