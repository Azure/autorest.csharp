// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoRest.Core.Utilities
{
    public class Factory
    {
        private readonly Dictionary<Type[], Delegate> _constructors = new Dictionary<Type[], Delegate>();
        private readonly Type _targetType;

        private const BindingFlags AllConstructorsFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        protected internal IEnumerable<ConstructorInfo> TargetTypeConstructors => _targetType.GetConstructors(AllConstructorsFlags);

        protected internal Factory(Type t)
        {
            _targetType = t;
        }

        internal Delegate GetConstructorImplementation(Type[] args)
        {
            var signatures = _constructors.Keys.Where(each => each.Length == args.Length).ToArray();

            if (!signatures.Any())
            {
                return null;
            }

            if (signatures.Length == 1)
            {
                // quick match : if there is only one match, let's just try that.
                return _constructors[signatures[0]];
            }

            // look for an exact match, or failing that, an acceptable match.
            var s = signatures.FirstOrDefault(signature => signature.SequenceEqual(args)) ?? 
                signatures.SingleOrDefault(each => AreAssignableFrom(each, args));

            if (s != null)
            {
                return _constructors[s];
            }

            return null;
        }

        private static bool AreAssignableFrom(Type[] signature, Type[] argTypes)
        {
            for (var i = 0; i < signature.Length; i++)
            {
                // if the argument is null, but the signature can take a null, it's a match.
                if (argTypes[i] == null && !signature[i].IsValueType())
                {
                    continue;
                }

                // if the object type isn't assignable, it's not a match.
                if (!signature[i].IsAssignableFrom(argTypes[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}