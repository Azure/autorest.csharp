import { TestHost } from "@typespec/compiler/testing";
import { ok, strictEqual } from "assert";
import { beforeEach, describe, it } from "vitest";
import {
    createEmitterContext,
    createEmitterTestHost,
    createNetSdkContext,
    typeSpecCompile
} from "./utils/test-util.js";
import { createModel } from "../../src/lib/client-model-builder.js";
import { UsageFlags } from "@azure-tools/typespec-client-generator-core";

describe("Test Usage", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });

    it("Get usage for body parameter type", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            model Foo {
                @doc("name of the Foo")
                name: string;
            }
            op test(@path id: string, @body foo: Foo): void;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const fooModel = root.Models.find((model) => model.Name === "Foo");

        ok(fooModel);
        strictEqual(fooModel.Usage, UsageFlags.Input);
    });

    it("Get usage for response body", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            model Foo {
                @doc("name of the Foo")
                name: string;
            }
            op test(@path id: string): Foo;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const fooModel = root.Models.find((model) => model.Name === "Foo");

        ok(fooModel);
        strictEqual(fooModel.Usage, UsageFlags.Output);
    });

    it("Get usage for the model in both input and output", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            model Foo {
                @doc("name of the Foo")
                name: string;
            }
            op test(@path id: string, @body foo: Foo): Foo;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const fooModel = root.Models.find((model) => model.Name === "Foo");

        ok(fooModel);
        strictEqual(fooModel.Usage, UsageFlags.Input | UsageFlags.Output);
    });

    it("Get usage for the model which is used in two operations", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            model Foo {
                @doc("name of the Foo")
                name: string;
            }
            op test(@path id: string, @body foo: Foo): void;
            op test2(@path id: string): Foo;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const fooModel = root.Models.find((model) => model.Name === "Foo");

        ok(fooModel);
        strictEqual(fooModel.Usage, UsageFlags.Input | UsageFlags.Output);
    });

    it("Get usage for the model as the template argument", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model template.")
            model TemplateModel<T> {
                @doc("name of the model.")
                name: string;
                prop: T;
            }
            @doc("This is a model.")
            model Foo {
                @doc("name of the Foo")
                name: string;
            }
            op test(@path id: string, @body foo: TemplateModel<Foo>): void;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const fooModel = root.Models.find((model) => model.Name === "Foo");
        const templateModel = root.Models.find((model) => model.Name === "TemplateModelFoo");

        ok(fooModel);
        strictEqual(fooModel.Usage, UsageFlags.Input);
        ok(templateModel);
        strictEqual(templateModel.Usage, UsageFlags.Input);
    });

    it("Test the usage inheritance between base model and derived model", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a base model.")
            model BaseModel {
                @doc("name of the model.")
                base: string;
            }
            @doc("This is a model.")
            model Foo extends BaseModel{
                @doc("name of the Foo")
                name: string;
            }
            op test(@path id: string, @body foo: Foo): void;
            op test2(@path id: string): BaseModel;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const baseModel = root.Models.find((model) => model.Name === "BaseModel");
        const fooModel = root.Models.find((model) => model.Name === "Foo");

        ok(baseModel);
        strictEqual(baseModel.Usage, UsageFlags.Input | UsageFlags.Output);
        ok(fooModel);
        strictEqual(fooModel.Usage, UsageFlags.Input);
    });

    it("Test the usage inheritance between base model and derived model which has model property", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This a model of a property in base model")
            model PropertyModel {
                @doc("name of the model.")
                base: string;
            }
            @doc("This is a base model.")
            model BaseModel {
                @doc("name of the model.")
                base: string;
                @doc("a property")
                prop: PropertyModel;
            }
            @doc("This is a model.")
            model Foo extends BaseModel {
                @doc("name of the Foo")
                name: string;
            }
            op test(@path id: string, @body foo: Foo): void;
            op test2(@path id: string): BaseModel;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const baseModel = root.Models.find((model) => model.Name === "BaseModel");
        const fooModel = root.Models.find((model) => model.Name === "Foo");
        const propertyModel = root.Models.find((model) => model.Name === "PropertyModel");

        ok(baseModel);
        strictEqual(baseModel.Usage, UsageFlags.Input | UsageFlags.Output);
        ok(fooModel);
        strictEqual(fooModel.Usage, UsageFlags.Input);
        ok(propertyModel);
        strictEqual(propertyModel.Usage, UsageFlags.Input | UsageFlags.Output);
    });

    it("Test the usage of models spread alias", async () => {
        const program = await typeSpecCompile(
            `
            alias FooAlias = {
                @path id: string;
                @doc("name of the Foo")
                name: string;
            };
            op test(...FooAlias): void;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const fooAlias = root.Models.find((model) => model.Name === "TestRequest");

            ok(fooAlias);
        strictEqual(fooAlias.Usage, UsageFlags.Input);
    });

    it("Test the usage of body parameter of azure core operation.", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            @resource("items")
            model Foo {
                @doc("id of Foo")
                @key
                @visibility("read","create","query")
                id: string;
                @doc("name of Foo")
                name: string;
            }

            @doc("The item information.")
            model FooInfo {
                @doc("name of Foo")
                name: string;
            }

            @doc("this is a response model.")
            model BatchCreateFooListItemsRequest {
                @doc("The items to create")
                fooInfos: FooInfo[];
            }

            @doc("this is a response model.")
            model BatchCreateTextListItemsResponse {
                @doc("The item list.")
                fooList: Foo[];
            }
            interface TextLists{
                @doc("create items")
                addItems is ResourceAction<Foo, BatchCreateFooListItemsRequest, BatchCreateTextListItemsResponse>;
            }
      `,
            runner,
            { IsNamespaceNeeded: true, IsAzureCoreNeeded: true }
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const fooInfo = root.Models.find((model) => model.Name === "FooInfo");
        const batchCreateFooListItemsRequest = root.Models.find((model) => model.Name === "BatchCreateFooListItemsRequest");
        const batchCreateTextListItemsResponse = root.Models.find((model) => model.Name === "BatchCreateTextListItemsResponse");

        ok(fooInfo);
        strictEqual(fooInfo.Usage, UsageFlags.Input);
        ok(batchCreateFooListItemsRequest);
        strictEqual(batchCreateFooListItemsRequest.Usage, UsageFlags.Input);
        ok(batchCreateTextListItemsResponse);
        strictEqual(batchCreateTextListItemsResponse.Usage, UsageFlags.Output);
    });

    it("Test the usage of body parameter and return type of azure core resource operation.", async () => {
        const program = await typeSpecCompile(
            `
            alias ResourceOperations = global.Azure.Core.ResourceOperations<NoConditionalRequests &
                NoRepeatableRequests &
                NoClientRequestId>;

            @doc("This is a model.")
            @resource("items")
            model Foo {
                @doc("id of Foo")
                @key
                @visibility("read","create","query")
                id: string;
                @doc("name of Foo")
                name: string;
            }

            interface FooClient{
                @doc("create Foo")
                createFoo is ResourceOperations.ResourceCreateOrUpdate<Foo>;
            }
      `,
            runner,
            { IsNamespaceNeeded: true, IsAzureCoreNeeded: true }
        );

        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const fooModel = root.Models.find((model) => model.Name === "Foo");

        ok(fooModel);
        strictEqual(fooModel.Usage, UsageFlags.Input | UsageFlags.Output | UsageFlags.JsonMergePatch);
    });

    it("Test the usage of body polymorphism type in azure core resource operation.", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            @resource("items")
            model Foo {
                @doc("id of Foo")
                @key
                @visibility("read","create","query")
                id: string;
                @doc("name of Foo")
                name: string;
            }

            #suppress "@azure-tools/typespec-azure-core/documentation-required" "The ModelProperty named 'discriminatorProperty' should have a documentation or description, please use decorator @doc to add it"
            @discriminator("discriminatorProperty")
            @doc("Base model with discriminator property.")
            model BaseModelWithDiscriminator {
                @doc("Optional property on base")
                optionalPropertyOnBase?: string;

                @doc("Required property on base")
                requiredPropertyOnBase: int32;
            }

            #suppress "@azure-tools/typespec-azure-core/documentation-required" "The ModelProperty named 'discriminatorProperty' should have a documentation or description, please use decorator @doc to add it"
            @doc("Deriver model with discriminator property.")
            model DerivedModelWithDiscriminatorA extends BaseModelWithDiscriminator {
                discriminatorProperty: "A";

                @doc("Required string.")
                requiredString: string;
            }

            interface FooClient{
                @doc("create Foo")
                op testFoo is Azure.Core.StandardResourceOperations.ResourceCollectionAction<
                Foo,
                BaseModelWithDiscriminator,
                {}
                >;
            }
      `,
            runner,
            { IsNamespaceNeeded: true, IsAzureCoreNeeded: true }
        );

        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const baseModel = root.Models.find((model) => model.Name === "BaseModelWithDiscriminator");
        const derivedModel = root.Models.find((model) => model.Name === "DerivedModelWithDiscriminatorA");

        ok(baseModel);
        strictEqual(baseModel.Usage, UsageFlags.Input);
        ok(derivedModel);
        strictEqual(derivedModel.Usage, UsageFlags.Input);
    });

    it("Test the usage of response polymorphism type in azure core resource operation.", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            @resource("items")
            model Foo {
                @doc("id of Foo")
                @key
                @visibility("read","create","query")
                id: string;
                @doc("name of Foo")
                name: string;
            }

            @doc("This is nested model.")
            model NestedModel {
                @doc("id of NestedModel")
                id: string;
            }

            #suppress "@azure-tools/typespec-azure-core/documentation-required" "The ModelProperty named 'discriminatorProperty' should have a documentation or description, please use decorator @doc to add it"
            @discriminator("discriminatorProperty")
            @doc("Base model with discriminator property.")
            model BaseModelWithDiscriminator {
                @doc("Optional property on base")
                optionalPropertyOnBase?: string;

                @doc("Required property on base")
                requiredPropertyOnBase: int32;
            }

            #suppress "@azure-tools/typespec-azure-core/documentation-required" "The ModelProperty named 'discriminatorProperty' should have a documentation or description, please use decorator @doc to add it"
            @doc("Deriver model with discriminator property.")
            model DerivedModelWithDiscriminatorA extends BaseModelWithDiscriminator {
                discriminatorProperty: "A";

                @doc("Required string.")
                requiredString: string;

                @doc("property with complex model type.")
                nestedModel: NestedModel;
            }

            interface FooClient{
                @doc("create Foo")
                op testFoo is Azure.Core.StandardResourceOperations.ResourceCollectionAction<
                Foo,
                {},
                BaseModelWithDiscriminator
                >;
            }
      `,
            runner,
            { IsNamespaceNeeded: true, IsAzureCoreNeeded: true }
        );

        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const baseModel = root.Models.find((model) => model.Name === "BaseModelWithDiscriminator");
        const derivedModel = root.Models.find((model) => model.Name === "DerivedModelWithDiscriminatorA");
        const nestedModel = root.Models.find((model) => model.Name === "NestedModel");

        ok(baseModel);
        strictEqual(baseModel.Usage, UsageFlags.Output);
        ok(derivedModel);
        strictEqual(derivedModel.Usage, UsageFlags.Output);
        ok(nestedModel);
        strictEqual(nestedModel.Usage, UsageFlags.Output);
    });

    it("Test the usage of enum which is renamed via @clientName.", async () => {
        const program = await typeSpecCompile(
            `
            @doc("fixed string enum")
            @clientName("SimpleEnumRenamed")
            enum SimpleEnum {
                @doc("Enum value one")
                One: "1",
                @doc("Enum value two")
                Two: "2",
                @doc("Enum value four")
                Four: "4"
            }

            op test(@path id: SimpleEnum): void;
      `,
            runner,
            { IsNamespaceNeeded: true, IsTCGCNeeded: true }
        );

        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const simpleEnumRenamed = root.Enums.find((enumType) => enumType.Name === "SimpleEnumRenamed");

        ok(simpleEnumRenamed);
        strictEqual(simpleEnumRenamed.Usage, UsageFlags.Input);
    });

    it("Test the usage of model which is renamed via @clientName.", async () => {
        const program = await typeSpecCompile(
            `
            @doc("A model plan to rename")
            @clientName("RenamedModel")
            model ModelToRename {
                value: string;
            }

            op test(@body body: ModelToRename): void;
      `,
            runner,
            { IsNamespaceNeeded: true, IsTCGCNeeded: true }
        );

        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        const renamedModel = root.Models.find((model) => model.Name === "RenamedModel");

        ok(renamedModel);
        strictEqual(renamedModel.Usage, UsageFlags.Input);
    });

    it("Test the usage of return type of a customized LRO operation.", async () => {
        const program = await typeSpecCompile(
            `
#suppress "@azure-tools/typespec-azure-core/documentation-required" "MUST fix in next version"
@doc("The status of the processing job.")
@lroStatus
enum JobStatus {
  NotStarted: "notStarted",
  Running: "running",
  Succeeded: "succeeded",
  Failed: "failed",
  Canceled: "canceled",
}

@doc("Provides status details for long running operations.")
model HealthInsightsOperationStatus<
  TStatusResult = never,
  TStatusError = Foundations.Error
> {
  @key("operationId")
  @doc("The unique ID of the operation.")
  @visibility("read")
  id: Azure.Core.uuid;

  @doc("The status of the operation")
  @visibility("read")
  @lroStatus
  status: JobStatus;

  @doc("The date and time when the processing job was created.")
  @visibility("read")
  createdDateTime?: utcDateTime;

  @doc("The date and time when the processing job is set to expire.")
  @visibility("read")
  expirationDateTime?: utcDateTime;

  @doc("The date and time when the processing job was last updated.")
  @visibility("read")
  lastUpdateDateTime?: utcDateTime;

  @doc("Error object that describes the error when status is Failed.")
  error?: TStatusError;

  @doc("The result of the operation.")
  @lroResult
  result?: TStatusResult;
}

@doc("The location of an instance of {name}", TResource)
scalar HealthInsightsResourceLocation<TResource extends {}> extends url;

@doc("Metadata for long running operation status monitor locations")
model HealthInsightsLongRunningStatusLocation<TStatusResult = never> {
  @pollingLocation
  @doc("The location for monitoring the operation state.")
  @TypeSpec.Http.header("Operation-Location")
  operationLocation: HealthInsightsResourceLocation<HealthInsightsOperationStatus<TStatusResult>>;
}
#suppress "@azure-tools/typespec-azure-core/long-running-polling-operation-required" "This is a template"
@doc("Long running RPC operation template")
op HealthInsightsLongRunningRpcOperation<
  TParams extends TypeSpec.Reflection.Model,
  TResponse extends TypeSpec.Reflection.Model,
  Traits extends Record<unknown> = {}
> is Azure.Core.RpcOperation<
  TParams & RepeatabilityRequestHeaders,
  Foundations.AcceptedResponse<HealthInsightsLongRunningStatusLocation<TResponse> &
    Foundations.RetryAfterHeader> &
    RepeatabilityResponseHeaders &
    HealthInsightsOperationStatus,
  Traits
>;
@trait("HealthInsightsRetryAfterTrait")
@doc("Health Insights retry after trait")
model HealthInsightsRetryAfterTrait {
  #suppress "@azure-tools/typespec-providerhub/no-inline-model" "This inline model is never used directly in operations."
  @doc("The retry-after header.")
  retryAfter: {
    @traitLocation(TraitLocation.Response)
    response: Foundations.RetryAfterHeader;
  };
}

@doc("The inference results for the Radiology Insights request.")
model RadiologyInsightsInferenceResult {
    id: string;
}
alias Request = {
    @doc("The list of patients, including their clinical information and data.")
    patients: string[];
  };
@resource("radiology-insights/jobs")
@doc("The response for the Radiology Insights request.")
model RadiologyInsightsResult
  is HealthInsightsOperationStatus<RadiologyInsightsInferenceResult>;

  @doc("The body of the Radiology Insights request.")
  model RadiologyInsightsData {
    ...Request;
  
    @doc("Configuration affecting the Radiology Insights model's inference.")
    configuration?: string;
  }

#suppress "@azure-tools/typespec-azure-core/long-running-polling-operation-required" "This is a template"
@doc("Long running Pool operation template")
op HealthInsightsLongRunningPollOperation<TResult extends TypeSpec.Reflection.Model> is Azure.Core.RpcOperation<
  {
    @doc("A processing job identifier.")
    @path("id")
    id: Azure.Core.uuid;
  },
  TResult,
  HealthInsightsRetryAfterTrait
>;

interface LegacyLro {
    #suppress "@azure-tools/typespec-azure-core/no-rpc-path-params" "Service uses a jobId in the path"
    @summary("Get Radiology Insights job details")
    @tag("RadiologyInsights")
    @doc("Gets the status and details of the Radiology Insights job.")
    @get
    @route("/radiology-insights/jobs/{id}")
    @convenientAPI(false)
    getJob is HealthInsightsLongRunningPollOperation<RadiologyInsightsResult>;
  
    #suppress "@azure-tools/typespec-azure-core/long-running-polling-operation-required" "Polling through operation-location"
    #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "There is no long-running RPC template in Azure.Core"
    @summary("Create Radiology Insights job")
    @tag("RadiologyInsights")
    @doc("Creates a Radiology Insights job with the given request body.")
    @pollingOperation(LegacyLro.getJob)
    @route("/radiology-insights/jobs")
    @convenientAPI(true)
    createJob is HealthInsightsLongRunningRpcOperation<
      RadiologyInsightsData,
      RadiologyInsightsResult
    >;
  }
      `,
            runner,
            {
                IsNamespaceNeeded: true,
                IsAzureCoreNeeded: true,
                IsTCGCNeeded: true
            }
        );

        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);   
        const radiologyInsightsInferenceResult = root.Models.find((model) => model.Name === "RadiologyInsightsInferenceResult");

        ok(radiologyInsightsInferenceResult);
        strictEqual(radiologyInsightsInferenceResult.Usage, UsageFlags.Output);
    });
});
