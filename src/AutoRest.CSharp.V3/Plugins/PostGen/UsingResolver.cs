// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Simplification;
using Microsoft.CodeAnalysis.Text;
using System.Net;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline.Generated;
using System.Net.Http;

namespace AutoRest.CSharp.V3.Plugins.PostGen
{
    [PluginName("using-resolver")]
    internal class UsingResolver : IPlugin
    {
        private static readonly string[] AssemblyPaths =
        {
            typeof(Uri).Assembly.Location,
            typeof(File).Assembly.Location,
            typeof(HttpStatusCode).Assembly.Location,
            typeof(HttpClient).Assembly.Location,
            typeof(object).Assembly.Location,
            typeof(XElement).Assembly.Location
        };
        //public Task Run() => Run(Settings.Instance.FileSystemOutput);

        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            //var fs = new MemoryFileSystem();
            string[] skipNamespace = (await autoRest.GetValue<string[]>("skip-simplifier-on-namespace"));

            //var files = autoRest.GetFiles("", "*.cs", SearchOption.AllDirectories).
            //    ToDictionary(each => each, each => fs.ReadAllText(each));

            var files = (await autoRest.ListInputs("source-file-csharp")).ToDictionary(n => n, n => autoRest.ReadFile(n).GetAwaiter().GetResult());
            var projectId = ProjectId.CreateNewId();
            var solution = new AdhocWorkspace().CurrentSolution.AddProject(projectId, "Temp", "Temp", LanguageNames.CSharp);
            solution = AssemblyPaths.Aggregate(solution, (s, a) => s.AddMetadataReference(projectId, MetadataReference.CreateFromFile(a)));
            solution = files.Keys.Aggregate(solution, (s, f) => s.AddDocument(DocumentId.CreateNewId(projectId), f, SourceText.From(files[f])));
            //foreach (var file in files.Keys)
            //{
            //    solution = solution.AddDocument(DocumentId.CreateNewId(projectId), file, SourceText.From(await files[file]));
            //}

            // Simplify docs and add to 
            foreach (var document in solution.Projects.SelectMany(p => p.Documents))
            {
                var newRoot = await document.GetSyntaxRootAsync();

                // get the namespaces used in the file
                var names = new QualifiedNamesRewriter().GetNames(newRoot).Where(each => !skipNamespace.Any(ns => ns == each)).ToArray();

                // add the usings that we found
                newRoot = new UsingsRewriter(names).Visit(newRoot);

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
                //fs.WriteAllText(document.Name, text);
                await autoRest.WriteFile(document.Name, text, "source-file-csharp");
            }

            return true;
        }
    }
}