// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Utilities;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace AutoRest.CSharp.Decorator
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
        public static CSharpType? GetExactMatch(ModelTypeProvider typeToReplace)
        {
            if (_valueCache.TryGetValue(typeToReplace.InputModel, out var result))
                return result;

            foreach (System.Type replacementType in TypeReferenceTypes)
            {
                if (PropertyMatchDetection.IsEqual(replacementType, typeToReplace))
                {
                    var csharpType = CSharpType.FromSystemType(replacementType, replacementType.Namespace!, null);
                    _valueCache.TryAdd(typeToReplace.InputModel, csharpType);
                    return csharpType;
                }
            }

            _valueCache.TryAdd(typeToReplace.InputModel, null);
            return null;
        }
    }
}
