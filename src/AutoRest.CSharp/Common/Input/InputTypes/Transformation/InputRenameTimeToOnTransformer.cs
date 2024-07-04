// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Common.Input
{
    internal class InputRenameTimeToOnTransformer
    {
        private const string _onSuffix = "On";
        private static readonly Dictionary<string, string> _nounToVerbMapping = new()
        {
            {"Creation", "Created"},
            {"Deletion", "Deleted"},
            {"Expiration", "Expire"},
            {"Modification", "Modified"},
        };

        private static string[] _wordsToSkip = new string[]
        {
            "From",
            "To",
            "PointInTime",
        };

        private static string[] _wordsToCut = new string[]
        {
            "DateTime",
            "Time",
            "Date",
            "At",
        };

        public static void Transform(InputNamespace inputNamespace)
        {
            foreach (var model in inputNamespace.Models)
            {
                if (model is not InputModelType inputModel)
                    continue;

                foreach (var property in inputModel.Properties)
                {
                    var propertyType = property.Type.GetImplementType();
                    if ((propertyType is InputPrimitiveType inputPrimitiveType && inputPrimitiveType.Kind == InputPrimitiveTypeKind.PlainDate) || propertyType is InputDateTimeType)
                    {
                        var propName = property.CSharpName().AsSpan();

                        foreach (var word in _wordsToSkip)
                        {
                            if (propName.StartsWith(word, StringComparison.Ordinal))
                            {
                                continue;
                            }
                        }

                        var lengthToCut = 0;
                        foreach (var word in _wordsToCut)
                        {
                            if (propName.EndsWith(word, StringComparison.Ordinal))
                            {
                                lengthToCut = word.Length;
                                break;
                            }
                        }

                        if (lengthToCut > 0 && lengthToCut < propName.Length)
                        {
                            var prefix = propName.Slice(0, propName.Length - lengthToCut).ToString();
                            var newName = (_nounToVerbMapping.TryGetValue(prefix, out var verb) ? verb : prefix) + _onSuffix;
                            property.Name = newName;
                        }
                    }
                }
            }
        }
    }
}
