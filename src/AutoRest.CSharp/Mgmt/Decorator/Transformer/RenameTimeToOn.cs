﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    internal static class RenameTimeToOn
    {
        private static readonly Dictionary<string, string> _nounToVerbDicts = new()
        {
            {"Creation", "Created"},
            {"Deletion", "Deleted"},
            {"Expiration", "Expire"},
            {"Modification", "Modified"},
        };

        public static void Update(CodeModel codeModel)
        {
            foreach (var schema in codeModel.AllSchemas)
            {
                if (schema is not ObjectSchema objSchema)
                    continue;

                foreach (var property in objSchema.Properties)
                {
                    if (property.Schema.Type is AllSchemaTypes.String or AllSchemaTypes.AnyObject)
                    {
                        if (TypeFactory.ToXMsFormatType(property.Schema.Extensions?.Format) != typeof(DateTimeOffset))
                        {
                            continue;
                        }
                    }
                    else if (property.Schema.Type is not (AllSchemaTypes.Date or AllSchemaTypes.DateTime or AllSchemaTypes.Unixtime))
                    {
                        continue;
                    }

                    var propName = property.CSharpName();

                    if (propName.StartsWith("From", StringComparison.Ordinal) ||
                        propName.StartsWith("To", StringComparison.Ordinal) ||
                        propName.EndsWith("PointInTime", StringComparison.Ordinal))
                        continue;

                    var lengthToCut = 0;
                    if (propName.Length > 8 &&
                        propName.EndsWith("DateTime", StringComparison.Ordinal))
                    {
                        lengthToCut = 8;
                    }
                    else if (propName.Length > 4 &&
                        propName.EndsWith("Time", StringComparison.Ordinal) ||
                        propName.EndsWith("Date", StringComparison.Ordinal))
                    {
                        lengthToCut = 4;
                    }
                    else if (propName.Length > 2 &&
                        propName.EndsWith("At", StringComparison.Ordinal))
                    {
                        lengthToCut = 2;
                    }

                    if (lengthToCut > 0)
                    {
                        var prefix = propName.Substring(0, propName.Length - lengthToCut);
                        var newName = (_nounToVerbDicts.TryGetValue(prefix, out var verb) ? verb : prefix) + "On";
                        property.Language.Default.Name = newName;
                    }
                }
            }
        }
    }
}
