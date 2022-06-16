// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.MgmtTest.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.MgmtTest.Extensions
{
    internal static class CodeWriterExtensions
    {
        public static CodeWriter AppendCommaSeparatedItems(this CodeWriter writer, IEnumerable<FormattableString> items)
        {
            foreach (var item in items)
            {
                writer.Append(item);
                writer.AppendRaw(",");
            }
            writer.RemoveTrailingComma();
            return writer;
        }

        public static CodeWriter AppendExampleValue(this CodeWriter writer, ExampleValue exampleValue)
        {
            // TODO -- just place holder
            writer.AppendRaw("default");
            return writer;
        }

        public static CodeWriter AppendExampleParameterValue(this CodeWriter writer, Parameter parameter, ExampleParameterValue exampleValue)
        {
            // for optional parameter, we write the parameter name here
            if (parameter.DefaultValue != null)
                writer.Append($"{parameter.Name}: ");
            if (exampleValue.Value != null)
                writer.AppendExampleValue(exampleValue.Value);
            else if (exampleValue.RawValue != null)
                writer.Append(exampleValue.RawValue);
            else
                throw new InvalidOperationException($"No value for parameter {exampleValue.Parameter.Name} assigned");
            return writer;
        }
    }
}
