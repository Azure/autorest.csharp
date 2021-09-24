// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using AutoRest.CSharp.Mgmt.Generation;

namespace AutoRest.CSharp.MgmtTest.Generation
{
    internal partial class TestTool
    {
        public static void WriteTestDecorator(CodeWriter writer)
        {
            writer.Line($"[TestCase]");
            writer.Line($"[RecordedTest]");
        }

        public static object ConvertToStringDictionary(object dict)
        {
            Type t = dict.GetType();
            bool isDict = t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>);
            if (!isDict)
            {
                return dict;
            }
            var ret = new Dictionary<string, object>();
            foreach (KeyValuePair<object, object> entry in (IEnumerable< KeyValuePair<object, object>>)dict)
            {
                ret.Add(entry.Key.ToString()!, ConvertToStringDictionary(entry.Value));
            }
            return ret;
        }

        public static string FormatResourceId(string resourceId)
        {
            resourceId = resourceId.Replace("{", "{{").Replace("}", "}}");
            var elements = resourceId.Split("/");
            for (int i = 2; i< elements.Length; i+=2)
            {
                if (elements[i-1].ToLower()== "subscriptions")
                {
                    elements[i] = "00000000-0000-0000-0000-000000000000";
                }
            }
            return String.Join("/", elements);
        }

        public static string GetTaskOrVoid(bool isAsync)
        {
            return isAsync ? "Task" : "void";
        }
    }
}
