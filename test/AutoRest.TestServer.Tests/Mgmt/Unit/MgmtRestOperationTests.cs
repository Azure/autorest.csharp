﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using Azure.Core;
using NUnit.Framework;
using static AutoRest.CSharp.Mgmt.Models.MgmtRestOperation;

namespace AutoRest.TestServer.Tests.Mgmt.Unit
{
    internal class MgmtRestOperationTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            var mgmtConfiguration = new MgmtConfiguration(
                operationGroupsToOmit: Array.Empty<string>(),
                requestPathIsNonResource: Array.Empty<string>(),
                noPropertyTypeReplacement: Array.Empty<string>(),
                listException: Array.Empty<string>(),
                promptedEnumValues: Array.Empty<string>(),
                keepOrphanedModels: Array.Empty<string>(),
                keepPluralEnums: Array.Empty<string>(),
                keepPluralResourceData: Array.Empty<string>(),
                noResourceSuffix: Array.Empty<string>(),
                schemasToPrependRPPrefix: Array.Empty<string>(),
                generateArmResourceExtensions: Array.Empty<string>(),
                parameterizedScopes: Array.Empty<string>(),
                mgmtDebug: new MgmtConfiguration.MgmtDebugConfiguration(),
                operationsToSkipLroApiVersionOverride: default,
                requestPathToParent: default,
                requestPathToResourceName: default,
                requestPathToResourceData: default,
                requestPathToResourceType: default,
                requestPathToScopeResourceTypes: default,
                operationPositions: default,
                requestPathToSingletonResource: default,
                overrideOperationName: default,
                acronymMapping: default,
                formatByNameRules: default,
                renameMapping: default,
                parameterRenameMapping: default,
                irregularPluralWords: default,
                mergeOperations: default,
                armCore: default,
                resourceModelRequiresType: default,
                resourceModelRequiresName: default,
                singletonRequiresKeyword: default,
                operationIdMappings: default,
                updateRequiredCopy: default,
                patchInitializerCustomization: default);
            Configuration.Initialize(outputFolder: ".",
                ns: "",
                libraryName: "",
                sharedSourceFolders: Array.Empty<string>(),
                saveInputs: true,
                azureArm: true,
                publicClients: true,
                modelNamespace: true,
                headAsBoolean: true,
                skipCSProj: true,
                skipCSProjPackageReference: true,
                generation1ConvenienceClient: false,
                singleTopLevelClient: false,
                skipSerializationFormatXml: false,
                disablePaginationTopRenaming: false,
                generateModelFactory: true,
                publicDiscriminatorProperty: false,
                deserializeNullCollectionAsNullValue: false,
                modelFactoryForHlc: Array.Empty<string>(),
                unreferencedTypesHandling: Configuration.UnreferencedTypesHandlingOption.RemoveOrInternalize,
                keepNonOverloadableProtocolSignature: false,
                useCoreDataFactoryReplacements: true,
                useModelReaderWriter: true,
                enableBicepSerialization: true,
                enableInternalRawData: false,
                projectFolder: "/..",
                existingProjectFolder: null,
                protocolMethodList: Array.Empty<string>(),
                suppressAbstractBaseClasses: Array.Empty<string>(),
                modelsToTreatEmptyStringAsNull: Array.Empty<string>(),
                additionalIntrinsicTypesToTreatEmptyStringAsNull: Array.Empty<string>(),
                shouldTreatBase64AsBinaryData: true,
                methodsToKeepClientDefaultValue: Array.Empty<string>(),
                mgmtConfiguration: mgmtConfiguration,
                mgmtTestConfiguration: null,
                flavor: "azure",
                disableXmlDocs: false,
                generateSampleProject: true,
                generateTestProject: true,
                examplesDirectory: null,
                helperNamespace: "");
        }

        private void TestPair(ResourceMatchType expected, string httpMethod, string resourcePathStr, string requestPathStr, bool isList)
        {
            RequestPath resourcePath = RequestPath.FromString(resourcePathStr);
            RequestPath requestPath = RequestPath.FromString(requestPathStr);
            Assert.AreEqual(expected, MgmtRestOperation.GetMatchType(new RequestMethod(httpMethod), resourcePath, requestPath, isList));
        }

        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/{scope}/providers/Microsoft.EventGrid/eventSubscriptions/{eventSubscriptionName}",
            "/subscriptions/{subscriptionId}/providers/Microsoft.EventGrid/eventSubscriptions")]
        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/{scope}/providers/Microsoft.EventGrid/eventSubscriptions/{eventSubscriptionName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/domains/{domainName}/topics/{topicName}/providers/Microsoft.EventGrid/eventSubscriptions")]
        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/{scope}/providers/Microsoft.EventGrid/eventSubscriptions/{eventSubscriptionName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{providerNamespace}/{resourceTypeName}/{resourceName}/providers/Microsoft.EventGrid/eventSubscriptions")]
        public void ValidateScopeListMatching(ResourceMatchType expected, string httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.ChildList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs")]
        [TestCase(ResourceMatchType.Context, "POST", false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs")]
        [TestCase(ResourceMatchType.None, "GET", false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/scm")]
        [TestCase(ResourceMatchType.Exact, "GET", false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/scm",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/scm")]
        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons")]
        [TestCase(ResourceMatchType.None, "GET", false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}")]
        [TestCase(ResourceMatchType.None, "GET", false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/ftp",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/scm")]
        [TestCase(ResourceMatchType.Exact, "GET", false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/scm",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/scm")]
        public void ValidateMatchingSegments(ResourceMatchType expected, string httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.ParentList, "GET", true,
           "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{continuouswebjobsName}",
           "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs")]
        [TestCase(ResourceMatchType.None, "POST", true,
           "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{continuouswebjobsName}",
           "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs")]
        [TestCase(ResourceMatchType.None, "GET", false,
            "/providers/Microsoft.Web/publishingUsers/web",
            "/providers/Microsoft.Web/sourcecontrols")]
        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/providers/Microsoft.Web/sourcecontrols/{sourceControlType}",
            "/providers/Microsoft.Web/sourcecontrols")]
        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/userProvidedFunctionApps/{functionAppName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/userProvidedFunctionApps")]
        [TestCase(ResourceMatchType.None, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/builds/{environmentName}/userProvidedFunctionApps/{functionAppName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/userProvidedFunctionApps")]
        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites")]
        [TestCase(ResourceMatchType.AncestorList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}",
            "/subscriptions/{subscriptionId}/providers/Microsoft.Web/staticSites")]
        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
            "/subscriptions/{subscriptionId}/resourceGroups")]
        [TestCase(ResourceMatchType.AncestorList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments")]
        public void ValidateListMatchingSegments(ResourceMatchType expected, string httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.Context, "POST", false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}/execute")]
        [TestCase(ResourceMatchType.None, "POST", false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slot}/detectors/{detectorName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}/execute")]
        public void PostMethodOnMultipleLevels(ResourceMatchType expected, string httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.None, "GET", false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/logs",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config")]
        [TestCase(ResourceMatchType.None, "GET", false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/slotConfigNames",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config")]
        [TestCase(ResourceMatchType.None, "GET", false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config")]
        [TestCase(ResourceMatchType.ChildList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config")]
        public void StaticSingletonEnumeration(ResourceMatchType expected, string httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.ChildList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/recommendationHistory")]
        public void DifferentReferenceName(ResourceMatchType expected, string httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.ChildList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/certificates")]
        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/certificates/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/certificates")]
        public void ParentListAndChildList(ResourceMatchType expected, string httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.None, "POST", false,
            "/providers/Microsoft.Web/sourcecontrols/{sourceControlType}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/validate")]
        [TestCase(ResourceMatchType.None, "POST", false,
            "/providers/Microsoft.Web/publishingUsers/web",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/validate")]
        [TestCase(ResourceMatchType.CheckName, "POST", false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}",
            "/subscriptions/{subscriptionId}/providers/Microsoft.Storage/checkNameAvailability")]
        public void ValidateCheckNameAvailability(ResourceMatchType expected, string httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}",
            "/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions")]
        [TestCase(ResourceMatchType.None, "GET", true,
            "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}",
            "/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions")]
        [TestCase(ResourceMatchType.None, "GET", true,
            "/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}",
            "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyDefinitions")]
        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}",
            "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyDefinitions")]
        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}",
            "/providers/Microsoft.Authorization/policyDefinitions")]
        [TestCase(ResourceMatchType.AncestorList, "GET", true,
            "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}",
            "/providers/Microsoft.Authorization/policyDefinitions")]
        public void PolicyDefinitionMultiParent(ResourceMatchType expected, string httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}",
            "/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups")]
        [TestCase(ResourceMatchType.AncestorList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}",
            "/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups")]
        [TestCase(ResourceMatchType.None, "GET", true,
            "/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups")]
        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups")]
        public void ChildListDifferentRoot(ResourceMatchType expected, string httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.ParentList, "GET", true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes")]
        public void ValidateCommonRestTestProject(ResourceMatchType expected, string httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);
    }
}
