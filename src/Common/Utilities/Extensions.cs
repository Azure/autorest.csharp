// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.Core.Utilities.Collections;
using Newtonsoft.Json;

#pragma warning disable CS3024 // Constraint type is not CLS-compliant
namespace AutoRest.Core.Utilities
{
    /// <summary>
    /// Provides useful extension methods to simplify common coding tasks.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        ///     Determines whether the collection object is either null or an empty collection.
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="collection"> The collection. </param>
        /// <returns>
        ///     <c>true</c> if [is null or empty] [the specified collection]; otherwise, <c>false</c> .
        /// </returns>
        /// <remarks>
        /// </remarks>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) => collection == null || !collection.Any();

        public static bool IsMarked<T>(this PropertyInfo property)
            => property.GetCustomAttributes(typeof(T), true).Any();

        public static bool IsValueType(this Type type) => type.GetTypeInfo().IsValueType;
        public static bool IsEnum(this Type type) => type.GetTypeInfo().IsEnum;
        public static Type BaseType(this Type type) => type.GetTypeInfo().BaseType;
        public static bool IsGenericType(this Type type) => type.GetTypeInfo().IsGenericType;
        public static Assembly GetAssembly(this Type type) => type.GetTypeInfo().Assembly;

        public static string ToTypesString(this Type[] types) => types?.Aggregate("", (current, type) => $"{current}, {type?.FullName ?? "�null�" }").Trim(',') ?? "";

        public static Type[] ParameterTypes(this IEnumerable<ParameterInfo> parameterInfos) => parameterInfos?.Select(p => p.ParameterType).ToArray();

        public static Type[] ParameterTypes(this MethodBase method) => method?.GetParameters().ParameterTypes();

        /// <summary>
        /// Performs shallow copy of properties from source into destination.
        /// </summary>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <param name="destination">Destination object.</param>
        /// <param name="source">Source object.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "U", Justification = "Common naming for generics.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "V", Justification = "Common naming for generics.")]
        public static TDestination LoadFrom<TDestination, TSource>(this TDestination destination, TSource source)
            where TDestination : class
            where TSource : class
        {
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var properties = destination.GetType().GetWriteableProperties();

            foreach (var destinationProperty in properties)
            {
                
                // skip items we've explicitly said not to copy.
                if ( destinationProperty.IsMarked<JsonIgnoreAttribute>())
                {
                    continue;
                }

                // get the source property
                var sourceProperty = source.GetType().GetReadableProperty(destinationProperty.Name);
                if (sourceProperty == null || !sourceProperty.CanRead)
                {
                    continue;
                }

                var destinationType = destinationProperty.PropertyType;


                if (typeof(ICopyFrom).IsAssignableFrom(destinationType))
                {
                    if (true == (destinationProperty.GetValue(destination) as ICopyFrom)?.CopyFrom(sourceProperty.GetValue(source, null)))
                    {
                        continue;
                    }
                }

                // if the property is an IDictionary, clear the destination, and copy the key/values across
                if (typeof(IDictionary).IsAssignableFrom(destinationType))
                {
                    var destinationDictionary = destinationProperty.GetValue(destination) as IDictionary;
                    if (destinationDictionary != null)
                    {
                        var sourceDictionary = sourceProperty.GetValue(source, null) as IDictionary;
                        if (sourceDictionary != null )
                        {
                            foreach (DictionaryEntry kv in sourceDictionary)
                            {
                                destinationDictionary.Add(kv.Key, kv.Value);
                            }
                            continue;
                        }
                    }
                   
                }

                // if the property is an IList, 
                if (typeof(IList).IsAssignableFrom(destinationType))
                {
                    var destinationList = destinationProperty.GetValue(destination) as IList;
                    if (destinationList != null)
                    {
                        var sourceValue = sourceProperty.GetValue(source, null) as IEnumerable;
                        if (sourceValue != null)
                        {
                            foreach (var i in sourceValue)
                            {
                                destinationList.Add(i);
                            }
                            continue;
                        }
                    }
                }

                if ( destinationProperty.CanWrite )
                {
                    var sourceValue = sourceProperty.GetValue(source, null);
                    

                    // this is a pretty weak assumption... (although, most of our collections should be ICopyFrom now.
                    if (destinationType.IsGenericType() && sourceValue is IEnumerable)
                    {
                        var ctor = destinationType.GetConstructor(new[] { destinationType });
                        if (ctor != null)
                        {
                            destinationProperty.SetValue(destination, ctor.Invoke(new[] { sourceValue }), null);
                            continue;
                        }
                    }
                    
                    // set the target property value.
                    destinationProperty.SetValue(destination, sourceValue, null);
                }
            }
            return destination;
        }

        private const BindingFlags AnyPropertyFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy /* | BindingFlags.GetProperty */ | BindingFlags.Instance;

        private static PropertyInfo GetReadableProperty(this Type type, string propertyName)
        {
            if (type == null)
            {
                return null;
            }

            var pi = type.GetProperty(propertyName,AnyPropertyFlags);
            return true == pi?.CanRead ? pi : GetReadableProperty(type.BaseType(), propertyName);
        }

        private static IEnumerable<PropertyInfo> GetWriteableProperties(this Type type)
        {
            return type.GetProperties(AnyPropertyFlags).Where(each => !each.IsMarked<JsonIgnoreAttribute>())
                    .Select(each => GetWriteableProperty(type, each.Name))
                    .WhereNotNull();
        }

        private static PropertyInfo GetWriteableProperty(this Type type, string propertyName)
        {
            if (type == null)
            {
                return null;
            }

            var pi = type.GetProperty(propertyName, AnyPropertyFlags);
            if (typeof(ICopyFrom).IsAssignableFrom(pi?.PropertyType) || typeof(IDictionary).IsAssignableFrom(pi?.PropertyType) || typeof(IList).IsAssignableFrom(pi?.PropertyType))
            {
                return pi;
            }
            return true == pi?.CanWrite ? pi : GetWriteableProperty(type.BaseType(), propertyName);
        }

        public static bool EqualsIgnoreCase(this string s1, Fixable<string> s2) => ReferenceEquals(s1,s2.Value) || (s1?.Equals(s2.Value, StringComparison.OrdinalIgnoreCase) ?? false);

        public static Task<T> AsResultTask<T>(this T result)
        {
            var x = new TaskCompletionSource<T>(TaskCreationOptions.AttachedToParent);
            x.SetResult(result);
            return x.Task;
        }
    }
}