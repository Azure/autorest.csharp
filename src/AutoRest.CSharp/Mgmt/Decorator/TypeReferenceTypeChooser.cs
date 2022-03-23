﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    /// <summary>
    /// This is a utility class to check and keep the result of whether a <c>MgmtObjectType</c> class can be replaced by
    /// an external type.
    /// </summary>
    internal static class TypeReferenceTypeChooser
    {
        internal const string TyepReferenceTypeAttribute = "TypeReferenceType";
        private const string TypeReferenceTypeAttributeType = "TypeReferenceTypeAttribute";

        private static IReadOnlyList<System.Type>? _typeReferenceTypes;
        private static IReadOnlyList<System.Type> TypeReferenceTypes => _typeReferenceTypes ??= GetTypeReferenceTypes();

        private static ConcurrentDictionary<Schema, CSharpType?> _valueCache = new ConcurrentDictionary<Schema, CSharpType?>();

        private static IReadOnlyList<System.Type> GetTypeReferenceTypes()
        {
            return ReferenceClassFinder.ExternalTypes.Where(t => t.GetCustomAttributes(false).Where(a => a.GetType().Name == TypeReferenceTypeAttributeType).Count() > 0).ToList();
        }

        /// <summary>
        /// Check whether a <c>MgmtObjectType</c> class can be replaced by an external type, and return the external type if available.
        /// </summary>
        /// <param name="typeToReplace">Type to check</param>
        /// <returns>Matched external type or null if not found</returns>
        public static CSharpType? GetExactMatch(MgmtObjectType typeToReplace)
        {
            if (_valueCache.TryGetValue(typeToReplace.ObjectSchema, out var result))
                return result;

            foreach (System.Type replacementType in TypeReferenceTypes)
            {
                if (PropertyMatchDetection.IsEqual(replacementType, typeToReplace))
                {
                    var csharpType = CSharpType.FromSystemType(typeToReplace.Context, replacementType);
                    _valueCache.TryAdd(typeToReplace.ObjectSchema, csharpType);
                    return csharpType;
                }
            }

            _valueCache.TryAdd(typeToReplace.ObjectSchema, null);
            return null;
        }

        /// <summary>
        /// Check whether there is a match for the given schema.
        /// </summary>
        /// <param name="schema"><c>ObjectSchema</c> of the target type</param>
        /// <returns></returns>
        public static bool HasMatch(ObjectSchema schema)
        {
            return _valueCache.TryGetValue(schema, out var match) && match != null;
        }
    }
}
