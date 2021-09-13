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

namespace AutoRest.CSharp.Mgmt.TestGeneration
{
    internal abstract class MgmtTestBaseWriter : MgmtClientBaseWriter
    {
        protected void WriteTestDecorator(CodeWriter writer)
        {
            writer.Line($"[TestCase]");
            writer.Line($"[RecordedTest]");
        }

        protected static Dictionary<string, EnumType> CollectEnumTypes(BuildContext<MgmtOutputLibrary> context)
        {
            var ret = new Dictionary<string, EnumType>();
            foreach (var model in context.Library.Models)
            {
                if (model is EnumType)
                {
                    var enumType = (EnumType)model;
                    ret.Add(enumType.Description!, enumType);
                }
            }
            return ret;
        }

        protected static string GetEnumValue(Dictionary<string, EnumType> EnumTypes, Schema schema, ExampleValue ev)
        {
            EnumType t = EnumTypes[schema.CSharpName()]!;

            return ModelWriter.GetValueFieldName(t.Declaration.Name, (string)ev.RawValue!, t.Values);
        }

        protected static object ConvertToStringDictionary(object dict)
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
    }
}
