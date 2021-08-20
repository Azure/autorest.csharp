// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class ContextualPathDetection
    {
        private static ConcurrentDictionary<OperationGroup, string> _valueCache = new ConcurrentDictionary<OperationGroup, string>();

        public static string ContextualPath(this OperationGroup operationGroup, MgmtConfiguration config)
        {
            if (operationGroup.TryGetContextualPath(config, out var contextualPath))
                return contextualPath;

            // otherwise we throw exception to notify the user to modify their readme.md
            throw new Exception($"Contextual Path schema not found! Please add the {operationGroup.Key} to its schema name mapping in the `operation-group-to-contextual-path` section of readme.md.");
        }

        public static bool TryGetContextualPath(this OperationGroup operationGroup, MgmtConfiguration config, [MaybeNullWhen(false)] out string contextualPath)
        {
            contextualPath = null;
            if (_valueCache.TryGetValue(operationGroup, out contextualPath))
            {
                return true;
            }

            // if this operationGroup does not correspond to a resource, return false immediately
            if (!operationGroup.IsResource(config))
                return false;

            // read the configuration first
            if (config.OperationGroupToContextualPath.TryGetValue(operationGroup.Key, out contextualPath))
            {
                _valueCache.TryAdd(operationGroup, contextualPath);
                return true;
            }

            // configuration does not set this, we should find a way to calculate this
            contextualPath = FindContextualPath(operationGroup, config);

            return contextualPath != null;
        }

        private static string? FindContextualPath(OperationGroup operationGroup, MgmtConfiguration config)
        {
            return null;
        }
    }
}
