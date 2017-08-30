// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

namespace AutoRest.CSharp.Unit.Tests {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;
    using Core.Utilities;
    using Microsoft.CodeAnalysis;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.CSharp.Compiler.Compilation;
    using Newtonsoft.Json;
    using Xunit.Abstractions;
    using OutputKind = Microsoft.Rest.CSharp.Compiler.Compilation.OutputKind;
    using System.Reflection;
    using System.Runtime.Loader;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    using IAnyPlugin = AutoRest.Core.Extensibility.IPlugin<AutoRest.Core.Extensibility.IGeneratorSettings, AutoRest.Core.IModelSerializer<AutoRest.Core.Model.CodeModel>, AutoRest.Core.ITransformer<AutoRest.Core.Model.CodeModel>, AutoRest.Core.CodeGenerator, AutoRest.Core.CodeNamer, AutoRest.Core.Model.CodeModel>;

    public class BugTest {
        internal static string[] SuppressWarnings = {"CS1701","CS1702", "CS1591"};
        //Todo: Remove CS1591 when issue https://github.com/Azure/autorest/issues/1387 is fixed

        protected Assembly LoadAssembly(MemoryStream stream) {
            return AssemblyLoadContext.Default.LoadFromStream(stream);    
        }

        internal static char Q = '"';
        private ITestOutputHelper _output;

        public BugTest(ITestOutputHelper output) {
            _output = output;
        }

        public BugTest() {
        }

        protected virtual MemoryFileSystem CreateMockFilesystem() => new MemoryFileSystem();

        protected virtual MemoryFileSystem GenerateCodeForTestFromSpec(IAnyPlugin plugin = null) {
            return GenerateCodeForTestFromSpec($"{GetType().Name}", plugin);
        }

        protected virtual MemoryFileSystem GenerateCodeForTestFromSpec(string dirName, IAnyPlugin plugin = null) {
            var fs = CreateMockFilesystem();
            return dirName.GenerateCodeInto(fs, plugin ?? new PluginCs());
        }

        protected virtual void WriteLine(string format, params object[] values) {
            if (format != null) {
                if (values != null && values.Length > 0) {
                    _output?.WriteLine(format, values);
                    Debug.WriteLine(format, values);
                } else {
                    _output?.WriteLine(format);
                    Debug.WriteLine(format);
                }
            } else {
                _output?.WriteLine("<null>");
                Debug.WriteLine("<null>");
            }
        }

        protected void Write(IEnumerable<Diagnostic> messages, MemoryFileSystem fileSystem) {
            if (messages.Any()) {
                foreach (var file in messages.GroupBy(each => each.Location?.SourceTree?.FilePath, each => each)) {
                    var text = file.Key != null ? fileSystem.VirtualStore[file.Key].ToString() : string.Empty;

                    foreach (var error in file) {
                        WriteLine(error.ToString());
                        // WriteLine(text.Substring(error.Location.SourceSpan.Start, error.Location.SourceSpan.Length));
                    }
                }
            }
        }
        
        protected static string DOTNET = Path.GetDirectoryName( System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        protected static string Shared = Path.Combine( DOTNET, "shared", "Microsoft.NETCore.App" );

        private static int VerNum(string version) 	{
            int n = 0;
            foreach (var i in version.Split('.'))
            {
                int p;
                if (!Int32.TryParse(i, out p))
                {
                    return n;
                }
                n = (n << 8) + p;
            }
            return n;
        }
        private static string _framework;
        protected static string FRAMEWORK { 
            get {
                if (string.IsNullOrEmpty(_framework ) ) {
                    _framework = Path.Combine( Shared, "2.0.0");
                }
                return _framework;
            }
        }

        protected static readonly string[] _assemblies = new[] {
            
            Path.Combine(FRAMEWORK, "System.Runtime.dll"),
            Path.Combine(FRAMEWORK, "mscorlib.dll"),
            Path.Combine(FRAMEWORK, "System.Threading.Tasks.dll"),
            Path.Combine(FRAMEWORK, "System.Net.Primitives.dll"),
            Path.Combine(FRAMEWORK, "System.Collections.dll"),
            Path.Combine(FRAMEWORK, "System.Text.Encoding.dll"),
            Path.Combine(FRAMEWORK, "System.Text.RegularExpressions.dll"),
            Path.Combine(FRAMEWORK, "System.IO.dll"),


            typeof(HttpClient).GetAssembly().Location,
            typeof(Object).GetAssembly().Location,
            typeof(Attribute).GetAssembly().Location,
            typeof(IAzureClient).GetAssembly().Location,
            typeof(RestException).GetAssembly().Location,
            typeof(Uri).GetAssembly().Location,
            typeof(File).GetAssembly().Location,
            typeof(Enumerable).GetAssembly().Location,
            typeof(JsonArrayAttribute).GetAssembly().Location,
            typeof(EnumMemberAttribute).GetAssembly().Location,
            typeof(Controller).GetAssembly().Location,
            typeof(ActionContext).GetAssembly().Location,
            typeof(InlineRouteParameterParser).GetAssembly().Location,
            typeof(ControllerBase).GetAssembly().Location,

        };

        protected async Task<CompilationResult> Compile(MemoryFileSystem fileSystem) {
            var compiler = new CSharpCompiler(fileSystem.GetFiles("", "*.cs", SearchOption.AllDirectories)
                .Select(each => new KeyValuePair<string, string>(each, fileSystem.ReadAllText(each))).ToArray(), _assemblies);
            var result = await compiler.Compile(OutputKind.DynamicallyLinkedLibrary);

            return result;
        }
    }
}