// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoRest.Core;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Simplification;
using Microsoft.CodeAnalysis.Text;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using AutoRest.Core.Utilities;
using System.Net;

namespace AutoRest.Simplify
{
    public class CSharpSimplifier
    {
        public Task Run() => Run(Settings.Instance.FileSystemOutput);

        public async Task Run(MemoryFileSystem fs)
        {
            var files = fs.GetFiles("", "*.cs", SearchOption.AllDirectories).
                ToDictionary(each => each, each => fs.ReadAllText(each));

            var assemblies = new[] {
                typeof(IAzureClient).GetAssembly().Location,
                typeof(RestException).GetAssembly().Location,
                typeof(Uri).GetAssembly().Location,
                typeof(File).GetAssembly().Location,
                typeof(HttpStatusCode).GetAssembly().Location,
                typeof(System.Net.Http.HttpClient).GetAssembly().Location,
                typeof(object).GetAssembly().Location,
                typeof(XElement).GetAssembly().Location,
                typeof(JsonConvert).GetAssembly().Location
            };

            var projectId = ProjectId.CreateNewId();
            var solution = new AdhocWorkspace().CurrentSolution
                .AddProject(projectId, "MyProject", "MyProject", LanguageNames.CSharp);
            // add assemblies
            solution = assemblies.Aggregate(solution, (current, asm) => current.AddMetadataReference(projectId, MetadataReference.CreateFromFile(asm)));

            // Add existing files
            foreach (var file in files.Keys)
            {
                var documentId = DocumentId.CreateNewId(projectId);
                solution = solution.AddDocument(documentId, file, SourceText.From(files[file]));
            }

            // Simplify docs and add to 
            foreach (var proj in solution.Projects)
            {
                foreach (var document in proj.Documents)
                {
                    var newRoot = await document.GetSyntaxRootAsync();

                    // get the namespaces used in the file
                    var names = new GetQualifiedNames().GetNames(newRoot).Where( each => each != "System.Security.Permissions").ToArray();

                    // add the usings that we found
                    newRoot = new AddUsingsRewriter(names).Visit(newRoot);

                    // tell roslyn to simplify where it can
                    newRoot = new SimplifyNamesRewriter().Visit(newRoot);
                    var doc = document.WithSyntaxRoot(newRoot);

                    // reduce the code 
                    var text = Simplifier.ReduceAsync(doc)
                        .Result.GetTextAsync()
                        .Result.ToString()
                        // get rid of any BOMs 
                        .Trim('\x00EF', '\x00BB', '\x00BF', '\uFEFF', '\u200B');


                    // special cases the simplifier can't handle.
                    text = text.
                        Replace("[Newtonsoft.Json.JsonConverter(", "[JsonConverter(").
                        Replace("[System.Runtime.Serialization.EnumMember(", "[EnumMember(").
                        Replace("[Newtonsoft.Json.JsonProperty(", "[JsonProperty(").
                        Replace("[Newtonsoft.Json.JsonProperty]", "[JsonProperty]").
                        Replace("[Newtonsoft.Json.JsonObject]", "[JsonObject]").
                        Replace("[Microsoft.Rest.Serialization.JsonTransformation]", "[JsonTransformation]").
                        Replace("[Newtonsoft.Json.JsonExtensionData]", "[JsonExtensionData]");

                    // Write out the files back to their original location
                    fs.WriteAllText(document.Name, text);
                }
            }
        }
    }
}