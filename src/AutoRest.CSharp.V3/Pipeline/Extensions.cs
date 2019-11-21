// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Pipeline
{
    internal static class Extensions
    {
        public static readonly Type[] GeneratedTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == typeof(CodeModel).Namespace).ToArray();

        private static readonly PropertyInfo[] SchemaCollectionProperties = typeof(Schemas).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(pi => pi.PropertyType.IsGenericType
                         && pi.PropertyType.IsInterface
                         && pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>)
                         && (pi.PropertyType.GenericTypeArguments.First().IsSubclassOf(typeof(Schema))
                            || pi.PropertyType.GenericTypeArguments.First() == typeof(Schema)))
            .ToArray();
        public static Schema[] GetAllSchemaNodes(this Schemas schemasNode) => SchemaCollectionProperties
                .Select(pi => pi.GetValue(schemasNode))
                .Where(c => c != null)
                .SelectMany(c => ((IEnumerable)c!).Cast<Schema>())
                .ToArray();

        // Cache the CSharpType so they become references in the YAML
        private static readonly Dictionary<Type, CSharpType> CSharpTypes = new Dictionary<Type, CSharpType>
        {
            { typeof(bool), new CSharpType { FrameworkType = typeof(bool) } },
            { typeof(char), new CSharpType { FrameworkType = typeof(char) } },
            { typeof(int), new CSharpType { FrameworkType = typeof(int) } },
            { typeof(double), new CSharpType { FrameworkType = typeof(double) } },
            { typeof(string), new CSharpType { FrameworkType = typeof(string) } },
            { typeof(byte[]), new CSharpType { FrameworkType = typeof(byte[]) } },
            { typeof(DateTime), new CSharpType { FrameworkType = typeof(DateTime) } },
            { typeof(TimeSpan), new CSharpType { FrameworkType = typeof(TimeSpan) } },
            { typeof(Uri), new CSharpType { FrameworkType = typeof(Uri) } }
        };

        public static CSharpType? GetFrameworkType(this AllSchemaTypes schemaType) => schemaType switch
        {
            AllSchemaTypes.Any => null,
            AllSchemaTypes.Array => null,
            AllSchemaTypes.Boolean => CSharpTypes[typeof(bool)],
            AllSchemaTypes.ByteArray => CSharpTypes[typeof(byte[])],
            AllSchemaTypes.Char => CSharpTypes[typeof(char)],
            AllSchemaTypes.Choice => null,
            AllSchemaTypes.Constant => null,
            AllSchemaTypes.Credential => null,
            AllSchemaTypes.Date => CSharpTypes[typeof(DateTime)],
            AllSchemaTypes.DateTime => CSharpTypes[typeof(DateTime)],
            AllSchemaTypes.Dictionary => null,
            AllSchemaTypes.Duration => CSharpTypes[typeof(TimeSpan)],
            AllSchemaTypes.Flag => null,
            AllSchemaTypes.Integer => CSharpTypes[typeof(int)],
            AllSchemaTypes.Not => null,
            AllSchemaTypes.Number => CSharpTypes[typeof(double)],
            AllSchemaTypes.Object => null,
            AllSchemaTypes.OdataQuery => CSharpTypes[typeof(string)],
            AllSchemaTypes.Or => null,
            AllSchemaTypes.ParameterGroup => null,
            AllSchemaTypes.SealedChoice => null,
            AllSchemaTypes.String => CSharpTypes[typeof(string)],
            AllSchemaTypes.Unixtime => CSharpTypes[typeof(DateTime)],
            AllSchemaTypes.Uri => CSharpTypes[typeof(Uri)],
            AllSchemaTypes.Uuid => CSharpTypes[typeof(string)],
            AllSchemaTypes.Xor => null,
            _ => null
        };
    }
}
