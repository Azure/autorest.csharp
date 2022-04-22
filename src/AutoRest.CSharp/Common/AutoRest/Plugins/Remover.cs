// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Common.AutoRest.Plugins
{
    internal static class Remover
    {
        public static async Task<Project> RemoveUnusedAsync(Project project)
        {
            // find all the declarations, including non-public declared
            var definitions = await Internalizer.GetModels(project, false);
            // build reference map
            var referenceMap = BuildReferenceMap(project);
            // traverse the map to determine the declarations that we are about to remove
            // TODO
            // remove those declarations one by one
            // TODO

            return project;
        }

        private static ReferenceMap BuildReferenceMap(Project project)
        {
            return new ReferenceMap();
        }

        private class ReferenceMap
        {
            // TODO -- design a data structure for this
        }
    }
}
