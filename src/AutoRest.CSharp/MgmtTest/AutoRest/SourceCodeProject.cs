﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.MgmtTest.AutoRest
{
    internal class SourceCodeProject
    {
        private static readonly string[] SharedFolders = { GeneratedCodeWorkspace.SharedFolder };
        private Project _sourceCodeProject;
        public SourceCodeProject(string sourceCodePath, string[] sharedSourceFolders)
        {
            if (Uri.IsWellFormedUriString(sourceCodePath, UriKind.RelativeOrAbsolute))
            {
                Uri uri = new Uri(sourceCodePath);
                sourceCodePath = uri.LocalPath;
            }
            else
            {
                sourceCodePath = Path.GetFullPath(sourceCodePath);
            }

            _sourceCodeProject = CreateSourceCodeProject(sourceCodePath, sharedSourceFolders);
        }

        public async Task<Compilation> GetCompilationAsync()
        {
            var compilation = await _sourceCodeProject.GetCompilationAsync() as CSharpCompilation;
            Debug.Assert(compilation != null);
            return compilation;
        }

        private static Project CreateSourceCodeProject(string sourceCodePath, string[] sharedSourceFolders)
        {
            var sourceCodeProject = CreateGeneratedCodeProject();
            var sourceCodeGeneratedDirectory = Path.Join(sourceCodePath, GeneratedCodeWorkspace.GeneratedFolder);

            sourceCodeProject = GeneratedCodeWorkspace.AddDirectory(sourceCodeProject, sourceCodePath, skipPredicate: sourceFile => sourceFile.StartsWith(sourceCodeGeneratedDirectory));

            foreach (var sharedSourceFolder in sharedSourceFolders)
            {
                sourceCodeProject = GeneratedCodeWorkspace.AddDirectory(sourceCodeProject, sharedSourceFolder, folders: SharedFolders);
            }

            sourceCodeProject = sourceCodeProject.WithParseOptions(new CSharpParseOptions(preprocessorSymbols: new[] { "EXPERIMENTAL" }));

            return sourceCodeProject;
        }

        private static Project CreateGeneratedCodeProject()
        {
            var workspace = new AdhocWorkspace();
            Project generatedCodeProject = workspace.AddProject("SourceCode", LanguageNames.CSharp);

            var corlibLocation = typeof(object).Assembly.Location;
            var references = new List<MetadataReference>();

            references.Add(MetadataReference.CreateFromFile(corlibLocation));

            var trustedAssemblies = ((string?)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES") ?? "").Split(Path.PathSeparator);
            foreach (var tpl in trustedAssemblies)
            {
                references.Add(MetadataReference.CreateFromFile(tpl));
            }

            generatedCodeProject = generatedCodeProject
                .AddMetadataReferences(references)
                .WithCompilationOptions(new CSharpCompilationOptions(
                    OutputKind.DynamicallyLinkedLibrary, nullableContextOptions: NullableContextOptions.Disable));
            return generatedCodeProject;
        }
    }
}
