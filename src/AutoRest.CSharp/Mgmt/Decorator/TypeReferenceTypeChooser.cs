// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Output;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    /// <summary>
    /// This is a utility class to check and keep the result of whether a <c>MgmtObjectType</c> class can be replaced by
    /// an external type.
    /// </summary>
    internal static class TypeReferenceTypeChooser
    {
        private static IReadOnlyList<System.Type>? _typeReferenceTypes;
        private static IReadOnlyList<System.Type> TypeReferenceTypes => _typeReferenceTypes ??= ReferenceClassFinder.GetTypeReferenceTypes();

        private static ConcurrentDictionary<InputModelType, CSharpType?> _valueCache = new ConcurrentDictionary<InputModelType, CSharpType?>();

        /// <summary>
        /// Check whether a <c>MgmtObjectType</c> class can be replaced by an external type, and return the external type if available.
        /// </summary>
        /// <param name="typeToReplace">Type to check</param>
        /// <returns>Matched external type or null if not found</returns>
        public static CSharpType? GetExactMatch(MgmtObjectType typeToReplace, SourceInputModel? sourceInputModel)
        {
            if (_valueCache.TryGetValue(typeToReplace.InputModel, out var result))
                return result;

            foreach (System.Type replacementType in TypeReferenceTypes)
            {
                if (PropertyMatchDetection.IsEqual(replacementType, typeToReplace))
                {
                    var csharpType = CSharpType.FromSystemType(sourceInputModel, replacementType);
                    _valueCache.TryAdd(typeToReplace.InputModel, csharpType);
                    return csharpType;
                }
            }

            _valueCache.TryAdd(typeToReplace.InputModel, null);
            return null;
        }

        /// <summary>
        /// Check whether there is a match for the given schema.
        /// </summary>
        /// <param name="inputModel"><c>InputModelType</c> of the target type</param>
        /// <returns></returns>
        public static bool HasMatch(InputModelType inputModel)
        {
            return _valueCache.TryGetValue(inputModel, out var match) && match != null;
        }
    }
}
