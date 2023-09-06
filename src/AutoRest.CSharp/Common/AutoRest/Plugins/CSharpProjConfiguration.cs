// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Communication;
using AutoRest.CSharp.AutoRest.Plugins;

namespace AutoRest.CSharp.Input
{
    /// <summary>
    /// Configuration required by <see cref="CSharpProj"/>.
    /// </summary>
    /// <param name="AbsoluteProjectFolder"></param>
    /// <param name="AzureArm"></param>
    /// <param name="Generation1ConvenienceClient"></param>
    /// <param name="IsMgmtTestProject"></param>
    /// <param name="LibraryName"></param>
    /// <param name="Namespace"></param>
    /// <param name="RelativeProjectFolder"></param>
    /// <param name="SkipCSProjPackageReference"></param>
    internal record CSharpProjConfiguration(
        string AbsoluteProjectFolder,
        bool AzureArm,
        bool Generation1ConvenienceClient,
        bool IsMgmtTestProject,
        string LibraryName,
        string Namespace,
        string RelativeProjectFolder,
        bool SkipCSProjPackageReference
    )
    {
        /// <summary>
        /// Load configuration from autorest.
        /// </summary>
        /// <param name="autoRest"></param>
        /// <param name="defaultLibraryName"></param>
        /// <param name="defaultNamespace"></param>
        /// <returns></returns>
        internal static CSharpProjConfiguration Initialize(IPluginCommunication autoRest, string defaultLibraryName, string defaultNamespace)
        {
            string outputFolder = Configuration.GetOutputFolderOption(autoRest);
            var projectFolder = Configuration.GetProjectFolderOption(autoRest) ?? Configuration.ProjectFolderDefault;
            (var absoluteProjectFolder, var relativeProjectFolder) = Configuration.ParseProjectFolders(outputFolder, projectFolder);

            return new CSharpProjConfiguration(
                AbsoluteProjectFolder: absoluteProjectFolder,
                AzureArm: Configuration.GetAzureArmOption(autoRest),
                IsMgmtTestProject: MgmtTestConfiguration.HasMgmtTestConfiguration(autoRest),
                LibraryName: Configuration.GetLibraryNameOption(autoRest, defaultLibraryName),
                Namespace: Configuration.GetNamespaceOption(autoRest, defaultNamespace),
                SkipCSProjPackageReference: Configuration.GetSkipCSProjPackageReferenceOption(autoRest),
                RelativeProjectFolder: relativeProjectFolder,
                Generation1ConvenienceClient: Configuration.GetGeneration1ConvenienceClientOption(autoRest)
            );
        }
    }
}
