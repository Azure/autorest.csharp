// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace _Specs_.Azure.ClientGenerator.Core.Access.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class SpecsAzureClientGeneratorCoreAccessModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.NoDecoratorModelInPublic"/>. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <returns> A new <see cref="Models.NoDecoratorModelInPublic"/> instance for mocking. </returns>
        public static NoDecoratorModelInPublic NoDecoratorModelInPublic(string name = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return new NoDecoratorModelInPublic(name);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PublicDecoratorModelInPublic"/>. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <returns> A new <see cref="Models.PublicDecoratorModelInPublic"/> instance for mocking. </returns>
        public static PublicDecoratorModelInPublic PublicDecoratorModelInPublic(string name = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return new PublicDecoratorModelInPublic(name);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PublicDecoratorModelInInternal"/>. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <returns> A new <see cref="Models.PublicDecoratorModelInInternal"/> instance for mocking. </returns>
        public static PublicDecoratorModelInInternal PublicDecoratorModelInInternal(string name = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return new PublicDecoratorModelInInternal(name);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SharedModel"/>. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <returns> A new <see cref="Models.SharedModel"/> instance for mocking. </returns>
        public static SharedModel SharedModel(string name = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return new SharedModel(name);
        }
    }
}
