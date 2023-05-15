import { readFile, writeFile } from "fs/promises";
import pacote from "pacote";
import { parseArgs } from "util";

const knownPackages = [
  "@typespec/compiler",
  "@typespec/rest",
  "@typespec/http",
  "@typespec/versioning",
  "@azure-tools/typespec-client-generator-core",
  "@azure-tools/typespec-azure-core",
  "@typespec/eslint-config-typespec",
];

async function getKnownPackageVersion(packageName: string): Promise<string> {
  return (await pacote.manifest(`${packageName}@next`)).version;
}

async function main() {
  const packageToVersionRecord = Object.fromEntries(
    await Promise.all(knownPackages.map(async (x) => [x, await getKnownPackageVersion(x)])),
  );
  // eslint-disable-next-line no-console
  console.log("The following is a mapping between packages and the versions we will update them to");
  // eslint-disable-next-line no-console
  console.log(packageToVersionRecord);
  const args = process.argv.slice(2);
  const options = {
    "add-rush-overrides": {
      type: "boolean",
    },
    "add-npm-overrides": {
      type: "boolean",
    },
  } as const;
  const { values, positionals } = parseArgs({ args, options, allowPositionals: true });
  const packageJsonPaths = positionals;
  const addRushOverrides = values["add-rush-overrides"];
  const addNpmOverrides = values["add-npm-overrides"];
  for (const packageJsonPath of packageJsonPaths) {
    const content = await readFile(packageJsonPath);
    const packageJson = JSON.parse(content.toString());
    const depTypes = ["dependencies", "devDependencies", "peerDependencies"];
    for (const depType of depTypes) {
      const deps = packageJson[depType];
      if (deps === undefined) continue;
      for (const dep of Object.keys(deps)) {
        if (packageToVersionRecord[dep] !== undefined) {
          deps[dep] = packageToVersionRecord[dep];
        }
      }
    }

    // add/merge package versions into "overrides" or "globalOverrides"
    let overridesType: string | undefined = undefined;
    if (addNpmOverrides) {
      overridesType = "overrides";
    } else if (addRushOverrides) {
      overridesType = "globalOverrides";
    }
    if (overridesType) {
      let deps = packageJson[overridesType];
      if (deps === undefined) {
        deps = {};
        packageJson[overridesType] = deps;
      }
      for (const [packageName, version] of Object.entries(packageToVersionRecord)) {
        deps[packageName] = version;
      }
    }

    // eslint-disable-next-line no-console
    console.log(`Updated ${packageJsonPath}`);
    await writeFile(packageJsonPath, JSON.stringify(packageJson, null, 2));
  }
}

main().catch((error) => {
  // eslint-disable-next-line no-console
  console.log("Error", error);
  process.exit(1);
});