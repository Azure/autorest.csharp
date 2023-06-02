import "@typespec/rest";
import "@typespec/http";
import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";

@service(
    {
        title: "Models in CADL",
        version: "0.1.0"
    }
)
@doc("CADL project to test various types of models.")
namespace CustomizationsInCadl;

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ClientGenerator.Core;
using Azure.Core;

@doc("The first layer model in the inheritance tree")
model FirstLayer {
    @doc("Property to change serialization and deserialization in this class and all derived classes")
    stringToBeChanged: string;
}

model SecondLayer extends FirstLayer {
    @doc("Other property")
    optionalString?: string;

    @doc("Yet another property")
    intToBeChanged?: int32;
}

model ThirdLayer extends SecondLayer {
    @doc("Other property on 3rd layer")
    optionalFloat?: float32;
}

@doc("Model to add additional serializable property")
model ModelToAddAdditionalSerializableProperty {
    @doc("Required int")
    requiredInt: int32;
}

@doc("Public model made internal")
model ModelToMakeInternal {
  @doc("Required int")
  requiredInt: int32; 
}

@doc("Renamed model (original name: ModelToRename)")
model ModelToRename {
  @doc("Required int")
  requiredInt: int32; 
}

@doc("Model moved into custom namespace")
model ModelToChangeNamespace {
  @doc("Required int")
  requiredInt: int32; 
}

@doc("Model with customized properties")
model ModelWithCustomizedProperties {
  @doc("Public property made internal")
  propertyToMakeInternal: int32; 

  @doc("Renamed property (original name: PropertyToRename)")
  propertyToRename: int32;
 
  @doc("Property with type changed to float (original type: int)")
  propertyToMakeFloat: int32; 
  
  @doc("Property with type changed to int (original type: float)")
  propertyToMakeInt: float32; 
 
  @doc("Property with type changed to duration (original type: string)")
  propertyToMakeDuration: string; 
  
  @doc("Property with type changed to string (original type: duration)")
  propertyToMakeString: duration; 
 
  @doc("Property with type changed to JsonElement (original type: string)")
  propertyToMakeJsonElement: string;  
 
  @doc("Field that replaces property (original name: PropertyToField)")
  propertyToField: string;

  @doc("Property renamed that is list")
  badListName: string[];

  @doc("Property renamed that is dictionary")
  badDictionaryName: Record<string>;

  @doc("Property renamed that is listoflist")
  badListOfListName: string[][];

  @doc("Property renamed that is listofdictionary")
  badListOfDictionaryName: Record<string>[];
}

@doc("Renamed enum (original name: EnumToRename)")
@fixed
enum EnumToRename {
    One: "1",
    Two: "2",
    Three: "3"
}

@doc("Enum with renamed value (original name: ValueToRename)")
@fixed
enum EnumWithValueToRename {
    One: "1",
    Two: "2",
    ValueToRename: "3"
}

@doc("Extensible enum")
enum EnumToBeMadeExtensible {
    ExOne: "1",
    ExTwo: "2",
    ExThree: "3"
}

@doc("Root RoundTrip model to reference all other types to ensure generation")
model RootModel {  
  @doc("ModelToMakeInternal")
  propertyModelToMakeInternal?: ModelToMakeInternal; 
  
  @doc("ModelToRename")
  propertyModelToRename?: ModelToRename; 
  
  @doc("ModelToChangeNamespace")
  propertyModelToChangeNamespace?: ModelToChangeNamespace; 
  
  @doc("ModelWithCustomizedProperties")
  propertyModelWithCustomizedProperties?: ModelWithCustomizedProperties; 
  
  @doc("EnumToRename")
  propertyEnumToRename?: EnumToRename; 
  
  @doc("EnumWithValueToRename")
  propertyEnumWithValueToRename?: EnumWithValueToRename; 

  @doc("EnumToBeMadeExtensible")
  propertyEnumToBeMadeExtensible?: EnumToBeMadeExtensible;

  @doc("ModelToAddAdditionalSerializableProperty")
  propertyModelToAddAdditionalSerializableProperty?: ModelToAddAdditionalSerializableProperty;

  @doc("First layer model's property")
  firstLayerModel?: FirstLayer;

  @doc("Second layer model's property")
  secondLayerModel?: SecondLayer;

  @doc("Third layer model's property")
  thirdLayerModel?: ThirdLayer;
}

@route("/inputToRoundTrip")
@doc("RoundTrip operation to make RootModel round-trip")
@get
@convenientAPI(true)
op roundTrip(@body input: RootModel): RootModel;
