import "@typespec/rest";
import "@typespec/http";
import "@typespec/versioning";
import "./univariate/routes.tsp";
import "./multivariate/routes.tsp";

using TypeSpec.Rest;
using TypeSpec.Http;
using TypeSpec.Versioning;

@versioned(Versions)
@service(#{title: "Anomaly Detector"})
@useAuth(ApiKeyAuth<ApiKeyLocation.header, "Ocp-Apim-Subscription-Key">)
@server(
  "{Endpoint}/anomalydetector/{ApiVersion}",
  "The Anomaly Detector API detects anomalies automatically in time series data. It supports two kinds of mode, one is for stateless using, another is for stateful using. In stateless mode, there are three functionalities. Entire Detect is for detecting the whole series with model trained by the time series, Last Detect is detecting last point with model trained by points before. ChangePoint Detect is for detecting trend changes in time series. In stateful mode, user can store time series, the stored time series will be used for detection anomalies. Under this mode, user can still use the above three functionalities by only giving a time range without preparing time series in client side. Besides the above three functionalities, stateful model also provide group based detection and labeling service. By leveraging labeling service user can provide labels for each detection result, these labels will be used for retuning or regenerating detection models. Inconsistency detection is a kind of group based detection, this detection will find inconsistency ones in a set of time series. By using anomaly detector service, business customers can discover incidents and establish a logic flow for root cause analysis.",
  {
    @doc("""
Supported Cognitive Services endpoints (protocol and hostname, for example:
https://westus2.api.cognitive.microsoft.com).
""")
    Endpoint: string,
    
    @doc("Api Version")
    @path
    ApiVersion: Versions,
  }
)
@doc("""
The Anomaly Detector API detects anomalies automatically in time series data.
It supports two kinds of mode, one is for stateless using, another is for
stateful using. In stateless mode, there are three functionalities. Entire
Detect is for detecting the whole series with model trained by the time series,
Last Detect is detecting last point with model trained by points before.
ChangePoint Detect is for detecting trend changes in time series. In stateful
mode, user can store time series, the stored time series will be used for
detection anomalies. Under this mode, user can still use the above three
functionalities by only giving a time range without preparing time series in
client side. Besides the above three functionalities, stateful model also
provide group based detection and labeling service. By leveraging labeling
service user can provide labels for each detection result, these labels will be
used for retuning or regenerating detection models. Inconsistency detection is
a kind of group based detection, this detection will find inconsistency ones in
a set of time series. By using anomaly detector service, business customers can
discover incidents and establish a logic flow for root cause analysis.
""")
namespace AnomalyDetector;

enum Versions {
  @useDependency(Azure.Core.Versions.v1_0_Preview_2)
  v1_1: "v1.1",
}
