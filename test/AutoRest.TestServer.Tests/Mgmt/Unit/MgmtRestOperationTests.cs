// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
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
                Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), new MgmtConfiguration.MgmtDebugConfiguration());
            Configuration.Initialize(".", null, null, Array.Empty<string>(), true, true, true, true, true, true, false, false, false, false, "/..", Array.Empty<string>(), mgmtConfiguration);
        }

        private RequestPath GetFromString(string path) => new RequestPath(path.Split('/', StringSplitOptions.RemoveEmptyEntries).Select(segment => new Segment(TrimRawSegment(segment), isConstant: !segment.Contains('{'))).ToList());

        private string TrimRawSegment(string segment) => segment.TrimStart('{').TrimEnd('}');

        private void TestPair(ResourceMatchType expected, HttpMethod httpMethod, string resourcePathStr, string requestPathStr, bool isList)
        {
            RequestPath resourcePath = GetFromString(resourcePathStr);
            RequestPath requestPath = GetFromString(requestPathStr);
            Assert.AreEqual(expected, MgmtRestOperation.GetMatchType(httpMethod, resourcePath, requestPath, isList));
        }

        [TestCase(ResourceMatchType.ChildList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs")]
        [TestCase(ResourceMatchType.Context, HttpMethod.Post, false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs")]
        [TestCase(ResourceMatchType.None, HttpMethod.Get, false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/scm")]
        [TestCase(ResourceMatchType.Exact, HttpMethod.Get, false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/scm",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/basicPublishingCredentialsPolicies/scm")]
        [TestCase(ResourceMatchType.ParentList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons")]
        [TestCase(ResourceMatchType.None, HttpMethod.Get, false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/premieraddons/{premierAddOnName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}")]
        [TestCase(ResourceMatchType.None, HttpMethod.Get, false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/ftp",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/scm")]
        [TestCase(ResourceMatchType.Exact, HttpMethod.Get, false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/scm",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/basicPublishingCredentialsPolicies/scm")]
        public void ValidateMatchingSegments(ResourceMatchType expected, HttpMethod httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.ParentList, HttpMethod.Get, true,
           "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{continuouswebjobsName}",
           "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs")]
        [TestCase(ResourceMatchType.None, HttpMethod.Post, true,
           "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs/{continuouswebjobsName}",
           "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/continuouswebjobs")]
        [TestCase(ResourceMatchType.None, HttpMethod.Get, false,
            "/providers/Microsoft.Web/publishingUsers/web",
            "/providers/Microsoft.Web/sourcecontrols")]
        [TestCase(ResourceMatchType.ParentList, HttpMethod.Get, true,
            "/providers/Microsoft.Web/sourcecontrols/{sourceControlType}",
            "/providers/Microsoft.Web/sourcecontrols")]
        [TestCase(ResourceMatchType.ParentList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/userProvidedFunctionApps/{functionAppName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/userProvidedFunctionApps")]
        [TestCase(ResourceMatchType.None, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/builds/{environmentName}/userProvidedFunctionApps/{functionAppName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}/userProvidedFunctionApps")]
        [TestCase(ResourceMatchType.ParentList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites")]
        [TestCase(ResourceMatchType.AncestorList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}",
            "/subscriptions/{subscriptionId}/providers/Microsoft.Web/staticSites")]
        [TestCase(ResourceMatchType.ParentList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}",
            "/subscriptions/{subscriptionId}/resourceGroups")]
        [TestCase(ResourceMatchType.AncestorList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments")]
        public void ValidateListMatchingSegments(ResourceMatchType expected, HttpMethod httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.Context, HttpMethod.Post, false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}/execute")]
        [TestCase(ResourceMatchType.None, HttpMethod.Post, false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slot}/detectors/{detectorName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/diagnostics/{diagnosticCategory}/detectors/{detectorName}/execute")]
        public void PostMethodOnMultipleLevels(ResourceMatchType expected, HttpMethod httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.None, HttpMethod.Get, false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/logs",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config")]
        [TestCase(ResourceMatchType.None, HttpMethod.Get, false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/slotConfigNames",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config")]
        [TestCase(ResourceMatchType.None, HttpMethod.Get, false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config/web",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config")]
        [TestCase(ResourceMatchType.ChildList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/config")]
        public void StaticSingletonEnumeration(ResourceMatchType expected, HttpMethod httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.ChildList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/recommendationHistory")]
        public void DifferentReferenceName(ResourceMatchType expected, HttpMethod httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.ChildList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/certificates")]
        [TestCase(ResourceMatchType.ParentList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/certificates/{name}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CertificateRegistration/certificateOrders/{certificateOrderName}/certificates")]
        public void ParentListAndChildList(ResourceMatchType expected, HttpMethod httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.None, HttpMethod.Post, false,
            "/providers/Microsoft.Web/sourcecontrols/{sourceControlType}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/validate")]
        [TestCase(ResourceMatchType.None, HttpMethod.Post, false,
            "/providers/Microsoft.Web/publishingUsers/web",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/validate")]
        [TestCase(ResourceMatchType.CheckName, HttpMethod.Post, false,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}",
            "/subscriptions/{subscriptionId}/providers/Microsoft.Storage/checkNameAvailability")]
        public void ValidateCheckNameAvailability(ResourceMatchType expected, HttpMethod httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.ParentList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}",
            "/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions")]
        [TestCase(ResourceMatchType.None, HttpMethod.Get, true,
            "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}",
            "/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions")]
        [TestCase(ResourceMatchType.None, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}",
            "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyDefinitions")]
        [TestCase(ResourceMatchType.ParentList, HttpMethod.Get, true,
            "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}",
            "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyDefinitions")]
        [TestCase(ResourceMatchType.ParentList, HttpMethod.Get, true,
            "/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}",
            "/providers/Microsoft.Authorization/policyDefinitions")]
        [TestCase(ResourceMatchType.AncestorList, HttpMethod.Get, true,
            "/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}",
            "/providers/Microsoft.Authorization/policyDefinitions")]
        public void PolicyDefinitionMultiParent(ResourceMatchType expected, HttpMethod httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.ParentList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}",
            "/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups")]
        [TestCase(ResourceMatchType.AncestorList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}",
            "/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups")]
        [TestCase(ResourceMatchType.None, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups")]
        [TestCase(ResourceMatchType.ParentList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups")]
        public void ChildListDifferentRoot(ResourceMatchType expected, HttpMethod httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);

        [TestCase(ResourceMatchType.ParentList, HttpMethod.Get, true,
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes/{typeOneName}",
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.TypeOne/typeOnes")]
        public void ValidateCommonRestTestProject(ResourceMatchType expected, HttpMethod httpMethod, bool isList, string resourcePathStr, string requestPathStr)
            => TestPair(expected, httpMethod, resourcePathStr, requestPathStr, isList);
    }
}
