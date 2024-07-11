using System;
using Azure.Core;
using Azure.ResourceManager;
using static CadlRanchProjects.Tests.OAuth2TestHelper;

namespace CadlRanchProjects.Tests
{
    public class MgmtTestHelper
    {
        public static ArmClient CreateArmClientWithMockAuth(Uri host, string defaultSubscriptionId = default)
        {
            var options = new ArmClientOptions();
            options.AddPolicy(new MockBearerTokenAuthenticationPolicy(new MockCredential(), new string[] { "https://security.microsoft.com/.default" }, options.Transport), HttpPipelinePosition.PerCall);
            options.Environment = new ArmEnvironment(host, "https://management.azure.com/");

            return new ArmClient(new MockCredential(), defaultSubscriptionId ?? Guid.Empty.ToString(), options);
        }
    }
}
