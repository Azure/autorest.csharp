using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AutoRest.CSharp.V3.CodeGen
{
    internal abstract class BaseCSharpWriter
    {
        private readonly HashSet<string> _usings = new HashSet<string>();
        public BaseCSharpWriter()
        {
        }

        public class CodeBlock : IDisposable
        {
            public Action? EndBlockAction;

            public CodeBlock(Action endBlockAction)
            {
                EndBlockAction = endBlockAction;
            }

            public void EndBlock()
            {
                var action = EndBlockAction;
                EndBlockAction = null;
                action?.Invoke();
            }

            public void Dispose()
            {
                EndBlock();
            }
        }

        public abstract void Line(string str = "");
        public abstract void Append(string str = "");

        public abstract string GetFormattedCode();

        public virtual void FileHeader()
        {
            Line("// Copyright (c) Microsoft Corporation. All rights reserved.");
            Line("// Licensed under the MIT License.");
            Line();
        }

        public virtual CodeBlock Scope(string start = "{", string end = "}")
        {
            Line(start);

            return new CodeBlock(() => EndScope(end));
        }

        public void EndScope(string end = "}")
        {
            Line(end);
        }

        public CodeBlock Namespace(string name)
        {
            Line($"namespace {name}");
            return Scope();
        }

        public CodeBlock Class(string modifiers, string name)
        {
            Line($"{modifiers} class {name}");
            return Scope();
        }

        public CodeBlock Method(string methodDeclaration)
        {
            Line(methodDeclaration);
            return Scope();
        }

        public void AutoProperty(string modifiers, string type, string name)
        {
            Line($"{modifiers} {type} {name}" + "{ get; set; }");
        }

        public CodeBlock Method(string modifiers, string type, string name, params string[] parameters)
        {
            Line($"{modifiers} {type} {name}({string.Join(", ", parameters)})");
            return Scope();
        }

        public void DocSummary(string summary)
        {
            Line("/// <summary>");
            var summaryLines = summary.Split(Environment.NewLine);
            foreach (var summaryLine in summaryLines)
            {
                Line($"/// {summaryLine}");
            }
            Line("/// </summary>");
        }
        public void DocParam(string paramName, string paramSummary)
        {
            Line($"/// <param name=\"{paramName}\">{paramSummary}</param>");
        }

        public void DocReturns(string returns)
        {
            Line($"/// <returns>{returns}</returns>");
        }

        public void Usings(params string[] namespaces)
        {
            foreach(var ns in namespaces)
            {
                _usings.Add(ns);
            }

            var sortedList = _usings.ToList();
            sortedList.Sort();
            foreach (var u in sortedList)
            {
                Line($"using {u};");
            }

            if (_usings.Any())
            {
                Line();
            }
        }
        public string TypeReference(string name)
        {
            var index = name.LastIndexOf('.');

            if (index > 0)
            {
                var ns = name.Substring(0, index);
                name = name.Substring(index + 1);

                _usings.Add(ns);
            }
            return name;
        }
    }
}
