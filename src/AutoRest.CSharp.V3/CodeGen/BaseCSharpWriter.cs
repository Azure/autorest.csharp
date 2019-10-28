using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal abstract class BaseCSharpWriter
    {
        private readonly List<CSharpNamespace?> _usingNamespaces = new List<CSharpNamespace?>();
        public bool UseTypeShortNames { get; set; } = true;

        public abstract void Line(string str = "");
        public abstract void Append(string str = "");
        public abstract void Replace(string oldValue = "", string newValue = "");
        public abstract string GetFormattedCode();

        public virtual void FileHeader()
        {
            Line("// Copyright (c) Microsoft Corporation. All rights reserved.");
            Line("// Licensed under the MIT License.");
            Line();
        }

        protected virtual EndBlock Scope(string start = "{", string end = "}")
        {
            Line(start);
            return new EndBlock(() => Line(end));
        }

        //public EndBlock Namespace(string name)
        //{
        //    Line($"namespace {name}");
        //    return Scope();
        //}

        public EndBlock Namespace(CSharpNamespace? @namespace = null)
        {
            Line($"namespace {@namespace?.FullName ?? "[NO NAMESPACE]"}");
            return Scope();
        }

        //public EndBlock Class(string modifiers, string name)
        //{
        //    Line($"{modifiers} class {name}");
        //    return Scope();
        //}

        public EndBlock Class(string modifiers, CSharpLanguage? cs = null)
        {
            Line($"{modifiers} class {cs?.Name ?? "[NO TYPE NAME]"}");
            return Scope();
        }

        //public EndBlock Enum(string modifiers, string name)
        //{
        //    Line($"{modifiers} enum {name}");
        //    return Scope();
        //}

        public EndBlock Enum(string modifiers, CSharpLanguage? cs = null)
        {
            Line($"{modifiers} enum {cs?.Name ?? "[NO ENUM NAME]"}");
            return Scope();
        }

        //public EndBlock Method(string methodDeclaration)
        //{
        //    Line(methodDeclaration);
        //    return Scope();
        //}

        //public EndBlock Method(string modifiers, string type, string name, params string[] parameters)
        //{
        //    Line($"{modifiers} {type} {name}({string.Join(", ", parameters)})");
        //    return Scope();
        //}

        //public void AutoProperty(string modifiers, string type, string name) => Line($"{modifiers} {type} {name} {{ get; set; }}");

        public void AutoProperty(string modifiers, CSharpType? type = null, CSharpLanguage? propertyCs = null) => Line($"{modifiers} {Type(type)} {propertyCs?.Name ?? "[NO PROPERTY NAME]"} {{ get; set; }}");

        public void EnumValue(CSharpLanguage? choiceCs = null) => Line($"{choiceCs?.Name ?? "[NO NAME]"},");

        //public void DocSummary(string summary)
        //{
        //    Line("/// <summary>");
        //    var summaryLines = summary.Split(Environment.NewLine);
        //    foreach (var summaryLine in summaryLines)
        //    {
        //        Line($"/// {summaryLine}");
        //    }
        //    Line("/// </summary>");
        //}
        //public void DocParam(string paramName, string paramSummary) =>
        //    Line($"/// <param name=\"{paramName}\">{paramSummary}</param>");

        //public void DocReturns(string returns) =>
        //    Line($"/// <returns>{returns}</returns>");

        //public void Usings(params string[] namespaces)
        //{
        //    foreach(var ns in namespaces)
        //    {
        //        _usings.Add(ns);
        //    }

        //    var sortedList = _usings.ToList();
        //    sortedList.Sort();
        //    foreach (var u in sortedList)
        //    {
        //        Line($"using {u};");
        //    }

        //    if (_usings.Any())
        //    {
        //        Line();
        //    }
        //}

        public EndBlock Usings()
        {
            //foreach (var ns in namespaces)
            //{
            //    _usings.Add(ns);
            //}

            //var sortedList = _usings.ToList();
            //sortedList.Sort();
            //foreach (var u in sortedList)
            //{
            //    Line($"using {u};");
            //}

            //if (_usings.Any())
            //{
            //    Line();
            //}
            const string usingBlockSymbol = "%%UsingBlock%%";
            Line(usingBlockSymbol);
            return new EndBlock(() =>
            {
                var usingBlock = String.Join(Environment.NewLine,
                    _usingNamespaces
                        .Where(un => un != null)
                        .Select(un => $"using {un!.FullName};")
                        .Distinct().ToList().OrderBy(u => u).ThenBy(u => u.Length));
                Replace(usingBlockSymbol, usingBlock + Environment.NewLine);
            });
        }

        //public string Type(string name)
        //{
        //    var index = name.LastIndexOf('.');

        //    if (index > 0)
        //    {
        //        var ns = name.Substring(0, index);
        //        name = name.Substring(index + 1);

        //        _usings.Add(ns);
        //    }
        //    return name;
        //}

        public string Type(CSharpType? type = null)
        {
            //var index = name.LastIndexOf('.');

            //if (index > 0)
            //{
            //    var ns = name.Substring(0, index);
            //    name = name.Substring(index + 1);

            //    _usings.Add(ns);
            //}
            _usingNamespaces.Add(type?.Namespace);
            return (UseTypeShortNames ? type?.Name : type?.FullName) ?? "[NO TYPE]";
        }
    }
}
