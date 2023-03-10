import "@typespec/rest";
import "@typespec/http";

using TypeSpec.Http;

@service(
    {
        title: "SecurityClient",
        version: "1.0.0"
    }
)
@server("http://localhost:3000", "TestServer endpoint")
@doc("Illustrates clients generated from a Cadl with security.")
@useAuth(OAuth2Auth<[AuthFlow]> | ApiKeyAuth<ApiKeyLocation.header, "x-ms-api-key">)
namespace SecurityClient;

model AuthFlow {
    type: OAuth2FlowType.clientCredentials;
    tokenUrl: "https://api.example.com/oauth2/token";
    refreshUrl: "https://api.example.com/oauth2/refresh";
    scopes: [
        "https://api.example.com/.default"
    ]
}

@route("/security")
@doc("Get security info")
@get
op genSecurity(): Response<200>;