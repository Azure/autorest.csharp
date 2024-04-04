// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    /// <summary>
    /// Resolves metadata references for a workspace.
    /// </summary>
    internal sealed class WorkspaceMetadataReferenceResolver : MetadataReferenceResolver
    {
        // The set of unique directory paths to probe for assemblies.
        internal readonly HashSet<string> ProbingPaths;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspaceMetadataReferenceResolver"/> class
        /// with the specified trusted platform assemblies.
        /// </summary>
        /// <param name="trustedPlatformAssemblies">The list of paths to the trusted platform assemblies.</param>
        internal WorkspaceMetadataReferenceResolver(IReadOnlyList<string> trustedPlatformAssemblies)
        {
            HashSet<string> probingPaths = new();
            foreach (var assembly in trustedPlatformAssemblies)
            {
                var directory = Path.GetDirectoryName(assembly);
                if (directory != null)
                {
                    probingPaths.Add(directory);
                }
            }

            ProbingPaths = probingPaths;
        }

        internal bool Equals(WorkspaceMetadataReferenceResolver? other)
        {
            return ReferenceEquals(this, other);
        }

        public override bool ResolveMissingAssemblies => true;

        public override bool Equals(object? other) => Equals(other as WorkspaceMetadataReferenceResolver);

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(ProbingPaths);
        }

        /// <summary>
        /// Attempts to resolve a missing assembly reference for the specified definition and reference identity.
        /// The resolver will attempt to locate the assembly in the probing paths <see cref="ProbingPaths"/>. If the assembly
        /// is found, a <see cref="PortableExecutableReference"/> is created and returned; otherwise, <see langword="null"/> is returned.
        /// </summary>
        public override PortableExecutableReference? ResolveMissingAssembly(MetadataReference definition, AssemblyIdentity referenceIdentity)
        {
            // check the probing paths
            if (ProbingPaths.Any())
            {
                foreach (var path in ProbingPaths)
                {
                    var assemblyPath = Path.Combine(path, referenceIdentity.Name + ".dll");
                    if (File.Exists(assemblyPath))
                    {
                        return MetadataReference.CreateFromFile(assemblyPath);
                    }
                }
            }

            return null;
        }

        public override ImmutableArray<PortableExecutableReference> ResolveReference(string reference, string? baseFilePath, MetadataReferenceProperties properties)
        {
            throw new NotImplementedException();
        }
    }
}
