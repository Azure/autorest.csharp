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

        private static readonly PropertyInfo[] SchemaCollectionProperties = typeof(Schemas).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(pi => pi.PropertyType.IsGenericType
                         && pi.PropertyType.IsInterface
                         && pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>)
                         && pi.PropertyType.GenericTypeArguments.First().IsSubclassOf(typeof(Schema)))
            .ToArray();
        public static Schema[] GetAllSchemaNodes(this Schemas schemasNode) => SchemaCollectionProperties
                .Select(pi => pi.GetValue(schemasNode))
                .Where(c => c != null)
                .SelectMany(c => ((IEnumerable)c!).Cast<Schema>())
                .ToArray();

        public static Type? GetFrameworkType(this AllSchemaTypes schemaType) =>
            schemaType switch
            {
                AllSchemaTypes.And => null,
                AllSchemaTypes.Array => null,
                AllSchemaTypes.Boolean => typeof(bool),
                AllSchemaTypes.ByteArray => typeof(byte[]),
                AllSchemaTypes.Char => typeof(char),
                AllSchemaTypes.Choice => null,
                AllSchemaTypes.Constant => null,
                AllSchemaTypes.Credential => null,
                AllSchemaTypes.Date => typeof(DateTime),
                AllSchemaTypes.DateTime => typeof(DateTime),
                AllSchemaTypes.Dictionary => null,
                AllSchemaTypes.Duration => typeof(TimeSpan),
                AllSchemaTypes.Flag => null,
                AllSchemaTypes.Integer => typeof(int),
                AllSchemaTypes.Not => null,
                AllSchemaTypes.Number => typeof(double),
                AllSchemaTypes.Object => null,
                AllSchemaTypes.OdataQuery => typeof(string),
                AllSchemaTypes.Or => null,
                AllSchemaTypes.ParameterGroup => null,
                AllSchemaTypes.SealedChoice => null,
                AllSchemaTypes.String => typeof(string),
                AllSchemaTypes.Unixtime => typeof(DateTime),
                AllSchemaTypes.Uri => typeof(string),
                AllSchemaTypes.Uuid => typeof(string),
                AllSchemaTypes.Xor => null,
                _ => null
            };
    }
}
