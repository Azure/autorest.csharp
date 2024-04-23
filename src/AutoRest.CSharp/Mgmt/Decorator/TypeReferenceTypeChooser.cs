// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
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
        private static ConcurrentDictionary<InputType, CSharpType?> _valueCache = new ConcurrentDictionary<InputType, CSharpType?>();

        /// <summary>
        /// Check whether a <c>MgmtObjectType</c> class can be replaced by an external type, and return the external type if available.
        /// </summary>
        /// <param name="typeToReplace">Type to check</param>
        /// <returns>Matched external type or null if not found</returns>
        public static CSharpType? GetExactMatch(MgmtObjectType typeToReplace)
        {
            if (_valueCache.TryGetValue(typeToReplace.InputModel, out var result))
                return result;

            var replacedType = BuildExactMatchType(typeToReplace);

            _valueCache.TryAdd(typeToReplace.InputModel, replacedType);
            return replacedType;
        }

        private static CSharpType? BuildExactMatchType(MgmtObjectType typeToReplace)
        {
            foreach (System.Type replacementType in ReferenceClassFinder.TypeReferenceTypes)
            {
                if (PropertyMatchDetection.IsEqual(replacementType, typeToReplace))
                {
                    var csharpType = CSharpType.FromSystemType(MgmtContext.Context, replacementType, typeToReplace.MyProperties);
                    _valueCache.TryAdd(typeToReplace.InputModel, csharpType);
                    return csharpType;
                }
            }

            // nothing matches, return null
            return null;
        }

        /// <summary>
        /// Check whether there is a match for the given schema.
        /// </summary>
        /// <param name="schema"><c>ObjectSchema</c> of the target type</param>
        /// <returns></returns>
        public static bool HasMatch(InputModelType schema)
        {
            return _valueCache.TryGetValue(schema, out var match) && match != null;
        }
    }
}
