import "@typespec/rest";
import "@typespec/http";
import "@typespec/versioning";
import "@typespec/openapi";
import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ClientGenerator.Core;
using TypeSpec.Versioning;

@service(
    {
        title: "Text authoring",
        version: "2022-05-15-preview"
    }
)
@versionedDependency(Azure.Core.Versions.v1_0_Preview_1)
@server(
    "{lroBasicUrl}",
    "Endpoint Service",
    {
        lroBasicUrl: string,
    }
)
namespace LroBasicCadl;


@resource("projects")
model Project {
  @key
  @visibility("read")
  id: string;
  description?: string;

  name?: string;
}

model Thing {
  name: string;
}

interface Authoring {
  createProjectStatusMonitor is CustomCore.PollingOperation<Project>;

  @convenientAPI(true)
  @Azure.Core.pollingOperation(Authoring.createProjectStatusMonitor)
  createProject is Azure.Core.LongRunningResourceCreateWithServiceProvidedName<Project>;
  
  @convenientAPI(true)
  @Azure.Core.pollingOperation(Authoring.createProjectStatusMonitor)
  op updateProject is Azure.Core.LongRunningResourceCreateOrReplace<Project, Project>;

  @convenientAPI(true)
  @Azure.Core.pollingOperation(Authoring.createProjectStatusMonitor)
  op createThing is CustomCore.LongRunningRpcOperation<Thing, Thing>;
}

namespace CustomCore {
  @parentResource(T)
  @resource("operations")
  model OperationStatusResource<T> is Azure.Core.Foundations.OperationStatus {
    operationId: string;
  }

  @route("operations")
  @convenientAPI(true)
  op PollingOperation<TCustom> is Azure.Core.ResourceRead<OperationStatusResource<TCustom>>;

  @doc("Long running RPC operation template")
  op LongRunningRpcOperation<
    TParams extends object,
    TResponse extends object
  > is Azure.Core.RpcOperation<
    TParams,
    Azure.Core.Foundations.AcceptedResponse<TResponse &
      Azure.Core.Foundations.LongRunningStatusLocation>
  >;
}
