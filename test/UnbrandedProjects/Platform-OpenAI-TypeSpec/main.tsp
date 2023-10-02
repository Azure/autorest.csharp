import "@typespec/http";
import "@typespec/openapi3";
import "@typespec/openapi";

import "./constants.tsp";
import "./models/completions.tsp";
import "./models/errors.tsp";
import "./models/edits.tsp";
import "./models/images.tsp";
import "./models/embeddings.tsp";
import "./models/audio.tsp";
import "./models/files.tsp";
import "./models/fine-tuning.tsp";
import "./models/models.tsp";
import "./models/moderation.tsp";
import "./operations.tsp";

using TypeSpec.Http;

/** The OpenAI REST API. Please see https://platform.openai.com/docs/api-reference for more details. */
@service({
  title: "OpenAI API",
  termsOfService: "https://openai.com/policies/terms-of-use",
  contact: {
    name: "OpenAI Support",
    url: "https://help.openai.com",
  },
  license: {
    name: "MIT",
    url: "https://github.com/openai/openai-openapi/blob/master/LICENSE",
  },
  version: "2.0.0",
})
@useAuth(BearerAuth)
@server("https://api.openai.com/v1", "OpenAI Endpoint")
namespace OpenAI;
